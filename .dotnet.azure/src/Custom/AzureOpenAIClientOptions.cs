// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI;

/// <summary>
/// Defines the scenario-independent, client-level options for the Azure-specific OpenAI client.
/// </summary>
public partial class AzureOpenAIClientOptions : ClientPipelineOptions
{
    /// <summary>
    /// The service API version label to use with Azure OpenAI.
    /// </summary>
    /// <remarks>
    /// Using non-default service API versions may not function as intended, as capabilities and payload structures
    /// may differ. Exercise caution when changing the service API version and consider using protocol method
    /// variants (e.g. <see cref="ChatClient.CompleteChat(BinaryContent,RequestOptions)"/>) to maximize cross-version
    /// compatibility.
    /// </remarks>
    public ServiceVersion Version
    {
        get => _serviceVersion ??= ServiceVersion.Default;
        set
        {
            AssertNotFrozen();
            _serviceVersion = value;
        }
    }
    private ServiceVersion? _serviceVersion;

    /// <summary>
    /// The authorization audience to use when authenticating with Azure authentication tokens
    /// </summary>
    /// <remarks>
    /// By default, the public Azure cloud will be used to authenticate tokens. Modify this value to authenticate tokens
    /// with other clouds like Azure Government.
    /// </remarks>
    public AzureOpenAIAudience? Audience
    {
        get => _authorizationAudience;
        set
        {
            AssertNotFrozen();
            _authorizationAudience = value;
        }
    }
    private AzureOpenAIAudience? _authorizationAudience;

    /// <inheritdoc cref="OpenAIClientOptions.ApplicationId"/>
    public string ApplicationId
    {
        get => _applicationId;
        set
        {
            AssertNotFrozen();
            _applicationId = value;
        }
    }
    private string _applicationId;

    /// <summary>
    /// Initializes a new instance of <see cref="AzureOpenAIClientOptions"/>
    /// </summary>
    /// <param name="version"> The service API version to use with the client. </param>
    /// <exception cref="NotSupportedException"> The provided service API version is not supported. </exception>
    public AzureOpenAIClientOptions()
        : base()
    {

        RetryPolicy = new RetryWithDelaysPolicy();
    }

    internal class RetryWithDelaysPolicy : ClientRetryPolicy
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
