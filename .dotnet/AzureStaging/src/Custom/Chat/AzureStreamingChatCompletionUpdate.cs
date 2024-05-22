// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Internal;
using OpenAI.Chat;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;
public static partial class AzureStreamingChatCompletionUpdateExtensions
{
    [Experimental("OPENAI002")]
    public static AzureChatMessageContext GetAzureMessageContext(this StreamingChatCompletionUpdate chatUpdate)
    {
        if (chatUpdate.Choices?.Count > 0)
        {
            return AdditionalPropertyHelpers.GetAdditionalProperty<AzureChatMessageContext>(
                chatUpdate.Choices[0].Delta?._serializedAdditionalRawData,
                "context");
        }
        return null;
    }
}
