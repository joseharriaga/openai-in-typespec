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
        messageBuilder.AppendLine($"HTTP {httpStatus} ({Type}: {Code})");
        if (!string.IsNullOrEmpty(Param))
        {
            messageBuilder.AppendLine($"Parameter: {Param}");
        }
        messageBuilder.AppendLine();
        messageBuilder.Append(Message);
        return messageBuilder.ToString();
    }
}
