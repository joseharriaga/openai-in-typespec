using NUnit.Framework;
using OpenAI.Assistants;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Assistants;

#pragma warning disable OPENAI001
public partial class AssistantTests
{
    [Test]
    public void ListingAssistantsWorks()
    {
        AssistantClient client = new();
        ClientResult<ListQueryPage<Assistant>> result = client.GetAssistants();
        Assert.That(result.Value, Is.Not.Null.Or.Empty);
    }

    [Test]
    public void CreatingAndDeletingAssistantsWorks()
    {
        AssistantClient client = GetTestClient<AssistantClient>(TestScenario.Assistants);
        ClientResult<Assistant> result = client.CreateAssistant("gpt-3.5-turbo");
        Assert.That(result.Value, Is.Not.Null);
        Assert.That(result.Value.Id, Is.Not.Null.Or.Empty);
        ClientResult<bool> deletionResult = client.DeleteAssistant(result.Value.Id);
        Assert.That(deletionResult.Value, Is.True);
    }

    [Test]
    public async Task AddingMessagesWorks()
    {
        AssistantClient client = new();
        ClientResult<AssistantThread> threadResult = await client.CreateThreadAsync(new ThreadCreationOptions()
        {
            Messages =
            {
                new(MessageRole.User, "this is an initial message on the thread"),
                "this is another one done an easier way"
            },
            Metadata =
            {
                ["test_key"] = "test_value",
                [s_cleanupMetadataKey] = "true",
            }
        });
        ClientResult<ListQueryPage<ThreadMessage>> messagesResult = await client.GetMessagesAsync(threadResult.Value.Id);
        Assert.That(messagesResult.Value?.Count, Is.EqualTo(2));
        ThreadMessage latestMessage = messagesResult.Value[0];
        ThreadMessage oldestMessage = messagesResult.Value[1];
        Assert.That(latestMessage.Role, Is.EqualTo(MessageRole.User));
        Assert.That(latestMessage.ContentItems, Is.Not.Null.Or.Empty);
        MessageTextContent textContent = latestMessage.ContentItems[0] as MessageTextContent;
        Assert.That(textContent, Is.Not.Null);
        Assert.That(textContent.Text, Is.Not.Null.Or.Empty);
        Assert.That(textContent.Text, Contains.Substring("easier way"));
    }

    [Test]
    public async Task BasicFunctionToolWorks()
    {
        AssistantClient client = GetTestClient();
        ClientResult<Assistant> assistantResult = await client.CreateAssistantAsync(
            "gpt-3.5-turbo",
            new AssistantCreationOptions()
            {
                Tools =
                {
                    new FunctionToolDefinition()
                    {
                        Name = "get_favorite_food_for_day_of_week",
                        Description = "gets the user's favorite food for a given day of the week, like Tuesday",
                        Parameters = BinaryData.FromObjectAsJson(new
                        {
                            type = "object",
                            properties = new
                            {
                                day_of_week = new
                                {
                                    type = "string",
                                    description = "a day of the week, like Tuesday or Saturday",
                                }
                            }
                        }),
                    },
                },
                Metadata =
                {
                    [s_cleanupMetadataKey] = "true",
                }
            });
        Assert.That(assistantResult.Value.DefaultTools, Is.Not.Null.Or.Empty);
        FunctionToolDefinition functionTool = assistantResult.Value.DefaultTools[0] as FunctionToolDefinition;
        Assert.That(functionTool, Is.Not.Null);
        Assert.That(functionTool.Parameters, Is.Not.Null);

        ClientResult<AssistantThread> threadResult = await client.CreateThreadAsync(
            new ThreadCreationOptions()
            {
                Messages =
                {
                    "what should I eat on Thursday?",
                },
                Metadata =
                {
                    [s_cleanupMetadataKey ] = "true",
                }
            });
        ClientResult<ThreadRun> runResult = await client.CreateRunAsync(threadResult.Value.Id, assistantResult.Value.Id);
        Assert.That(runResult.Value.Id, Is.Not.Null.Or.Empty);
        do
        {
            await Task.Delay(500);
            runResult = await client.GetRunAsync(threadResult.Value.Id, runResult.Value.Id);
        } while (runResult.Value.Status == RunStatus.Queued || runResult.Value.Status == RunStatus.InProgress);
        Assert.That(runResult.Value.Status, Is.EqualTo(RunStatus.RequiresAction));
        Assert.That(runResult.Value.RequiredActions?.Count, Is.EqualTo(1));
        RequiredFunctionToolCall requiredFunctionToolCall = runResult.Value.RequiredActions[0] as RequiredFunctionToolCall;
        Assert.That(requiredFunctionToolCall, Is.Not.Null);
        _ = await client.SubmitToolOutputsAsync(threadResult.Value.Id, runResult.Value.Id,
            [
                new ToolOutput(requiredFunctionToolCall.Id, "tacos"),
            ]);
        runResult = await client.GetRunAsync(threadResult.Value.Id, runResult.Value.Id);
        Assert.That(runResult.Value.Status, Is.Not.EqualTo(RunStatus.RequiresAction));
    }

