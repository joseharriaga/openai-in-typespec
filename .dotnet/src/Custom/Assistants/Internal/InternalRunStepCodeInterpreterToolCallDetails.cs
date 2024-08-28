using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Assistants;

[Experimental("OPENAI001")]
[CodeGenModel("RunStepDetailsToolCallsCodeObject")]
internal partial class InternalRunStepCodeInterpreterToolCallDetails
{
    /// <inheritdoc cref="InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter.Input"/>
    public string Input => _codeInterpreter.Input;
    
    /// <inheritdoc cref="InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter.Outputs"/>
    public IReadOnlyList<RunStepCodeInterpreterOutput> Outputs => _codeInterpreter.Outputs;

    [CodeGenMember("CodeInterpreter")]
    internal InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter _codeInterpreter;
}