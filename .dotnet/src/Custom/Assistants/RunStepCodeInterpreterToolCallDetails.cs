using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("RunStepDetailsToolCallsCodeObject")]
public partial class RunStepCodeInterpreterToolCallDetails
{
    /// <inheritdoc cref="InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter.Input"/>
    public string Input => _internalDetails.Input;
    
    /// <inheritdoc cref="InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter.Outputs"/>
    public IReadOnlyList<RunStepCodeInterpreterOutput> Outputs => _internalDetails.Outputs;

    [CodeGenMember("CodeInterpreter")]
    internal InternalRunStepDetailsToolCallsCodeObjectCodeInterpreter _internalDetails;
}