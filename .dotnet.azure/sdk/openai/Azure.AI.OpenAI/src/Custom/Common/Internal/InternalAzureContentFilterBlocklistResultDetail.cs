// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI;

[Experimental("AOAI001")][CodeGenModel("AzureContentFilterBlocklistResultDetail")]
internal partial class InternalAzureContentFilterBlocklistResultDetail
{
    [CodeGenMember("Filtered")]
    internal bool IsFiltered { get; set; }
}
