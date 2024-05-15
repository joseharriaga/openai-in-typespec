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
    [CodeGenMember("ToolCalls")]
    private IReadOnlyList<RunStepToolCall> InternalToolCalls { get; } = [];

    /// <inheritdoc/>
    public RunStepToolCall this[int index] => InternalToolCalls[index];

    /// <inheritdoc/>
    public int Count => InternalToolCalls.Count;

    /// <inheritdoc/>
    public IEnumerator<RunStepToolCall> GetEnumerator() => InternalToolCalls.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => InternalToolCalls.GetEnumerator();
}
