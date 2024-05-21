// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.AI.OpenAI.Assistants;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Files;
using OpenAI.VectorStores;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;

namespace Azure.AI.OpenAI.Tests;

#pragma warning disable OPENAI001

public class AssistantTests : TestBase<AssistantClient>
{
    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<AssistantClient>());

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
        PageableCollection<Assistant> recentAssistants = client.GetAssistants();
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
    public void SettingResponseFormatWorks()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = client.CreateAssistant("gpt-35-turbo-latest", new()
        {
            ResponseFormat = AssistantResponseFormat.JsonObject,
        });
        Validate(assistant);
        Assert.That(assistant.ResponseFormat, Is.EqualTo(AssistantResponseFormat.JsonObject));
        assistant = client.ModifyAssistant(assistant, new()
        {
            ResponseFormat = AssistantResponseFormat.Text,
        });
        Assert.That(assistant.ResponseFormat, Is.EqualTo(AssistantResponseFormat.Text));
        AssistantThread thread = client.CreateThread();
        Validate(thread);
        ThreadMessage message = client.CreateMessage(thread, ["Write some JSON for me!"]);
        Validate(message);
        ThreadRun run = client.CreateRun(thread, assistant, new()
        {
            ResponseFormat = AssistantResponseFormat.JsonObject,
        });
        Validate(run);
        Assert.That(run.ResponseFormat, Is.EqualTo(AssistantResponseFormat.JsonObject));
    }

    [TestCase]
    public async Task StreamingToolCall()
    {
        AssistantClient client = GetTestClient();
        FunctionToolDefinition getWeatherTool = new("get_current_weather", "Gets the user's current weather");
        Assistant assistant = await client.CreateAssistantAsync("gpt-35-turbo-latest", new()
        {
            Tools = { getWeatherTool }
        });
        Validate(assistant);

        Stopwatch stopwatch = Stopwatch.StartNew();
        void Print(string message) => Console.WriteLine($"[{stopwatch.ElapsedMilliseconds,6}] {message}");

        Print(" >>> Beginning call ... ");
        AsyncResultCollection<StreamingUpdate> asyncResults = client.CreateThreadAndRunStreamingAsync(
            assistant,
            new()
            {
                InitialMessages = { new(["What should I wear outside right now?"]), },
            });
        Print(" >>> Starting enumeration ...");

        ThreadRun run = null;

        do
        {
            run = null;
            List<ToolOutput> toolOutputs = [];
            await foreach (StreamingUpdate update in asyncResults)
            {
                string message = update.UpdateKind.ToString();

                if (update is RunUpdate runUpdate)
                {
                    message += $" run_id:{runUpdate.Value.Id}";
                    run = runUpdate.Value;
                }
                if (update is RequiredActionUpdate requiredActionUpdate)
                {
                    Assert.That(requiredActionUpdate.FunctionName, Is.EqualTo(getWeatherTool.FunctionName));
                    Assert.That(requiredActionUpdate.GetThreadRun().Status, Is.EqualTo(RunStatus.RequiresAction));
                    message += $" {requiredActionUpdate.FunctionName}";
                    toolOutputs.Add(new(requiredActionUpdate.ToolCallId, "warm and sunny"));
                }
                if (update is MessageContentUpdate contentUpdate)
                {
                    message += $" {contentUpdate.Text}";
                }
                Print(message);
            }
            if (toolOutputs.Count > 0)
            {
                asyncResults = client.SubmitToolOutputsToRunStreamingAsync(run, toolOutputs);
            }
        } while (run?.Status.IsTerminal == false);
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

        // BUG: Can't currently delete messages on AOAI
        bool deleted = client.DeleteMessage(message);
        Assert.That(deleted, Is.True);

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

        PageableCollection<ThreadMessage> messagePage = client.GetMessages(thread);
        Assert.That(messagePage.Count, Is.EqualTo(2));
        // BUG: Can't currently delete messages
        Assert.That(messagePage.Count, Is.EqualTo(1));
        Assert.That(messagePage.ElementAt(0).Id, Is.EqualTo(message.Id));
        Assert.That(messagePage.ElementAt(0).Metadata.TryGetValue("messageMetadata", out metadataValue) && metadataValue == "newValue");
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
        PageableCollection<ThreadMessage> messagePage = client.GetMessages(thread, resultOrder: ListOrder.OldestFirst);
        List<ThreadMessage> messageList = messagePage.ToList();
        Assert.That(messageList.Count, Is.EqualTo(2));
        Assert.That(messageList[0].Role, Is.EqualTo(MessageRole.User));
        Assert.That(messageList[0].Content?.Count, Is.EqualTo(1));
        Assert.That(messageList[0].Content[0].Text, Is.EqualTo("Hello, world!"));
        Assert.That(messageList[1].Content?.Count, Is.EqualTo(2));
        Assert.That(messageList[1].Content[0], Is.Not.Null);
        Assert.That(messageList[1].Content[0].Text, Is.EqualTo("Can you describe this image for me?"));
        Assert.That(messageList[1].Content[1], Is.Not.Null);
        Assert.That(messageList[1].Content[1].ImageUrl.AbsoluteUri, Is.EqualTo("https://test.openai.com/image.png"));
    }

    [Test]
    public void BasicRunOperationsWork()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = client.CreateAssistant("gpt-35-turbo-latest");
        Validate(assistant);
        AssistantThread thread = client.CreateThread();
        Validate(thread);
        PageableCollection<ThreadRun> runPage = client.GetRuns(thread.Id);
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
        Assert.That(runPage.ElementAt(0).Id, Is.EqualTo(run.Id));

        PageableCollection<ThreadMessage> messages = client.GetMessages(thread);
        Assert.That(messages.Count, Is.EqualTo(1));

        for (int i = 0; i < 10 && !run.Status.IsTerminal; i++)
        {
            Thread.Sleep(500);
            run = client.GetRun(run);
        }
        Assert.Multiple(() =>
        {
            Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));
            Assert.That(run.CompletedAt, Is.GreaterThan(s_2024));
            Assert.That(run.RequiredActions, Is.Empty);
            Assert.That(run.AssistantId, Is.EqualTo(assistant.Id));
            Assert.That(run.FailedAt, Is.Null);
            Assert.That(run.IncompleteDetails, Is.Null);
        });
        messages = client.GetMessages(thread);
        Assert.That(messages.Count, Is.EqualTo(2));

        Assert.That(messages.ElementAt(0).Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(messages.ElementAt(1).Role, Is.EqualTo(MessageRole.User));
        Assert.That(messages.ElementAt(1).Id, Is.EqualTo(message.Id));
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

        PageableCollection<RunStep> runSteps = client.GetRunSteps(run);
        Assert.That(runSteps.Count(), Is.GreaterThan(1));
        Assert.Multiple(() =>
        {
            Assert.That(runSteps.ElementAt(0).AssistantId, Is.EqualTo(assistant.Id));
            Assert.That(runSteps.ElementAt(0).ThreadId, Is.EqualTo(thread.Id));
            Assert.That(runSteps.ElementAt(0).RunId, Is.EqualTo(run.Id));
            Assert.That(runSteps.ElementAt(0).CreatedAt, Is.GreaterThan(s_2024));
            Assert.That(runSteps.ElementAt(0).CompletedAt, Is.GreaterThan(s_2024));
        });
        RunStepDetails details = runSteps.ElementAt(0).Details;
        Assert.That(details?.CreatedMessageId, Is.Not.Null.Or.Empty);

        details = runSteps.ElementAt(1).Details;
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

        PageableCollection<ThreadMessage> messages = client.GetMessages(run.ThreadId, resultOrder: ListOrder.NewestFirst);
        Assert.That(messages.Count, Is.GreaterThan(1));
        Assert.That(messages.ElementAt(0).Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(messages.ElementAt(0).Content?[0], Is.Not.Null);
        Assert.That(messages.ElementAt(0).Content?[0].Text, Does.Contain("tacos"));
    }

    [Test]
    public void BasicFileSearchWorks()
    {
        // First, we need to upload a simple test file.
        AssistantClient client = GetTestClient();
        FileClient fileClient = GetChildTestClient<FileClient>(client);

        OpenAIFileInfo testFile = fileClient.UploadFile(
            BinaryData.FromString("""
            This file describes the favorite foods of several people.

            Summanus Ferdinand: tacos
            Tekakwitha Effie: pizza
            Filip Carola: cake
            """).ToStream(),
            "favorite_foods.txt",
            FileUploadPurpose.Assistants);
        Validate(testFile);

        // Create an assistant, using the creation helper to make a new vector store
        Assistant assistant = client.CreateAssistant("gpt-35-turbo-latest", new()
        {
            Tools = { new FileSearchToolDefinition() },
            ToolResources = new()
            {
                FileSearch = new()
                {
                    NewVectorStores =
                    {
                        new VectorStoreCreationHelper([testFile.Id]),
                    }
                }
            }
        });
        Validate(assistant);
        Assert.That(assistant.ToolResources?.FileSearch?.VectorStoreIds, Has.Count.EqualTo(1));
        string createdVectorStoreId = assistant.ToolResources.FileSearch.VectorStoreIds[0];
        ValidateById<VectorStore>(createdVectorStoreId);

        // Modify an assistant to use the existing vector store
        assistant = client.ModifyAssistant(assistant, new AssistantModificationOptions()
        {
            ToolResources = new()
            {
                FileSearch = new()
                {
                    VectorStoreIds = { assistant.ToolResources.FileSearch.VectorStoreIds[0] },
                },
            },
        });
        Assert.That(assistant.ToolResources?.FileSearch?.VectorStoreIds, Has.Count.EqualTo(1));
        Assert.That(assistant.ToolResources.FileSearch.VectorStoreIds[0], Is.EqualTo(createdVectorStoreId));

        // Create a thread with an override vector store
        AssistantThread thread = client.CreateThread(new ThreadCreationOptions()
        {
            InitialMessages = { new(["Using the files you have available, what's Filip's favorite food?"]) },
            ToolResources = new()
            {
                FileSearch = new()
                {
                    NewVectorStores =
                    {
                        new VectorStoreCreationHelper([testFile.Id])
                    }
                }
            }
        });
        Validate(thread);
        Assert.That(thread.ToolResources?.FileSearch?.VectorStoreIds, Has.Count.EqualTo(1));
        createdVectorStoreId = thread.ToolResources.FileSearch.VectorStoreIds[0];
        ValidateById<VectorStore>(createdVectorStoreId);

        // Ensure that modifying the thread with an existing vector store works
        thread = client.ModifyThread(thread, new ThreadModificationOptions()
        {
            ToolResources = new()
            {
                FileSearch = new()
                {
                    VectorStoreIds = { createdVectorStoreId },
                }
            }
        });
        Assert.That(thread.ToolResources?.FileSearch?.VectorStoreIds, Has.Count.EqualTo(1));
        Assert.That(thread.ToolResources.FileSearch.VectorStoreIds[0], Is.EqualTo(createdVectorStoreId));

        ThreadRun run = client.CreateRun(thread, assistant);
        Validate(run);
        do
        {
            Thread.Sleep(1000);
            run = client.GetRun(run);
        } while (run?.Status.IsTerminal == false);
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));

        PageableCollection<ThreadMessage> messages = client.GetMessages(thread, resultOrder: ListOrder.NewestFirst);
        foreach (ThreadMessage message in messages)
        {
            foreach (MessageContent content in message.Content)
            {
                Console.WriteLine(content.Text);
                foreach (TextAnnotation annotation in content.TextAnnotations)
                {
                    Console.WriteLine($"  --> From file: {annotation.InputFileId}, quote: {annotation.InputQuote}, replacement: {annotation.TextToReplace}");
                }
            }
        }
        Assert.That(messages.Count() > 1);
        Assert.That(messages.Any(message => message.Content.Any(content => content.Text.ToLower().Contains("cake"))));
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

        AsyncResultCollection<StreamingUpdate> streamingResult
            = client.CreateRunStreamingAsync(thread.Id, assistant.Id);

        Print(">>> Connected <<<");

        await foreach (StreamingUpdate update in streamingResult)
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

    private static readonly DateTimeOffset s_2024 = new(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
}