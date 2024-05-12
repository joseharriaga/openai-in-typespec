using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("RunStepDetailsToolCallsObject")]
public partial class RunStepToolCallDetailsCollection : IReadOnlyList<RunStepToolCallDetails>
{
    /// <inheritdoc/>
    public RunStepToolCallDetails this[int index] => ToolCalls[index];

    /// <inheritdoc/>
    public int Count => ToolCalls.Count;

    /// <inheritdoc/>
    public IEnumerator<RunStepToolCallDetails> GetEnumerator()
    {
        return ToolCalls.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)ToolCalls).GetEnumerator();
    }
}
