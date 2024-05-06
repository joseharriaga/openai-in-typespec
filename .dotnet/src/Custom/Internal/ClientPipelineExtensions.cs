using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Runtime.ExceptionServices;
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

        if (message.Response.IsError && (options?.ErrorOptions & ClientErrorBehaviors.NoThrow) != ClientErrorBehaviors.NoThrow)
        {
            throw await TryBufferResponseAndCreateErrorAsync(message).ConfigureAwait(false) switch
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
            throw TryBufferResponseAndCreateError(message) switch
            {
                string errorMessage when !string.IsNullOrEmpty(errorMessage)
                    => new ClientResultException(errorMessage, message.Response),
                _ => new ClientResultException(message.Response),
            };
        }

        return message.Response;
    }

    private static string TryBufferResponseAndCreateError(PipelineMessage message)
    {
        if (message.BufferResponse)
        {
            message.Response.BufferContent();
        }
        return TryCreateErrorMessageFromResponse(message.Response);
    }

    private static async Task<string> TryBufferResponseAndCreateErrorAsync(PipelineMessage message)
    {
        if (message.BufferResponse)
        {
            await message.Response.BufferContentAsync().ConfigureAwait(false);
        }
        return TryCreateErrorMessageFromResponse(message.Response);
    }

    private static string TryCreateErrorMessageFromResponse(PipelineResponse response)
        => Internal.OpenAIError.TryCreateFromResponse(response)?.ToExceptionMessage(response.Status);
}
