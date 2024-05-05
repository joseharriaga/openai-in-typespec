using System.ClientModel.Primitives;
using System.Text;
using System.Text.Json;

namespace OpenAI.Internal;

// Custom:
// - Renamed
// - 'FromResponse' added for convenience with parent type
// - 'ToExceptionMessage' added for encapsulated message formatting

[CodeGenModel("Error")]
internal partial class OpenAIError
{
    internal static OpenAIError FromResponse(PipelineResponse response)
    {
        using JsonDocument errorDocument = JsonDocument.Parse(response.Content);
        OpenAIErrorResponse errorResponse
            = OpenAIErrorResponse.DeserializeOpenAIErrorResponse(errorDocument.RootElement);
        return errorResponse.Error;
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

// Custom:
// - Renamed

[CodeGenModel("ErrorResponse")]
internal partial class OpenAIErrorResponse { }
