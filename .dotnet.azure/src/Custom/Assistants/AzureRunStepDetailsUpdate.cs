// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Azure.AI.OpenAI;

public static class RunStepDetailsUpdateExtensions
{
    /// <summary>
    /// Gets a value indicating whether this <see cref="RunStepToolCall"/> instance represents a call to a <c>browser</c> tool.
    /// </summary>
    /// <param name="runStepToolCall"> The tool call to check the type of. </param>
    /// <returns> True if the tool call represents a browser tool call, false otherwise. </returns>
    [Experimental("AOAI001")]
    public static bool IsBingSearchKind(this RunStepDetailsUpdate baseUpdate)
    {
        return baseUpdate?._toolCall?.Type == "browser";
    }
}
