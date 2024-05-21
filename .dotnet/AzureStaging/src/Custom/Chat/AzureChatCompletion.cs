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
        if (chatCompletion.SerializedAdditionalRawData.TryGetValue("prompt_filter_results", out BinaryData binaryResult))
        {
            using JsonDocument document = JsonDocument.Parse(binaryResult);
            if (document.RootElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement resultElement in document.RootElement.EnumerateArray())
                {
                    return ContentFilterResultForPrompt.DeserializeContentFilterResultForPrompt(resultElement);
                }
            }
        }
        return null;
    }

    [Experimental("OPENAI002")]
    public static ContentFilterResultForResponse GetResponseContentFilterResult(this ChatCompletion chatCompletion)
        => AdditionalPropertyHelpers.TryGetAdditionalProperty(
            chatCompletion.SerializedAdditionalRawData,
            "sdk_content_filter_response",
            out ContentFilterResultForResponse response)
                ? response
                : null;

    [Experimental("OPENAI002")]
    public static AzureChatMessageContext GetAzureMessageContext(this ChatCompletion chatCompletion)
        => AdditionalPropertyHelpers.TryGetAdditionalProperty(
            chatCompletion.SerializedAdditionalRawData,
            "sdk_azure_message_context",
            out AzureChatMessageContext messageContext)
                ? messageContext
                : null;
}