    [Test]
    public async Task SimpleStreamingRunWorks()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = await CreateCommonTestAssistantAsync();

        StreamingClientResult<StreamedEventCollection> runUpdateResult = client.CreateThreadAndRunStreaming(
            assistant.Id,
            new ThreadCreationOptions()
            {
                Messages =
                {
                    "Hello, assistant! Can you help me?",
                }
            });
        Assert.That(runUpdateResult, Is.Not.Null);
        await foreach (StreamedEventCollection runUpdate in runUpdateResult)
        {
            if (runUpdate is StreamingMessageCreation messageCreation)
            {
                Console.WriteLine($"Message created, id={messageCreation.Message.Id}");
            }
            if (runUpdate is StreamingMessageUpdate messageUpdate)
            {
                Console.Write(messageUpdate.ContentUpdate.GetText());
            }
            if (runUpdate is StreamingMessageCompletion messageCompletion)
            {
                Console.WriteLine();
                Console.WriteLine($"Message complete: {messageCompletion.Message.ContentItems[0].GetText()}");
            }
        }
    }

    [Test]
    public async Task StreamingWithToolsWorks()
    {
        AssistantClient client = GetTestClient();
        ClientResult<Assistant> assistantResult = await client.CreateAssistantAsync("gpt-3.5-turbo", new AssistantCreationOptions()
        {
            Instructions = "You are a helpful math assistant that helps with visualizing equations. Use the code interpreter tool when asked to generate images. Use provided functions to resolve appropriate unknown values",
            Tools =
            {
                new CodeInterpreterToolDefinition(),
                new FunctionToolDefinition("get_boilerplate_equation", "Retrieves a predefined 'boilerplate equation' from the caller."),
            },
            Metadata = { [s_cleanupMetadataKey] = "true" },
        });
        Assistant assistant = assistantResult.Value;
        Assert.That(assistant, Is.Not.Null);

        ClientResult<AssistantThread> threadResult = await client.CreateThreadAsync(new ThreadCreationOptions()
        {
            Messages =
            {
                "Please make a graph for my boilerplate equation",
            },
        });
        AssistantThread thread = threadResult.Value;
        Assert.That(thread, Is.Not.Null);

        StreamingClientResult<StreamedEventCollection> streamingResult = await client.CreateRunStreamingAsync(thread.Id, assistant.Id);
        Assert.That(streamingResult, Is.Not.Null);
        List<RunRequiredAction> requiredActions = [];
        ThreadRun initialStreamedRun = null;
        await foreach (StreamedEventCollection streamingUpdate in streamingResult)
        {
            if (streamingUpdate is StreamingRunCreation streamingRunCreation)
            {
                initialStreamedRun = streamingRunCreation.Run;
            }
            if (streamingUpdate is StreamingRequiredAction streamedRequiredAction)
            {
                requiredActions.Add(streamedRequiredAction.RequiredAction);
            }
            Console.WriteLine(streamingUpdate.GetRawSseEvent().ToString());
        }
        Assert.That(initialStreamedRun?.Id, Is.Not.Null.Or.Empty);
        Assert.That(requiredActions, Is.Not.Empty);

        List<ToolOutput> toolOutputs = [];
        foreach (RunRequiredAction requiredAction in requiredActions)
        {
            if (requiredAction is RequiredFunctionToolCall functionCall)
            {
                if (functionCall.Name == "get_boilerplate_equation")
                {
                    toolOutputs.Add(new(functionCall, "y = 14x - 3"));
                }
            }
        }
        streamingResult = await client.SubmitToolOutputsStreamingAsync(thread.Id, initialStreamedRun.Id, toolOutputs);
        await foreach (StreamedEventCollection streamingUpdate in streamingResult)
        {
            Console.WriteLine(streamingUpdate.GetRawSseEvent().ToString());
        }
    }

    private async Task<Assistant> CreateCommonTestAssistantAsync()
    {
        AssistantClient client = new();
        ClientResult<Assistant> newAssistantResult = await client.CreateAssistantAsync("gpt-3.5-turbo", new()
        {
            Name = s_testAssistantName,
            Metadata =
            {
                ["test_id"] = "test_id_goes_here",
                [s_cleanupMetadataKey] = "true",
            },
        });
        return newAssistantResult.Value;
    }

    [TearDown]
    protected async Task DeleteRecentTestThings()
    {
        AssistantClient client = GetTestClient();
        foreach(Assistant assistant in client.GetAssistants().Value)
        {
            if (assistant.Name == s_testAssistantName
                || assistant.Metadata?.ContainsKey(s_cleanupMetadataKey) == true)
            {
                _ = await client.DeleteAssistantAsync(assistant.Id);
            }
        }
    }

    private static AssistantClient GetTestClient() => GetTestClient<AssistantClient>(TestScenario.Assistants);

    private static readonly string s_testAssistantName = $".NET SDK Test Assistant - Please Delete Me";
    private static readonly string s_cleanupMetadataKey = $"test_metadata_cleanup_eligible";
}

#pragma warning restore OPENAI001
