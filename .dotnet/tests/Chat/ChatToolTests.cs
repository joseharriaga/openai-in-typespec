﻿using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenAI.Chat;
using OpenAI.TestFramework;
using OpenAI.Tests.Utility;

namespace OpenAI.Tests.Chat;

[Category("Chat")]
public partial class ChatToolTests : OpenAiTestBase
{
    public ChatToolTests(bool isAsync) : base(isAsync)
    {
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

    private const string GetFavoriteColorToolFunctionName = "get_favorite_color";

    private static ChatTool s_getFavoriteColorTool = ChatTool.CreateFunctionTool(
        GetFavoriteColorToolFunctionName,
        "gets the favorite color of the caller"
    );

    private const string GetFavoriteColorForMonthToolFunctionName = "get_favorite_color_for_month";

    private static ChatTool s_getFavoriteColorForMonthTool = ChatTool.CreateFunctionTool(
        GetFavoriteColorForMonthToolFunctionName,
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

    private const string GetFavoriteColorForMonthFunctionName = "get_favorite_color_for_month";

#pragma warning disable CS0618
    private static ChatFunction s_getFavoriteColorForMonthFunction = new ChatFunction(
        GetFavoriteColorForMonthToolFunctionName,
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
#pragma warning restore CS0618

    private const string GetWeatherForCityToolName = "get_weather_for_city";

    private static ChatTool s_getWeatherForCityTool = ChatTool.CreateFunctionTool(
        GetWeatherForCityToolName,
        "gets the current weather for a given city",
        BinaryData.FromString("""
            {
                "type": "object",
                "properties": {
                    "city_name": {
                        "type": "string",
                        "description": "the name of a city, e.g. Johannesburg or Ho Chi Minh City."
                    }
                },
                "required": [ "city_name" ]
            }
            """)
    );

    private const string GetMoodForWeatherToolName = "get_mood_for_weather";

    private static ChatTool s_getMoodForWeatherTool = ChatTool.CreateFunctionTool(
        GetMoodForWeatherToolName,
        "gets the caller's mood for a given weather",
        BinaryData.FromString("""
            {
                "type": "object",
                "properties": {
                    "weather": {
                        "type": "string",
                        "description": "the current weather of where the caller is located, e.g. sunny or cloudy."
                    }
                },
                "required": [ "weather" ]
            }
            """)
    );

    [RecordedTest]
    public async Task ConstraintsWork()
    {
        ChatClient client = GetTestClient<ChatClient>();
        IEnumerable<ChatMessage> messages = [new UserChatMessage("What's the number for the word 'banana'?")];

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
            ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages, options);
            Assert.That(result.Value.FinishReason, Is.EqualTo(reason));
        }
    }

    [RecordedTest]
    public async Task NoParameterToolWorks()
    {
        ChatClient client = GetTestClient<ChatClient>();
        ICollection<ChatMessage> messages = [new UserChatMessage("What's my favorite color?")];
        ChatCompletionOptions options = new()
        {
            Tools = { s_getFavoriteColorTool },
        };
        ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages, options);

        Assert.That(result.Value.FinishReason, Is.EqualTo(ChatFinishReason.ToolCalls));
        Assert.That(result.Value.ToolCalls.Count, Is.EqualTo(1));
        var toolCall = result.Value.ToolCalls[0];
        var toolCallArguments = BinaryData.FromString(toolCall.FunctionArguments).ToObjectFromJson<Dictionary<string, object>>();
        Assert.That(toolCall.FunctionName, Is.EqualTo(GetFavoriteColorToolFunctionName));
        Assert.That(toolCall.Id, Is.Not.Null.And.Not.Empty);
        Assert.That(toolCallArguments.Count, Is.EqualTo(0));

        messages.Add(new AssistantChatMessage(result.Value));
        messages.Add(new ToolChatMessage(toolCall.Id, "green"));
        result = await client.CompleteChatAsync(messages, options);

        Assert.That(result.Value.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
        Assert.That(result.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring("green"));
    }

    [RecordedTest]
    public async Task ParametersWork()
    {
        ChatClient client = GetTestClient<ChatClient>();
        ChatCompletionOptions options = new()
        {
            Tools = { s_getFavoriteColorForMonthTool },
        };
        List<ChatMessage> messages =
        [
            new UserChatMessage("What's my favorite color in February?"),
        ];
        ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages, options);
        Assert.That(result.Value.FinishReason, Is.EqualTo(ChatFinishReason.ToolCalls));
        Assert.That(result.Value.ToolCalls?.Count, Is.EqualTo(1));
        var toolCall = result.Value.ToolCalls[0];
        Assert.That(toolCall.FunctionName, Is.EqualTo(GetFavoriteColorForMonthToolFunctionName));
        JsonObject argumentsJson = JsonSerializer.Deserialize<JsonObject>(toolCall.FunctionArguments);
        Assert.That(argumentsJson.Count, Is.EqualTo(1));
        Assert.That(argumentsJson.ContainsKey("month_name"));
        Assert.That(argumentsJson["month_name"].ToString().ToLowerInvariant(), Is.EqualTo("february"));
        messages.Add(new AssistantChatMessage(result.Value));
        messages.Add(new ToolChatMessage(toolCall.Id, "chartreuse"));
        result = await client.CompleteChatAsync(messages, options);
        Assert.That(result.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring("chartreuse"));
    }

