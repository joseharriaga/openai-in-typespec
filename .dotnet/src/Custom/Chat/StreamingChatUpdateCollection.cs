﻿using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

#nullable enable

namespace OpenAI.Chat;

/// <summary>
/// Implementation of collection abstraction over streaming chat updates.
/// </summary>
internal class StreamingChatUpdateCollection : ResultCollection<StreamingChatUpdate>
{
    private readonly Func<ClientResult> _getResult;

    public StreamingChatUpdateCollection(Func<ClientResult> getResult) : base()
    {
        Argument.AssertNotNull(getResult, nameof(getResult));

        _getResult = getResult;
    }

    public override IEnumerator<StreamingChatUpdate> GetEnumerator()
    {
        return new StreamingChatUpdateEnumerator(_getResult, this);
    }

    private sealed class StreamingChatUpdateEnumerator : IEnumerator<StreamingChatUpdate>
    {
        private const string _terminalData = "[DONE]";

        private readonly Func<ClientResult> _getResult;
        private readonly StreamingChatUpdateCollection _enumerable;

        // These enumerators represent what is effectively a doubly-nested
        // loop over the outer event collection and the inner update collection,
        // i.e.:
        //   foreach (var sse in _events) {
        //       // get _updates from sse event
        //       foreach (var update in _updates) { ... }
        //   }
        private IEnumerator<ServerSentEvent>? _events;
        private IEnumerator<StreamingChatUpdate>? _updates;

        private StreamingChatUpdate? _current;
        private bool _started;

        public StreamingChatUpdateEnumerator(Func<ClientResult> getResult, 
            StreamingChatUpdateCollection enumerable)
        {
            Debug.Assert(getResult is not null);
            Debug.Assert(enumerable is not null);

            _getResult = getResult!;
            _enumerable = enumerable!;
        }

        StreamingChatUpdate IEnumerator<StreamingChatUpdate>.Current
            => _current!;

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (_events is null && _started)
            {
                throw new ObjectDisposedException(nameof(StreamingChatUpdateEnumerator));
            }

            _events ??= CreateEventEnumerator();
            _started = true;

            if (_updates is not null && _updates.MoveNext())
            {
                _current = _updates.Current;
                return true;
            }

            if (_events.MoveNext())
            {
                if (_events.Current.Data == _terminalData)
                {
                    _current = default;
                    return false;
                }

                using JsonDocument doc = JsonDocument.Parse(_events.Current.Data);
                var updates = StreamingChatUpdate.DeserializeStreamingChatUpdates(doc.RootElement);
                _updates = updates.GetEnumerator();

                if (_updates.MoveNext())
                {
                    _current = _updates.Current;
                    return true;
                }
            }

            _current = default;
            return false;
        }

        private IEnumerator<ServerSentEvent> CreateEventEnumerator()
        {
            ClientResult result = _getResult();
            PipelineResponse response = result.GetRawResponse();
            _enumerable.SetRawResponse(response);

            if (response.ContentStream is null)
            {
                throw new InvalidOperationException("Unable to create result from response with null ContentStream");
            }

            ServerSentEventEnumerable enumerable = new(response.ContentStream);
            return enumerable.GetEnumerator();
        }

        public void Reset()
        {
            throw new NotSupportedException("Cannot seek back in an SSE stream.");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && _events is not null)
            {
                _events.Dispose();
                _events = null;

                // Dispose the response so we don't leave the unbuffered
                // network stream open.
                PipelineResponse response = _enumerable.GetRawResponse();
                response.Dispose();
            }
        }
    }
}
