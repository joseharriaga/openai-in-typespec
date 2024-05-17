using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;

namespace OpenAI.Internal;

internal partial class OpenAIError
{
    internal static OpenAIError TryCreateFromResponse(PipelineResponse response)
    {
        try
        {
            using JsonDocument errorDocument = JsonDocument.Parse(response.Content);
            OpenAIErrorResponse errorResponse
                = OpenAIErrorResponse.DeserializeOpenAIErrorResponse(errorDocument.RootElement);
            return errorResponse.Error;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    public string ToExceptionMessage(int httpStatus)
    {
        StringBuilder messageBuilder = new();
        messageBuilder.Append($"HTTP {httpStatus}");
        messageBuilder.Append(!string.IsNullOrEmpty(Type) || !string.IsNullOrEmpty(Code) ? " (" : string.Empty);
        messageBuilder.Append(Type);
        messageBuilder.Append(!string.IsNullOrEmpty(Type) ? ": " : string.Empty);
        messageBuilder.Append(Code);
        messageBuilder.Append(!string.IsNullOrEmpty(Type) || !string.IsNullOrEmpty(Code) ? ")" : string.Empty);
        messageBuilder.AppendLine();

        if (!string.IsNullOrEmpty(Param))
        {
            messageBuilder.AppendLine($"Parameter: {Param}");
        }

        messageBuilder.AppendLine();
        messageBuilder.Append(Message);
        return messageBuilder.ToString();
    }
}