    [RecordedTest]
    public async Task FunctionsWork()
    {
        ChatClient client = GetTestClient<ChatClient>();
        ChatCompletionOptions options = new()
        {
            Functions = { s_getFavoriteColorForMonthFunction },
        };
        List<ChatMessage> messages =
        [
            new UserChatMessage("What's my favorite color in February?"),
        ];
        ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages, options);
        Assert.That(result.Value.FinishReason, Is.EqualTo(ChatFinishReason.FunctionCall));
        var functionCall = result.Value.FunctionCall;
        Assert.That(functionCall, Is.Not.Null);
        Assert.That(functionCall.FunctionName, Is.EqualTo(GetFavoriteColorForMonthFunctionName));
        JsonObject argumentsJson = JsonSerializer.Deserialize<JsonObject>(functionCall.FunctionArguments);
        Assert.That(argumentsJson.Count, Is.EqualTo(1));
        Assert.That(argumentsJson.ContainsKey("month_name"));
        Assert.That(argumentsJson["month_name"].ToString().ToLowerInvariant(), Is.EqualTo("february"));
        messages.Add(new AssistantChatMessage(result.Value));
#pragma warning disable CS0618
        messages.Add(new FunctionChatMessage(GetFavoriteColorForMonthFunctionName, "chartreuse"));
#pragma warning restore CS0618
        result = await client.CompleteChatAsync(messages, options);
        Assert.That(result.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring("chartreuse"));
    }

    [RecordedTest]
    public async Task ParallelToolCalls()
    {
        ChatClient client = GetTestClient<ChatClient>();
        ChatCompletionOptions options = new()
        {
            Tools = { s_getWeatherForCityTool },
        };
        List<ChatMessage> messages = [
            new UserChatMessage("Tell me what's the current weather in the following cities: Santiago and Karachi."),
        ];
        ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages, options);

        Assert.That(result.Value.FinishReason, Is.EqualTo(ChatFinishReason.ToolCalls));
        Assert.That(result.Value.ToolCalls.Count, Is.EqualTo(2));

        var santiagoToolCall = result.Value.ToolCalls.Single(call => call.FunctionArguments.ToLowerInvariant().Contains("santiago"));
        var karachiToolCall = result.Value.ToolCalls.Single(call => call.FunctionArguments.ToLowerInvariant().Contains("karachi"));

        JsonObject argumentsJson = JsonSerializer.Deserialize<JsonObject>(santiagoToolCall.FunctionArguments);
        Assert.That(argumentsJson.Count, Is.EqualTo(1));
        Assert.That(argumentsJson.ContainsKey("city_name"));
        Assert.That(argumentsJson["city_name"].ToString().ToLowerInvariant(), Is.EqualTo("santiago"));

        argumentsJson = JsonSerializer.Deserialize<JsonObject>(karachiToolCall.FunctionArguments);
        Assert.That(argumentsJson.Count, Is.EqualTo(1));
        Assert.That(argumentsJson.ContainsKey("city_name"));
        Assert.That(argumentsJson["city_name"].ToString().ToLowerInvariant(), Is.EqualTo("karachi"));

        messages.Add(new AssistantChatMessage(result.Value));
        messages.Add(new ToolChatMessage(santiagoToolCall.Id, "rainy"));
        messages.Add(new ToolChatMessage(karachiToolCall.Id, "sunny"));

        result = await client.CompleteChatAsync(messages, options);

        Assert.That(result.Value.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
        Assert.That(result.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring("rainy"));
        Assert.That(result.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring("sunny"));
    }

    [RecordedTest]
    public async Task ConsecutiveToolCalls()
    {
        ChatClient client = GetTestClient<ChatClient>();
        ChatCompletionOptions options = new()
        {
            Tools = { s_getWeatherForCityTool, s_getMoodForWeatherTool },
        };
        List<ChatMessage> messages = [
            new UserChatMessage("Can you guess my mood given that I'm currently located in Osaka?"),
        ];
        ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages, options);

        Assert.That(result.Value.ToolCalls?.Count, Is.EqualTo(1));
        var toolCall = result.Value.ToolCalls[0];
        Assert.That(toolCall.FunctionName, Is.EqualTo(GetWeatherForCityToolName));

        JsonObject argumentsJson = JsonSerializer.Deserialize<JsonObject>(toolCall.FunctionArguments);
        Assert.That(argumentsJson.Count, Is.EqualTo(1));
        Assert.That(argumentsJson.ContainsKey("city_name"));
        Assert.That(argumentsJson["city_name"].ToString().ToLowerInvariant(), Is.EqualTo("osaka"));

        messages.Add(new AssistantChatMessage(result.Value));
        messages.Add(new ToolChatMessage(toolCall.Id, "rainy"));
        result = await client.CompleteChatAsync(messages, options);

        Assert.That(result.Value.ToolCalls?.Count, Is.EqualTo(1));
        toolCall = result.Value.ToolCalls[0];
        Assert.That(toolCall.FunctionName, Is.EqualTo(GetMoodForWeatherToolName));

        argumentsJson = JsonSerializer.Deserialize<JsonObject>(toolCall.FunctionArguments);
        Assert.That(argumentsJson.Count, Is.EqualTo(1));
        Assert.That(argumentsJson.ContainsKey("weather"));
        Assert.That(argumentsJson["weather"].ToString().ToLowerInvariant(), Is.EqualTo("rainy"));

        messages.Add(new AssistantChatMessage(result.Value));
        messages.Add(new ToolChatMessage(toolCall.Id, "bored"));
        result = await client.CompleteChatAsync(messages, options);

        Assert.That(result.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring("bored"));
    }

    public enum SchemaPresence { WithSchema, WithoutSchema }
    public enum StrictnessPresence { Unspecified, Strict, NotStrict }
    public enum FailureExpectation { FailureExpected, FailureNotExpected }

    [RecordedTest]
    [TestCase(SchemaPresence.WithoutSchema, StrictnessPresence.Unspecified)]
    [TestCase(SchemaPresence.WithoutSchema, StrictnessPresence.NotStrict)]
    [TestCase(SchemaPresence.WithoutSchema, StrictnessPresence.Strict, FailureExpectation.FailureExpected)]
    [TestCase(SchemaPresence.WithSchema, StrictnessPresence.Unspecified)]
    [TestCase(SchemaPresence.WithSchema, StrictnessPresence.NotStrict)]
    [TestCase(SchemaPresence.WithSchema, StrictnessPresence.Strict)]
    public async Task StructuredOutputs(
        SchemaPresence schemaPresence,
        StrictnessPresence strictnessPresence,
        FailureExpectation failureExpectation = FailureExpectation.FailureNotExpected)
    {
        // Note: proper output requires 2024-08-06 or later models
        ChatClient client = GetTestClient<ChatClient>("gpt-4o-2024-08-06");

        const string toolName = "get_favorite_color_for_day_of_week";
        const string toolDescription = "Given a weekday name like Tuesday, gets the favorite color of the user on that day.";
        BinaryData toolSchema = schemaPresence == SchemaPresence.WithSchema
            ? BinaryData.FromObjectAsJson(new
            {
                type = "object",
                properties = new
                {
                    the_day_of_the_week = new
                    {
                        type = "string"
                    }
                },
                required = new[] { "the_day_of_the_week" },
                additionalProperties = !(strictnessPresence == StrictnessPresence.Strict),
            })
            : null;
        bool? useStrictSchema = strictnessPresence switch
        {
            StrictnessPresence.Strict => true,
            StrictnessPresence.NotStrict => false,
            _ => null,
        };

        ChatCompletionOptions options = new()
        {
            Tools = { ChatTool.CreateFunctionTool(toolName, toolDescription, toolSchema, useStrictSchema) },
        };

        List<ChatMessage> messages = [
            new SystemChatMessage("Call applicable tools when the user asks a question. Prefer JSON output when possible."),
            new UserChatMessage("What's my favorite color on Tuesday?"),
        ];

        if (failureExpectation == FailureExpectation.FailureExpected)
        {
            ClientResultException thrownException = Assert.ThrowsAsync<ClientResultException>(() => client.CompleteChatAsync(messages, options));
            Assert.That(thrownException.Message, Does.Contain("function.parameters"));
        }
        else
        {
            ChatCompletion completion = await client.CompleteChatAsync(messages, options);
            Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.ToolCalls));
            Assert.That(completion.ToolCalls, Has.Count.EqualTo(1));
            Assert.That(completion.ToolCalls[0].FunctionArguments, Is.Not.Null.And.Not.Empty);

            if (schemaPresence == SchemaPresence.WithSchema && strictnessPresence == StrictnessPresence.Strict)
            {
                using JsonDocument argumentsDocument = JsonDocument.Parse(completion.ToolCalls[0].FunctionArguments);
                Assert.That(argumentsDocument.RootElement.GetProperty("the_day_of_the_week").GetString(), Is.EqualTo("Tuesday"));
            }
        }
    }
}
