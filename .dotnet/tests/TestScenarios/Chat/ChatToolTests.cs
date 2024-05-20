using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Chat;

public partial class ChatToolTests
{
    [Test]
    public void ConstraintsWork()
    {
        ChatClient client = new("gpt-3.5-turbo");

        foreach (var (choice, reason) in new (ChatToolChoice, ChatFinishReason)[]
        {
            (null, ChatFinishReason.ToolCalls),
            (ChatToolChoice.None, ChatFinishReason.Stop),
            (new ChatToolChoice(s_numberForWordTool), ChatFinishReason.Stop),
            (ChatToolChoice.Auto, ChatFinishReason.ToolCalls),
            // TODO: Add test for ChatToolChoice.Required
        })
        {
            ChatCompletionOptions options = new()
            {
                Tools = { s_numberForWordTool },
                ToolChoice = choice,
            };
            ClientResult<ChatCompletion> result = client.CompleteChat([new UserChatMessage("What's the number for the word 'banana'?")], options);
            Assert.That(result.Value.FinishReason, Is.EqualTo(reason));
        }
    }

    private static ChatTool s_numberForWordTool = ChatTool.CreateFunctionTool(
        "get_number_for_word",
        "gets an arbitrary number assigned to a given word",
        BinaryData.FromString("""
            {
                "type": "object",
                "properties": {
                    "word": {
                        "type": "string"
                    }
                }
            }
            """)
        );

    [Test]
    public void NoParameterToolWorks()
    {
        ChatClient client = new("gpt-3.5-turbo");
        ChatTool getFavoriteColorTool = ChatTool.CreateFunctionTool(
            "get_favorite_color",
            "gets the favorite color of the caller"
        );
        ChatCompletionOptions options = new()
        {
            Tools = { getFavoriteColorTool },
        };
        ClientResult<ChatCompletion> result = client.CompleteChat([new UserChatMessage("What's my favorite color?")], options);
        Assert.That(result.Value.FinishReason, Is.EqualTo(ChatFinishReason.ToolCalls));
        Assert.That(result.Value.ToolCalls.Count, Is.EqualTo(1));
        var functionToolCall = result.Value.ToolCalls[0];
        var toolCallArguments = BinaryData.FromString(functionToolCall.FunctionArguments).ToObjectFromJson<Dictionary<string, object>>();
        Assert.That(functionToolCall, Is.Not.Null);
        Assert.That(functionToolCall.FunctionName, Is.EqualTo(getFavoriteColorTool.FunctionName));
        Assert.That(functionToolCall.Id, Is.Not.Null.Or.Empty);
        Assert.That(toolCallArguments.Count, Is.EqualTo(0));

        result = client.CompleteChat(
            [
                new UserChatMessage("What's my favorite color?"),
                new AssistantChatMessage(result.Value),
                new ToolChatMessage(functionToolCall.Id, "green"),
            ]);
        Assert.That(result.Value.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
        Assert.That(result.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring("green"));
    }

    [Test]
    public void ParametersWork()
    {
        ChatClient client = GetTestClient<ChatClient>(TestScenario.Chat);
        ChatTool favoriteColorForMonthTool = ChatTool.CreateFunctionTool(
            "get_favorite_color_for_month",
            "gets the caller's favorite color for a given month",
            BinaryData.FromString("""
                {
                    "type": "object",
                    "properties": {
                        "month_name": {
                            "type": "string",
                            "description": "the name of a calendar month, e.g. February or October."
                        }
                    },
                    "required": [ "month_name" ]
                }
                """)
        );
        ChatCompletionOptions options = new()
        {
            Tools = { favoriteColorForMonthTool },
        };
        List<ChatMessage> messages =
        [
            new UserChatMessage("What's my favorite color in February?"),
        ];
        ClientResult<ChatCompletion> result = client.CompleteChat(messages, options);
        Assert.That(result.Value.FinishReason, Is.EqualTo(ChatFinishReason.ToolCalls));
        Assert.That(result.Value.ToolCalls?.Count, Is.EqualTo(1));
        var functionToolCall = result.Value.ToolCalls[0];
        Assert.That(functionToolCall.FunctionName, Is.EqualTo(favoriteColorForMonthTool.FunctionName));
        JsonObject argumentsJson = JsonSerializer.Deserialize<JsonObject>(functionToolCall.FunctionArguments);
        Assert.That(argumentsJson.Count, Is.EqualTo(1));
        Assert.That(argumentsJson.ContainsKey("month_name"));
        Assert.That(argumentsJson["month_name"].ToString().ToLowerInvariant(), Is.EqualTo("february"));
        messages.Add(new AssistantChatMessage(result.Value));
        messages.Add(new ToolChatMessage(functionToolCall.Id, "chartreuse"));
        result = client.CompleteChat(messages, options);
        Assert.That(result.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring("chartreuse"));
    }
}
