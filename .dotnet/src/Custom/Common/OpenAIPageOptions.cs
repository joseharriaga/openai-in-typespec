using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAI;

#nullable enable

public class OpenAIPageOptions
{
    public int? PageSize { get; init; }

    public ListOrder? Order { get; init; }

    public string? AfterItemId { get; init; }

    public string? BeforeItemId { get; init; }
}
