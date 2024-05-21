// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Chat;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;
public static partial class AzureStreamingChatCompletionUpdateExtensions
{
    [Experimental("OPENAI002")]
    public static AzureChatMessageContext GetAzureMessageContext(this StreamingChatCompletionUpdate chatUpdate)
    {
        throw new NotImplementedException();
    }

    private static Type InternalChoiceType =>
        s_internalChoiceType ??= typeof(StreamingChatCompletionUpdate).Assembly.GetType("InternalCreateChatCompletionStreamResponseChoice");
    private static Type InternalDeltaType =>
        s_internalDeltaType ??= typeof(StreamingChatCompletionUpdate).Assembly.GetType("InternalChatCompletionStreamResponseDelta");

    private static Type s_internalChoiceType;
    private static Type s_internalDeltaType;
}
