using System;
using System.ClientModel.Primitives;

namespace OpenAI;

/// <summary>
/// Client-level options for the OpenAI service.
/// </summary>
[CodeGenModel("OpenAIClientOptions")]
public partial class OpenAIClientOptions : ClientPipelineOptions
{
    public OpenAIClientOptions()
    {
        RetryPolicy = new HeaderInformedRetryPolicy();
    }

    /// <summary>
    /// A non-default base endpoint that clients should use when connecting.
    /// </summary>
    public Uri Endpoint { get; init; }

    /// <summary>
    /// An optional application ID to use as part of the request User-Agent header.
    /// </summary>
    public string ApplicationId { get; init; }

    /// <summary>
    /// An optional ID added to OpenAI-Organization header
    /// </summary>
    public string OrganizationId { get; init; }

    /// <summary>
    /// An optional ID added to OpenAI-Project header
    /// </summary>
    public string ProjectId { get; init; }

    private class HeaderInformedRetryPolicy : ClientRetryPolicy
    {
        protected override TimeSpan GetNextDelay(PipelineMessage message, int tryCount)
        {
            TimeSpan? TryGetTimeSpanFromHeader(string headerName, int millisecondsPerValue = 1, bool allowDateTimeOffset = false)
            {
                if (double.TryParse(
                    message?.Response?.Headers?.TryGetValue(headerName, out string textValue) == true ? textValue : null,
                    out double doubleValue) == true)
                {
                    return TimeSpan.FromMilliseconds(millisecondsPerValue * doubleValue);
                }
                else if (allowDateTimeOffset && DateTimeOffset.TryParse(headerName, out DateTimeOffset delayUntil))
                {
                    return delayUntil - DateTimeOffset.Now;
                }
                return null;
            }

            TimeSpan? delayFromHeader =
                TryGetTimeSpanFromHeader("retry-after-ms")
                ?? TryGetTimeSpanFromHeader("x-ms-retry-after-ms")
                ?? TryGetTimeSpanFromHeader("Retry-After", millisecondsPerValue: 1000, allowDateTimeOffset: true);

            return delayFromHeader ?? base.GetNextDelay(message, tryCount);
        }
    }
}
