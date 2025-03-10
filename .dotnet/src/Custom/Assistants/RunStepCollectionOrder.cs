﻿using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Assistants;

// CUSTOM: Renamed.
[Experimental("OPENAI001")]
[CodeGenType("ListRunStepsRequestOrder")]
public readonly partial struct RunStepCollectionOrder
{
    // CUSTOM: Renamed.
    [CodeGenMember("Asc")]
    public static RunStepCollectionOrder Ascending { get; } = new RunStepCollectionOrder(AscValue);

    // CUSTOM: Renamed.
    [CodeGenMember("Desc")]
    public static RunStepCollectionOrder Descending { get; } = new RunStepCollectionOrder(DescValue);
}
