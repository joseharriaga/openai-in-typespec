using NUnit.Framework;

#region usings
using System;
using System.Collections.Generic;

using OpenAI.Chat;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class ChatDocs
{
    [Test]
    public void CreateChatCompletion_Functions()
    {
        #region logic

        ChatClient client = new(
            model: "gpt-4o",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ChatTool getCurrentWeatherTool = ChatTool.CreateFunctionTool(
            functionName: "get_current_weather",
            functionDescription: "Get the current weather in a given location",
            functionParameters: BinaryData.FromString("""
                {
                    "type": "object",
                    "properties": {
                        "location": {
                            "type": "string",
                            "description": "The city and state, e.g. San Francisco, CA"
                        },
                        "unit": {
                            "type": "string",
                            "enum": [ "celsius", "fahrenheit" ]
                        }
                    },
                    "required": [ "location" ]
                }
            """)
        );

        List<ChatMessage> messages =
        [
            new UserChatMessage("What's the weather like in Boston today?"),
        ];

        ChatCompletionOptions options = new()
        {
            Tools =
            {
                getCurrentWeatherTool
            },
            ToolChoice = ChatToolChoice.CreateAutoChoice(),
        };

        ChatCompletion completion = client.CompleteChat(messages, options);

        #endregion

        Assert.That(completion, Is.Not.Null);
        Assert.That(completion.ToolCalls, Has.Count.EqualTo(1));
        Assert.That(completion.ToolCalls[0].FunctionName, Is.EqualTo("get_current_weather"));
    }
}
