// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Assistants;
using OpenAI.Assistants;

namespace Azure.AI.OpenAI.Assistants;

/// <summary> The BingSearchToolDefinition. </summary>
[CodeGenModel("BingSearchToolDefinition")]
public partial class BingSearchToolDefinition : ToolDefinition
{
    public required string BingResourceId
    {
        get => _internalBrowser.BingResourceId;
        set => _internalBrowser.BingResourceId = value;
    }

    /// <summary> Initializes a new instance of <see cref="BingSearchToolDefinition"/>. </summary>
    public BingSearchToolDefinition()
    {
        Type = "browser";
        _internalBrowser = new();
    }

    [SetsRequiredMembers]
    public BingSearchToolDefinition(string bingResourceId)
        : this()
    {
        _internalBrowser.BingResourceId = bingResourceId;
    }

    /// <summary> Initializes a new instance of <see cref="BingSearchToolDefinition"/>. </summary>
    /// <param name="type"> Discriminator. </param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    /// <param name="browser"> Overrides for the file search tool. </param>
    [SetsRequiredMembers]
    internal BingSearchToolDefinition(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalBingSearchToolDefinitionBrowser browser) : base(type, serializedAdditionalRawData)
    {
        _internalBrowser = browser;
    }

    /// <summary> Overrides for the file search tool. </summary>
    [CodeGenMember("Browser")]
    internal InternalBingSearchToolDefinitionBrowser _internalBrowser { get; set; }
}
