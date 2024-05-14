using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("RunStepDetailsToolCallsObject")]
internal partial class InternalRunStepToolCallDetailsCollection : IReadOnlyList<RunStepToolCall>
{
    /// <inheritdoc/>
    public RunStepToolCall this[int index] => InternalToolCalls[index];

    /// <inheritdoc/>
    public int Count => InternalToolCalls.Count;

    [CodeGenMember("ToolCalls")]
    private IReadOnlyList<RunStepToolCall> InternalToolCalls { get; }

    /// <inheritdoc/>
    public IEnumerator<RunStepToolCall> GetEnumerator()
    {
        return ToolCalls.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)ToolCalls).GetEnumerator();
    }
}
