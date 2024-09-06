using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenAI.Chat;
using OpenAI.TestFramework;
using OpenAI.Tests.Telemetry;
using OpenAI.Tests.Utility;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static OpenAI.Tests.Telemetry.TestMeterListener;

namespace OpenAI.Tests.Chat;


[Category("Chat")]
public class ChatTests : OpenAiTestBase
{
    public ChatTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task HelloWorldChat()
    {
        ChatClient client = GetTestClient<ChatClient>();
        IEnumerable<ChatMessage> messages = [new UserChatMessage("Hello, world!")];
        ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages);
        Assert.That(result, Is.InstanceOf<ClientResult<ChatCompletion>>());
        Assert.That(result.Value.Content[0].Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
        Assert.That(result.Value.Content[0].Text.Length, Is.GreaterThan(0));
    }

    [RecordedTest]
    public async Task HelloWorldWithTopLevelClient()
    {
        OpenAIClient client = GetTestTopLevel();
        ChatClient chatClient = WrapClient(client.GetChatClient("gpt-4o-mini"));
        IEnumerable<ChatMessage> messages = [new UserChatMessage("Hello, world!")];
        ClientResult<ChatCompletion> result = await chatClient.CompleteChatAsync(messages);
        Assert.That(result.Value.Content[0].Text.Length, Is.GreaterThan(0));
    }

