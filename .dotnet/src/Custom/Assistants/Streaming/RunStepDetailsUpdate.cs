using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

/// <summary>
/// The update type presented when run step details, including tool call progress, have changed.
/// </summary>
public class RunStepDetailsUpdate : StreamingUpdate
{
    private readonly RunStepDelta _delta;

    /// <inheritdoc cref="RunStepDeltaObjectDelta.StepDetails"/>
    public BinaryData StepDetails => _delta.Delta.StepDetails;

    internal RunStepDetailsUpdate(RunStepDelta stepDelta, StreamingUpdateReason updateKind)
        : base(updateKind)
    {
        _delta = stepDelta;
    }

    internal static IEnumerable<RunStepDetailsUpdate> DeserializeRunStepDetailsUpdates(
        JsonElement element,
        StreamingUpdateReason updateKind,
        ModelReaderWriterOptions options = null)
    {
        RunStepDelta stepDelta = RunStepDelta.DeserializeRunStepDelta(element, options);
        return updateKind switch
        {
            _ => [new RunStepDetailsUpdate(stepDelta, updateKind)],
        };
    }
}
