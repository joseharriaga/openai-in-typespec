

using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI;

internal class PipelineMessageWithContext : PipelineMessage
{

    public PipelineMessageWithContext(PipelineMessage message) : this(message.Request)
    { }

    protected internal PipelineMessageWithContext(PipelineRequest request) : base(request)
    {
    }
}