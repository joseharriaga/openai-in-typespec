// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

public static partial class RunStepToolCallExtensions
{
    /// <summary>
    /// Gets a value indicating whether this <see cref="RunStepToolCall"/> instance represents a call to a <c>browser</c> tool.
    /// </summary>
    /// <param name="runStepToolCall"> The tool call to check the type of. </param>
    /// <returns> True if the tool call represents a browser tool call, false otherwise. </returns>
    [Experimental("AOAI001")]
    public static bool IsBingSearchKind(this RunStepToolCall runStepToolCall)
    {
        return runStepToolCall.Type == "browser";
    }
}
