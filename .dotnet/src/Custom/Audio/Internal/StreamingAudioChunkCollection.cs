using System;
using System.Buffers;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

#nullable enable

namespace OpenAI.Audio;

/// <summary>
/// Implementation of collection abstraction over chunk-transfer-encoded audio.
/// </summary>
internal class StreamingAudioChunkCollection : ResultCollection<BinaryData>
{
    private readonly Func<ClientResult> _getResult;

    public StreamingAudioChunkCollection(Func<ClientResult> getResult) : base()
    {
        Argument.AssertNotNull(getResult, nameof(getResult));
        _getResult = getResult;
    }

    public override IEnumerator<BinaryData> GetEnumerator()
    {
        return new StreamingAudioChunkEnumerator(_getResult, this);
    }

    private sealed class StreamingAudioChunkEnumerator : IEnumerator<BinaryData>
    {
        private readonly Func<ClientResult> _getResult;
        private readonly StreamingAudioChunkCollection _enumerable;

        private PipelineResponse? _response;
        private BinaryData? _current;
        private bool _started;

        public StreamingAudioChunkEnumerator(Func<ClientResult> getResult,
            StreamingAudioChunkCollection enumerable)
        {
            Debug.Assert(getResult is not null);
            Debug.Assert(enumerable is not null);

            _getResult = getResult!;
            _enumerable = enumerable!;
        }

        BinaryData IEnumerator<BinaryData>.Current => _current!;

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (_response is null && _started)
            {
                throw new ObjectDisposedException(nameof(StreamingAudioChunkEnumerator));
            }

            if (_response is null)
            {
                ClientResult result = _getResult();
                _response = result.GetRawResponse();
                _enumerable.SetRawResponse(_response);
            }

            if (_response.ContentStream is null)
            {
                throw new InvalidOperationException("Unable to create result from response with null ContentStream");
            }

            _started = true;

            if (!_response.ContentStream.CanRead)
            {
                _current = default;
                return false;
            }

            byte[] buffer = ArrayPool<byte>.Shared.Rent(4096);
            int bytesAlreadyRead = 0;

            do
            {
                if (bytesAlreadyRead == buffer.Length)
                {
                    byte[] newBuffer = ArrayPool<byte>.Shared.Rent(2 * buffer.Length);
                    Array.Copy(buffer, newBuffer, bytesAlreadyRead);
                    ArrayPool<byte>.Shared.Return(buffer);
                    buffer = newBuffer;
                }

                bytesAlreadyRead += _response.ContentStream.Read(buffer, bytesAlreadyRead, buffer.Length - bytesAlreadyRead);
            } while (_response.ContentStream.CanRead && bytesAlreadyRead == buffer.Length);

            if (bytesAlreadyRead > 0)
            {
                _current = BinaryData.FromBytes(new ReadOnlyMemory<byte>(buffer, 0, bytesAlreadyRead));
                return true;
            }

            _current = default;
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException("Cannot seek back in a chunked response stream.");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && _response is not null)
            {
                // Dispose the response so we don't leave the unbuffered
                // network stream open.
                _response.Dispose();
                _response = null;
            }
        }
    }
}
