// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Internal;
using OpenAI.Chat;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Azure.AI.OpenAI.Chat;

public static partial class AzureChatCompletionExtensions
{
    [Experimental("OPENAI002")]
    public static ContentFilterResultForPrompt GetPromptContentFilterResult(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalListProperty<ContentFilterResultForPrompt>(
            chatCompletion._serializedAdditionalRawData,
            "prompt_filter_results")?[0];
    }

    [Experimental("OPENAI002")]
    public static ContentFilterResultForResponse GetResponseContentFilterResult(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalProperty<ContentFilterResultForResponse>(
            chatCompletion.Choices?[0]?._serializedAdditionalRawData,
            "content_filter_results");
    }

    [Experimental("OPENAI002")]
    public static AzureChatMessageContext GetAzureMessageContext(this ChatCompletion chatCompletion)
    {
        return AdditionalPropertyHelpers.GetAdditionalProperty<AzureChatMessageContext>(
            chatCompletion.Choices?[0]?.Message?._serializedAdditionalRawData,
            "context");
    }
}
