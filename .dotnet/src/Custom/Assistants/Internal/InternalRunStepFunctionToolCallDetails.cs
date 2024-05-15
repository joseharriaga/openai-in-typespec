using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("RunStepDetailsToolCallsFunctionObject")]
internal partial class InternalRunStepFunctionToolCallDetails
{
    public string InternalName => _internalFunction.Name;
    public string InternalArguments => _internalFunction.Arguments;
    public string InternalOutput => _internalFunction.Output;

    [CodeGenMember("Function")]
    internal InternalRunStepDetailsToolCallsFunctionObjectFunction _internalFunction;
}
