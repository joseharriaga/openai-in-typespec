using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI;

internal static class ClientPipelineExtendedExtensions
{
    public static async ValueTask<PipelineResponse> ProcessMessageExAsync(
        this ClientPipeline pipeline,
        PipelineMessage message,
        RequestOptions requestContext,
        CancellationToken cancellationToken = default)
    {
        await pipeline.SendAsync(message).ConfigureAwait(false);

        if (message.Response == null)
        {
            throw new InvalidOperationException("Failed to receive Result.");
        }

        if (!message.Response.IsError || requestContext?.ErrorOptions == ClientErrorBehaviors.NoThrow)
        {
            return message.Response;
        }

        string errorMessage = await CreateBufferedErrorMessageAsync(message, cancellationToken).ConfigureAwait(false);
        throw new ClientResultException(errorMessage, message.Response);
    }

    public static PipelineResponse ProcessMessageEx(
        this ClientPipeline pipeline,
        PipelineMessage message,
        RequestOptions requestContext,
        CancellationToken cancellationToken = default)
    {
        pipeline.Send(message);

        if (message.Response == null)
        {
            throw new InvalidOperationException("Failed to receive Result.");
        }

        if (!message.Response.IsError || requestContext?.ErrorOptions == ClientErrorBehaviors.NoThrow)
        {
            return message.Response;
        }

        string errorMessage = CreateBufferedErrorMessage(message, cancellationToken);
        throw new ClientResultException(errorMessage, message.Response);
    }

    private static string CreateBufferedErrorMessage(PipelineMessage message, CancellationToken cancellationToken)
    {
        message.Response.BufferContent(cancellationToken);
        return CreateErrorMessage(message.Response);
    }

    private static async Task<string> CreateBufferedErrorMessageAsync(PipelineMessage message, CancellationToken cancellationToken)
    {
        await message.Response.BufferContentAsync(cancellationToken).ConfigureAwait(false);
        return CreateErrorMessage(message.Response);
    }

    private static string CreateErrorMessage(PipelineResponse response)
    {
        // Presumes OpenAI's error schema:
        // https://github.com/openai/openai-openapi/blob/28a300c5784415af66f81b2acc0db182f6eb3bbd/openapi.yaml#L5152

        string customErrorType = null;
        string customErrorMessage = null;

        try
        {
            using JsonDocument errorDocument = JsonDocument.Parse(response.Content);
            foreach (JsonProperty documentProperty in errorDocument.RootElement.EnumerateObject())
            {
                if (documentProperty.NameEquals("error"u8))
                {
                    foreach (JsonProperty errorProperty in documentProperty.Value.EnumerateObject())
                    {
                        if (errorProperty.NameEquals("message"u8))
                        {
                            customErrorMessage = errorProperty.Value.GetString();
                        }
                        else if (errorProperty.NameEquals("type"u8))
                        {
                            customErrorType = errorProperty.Value.GetString();
                        }
                    }
                }
            }
        }
        catch (JsonException)
        {
            return null;
        }

        StringBuilder builder = new($"HTTP {response.Status}");
        if (!string.IsNullOrEmpty(customErrorType))
        {
            builder.Append($", {customErrorType}: ");
        }
        else
        {
            builder.Append(": ");
        }
        builder.Append(customErrorMessage);

        return builder.ToString();
    }
}
