using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("RunStepDetailsToolCallsFunctionObject")]
public partial class RunStepFunctionToolCallDetails
{
    public string Name => _internalFunction.Name;
    public string Arguments => _internalFunction.Arguments;
    public string Output => _internalFunction.Output;

    [CodeGenMember("Function")]
    internal InternalRunStepDetailsToolCallsFunctionObjectFunction _internalFunction;
}
