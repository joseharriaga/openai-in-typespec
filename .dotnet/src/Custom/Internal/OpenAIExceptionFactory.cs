using OpenAI.Internal;
using System.ClientModel.Primitives;

#nullable enable

namespace OpenAI;

internal class OpenAIExceptionFactory : ClientResultExceptionFactory
{
    public override bool TryGetMessage(PipelineResponse response, out string? message)
    {
        message = OpenAIError.TryCreateFromResponse(response)?.ToExceptionMessage(response.Status);
        return message != null;
    }
}