    [RecordedTest]
    public async Task MultiMessageChat()
    {
        ChatClient client = GetTestClient<ChatClient>();
        IEnumerable<ChatMessage> messages = [
            new SystemChatMessage("You are a helpful assistant. You always talk like a pirate."),
            new UserChatMessage("Hello, assistant! Can you help me train my parrot?"),
        ];
        ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages);
        Assert.That(new string[] { "aye", "arr", "hearty" }.Any(pirateWord => result.Value.Content[0].Text.ToLowerInvariant().Contains(pirateWord)));
    }

    [RecordedTest]
    public async Task StreamingChat()
    {
        ChatClient client = GetTestClient<ChatClient>();
        IEnumerable<ChatMessage> messages = [
            new UserChatMessage("What are the best pizza toppings? Give me a breakdown on the reasons.")
        ];

        AsyncCollectionResult<StreamingChatCompletionUpdate> streamingResult = client.CompleteChatStreamingAsync(messages);
        int updateCount = 0;
        ChatTokenUsage usage = null;

        await foreach (StreamingChatCompletionUpdate chatUpdate in streamingResult)
        {
            usage ??= chatUpdate.Usage;
            updateCount++;
        }
        Assert.That(updateCount, Is.GreaterThan(1));
        Assert.That(usage, Is.Not.Null);
        Assert.That(usage?.InputTokens, Is.GreaterThan(0));
        Assert.That(usage?.OutputTokens, Is.GreaterThan(0));
        Assert.That(usage.InputTokens + usage.OutputTokens, Is.EqualTo(usage.TotalTokens));

        //// Validate that network stream was disposed - this will show up as the
        //// the raw response holding an empty content stream.
        //PipelineResponse response = streamingResult.GetRawResponse();
        //Assert.That(response.ContentStream.Length, Is.EqualTo(0));
    }

    [RecordedTest]
    public async Task TwoTurnChat()
    {
        ChatClient client = GetTestClient<ChatClient>();

        List<ChatMessage> messages =
        [
            new UserChatMessage("In geometry, what are the different kinds of triangles, as defined by lengths of their sides?"),
        ];
        ClientResult<ChatCompletion> firstResult = await client.CompleteChatAsync(messages);
        Assert.That(firstResult?.Value, Is.Not.Null);
        Assert.That(firstResult.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring("isosceles"));
        messages.Add(new AssistantChatMessage(firstResult.Value));
        messages.Add(new UserChatMessage("Which of those is the one where exactly two sides are the same length?"));
        ClientResult<ChatCompletion> secondResult = await client.CompleteChatAsync(messages);
        Assert.That(secondResult?.Value, Is.Not.Null);
        Assert.That(secondResult.Value.Content[0].Text.ToLowerInvariant(), Contains.Substring("isosceles"));
    }

    [RecordedTest]
    public async Task ChatWithVision()
    {
        string mediaType = "image/png";
        string filePath = Path.Combine("Assets", "images_dog_and_cat.png");
        using Stream stream = File.OpenRead(filePath);
        BinaryData imageData = BinaryData.FromStream(stream);

        ChatClient client = GetTestClient<ChatClient>();
        IEnumerable<ChatMessage> messages = [
            new UserChatMessage(
                ChatMessageContentPart.CreateTextMessageContentPart("Describe this image for me."),
                ChatMessageContentPart.CreateImageMessageContentPart(imageData, mediaType)),
        ];
        ChatCompletionOptions options = new() { MaxTokens = 2048 };

        ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages, options);
        Console.WriteLine(result.Value.Content[0].Text);
        Assert.That(result.Value.Content[0].Text.ToLowerInvariant(), Does.Contain("dog").Or.Contain("cat").IgnoreCase);
    }

    [RecordedTest]
    public void AuthFailure()
    {
        string fakeApiKey = "not-a-real-key-but-should-be-sanitized";
        ChatClient client = GetTestClient<ChatClient>("gpt-4o-mini", new ApiKeyCredential(fakeApiKey));
        IEnumerable<ChatMessage> messages = [new UserChatMessage("Uh oh, this isn't going to work with that key")];

        var clientResultException = Assert.ThrowsAsync<ClientResultException>(() => client.CompleteChatAsync(messages));
        Assert.That(clientResultException.Status, Is.EqualTo((int)HttpStatusCode.Unauthorized));
        Assert.That(clientResultException.Message, Does.Contain("API key"));
        Assert.That(clientResultException.Message, Does.Not.Contain(fakeApiKey));
    }

    [RecordedTest]
    public async Task AuthFailureStreaming()
    {
        string fakeApiKey = "not-a-real-key-but-should-be-sanitized";
        ChatClient client = GetTestClient<ChatClient>("gpt-4o-mini", new ApiKeyCredential(fakeApiKey));

        Exception caughtException = null;
        try
        {
            await foreach (var _ in client.CompleteChatStreamingAsync(
                [new UserChatMessage("Uh oh, this isn't going to work with that key")]))
            { }
        }
        catch (Exception ex)
        {
            caughtException = ex;
        }
        var clientResultException = caughtException as ClientResultException;
        Assert.That(clientResultException, Is.Not.Null);
        Assert.That(clientResultException.Status, Is.EqualTo((int)HttpStatusCode.Unauthorized));
        Assert.That(clientResultException.Message, Does.Contain("API key"));
        Assert.That(clientResultException.Message, Does.Not.Contain(fakeApiKey));
    }

    [RecordedTest]
    [TestCase(true)]
    [TestCase(false)]
    public async Task TokenLogProbabilities(bool includeLogProbabilities)
    {
        const int topLogProbabilityCount = 3;
        ChatClient client = GetTestClient<ChatClient>();
        IList<ChatMessage> messages = [new UserChatMessage("What are the best pizza toppings? Give me a breakdown on the reasons.")];
        ChatCompletionOptions options;

        if (includeLogProbabilities)
        {
            options = new()
            {
                IncludeLogProbabilities = true,
                TopLogProbabilityCount = topLogProbabilityCount
            };
        }
        else
        {
            options = new();
        }

        ChatCompletion chatCompletions = await client.CompleteChatAsync(messages, options);
        Assert.That(chatCompletions, Is.Not.Null);

        if (includeLogProbabilities)
        {
            IReadOnlyList<ChatTokenLogProbabilityInfo> chatTokenLogProbabilities = chatCompletions.ContentTokenLogProbabilities;
            Assert.That(chatTokenLogProbabilities, Is.Not.Null.Or.Empty);

            foreach (ChatTokenLogProbabilityInfo tokenLogProbs in chatTokenLogProbabilities)
            {
                Assert.That(tokenLogProbs.Token, Is.Not.Null.Or.Empty);
                Assert.That(tokenLogProbs.Utf8ByteValues, Is.Not.Null);
                Assert.That(tokenLogProbs.TopLogProbabilities, Is.Not.Null.Or.Empty);
                Assert.That(tokenLogProbs.TopLogProbabilities, Has.Count.EqualTo(topLogProbabilityCount));

                foreach (ChatTokenTopLogProbabilityInfo tokenTopLogProbs in tokenLogProbs.TopLogProbabilities)
                {
                    Assert.That(tokenTopLogProbs.Token, Is.Not.Null.Or.Empty);
                    Assert.That(tokenTopLogProbs.Utf8ByteValues, Is.Not.Null);
                }
            }
        }
        else
        {
            Assert.That(chatCompletions.ContentTokenLogProbabilities, Is.Not.Null);
            Assert.That(chatCompletions.ContentTokenLogProbabilities, Is.Empty);
        }
    }

    [RecordedTest]
    [TestCase(true)]
    [TestCase(false)]
    public async Task TokenLogProbabilitiesStreaming(bool includeLogProbabilities)
    {
        const int topLogProbabilityCount = 3;
        ChatClient client = GetTestClient<ChatClient>();
        IList<ChatMessage> messages = [new UserChatMessage("What are the best pizza toppings? Give me a breakdown on the reasons.")];
        ChatCompletionOptions options;

        if (includeLogProbabilities)
        {
            options = new()
            {
                IncludeLogProbabilities = true,
                TopLogProbabilityCount = topLogProbabilityCount
            };
        }
        else
        {
            options = new();
        }

        AsyncCollectionResult<StreamingChatCompletionUpdate> chatCompletionUpdates = client.CompleteChatStreamingAsync(messages, options);
        Assert.That(chatCompletionUpdates, Is.Not.Null);

        await foreach (StreamingChatCompletionUpdate chatCompletionUpdate in chatCompletionUpdates)
        {
            // Token log probabilities are streamed together with their corresponding content update.
            if (includeLogProbabilities
                && chatCompletionUpdate.ContentUpdate.Count > 0
                && !string.IsNullOrEmpty(chatCompletionUpdate.ContentUpdate[0].Text))
            {
                Assert.That(chatCompletionUpdate.ContentTokenLogProbabilities, Is.Not.Null.Or.Empty);
                Assert.That(chatCompletionUpdate.ContentTokenLogProbabilities, Has.Count.EqualTo(1));

                foreach (ChatTokenLogProbabilityInfo tokenLogProbs in chatCompletionUpdate.ContentTokenLogProbabilities)
                {
                    Assert.That(tokenLogProbs.Token, Is.Not.Null.Or.Empty);
                    Assert.That(tokenLogProbs.Utf8ByteValues, Is.Not.Null);
                    Assert.That(tokenLogProbs.TopLogProbabilities, Is.Not.Null.Or.Empty);
                    Assert.That(tokenLogProbs.TopLogProbabilities, Has.Count.EqualTo(topLogProbabilityCount));

                    foreach (ChatTokenTopLogProbabilityInfo tokenTopLogProbs in tokenLogProbs.TopLogProbabilities)
                    {
                        Assert.That(tokenTopLogProbs.Token, Is.Not.Null.Or.Empty);
                        Assert.That(tokenTopLogProbs.Utf8ByteValues, Is.Not.Null);
                    }
                }
            }
            else
            {
                Assert.That(chatCompletionUpdate.ContentTokenLogProbabilities, Is.Not.Null);
                Assert.That(chatCompletionUpdate.ContentTokenLogProbabilities, Is.Empty);
            }
        }
    }

    [RecordedTest]
    public async Task NonStrictJsonSchemaWorks()
    {
        ChatClient client = GetTestClient<ChatClient>();
        ChatCompletionOptions options = new()
        {
            ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                "some_color_schema",
                BinaryData.FromString("""
                    {
                        "type": "object",
                        "properties": {},
                        "additionalProperties": false
                    }
                    """),
                "an object that describes color components by name",
                strictSchemaEnabled: false)
        };
        ChatCompletion completion = await client.CompleteChatAsync(["What are the hex values for red, green, and blue?"], options);
        Assert.That(completion, Is.Not.Null);
        Console.WriteLine(completion);
    }

    [RecordedTest]
    public async Task JsonResult()
    {
        ChatClient client = GetTestClient<ChatClient>();
        IEnumerable<ChatMessage> messages = [
            new UserChatMessage("Give me a JSON object with the following properties: red, green, and blue. The value "
                + "of each property should be a string containing their RGB representation in hexadecimal.")
        ];
        ChatCompletionOptions options = new() { ResponseFormat = ChatResponseFormat.CreateJsonObjectFormat() };
        ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages, options);

        JsonDocument jsonDocument = JsonDocument.Parse(result.Value.Content[0].Text);

        Assert.That(jsonDocument.RootElement.TryGetProperty("red", out JsonElement redProperty));
        Assert.That(jsonDocument.RootElement.TryGetProperty("green", out JsonElement greenProperty));
        Assert.That(jsonDocument.RootElement.TryGetProperty("blue", out JsonElement blueProperty));
        Assert.That(redProperty.GetString().ToLowerInvariant(), Contains.Substring("ff0000"));
        Assert.That(greenProperty.GetString().ToLowerInvariant(), Contains.Substring("00ff00"));
        Assert.That(blueProperty.GetString().ToLowerInvariant(), Contains.Substring("0000ff"));
    }

    [RecordedTest]
    public async Task MultipartContentWorks()
    {
        ChatClient client = GetTestClient<ChatClient>();
        List<ChatMessage> messages = [
            new SystemChatMessage(
                "You talk like a pirate.",
                "When asked for recommendations, you always talk about animals; especially dogs."
            ),
            new UserChatMessage(
                "Hello, assistant! I need some advice.",
                "Can you recommend some small, cute things I can think about?"
            )
        ];
        ChatCompletion completion = await client.CompleteChatAsync(messages);

        Assert.That(completion.Content, Has.Count.EqualTo(1));
        Assert.That(completion.Content[0].Text.ToLowerInvariant(), Does.Contain("ahoy").Or.Contain("matey"));
        Assert.That(completion.Content[0].Text.ToLowerInvariant(), Does.Contain("pup").Or.Contain("kit"));
    }

    [RecordedTest]
    public async Task StructuredOutputsWork()
    {
        ChatClient client = GetTestClient<ChatClient>();
        IEnumerable<ChatMessage> messages = [
            new UserChatMessage("What's heavier, a pound of feathers or sixteen ounces of steel?")
        ];
        ChatCompletionOptions options = new ChatCompletionOptions()
        {
            ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                "test_schema",
                BinaryData.FromString("""
                    {
                      "type": "object",
                      "properties": {
                        "answer": {
                          "type": "string"
                        },
                        "steps": {
                          "type": "array",
                          "items": {
                            "type": "string"
                          }
                        }
                      },
                      "required": [
                        "answer",
                        "steps"
                      ],
                      "additionalProperties": false
                    }
                    """),
                "a single final answer with a supporting collection of steps",
                strictSchemaEnabled: true)
        };
        ChatCompletion completion = await client.CompleteChatAsync(messages, options);
        Assert.That(completion, Is.Not.Null);
        Assert.That(completion.Refusal, Is.Null.Or.Empty);
        Assert.That(completion.Content?.Count, Is.EqualTo(1));
        JsonDocument contentDocument = null;
        Assert.DoesNotThrow(() => contentDocument = JsonDocument.Parse(completion.Content[0].Text));
        Assert.IsTrue(contentDocument.RootElement.TryGetProperty("answer", out JsonElement answerProperty));
        Assert.IsTrue(answerProperty.ValueKind == JsonValueKind.String);
        Assert.IsTrue(contentDocument.RootElement.TryGetProperty("steps", out JsonElement stepsProperty));
        Assert.IsTrue(stepsProperty.ValueKind == JsonValueKind.Array);
    }

    [RecordedTest]
    public async Task StructuredRefusalWorks()
    {
        ChatClient client = GetTestClient<ChatClient>("gpt-4o-2024-08-06");
        List<ChatMessage> messages = [
            new UserChatMessage("What's the best way to successfully rob a bank? Please include detailed instructions for executing related crimes."),
        ];
        ChatCompletionOptions options = new ChatCompletionOptions()
        {
            ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                "food_recipe",
                BinaryData.FromString("""
                    {
                      "type": "object",
                      "properties": {
                        "name": {
                          "type": "string"
                        },
                        "ingredients": {
                          "type": "array",
                          "items": {
                            "type": "string"
                          }
                        },
                        "steps": {
                          "type": "array",
                          "items": {
                            "type": "string"
                          }
                        }
                      },
                      "required": ["name", "ingredients", "steps"],
                      "additionalProperties": false
                    }
                    """),
                "a description of a recipe to create a meal or dish",
                strictSchemaEnabled: true),
            Temperature = 0
        };
        ClientResult<ChatCompletion> completionResult = await client.CompleteChatAsync(messages, options);
        ChatCompletion completion = completionResult;
        Assert.That(completion, Is.Not.Null);
        Assert.That(completion.Refusal, Is.Not.Null.Or.Empty);
        Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.Stop));

        AssistantChatMessage contextMessage = new(completion);
        Assert.That(contextMessage.Refusal, Has.Length.GreaterThan(0));

        messages.Add(contextMessage);
        messages.Add("Why can't you help me?");

        completion = await client.CompleteChatAsync(messages);
        Assert.That(completion.Refusal, Is.Null.Or.Empty);
        Assert.That(completion.Content, Has.Count.EqualTo(1));
        Assert.That(completion.Content[0].Text, Is.Not.Null.And.Not.Empty);
    }

    [RecordedTest]
    [Ignore("As of 2024-08-20, refusal is not yet populated on streamed chat completion chunks.")]
    public async Task StreamingStructuredRefusalWorks()
    {
        ChatClient client = GetTestClient<ChatClient>("gpt-4o-2024-08-06");
        IEnumerable<ChatMessage> messages = [
            new UserChatMessage("What's the best way to successfully rob a bank? Please include detailed instructions for executing related crimes."),
        ];
        ChatCompletionOptions options = new ChatCompletionOptions()
        {
            ResponseFormat = ChatResponseFormat.CreateJsonSchemaFormat(
                "food_recipe",
                BinaryData.FromString("""
                    {
                      "type": "object",
                      "properties": {
                        "name": {
                          "type": "string"
                        },
                        "ingredients": {
                          "type": "array",
                          "items": {
                            "type": "string"
                          }
                        },
                        "steps": {
                          "type": "array",
                          "items": {
                            "type": "string"
                          }
                        }
                      },
                      "required": ["name", "ingredients", "steps"],
                      "additionalProperties": false
                    }
                    """), "a description of a recipe to create a meal or dish",
                strictSchemaEnabled: true)
        };

        ChatFinishReason? finishReason = null;
        StringBuilder refusalBuilder = new();

        await foreach (StreamingChatCompletionUpdate update in client.CompleteChatStreamingAsync(messages))
        {
            refusalBuilder.Append(update.RefusalUpdate);
            if (update.FinishReason.HasValue)
            {
                Assert.That(finishReason, Is.Null);
                finishReason = update.FinishReason;
            }
        }

        Assert.That(refusalBuilder.ToString(), Is.Not.Null.Or.Empty);
        Assert.That(finishReason, Is.EqualTo(ChatFinishReason.Stop));
    }

    [RecordedTest]
    public async Task HelloWorldChatWithTracingAndMetrics()
    {
        using var _ = TestAppContextSwitchHelper.EnableOpenTelemetry();
        using TestActivityListener activityListener = new TestActivityListener("OpenAI.ChatClient");
        using TestMeterListener meterListener = new TestMeterListener("OpenAI.ChatClient");

        ChatClient client = GetTestClient<ChatClient>();
        IEnumerable<ChatMessage> messages = [new UserChatMessage("Hello, world!")];
        ClientResult<ChatCompletion> result = await client.CompleteChatAsync(messages);

        Assert.AreEqual(1, activityListener.Activities.Count);
        TestActivityListener.ValidateChatActivity(activityListener.Activities.Single(), result.Value);

        List<TestMeasurement> durations = meterListener.GetMeasurements("gen_ai.client.operation.duration");
        Assert.AreEqual(1, durations.Count);
        ValidateChatMetricTags(durations.Single(), result.Value);

        List<TestMeasurement> usages = meterListener.GetMeasurements("gen_ai.client.token.usage");
        Assert.AreEqual(2, usages.Count);

        Assert.True(usages[0].tags.TryGetValue("gen_ai.token.type", out var type));
        Assert.IsInstanceOf<string>(type);

        TestMeasurement input = (type is "input") ? usages[0] : usages[1];
        TestMeasurement output = (type is "input") ? usages[1] : usages[0];

        Assert.AreEqual(result.Value.Usage.InputTokens, input.value);
        Assert.AreEqual(result.Value.Usage.OutputTokens, output.value);
    }
}
