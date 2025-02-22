// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalRunStepDetailsToolCallsCodeObject : RunStepToolCall
    {
        internal InternalRunStepDetailsToolCallsCodeObject(string id, InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter codeInterpreter) : base(id, Assistants.RunStepToolCallKind.CodeInterpreter)
        {
            CodeInterpreter = codeInterpreter;
        }

        internal InternalRunStepDetailsToolCallsCodeObject(string id, Assistants.RunStepToolCallKind kind, IDictionary<string, BinaryData> additionalBinaryDataProperties, InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter codeInterpreter) : base(id, kind, additionalBinaryDataProperties)
        {
            CodeInterpreter = codeInterpreter;
        }

        public InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter CodeInterpreter { get; }
    }
}
