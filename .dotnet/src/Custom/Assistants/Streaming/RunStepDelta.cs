using OpenAI.Internal.Models;
using System;
using System.Collections.Generic;

namespace OpenAI.Assistants;

[CodeGenModel("RunStepDeltaObject")]
public partial class RunStepDelta
{
    private readonly object Object;

    /// <inheritdoc cref="InternalRunStepDeltaObjectDelta.StepDetails"/>
    public BinaryData StepDetails { get; }

    [CodeGenMember("Delta")]
    internal InternalRunStepDeltaObjectDelta _delta;
}
