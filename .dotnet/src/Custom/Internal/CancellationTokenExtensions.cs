using System.ClientModel.Primitives;
using System.ClientModel.Primitives.TwoWayClient;
using System.Threading;

namespace OpenAI;

internal static class CancellationTokenExtensions
{
    public static RequestOptions ToRequestOptions(this CancellationToken cancellationToken, bool streaming = false)
    {
        if (cancellationToken == default)
        {
            if (!streaming) return null;
            return StreamRequestOptions;
        }

        return new RequestOptions()
        {
            CancellationToken = cancellationToken,
            BufferResponse = !streaming,
        };
    }

    public static DuplexRequestOptions ToMessageOptions(this CancellationToken cancellationToken)
    {
        if (cancellationToken == default)
        {
            return TwoWayOptions;
        }

        return new DuplexRequestOptions()
        {
            CancellationToken = cancellationToken
        };
    }

    private static RequestOptions StreamRequestOptions => _streamRequestOptions ??= new() { BufferResponse = false };
    private static RequestOptions _streamRequestOptions;

    private static DuplexRequestOptions TwoWayOptions
    {
        get
        {
            if (_twoWayOptions == null)
            {
                _twoWayOptions = new();
                _twoWayOptions.Freeze();
            }

            return _twoWayOptions;
        }
    }
    private static DuplexRequestOptions _twoWayOptions;
}
