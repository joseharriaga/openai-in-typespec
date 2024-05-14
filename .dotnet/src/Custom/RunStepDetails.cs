using System.Collections.Generic;

namespace OpenAI.Assistants
{
    [CodeGenModel("RunStepObjectStepDetails")]
    public abstract partial class RunStepDetails
    {
        public string CreatedMessageId => AsInternalMessageCreation?.InternalMessageId;
        public IReadOnlyList<RunStepToolCall> ToolCalls => AsInternalToolCalls ?? [];

        private InternalRunStepMessageCreationDetails AsInternalMessageCreation => this as InternalRunStepMessageCreationDetails;
        private InternalRunStepToolCallDetailsCollection AsInternalToolCalls => this as InternalRunStepToolCallDetailsCollection;
    }
}
