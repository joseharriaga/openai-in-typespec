using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.Collections.Generic;

namespace OpenAI.Tests.Chat;

public partial class ChatFunctionCallingTests
{
    static class MyFunctions
    {
        [Description("Returns the current weather at the specified location")]
        public static string GetCurrentWeather(string location, string unit) => $"31 {unit}";
    }

    [Test]
    public void ChatWithFunctionCalling()
    {
        ChatClient client = new("gpt-3.5-turbo", Environment.GetEnvironmentVariable("OpenAIClient_KEY"));
        ChatFunctions funtions = new(typeof(MyFunctions));

        List<ChatRequestMessage> messages = [
            new ChatRequestSystemMessage(
               "Don't make assumptions about what values to plug into functions."
               + " Ask for clarification if a user request is ambiguous."),
            new ChatRequestUserMessage("What's the weather like in San Francisco?"),
        ];

        ChatCompletionOptions options = new()
        {
            Tools = funtions.Definitions
        };

        ChatCompletion chatCompletion = client.CompleteChat(messages, options);

        if (chatCompletion.FinishReason == ChatFinishReason.ToolCalls)
        {
            // First, add the assistant message with tool calls to the conversation history.
            messages.Add(new ChatRequestAssistantMessage(chatCompletion));

            IEnumerable<ChatRequestToolMessage> callResults = funtions.CallAll(chatCompletion.ToolCalls);
            // Then, add a new tool message for each tool call that is resolved.
            messages.AddRange(callResults);

            // Finally, make a new request to chat completions to let the assistant summarize the tool results
            // and add the resulting message to the conversation history to keep it organized all in one place.
            ChatCompletion chatCompletionAfterToolMessages = client.CompleteChat(messages, options);
            messages.Add(new ChatRequestAssistantMessage(chatCompletionAfterToolMessages));
        }
    }
}
