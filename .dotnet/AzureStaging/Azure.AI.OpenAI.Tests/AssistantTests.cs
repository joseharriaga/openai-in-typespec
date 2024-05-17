// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Identity;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Tests;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;

namespace Azure.AI.OpenAI.Tests;

#pragma warning disable OPENAI001

public class AssistantTests
{
    [Test]
    public void CanCreateClient()
    {
        AzureOpenAIClient client = new();
        AssistantClient assistantClient = client.GetAssistantClient();
        Assert.That(assistantClient, Is.Not.Null);
    }

    [Test]
    public void BasicAssistantOperationsWork()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = client.CreateAssistant("gpt-35-turbo-latest");
        Validate(assistant);
        Assert.That(assistant.Name, Is.Null.Or.Empty);
        assistant = client.ModifyAssistant(assistant.Id, new AssistantModificationOptions()
        {
            Name = "test assistant name",
        });
        Assert.That(assistant.Name, Is.EqualTo("test assistant name"));
        bool deleted = client.DeleteAssistant(assistant.Id);
        Assert.That(deleted, Is.True);
        _assistantsToDelete.Remove(assistant);
        assistant = client.CreateAssistant("gpt-35-turbo-latest", new AssistantCreationOptions()
        {
            Metadata =
            {
                ["testkey"] = "hello!"
            },
        });
        Validate(assistant);
        Assistant retrievedAssistant = client.GetAssistant(assistant.Id);
        Assert.That(retrievedAssistant.Id, Is.EqualTo(assistant.Id));
        Assert.That(retrievedAssistant.Metadata.TryGetValue("testkey", out string metadataValue) && metadataValue == "hello!");
        Assistant modifiedAssistant = client.ModifyAssistant(assistant.Id, new AssistantModificationOptions()
        {
            Metadata =
            {
                ["testkey"] = "goodbye!",
            },
        });
        Assert.That(modifiedAssistant.Id, Is.EqualTo(assistant.Id));
        ListQueryPage<Assistant> recentAssistants = client.GetAssistants();
        Assistant listedAssistant = recentAssistants.FirstOrDefault(pageItem => pageItem.Id == assistant.Id);
        Assert.That(listedAssistant, Is.Not.Null);
        Assert.That(listedAssistant.Metadata.TryGetValue("testkey", out string newMetadataValue) && newMetadataValue == "goodbye!");
    }

    [Test]
    public void BasicThreadOperationsWork()
    {
        AssistantClient client = GetTestClient();
        AssistantThread thread = client.CreateThread();
        Validate(thread);
        Assert.That(thread.CreatedAt, Is.GreaterThan(s_2024));
        bool deleted = client.DeleteThread(thread.Id);
        Assert.That(deleted, Is.True);
        _threadsToDelete.Remove(thread);

        ThreadCreationOptions options = new()
        {
            Metadata =
            {
                ["threadMetadata"] = "threadMetadataValue",
            }
        };
        thread = client.CreateThread(options);
        Validate(thread);
        Assert.That(thread.Metadata.TryGetValue("threadMetadata", out string threadMetadataValue) && threadMetadataValue == "threadMetadataValue");
        AssistantThread retrievedThread = client.GetThread(thread.Id);
        Assert.That(retrievedThread.Id, Is.EqualTo(thread.Id));
        thread = client.ModifyThread(thread, new ThreadModificationOptions()
        {
            Metadata =
            {
                ["threadMetadata"] = "newThreadMetadataValue",
            },
        });
        Assert.That(thread.Metadata.TryGetValue("threadMetadata", out threadMetadataValue) && threadMetadataValue == "newThreadMetadataValue");
    }

    [Test]
    public void BasicMessageOperationsWork()
    {
        AssistantClient client = GetTestClient();
        AssistantThread thread = client.CreateThread();
        Validate(thread);
        ThreadMessage message = client.CreateMessage(thread, ["Hello, world!"]);
        Validate(message);
        Assert.That(message.CreatedAt, Is.GreaterThan(s_2024));
        Assert.That(message.Content?.Count, Is.EqualTo(1));
        Assert.That(message.Content[0], Is.Not.Null);
        Assert.That(message.Content[0].Text, Is.EqualTo("Hello, world!"));
        // BUG: Can't currently delete messages
        // bool deleted = client.DeleteMessage(message);
        // Assert.That(deleted, Is.True);
        // _messagesToDelete.Remove(message);

        message = client.CreateMessage(thread, ["Goodbye, world!"], new MessageCreationOptions()
        {
            Metadata =
            {
                ["messageMetadata"] = "messageMetadataValue",
            },
        });
        Validate(message);
        Assert.That(message.Metadata.TryGetValue("messageMetadata", out string metadataValue) && metadataValue == "messageMetadataValue");

        ThreadMessage retrievedMessage = client.GetMessage(thread.Id, message.Id);
        Assert.That(retrievedMessage.Id, Is.EqualTo(message.Id));

        message = client.ModifyMessage(message, new MessageModificationOptions()
        {
            Metadata =
            {
                ["messageMetadata"] = "newValue",
            }
        });
        Assert.That(message.Metadata.TryGetValue("messageMetadata", out metadataValue) && metadataValue == "newValue");

        ListQueryPage<ThreadMessage> messagePage = client.GetMessages(thread);
        Assert.That(messagePage.Count, Is.EqualTo(2));
        // BUG: Can't currently delete messages
        // Assert.That(messagePage.Count, Is.EqualTo(1));
        Assert.That(messagePage[0].Id, Is.EqualTo(message.Id));
        Assert.That(messagePage[0].Metadata.TryGetValue("messageMetadata", out metadataValue) && metadataValue == "newValue");
    }

    [Test]
    public void ThreadWithInitialMessagesWorks()
    {
        AssistantClient client = GetTestClient();
        ThreadCreationOptions options = new()
        {
            InitialMessages =
            {
                new(["Hello, world!"]),
                new(
                [
                    "Can you describe this image for me?",
                    MessageContent.FromImageUrl(new Uri("https://test.openai.com/image.png"))
                ])
                {
                    Metadata =
                    {
                        ["messageMetadata"] = "messageMetadataValue",
                    },
                },
            },
        };
        AssistantThread thread = client.CreateThread(options);
        Validate(thread);
        ListQueryPage<ThreadMessage> messagePage = client.GetMessages(thread, resultOrder: ListOrder.OldestFirst);
        Assert.That(messagePage.Count, Is.EqualTo(2));
        Assert.That(messagePage[0].Role, Is.EqualTo(MessageRole.User));
        Assert.That(messagePage[0].Content?.Count, Is.EqualTo(1));
        Assert.That(messagePage[0].Content[0].Text, Is.EqualTo("Hello, world!"));
        Assert.That(messagePage[1].Content?.Count, Is.EqualTo(2));
        Assert.That(messagePage[1].Content[0], Is.Not.Null);
        Assert.That(messagePage[1].Content[0].Text, Is.EqualTo("Can you describe this image for me?"));
        Assert.That(messagePage[1].Content[1], Is.Not.Null);
        Assert.That(messagePage[1].Content[1].ImageUrl.AbsoluteUri, Is.EqualTo("https://test.openai.com/image.png"));
    }

    [Test]
    public void BasicRunOperationsWork()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = client.CreateAssistant("gpt-35-turbo-latest");
        Validate(assistant);
        AssistantThread thread = client.CreateThread();
        Validate(thread);
        ListQueryPage<ThreadRun> runPage = client.GetRuns(thread.Id);
        Assert.That(runPage.Count, Is.EqualTo(0));
        ThreadMessage message = client.CreateMessage(thread.Id, ["Hello, assistant!"]);
        Validate(message);
        Thread.Sleep(3000);
        ThreadRun run = client.CreateRun(thread.Id, assistant.Id);
        Validate(run);
        Assert.That(run.Status, Is.EqualTo(RunStatus.Queued));
        Assert.That(run.CreatedAt, Is.GreaterThan(s_2024));
        ThreadRun retrievedRun = client.GetRun(thread.Id, run.Id);
        Assert.That(retrievedRun.Id, Is.EqualTo(run.Id));
        runPage = client.GetRuns(thread.Id);
        Assert.That(runPage.Count, Is.EqualTo(1));
        Assert.That(runPage[0].Id, Is.EqualTo(run.Id));

        ListQueryPage<ThreadMessage> messages = client.GetMessages(thread);
        Assert.That(messages.Count, Is.EqualTo(1));

        for (int i = 0; i < 10 && !run.Status.IsTerminal; i++)
        {
            Thread.Sleep(500);
            run = client.GetRun(run);
        }
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));
        Assert.That(run.CompletedAt, Is.GreaterThan(s_2024));
        Assert.That(run.RequiredActions.Count, Is.EqualTo(0));
        Assert.That(run.AssistantId, Is.EqualTo(assistant.Id));
        Assert.That(run.FailedAt, Is.Null);
        Assert.That(run.IncompleteDetails, Is.Null);

        messages = client.GetMessages(thread);
        Assert.That(messages.Count, Is.EqualTo(2));

        Assert.That(messages[0].Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(messages[1].Role, Is.EqualTo(MessageRole.User));
        Assert.That(messages[1].Id, Is.EqualTo(message.Id));
    }

    [Test]
    public void BasicRunStepFunctionalityWorks()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = client.CreateAssistant("gpt-35-turbo-latest", new AssistantCreationOptions()
        {
            Tools = { new CodeInterpreterToolDefinition() },
            Instructions = "Call the code interpreter tool when asked to visualize mathematical concepts.",
        });
        Validate(assistant);

        AssistantThread thread = client.CreateThread(new()
        {
            InitialMessages = { new(["Please graph the equation y = 3x + 4"]), },
        });
        Validate(thread);

        ThreadRun run = client.CreateRun(thread, assistant);
        Validate(run);

        while (!run.Status.IsTerminal)
        {
            Thread.Sleep(1000);
            run = client.GetRun(run);
        }
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));
        Assert.That(run.Usage?.TotalTokens, Is.GreaterThan(0));

        ListQueryPage<RunStep> runSteps = client.GetRunSteps(run, maxResults: 100);
        Assert.That(runSteps, Has.Count.GreaterThan(1));
        Assert.Multiple(() =>
        {
            Assert.That(runSteps[0].AssistantId, Is.EqualTo(assistant.Id));
            Assert.That(runSteps[0].ThreadId, Is.EqualTo(thread.Id));
            Assert.That(runSteps[0].RunId, Is.EqualTo(run.Id));
            Assert.That(runSteps[0].CreatedAt, Is.GreaterThan(s_2024));
            Assert.That(runSteps[0].CompletedAt, Is.GreaterThan(s_2024));
        });
        RunStepDetails details = runSteps[0].Details;
        Assert.That(details?.CreatedMessageId, Is.Not.Null.Or.Empty);

        details = runSteps[1].Details;
        Assert.Multiple(() =>
        {
            Assert.That(details?.ToolCalls.Count, Is.GreaterThan(0));
            Assert.That(details.ToolCalls[0].ToolKind, Is.EqualTo(RunStepToolCallKind.CodeInterpreter));
            Assert.That(details.ToolCalls[0].ToolCallId, Is.Not.Null.Or.Empty);
            Assert.That(details.ToolCalls[0].CodeInterpreterInput, Is.Not.Null.Or.Empty);
            Assert.That(details.ToolCalls[0].CodeInterpreterOutputs?.Count, Is.GreaterThan(0));
            Assert.That(details.ToolCalls[0].CodeInterpreterOutputs[0].ImageFileId, Is.Not.Null.Or.Empty);
        });
    }

    [Test]
    public void FunctionToolsWork()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = client.CreateAssistant("gpt-35-turbo-latest", new AssistantCreationOptions()
        {
            Tools =
            {
                new FunctionToolDefinition()
                {
                    FunctionName = "get_favorite_food_for_day_of_week",
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
        });
        Validate(assistant);
        Assert.That(assistant.Tools?.Count, Is.EqualTo(1));

        FunctionToolDefinition responseToolDefinition = assistant.Tools[0] as FunctionToolDefinition;
        Assert.That(responseToolDefinition?.FunctionName, Is.EqualTo("get_favorite_food_for_day_of_week"));
        Assert.That(responseToolDefinition?.Parameters, Is.Not.Null);

        ThreadRun run = client.CreateThreadAndRun(
            assistant,
            new ThreadCreationOptions()
            {
                InitialMessages = { new(["What should I eat on Thursday?"]) },
            },
            new RunCreationOptions()
            {
                AdditionalInstructions = "Call provided tools when appropriate.",
            });
        Validate(run);
        Console.WriteLine($" Run status right after creation: {run.Status}");
        for (int i = 0; i < 10 && !run.Status.IsTerminal; i++)
        {
            Thread.Sleep(500);
            run = client.GetRun(run);
        }
        Assert.That(run.Status, Is.EqualTo(RunStatus.RequiresAction));
        Assert.That(run.RequiredActions?.Count, Is.EqualTo(1));
        Assert.That(run.RequiredActions[0].ToolCallId, Is.Not.Null.Or.Empty);
        Assert.That(run.RequiredActions[0].FunctionName, Is.EqualTo("get_favorite_food_for_day_of_week"));
        Assert.That(run.RequiredActions[0].FunctionArguments, Is.Not.Null.Or.Empty);

        run = client.SubmitToolOutputsToRun(run, [new(run.RequiredActions[0].ToolCallId, "tacos")]);
        Assert.That(run.Status.IsTerminal, Is.False);

        for (int i = 0; i < 10 && !run.Status.IsTerminal; i++)
        {
            Thread.Sleep(500);
            run = client.GetRun(run);
        }
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));

        ListQueryPage<ThreadMessage> messages = client.GetMessages(run.ThreadId, resultOrder: ListOrder.NewestFirst);
        Assert.That(messages.Count, Is.GreaterThan(1));
        Assert.That(messages[0].Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(messages[0].Content?[0], Is.Not.Null);
        Assert.That(messages[0].Content[0].Text, Does.Contain("tacos"));
    }

    [Test]
    public async Task StreamingRunWorks()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = await client.CreateAssistantAsync("gpt-35-turbo-latest");
        Validate(assistant);

        AssistantThread thread = await client.CreateThreadAsync(new()
        {
            InitialMessages = { new(["Hello there, assistant! How are you today?"]), },
        });
        Validate(thread);

        Stopwatch stopwatch = Stopwatch.StartNew();
        void Print(string message) => Console.WriteLine($"[{stopwatch.ElapsedMilliseconds,6}] {message}");

        ClientResult<IAsyncEnumerable<StreamingUpdate>> streamingResult
            = await client.CreateRunStreamingAsync(thread.Id, assistant.Id);

        Print(">>> Connected <<<");

        await foreach (StreamingUpdate update in streamingResult.Value)
        {
            string message = $"{update.UpdateKind} ";
            if (update is RunUpdate runUpdate)
            {
                DateTimeOffset? time = update.UpdateKind switch
                {
                    StreamingUpdateReason.RunCreated => runUpdate.Value.CreatedAt,
                    StreamingUpdateReason.RunQueued => runUpdate.Value.StartedAt,
                    StreamingUpdateReason.RunInProgress => runUpdate.Value.StartedAt,
                    StreamingUpdateReason.RunCompleted => runUpdate.Value.CompletedAt,
                    _ => null,
                };
                message += $"at {time}";
            }
            if (update is MessageContentUpdate contentUpdate)
            {
                if (contentUpdate.Role.HasValue)
                {
                    message += $"[{contentUpdate.Role}]";
                }
                message += $"[{contentUpdate.MessageIndex}] {contentUpdate.Text}";
            }
            Print(message);
        }
        Print(">>> Done <<<");
    }

    [TearDown]
    protected void Cleanup()
    {
        AssistantClient client = new();
        RequestOptions requestOptions = new()
        {
            ErrorOptions = ClientErrorBehaviors.NoThrow,
        };
        foreach (ThreadMessage message in _messagesToDelete)
        {
            Console.WriteLine($"Cleanup: {message.Id} -> {client.DeleteMessage(message.ThreadId, message.Id, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (Assistant assistant in _assistantsToDelete)
        {
            Console.WriteLine($"Cleanup: {assistant.Id} -> {client.DeleteAssistant(assistant.Id, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (AssistantThread thread in _threadsToDelete)
        {
            Console.WriteLine($"Cleanup: {thread.Id} -> {client.DeleteThread(thread.Id, requestOptions)?.GetRawResponse().Status}");
        }
        _messagesToDelete.Clear();
        _assistantsToDelete.Clear();
        _threadsToDelete.Clear();
    }

    /// <summary>
    /// Performs basic, invariant validation of a target that was just instantiated from its corresponding origination
    /// mechanism. If applicable, the instance is recorded into the test run for cleanup of persistent resources.
    /// </summary>
    /// <typeparam name="T"> Instance type being validated. </typeparam>
    /// <param name="target"> The instance to validate. </param>
    /// <exception cref="NotImplementedException"> The provided instance type isn't supported. </exception>
    private void Validate<T>(T target)
    {
        if (target is Assistant assistant)
        {
            Assert.That(assistant?.Id, Is.Not.Null);
            _assistantsToDelete.Add(assistant);
        }
        else if (target is AssistantThread thread)
        {
            Assert.That(thread?.Id, Is.Not.Null);
            _threadsToDelete.Add(thread);
        }
        else if (target is ThreadMessage message)
        {
            Assert.That(message?.Id, Is.Not.Null);
            _messagesToDelete.Add(message);
        }
        else if (target is ThreadRun run)
        {
            Assert.That(run?.Id, Is.Not.Null);
        }
        else
        {
            throw new NotImplementedException($"{nameof(Validate)} helper not implemented for: {typeof(T)}");
        }
    }

    private readonly List<Assistant> _assistantsToDelete = [];
    private readonly List<AssistantThread> _threadsToDelete = [];
    private readonly List<ThreadMessage> _messagesToDelete = [];

    private static AssistantClient GetTestClient()
    {
        AzureOpenAIClientOptions options = new();
        options.AddPolicy(new TestPipelinePolicy((m) =>
        {
            Console.WriteLine($"--- New request ---");
            IEnumerable<string> headerPairs = m?.Request?.Headers?.Select(header => $"{header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
            string headers = string.Join(',', headerPairs);
            Console.WriteLine($"Headers: {headers}");
            Console.WriteLine($"{m?.Request?.Method} URI: {m?.Request?.Uri}");
            if (m.Request?.Content != null)
            {
                using MemoryStream stream = new();
                m.Request.Content.WriteTo(stream, default);
                stream.Position = 0;
                using StreamReader reader = new(stream);
                Console.WriteLine(reader.ReadToEnd());
            }
        }), PipelinePosition.PerCall);
        AzureOpenAIClient azureClient = new(
            new Uri(Environment.GetEnvironmentVariable("AZURE_OPENAI_TIP_ENDPOINT")),
            new ApiKeyCredential(Environment.GetEnvironmentVariable("AZURE_OPENAI_TIP_API_KEY")),
            options);
        return azureClient.GetAssistantClient();
    }

    private static readonly DateTimeOffset s_2024 = new(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
}