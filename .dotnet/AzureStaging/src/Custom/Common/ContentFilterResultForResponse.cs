using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;
[CodeGenModel("AzureContentFilterResultForChoice")]
public partial class ContentFilterResultForResponse
{
    internal InternalAzureContentFilterResultForPromptContentFilterResultsError Error { get; }
}
