using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI;

internal static partial class ClientPipelineExtensions
{
    // CUSTOM:
    // - Supplemented exception body with deserialized OpenAI error details

    public static async ValueTask<PipelineResponse> ProcessMessageAsync(
        this ClientPipeline pipeline,
        PipelineMessage message,
        RequestOptions options)
    {
        await pipeline.SendAsync(message).ConfigureAwait(false);

        if (message.Response == null)
        {
            throw new InvalidOperationException("Failed to receive Result.");
        }

        if (message.Response.IsError && (options?.ErrorOptions & ClientErrorBehaviors.NoThrow) != ClientErrorBehaviors.NoThrow)
        {
            throw await TryBufferResponseAndCreateErrorAsync(message.Response).ConfigureAwait(false) switch
            {
                string errorMessage when !string.IsNullOrEmpty(errorMessage)
                    => new ClientResultException(errorMessage, message.Response),
                _ => new ClientResultException(message.Response),
            };
        }

        return message.Response;
    }
        
    public static PipelineResponse ProcessMessage(
        this ClientPipeline pipeline,
        PipelineMessage message,
        RequestOptions options)
    {
        pipeline.Send(message);

        if (message.Response.IsError && (options?.ErrorOptions & ClientErrorBehaviors.NoThrow) != ClientErrorBehaviors.NoThrow)
        {
            throw TryBufferResponseAndCreateError(message.Response) switch
            {
                string errorMessage when !string.IsNullOrEmpty(errorMessage)
                    => new ClientResultException(errorMessage, message.Response),
                _ => new ClientResultException(message.Response),
            };
        }

        return message.Response;
    }

    private static string TryBufferResponseAndCreateError(PipelineResponse response)
    {
        response.BufferContent();
        return TryCreateErrorMessageFromResponse(response);
    }

    private static async Task<string> TryBufferResponseAndCreateErrorAsync(PipelineResponse response)
    {
        await response.BufferContentAsync().ConfigureAwait(false);
        return TryCreateErrorMessageFromResponse(response);
    }

    private static string TryCreateErrorMessageFromResponse(PipelineResponse response)
    {
        try
        {
            Internal.OpenAIError openAIError = Internal.OpenAIError.FromResponse(response);
            return openAIError.ToExceptionMessage(response.Status);
        }
        catch (Exception)
        {
            return null;
        }
    }
}
