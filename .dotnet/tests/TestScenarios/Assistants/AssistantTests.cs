using NUnit.Framework;
using OpenAI.Assistants;
using OpenAI.Files;
using OpenAI.VectorStores;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Assistants;

#pragma warning disable OPENAI001
public partial class AssistantTests
{
    [Test]
    public void BasicAssistantOperationsWork()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = client.CreateAssistant("gpt-3.5-turbo");
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
        assistant = client.CreateAssistant("gpt-3.5-turbo", new AssistantCreationOptions()
        {
            Metadata =
            {
                [s_cleanupMetadataKey] = "hello!"
            },
        });
        Validate(assistant);
        Assistant retrievedAssistant = client.GetAssistant(assistant.Id);
        Assert.That(retrievedAssistant.Id, Is.EqualTo(assistant.Id));
        Assert.That(retrievedAssistant.Metadata.TryGetValue(s_cleanupMetadataKey, out string metadataValue) && metadataValue == "hello!");
        Assistant modifiedAssistant = client.ModifyAssistant(assistant.Id, new AssistantModificationOptions()
        {
            Metadata =
            {
                [s_cleanupMetadataKey] = "goodbye!",
            },
        });
        Assert.That(modifiedAssistant.Id, Is.EqualTo(assistant.Id));
        PageableResult<Assistant> recentAssistants = client.GetAssistants();
        Assistant listedAssistant = recentAssistants.FirstOrDefault(pageItem => pageItem.Id == assistant.Id);
        Assert.That(listedAssistant, Is.Not.Null);
        Assert.That(listedAssistant.Metadata.TryGetValue(s_cleanupMetadataKey, out string newMetadataValue) && newMetadataValue == "goodbye!");
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
        bool deleted = client.DeleteMessage(message);
        Assert.That(deleted, Is.True);
        _messagesToDelete.Remove(message);

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

        PageableResult<ThreadMessage> messagePage = client.GetMessages(thread);
        Assert.That(messagePage.Count, Is.EqualTo(1));
        Assert.That(messagePage.First().Id, Is.EqualTo(message.Id));
        Assert.That(messagePage.First().Metadata.TryGetValue("messageMetadata", out metadataValue) && metadataValue == "newValue");
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
        PageableResult<ThreadMessage> messages = client.GetMessages(thread, itemOrder: ListOrder.OldestFirst);
        Assert.That(messages.Count, Is.EqualTo(2));
        Assert.That(messages.First().Role, Is.EqualTo(MessageRole.User));
        Assert.That(messages.First().Content?.Count, Is.EqualTo(1));
        Assert.That(messages.First().Content[0].Text, Is.EqualTo("Hello, world!"));
        Assert.That(messages.AsPages().First().Values[1].Content?.Count, Is.EqualTo(2));
        Assert.That(messages.AsPages().First().Values[1].Content[0], Is.Not.Null);
        Assert.That(messages.AsPages().First().Values[1].Content[0].Text, Is.EqualTo("Can you describe this image for me?"));
        Assert.That(messages.AsPages().First().Values[1].Content[1], Is.Not.Null);
        Assert.That(messages.AsPages().First().Values[1].Content[1].ImageUrl.AbsoluteUri, Is.EqualTo("https://test.openai.com/image.png"));
    }

    [Test]
    public void BasicRunOperationsWork()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = client.CreateAssistant("gpt-3.5-turbo");
        Validate(assistant);
        AssistantThread thread = client.CreateThread();
        Validate(thread);
        PageableResult<ThreadRun> runs = client.GetRuns(thread);
        Assert.That(runs.Count, Is.EqualTo(0));
        ThreadMessage message = client.CreateMessage(thread.Id, ["Hello, assistant!"]);
        Validate(message);
        ThreadRun run = client.CreateRun(thread.Id, assistant.Id);
        Validate(run);
        Assert.That(run.Status, Is.EqualTo(RunStatus.Queued));
        Assert.That(run.CreatedAt, Is.GreaterThan(s_2024));
        ThreadRun retrievedRun = client.GetRun(thread.Id, run.Id);
        Assert.That(retrievedRun.Id, Is.EqualTo(run.Id));
        runs = client.GetRuns(thread);
        Assert.That(runs.Count, Is.EqualTo(1));
        Assert.That(runs.First().Id, Is.EqualTo(run.Id));

        PageableResult<ThreadMessage> messages = client.GetMessages(thread);
        Assert.That(messages.Count, Is.GreaterThanOrEqualTo(1));
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

        Assert.That(messages.ElementAt(0).Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(messages.ElementAt(1).Role, Is.EqualTo(MessageRole.User));
        Assert.That(messages.ElementAt(1).Id, Is.EqualTo(message.Id));
    }

    [Test]
    public void BasicRunStepFunctionalityWorks()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = client.CreateAssistant("gpt-3.5-turbo", new AssistantCreationOptions()
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

        PageableResult<RunStep> runSteps = client.GetRunSteps(run);
        Assert.That(runSteps.Count, Is.GreaterThan(1));
        Assert.Multiple(() =>
        {
            Assert.That(runSteps.First().AssistantId, Is.EqualTo(assistant.Id));
            Assert.That(runSteps.First().ThreadId, Is.EqualTo(thread.Id));
            Assert.That(runSteps.First().RunId, Is.EqualTo(run.Id));
            Assert.That(runSteps.First().CreatedAt, Is.GreaterThan(s_2024));
            Assert.That(runSteps.First().CompletedAt, Is.GreaterThan(s_2024));
        });
        RunStepDetails details = runSteps.First().Details;
        Assert.That(details?.CreatedMessageId, Is.Not.Null.And.Not.Empty);

        details = runSteps.ElementAt(1).Details;
        Assert.Multiple(() =>
        {
            Assert.That(details?.ToolCalls.Count, Is.GreaterThan(0));
            Assert.That(details.ToolCalls[0].ToolKind, Is.EqualTo(RunStepToolCallKind.CodeInterpreter));
            Assert.That(details.ToolCalls[0].ToolCallId, Is.Not.Null.And.Not.Empty);
            Assert.That(details.ToolCalls[0].CodeInterpreterInput, Is.Not.Null.And.Not.Empty);
            Assert.That(details.ToolCalls[0].CodeInterpreterOutputs?.Count, Is.GreaterThan(0));
            Assert.That(details.ToolCalls[0].CodeInterpreterOutputs[0].ImageFileId, Is.Not.Null.And.Not.Empty);
        });
    }

    [Test]
    public void SettingResponseFormatWorks()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = client.CreateAssistant("gpt-4-turbo", new()
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

    [Test]
    public void FunctionToolsWork()
    {
        AssistantClient client = GetTestClient();
        Assistant assistant = client.CreateAssistant("gpt-3.5-turbo", new AssistantCreationOptions()
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

        for (int i = 0; i < 10 && !run.Status.IsTerminal; i++)
        {
            Thread.Sleep(500);
            run = client.GetRun(run);
        }
        Assert.That(run.Status, Is.EqualTo(RunStatus.RequiresAction));
        Assert.That(run.RequiredActions?.Count, Is.EqualTo(1));
        Assert.That(run.RequiredActions[0].ToolCallId, Is.Not.Null.And.Not.Empty);
        Assert.That(run.RequiredActions[0].FunctionName, Is.EqualTo("get_favorite_food_for_day_of_week"));
        Assert.That(run.RequiredActions[0].FunctionArguments, Is.Not.Null.And.Not.Empty);

        run = client.SubmitToolOutputsToRun(run, [new(run.RequiredActions[0].ToolCallId, "tacos")]);
        Assert.That(run.Status.IsTerminal, Is.False);

        for (int i = 0; i < 10 && !run.Status.IsTerminal; i++)
        {
            Thread.Sleep(500);
            run = client.GetRun(run);
        }
        Assert.That(run.Status, Is.EqualTo(RunStatus.Completed));

        PageableResult<ThreadMessage> messages = client.GetMessages(run.ThreadId, itemOrder: ListOrder.NewestFirst);
        Assert.That(messages.Count, Is.GreaterThan(1));
        Assert.That(messages.First().Role, Is.EqualTo(MessageRole.Assistant));
        Assert.That(messages.First().Content?[0], Is.Not.Null);
        Assert.That(messages.First().Content[0].Text, Does.Contain("tacos"));
    }

    [Test]
    public async Task StreamingRunWorks()
    {
        AssistantClient client = new();
        Assistant assistant = await client.CreateAssistantAsync("gpt-3.5-turbo");
        Validate(assistant);

        AssistantThread thread = await client.CreateThreadAsync(new()
        {
            InitialMessages = { new(["Hello there, assistant! How are you today?"]), },
        });
        Validate(thread);

        Stopwatch stopwatch = Stopwatch.StartNew();
        void Print(string message) => Console.WriteLine($"[{stopwatch.ElapsedMilliseconds,6}] {message}");

        AsyncCollectionResult<StreamingUpdate> streamingResult
            = client.CreateRunStreamingAsync(thread.Id, assistant.Id);

        Print(">>> Connected <<<");

        await foreach (StreamingUpdate update in streamingResult)
        {
            string message = $"{update.UpdateKind} ";
            if (update is RunUpdate runUpdate)
            {
                message += $"at {update.UpdateKind switch
                {
                    StreamingUpdateReason.RunCreated => runUpdate.Value.CreatedAt,
                    StreamingUpdateReason.RunQueued => runUpdate.Value.StartedAt,
                    StreamingUpdateReason.RunInProgress => runUpdate.Value.StartedAt,
                    StreamingUpdateReason.RunCompleted => runUpdate.Value.CompletedAt,
                    _ => "???",
                }}";
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

    [TestCase]
    public async Task StreamingToolCall()
    {
        AssistantClient client = GetTestClient();
        FunctionToolDefinition getWeatherTool = new("get_current_weather", "Gets the user's current weather");
        Assistant assistant = await client.CreateAssistantAsync("gpt-3.5-turbo", new()
        {
            Tools = { getWeatherTool }
        });
        Validate(assistant);

        Stopwatch stopwatch = Stopwatch.StartNew();
        void Print(string message) => Console.WriteLine($"[{stopwatch.ElapsedMilliseconds,6}] {message}");

        Print(" >>> Beginning call ... ");
        AsyncCollectionResult<StreamingUpdate> asyncResults = client.CreateThreadAndRunStreamingAsync(
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
    public void BasicFileSearchWorks()
    {
        // First, we need to upload a simple test file.
        FileClient fileClient = new();
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

        AssistantClient client = GetTestClient();

        // Create an assistant, using the creation helper to make a new vector store
        Assistant assistant = client.CreateAssistant("gpt-4-turbo", new()
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
        _vectorStoreIdsToDelete.Add(createdVectorStoreId);

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
        _vectorStoreIdsToDelete.Add(createdVectorStoreId);

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

        PageableResult<ThreadMessage> messages = client.GetMessages(thread, itemOrder: ListOrder.NewestFirst);
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
    public async Task CanEnumerateAssistants()
    {
        AssistantClient client = GetTestClient();

        // Create assistant collection
        for (int i = 0; i < 10; i++)
        {
            Assistant assistant = client.CreateAssistant("gpt-3.5-turbo", new AssistantCreationOptions()
            {
                Name = $"Test Assistant {i}",
            });
            Validate(assistant);
            Assert.That(assistant.Name, Is.EqualTo($"Test Assistant {i}"));
        }

        // Page through collection
        int count = 0;
        AsyncPageableResult<Assistant> assistants = client.GetAssistantsAsync(ListOrder.NewestFirst, pageSize: 2);

        int lastIdSeen = int.MaxValue;

        List<string> todelete = new();

        await foreach (Assistant assistant in assistants)
        {
            Console.WriteLine($"[{count,3}] {assistant.Id} {assistant.CreatedAt:s} {assistant.Name}");
            if (assistant.Name?.StartsWith("Test Assistant ") == true)
            {
                Assert.That(int.TryParse(assistant.Name["Test Assistant ".Length..], out int seenId), Is.True);
                Assert.That(seenId, Is.LessThan(lastIdSeen));
                lastIdSeen = seenId;

                todelete.Add(assistant.Id);
            }
            count++;
            if (lastIdSeen == 0 || count > 100)
            {
                break;
            }
        }

        // delete them all!
        foreach(var a in todelete)
        {
            await client.DeleteAssistantAsync(a);
        }

        Assert.That(count, Is.GreaterThanOrEqualTo(10));
    }

    [Test]
    public async Task CanEnumerateAssistantsByPage()
    {
        AssistantClient client = GetTestClient();

        // Create assistant collection
        for (int i = 0; i < 10; i++)
        {
            Assistant assistant = client.CreateAssistant("gpt-3.5-turbo", new AssistantCreationOptions()
            {
                Name = $"Test Assistant {i}"
            });
            Validate(assistant);
            Assert.That(assistant.Name, Is.EqualTo($"Test Assistant {i}"));
        }

        // Get a count of the assistants as a baseline.
        PageableResult<Assistant> enumerable = client.GetAssistants(ListOrder.NewestFirst, pageSize: 100);
        int totalCount = enumerable.Count();

        // Page through collection
        int itemCount = 0;
        int pageCount = 0;
        AsyncPageableResult<Assistant> assistants = client.GetAssistantsAsync(pageSize: 2, itemOrder: ListOrder.NewestFirst);
        IAsyncEnumerable<ClientPage<Assistant>> pages = assistants.AsPages();

        await foreach (ClientPage<Assistant> page in pages)
        {
            foreach (Assistant assistant in page.Values)
            {
                itemCount++;
            }

            pageCount++;
        }

        // Counts should equal the number of items and pages we expect.
        Assert.That(itemCount, Is.EqualTo(totalCount));

        // Add one for the last empty page that sets continuation token to null.
        Assert.That(pageCount, Is.EqualTo(Math.Ceiling(totalCount / 2.0) + 1));
    }

#nullable enable

    [Test]
    public async Task CanEnumerateAssistantsByPageAndResume()
    {
        AssistantClient client = GetTestClient();

        // Create assistant collection
        for (int i = 0; i < 10; i++)
        {
            Assistant assistant = client.CreateAssistant("gpt-3.5-turbo", new AssistantCreationOptions()
            {
                Name = $"Test Assistant {i}"
            });
            Validate(assistant);
            Assert.That(assistant.Name, Is.EqualTo($"Test Assistant {i}"));
        }

        // Get a count of the assistants as a baseline.
        PageableResult<Assistant> enumerable = client.GetAssistants(ListOrder.NewestFirst, pageSize: 100);
        int totalCount = enumerable.Count();

        // Page through collection
        int itemCount = 0;
        int pageCount = 0;
        AsyncPageableResult<Assistant> assistants = client.GetAssistantsAsync(pageSize: 2, itemOrder: ListOrder.NewestFirst);
        IAsyncEnumerable<ClientPage<Assistant>> pages = assistants.AsPages();

        string? pageToken = default;

        // First iteration - stop after two pages
        await foreach (ClientPage<Assistant> page in pages)
        {
            foreach (Assistant assistant in page.Values)
            {
                itemCount++;
            }

            pageCount++;

            if (pageCount > 1)
            {
                pageToken = page.NextPageToken;
                break;
            }
        }

        // Second iteration - resume from continuation token.

        // First: call the service method to get the pageable collection.  This makes no service calls,
        // but sets up the closures needed to replicate the collection from the first call.
        assistants = client.GetAssistantsAsync(pageSize: 2, itemOrder: ListOrder.NewestFirst);

        // Next: call AsPages, passing the continuation token we reserved from the previous iteration.
        // This does make a service call - it should make a request to the service for the next page
        // after where we stopped in the prior iteration.
        pages = assistants.AsPages(pageToken);

        // Now iterate again, continuing the counts.
        await foreach (ClientPage<Assistant> page in pages)
        {
            foreach (Assistant assistant in page.Values)
            {
                itemCount++;
            }

            pageCount++;
        }

        // Counts should equal the number of items and pages we expect.
        Assert.That(itemCount, Is.EqualTo(totalCount));

        // Add one for the last empty page that sets continuation token to null.
        Assert.That(pageCount, Is.EqualTo(Math.Ceiling(totalCount / 2.0) + 1));
    }
#nullable disable


    [Test]
    public void CanGetPrevPageWhenEnumeratingPages()
    {
        AssistantClient client = GetTestClient();

        //// Create assistant collection
        //for (int i = 0; i < 10; i++)
        //{
        //    Assistant assistant = client.CreateAssistant("gpt-3.5-turbo", new AssistantCreationOptions()
        //    {
        //        Name = $"Test Assistant {i}",
        //    });
        //    Validate(assistant);
        //    Assert.That(assistant.Name, Is.EqualTo($"Test Assistant {i}"));
        //}

        //// Get the full list of assistants in the order they were created.
        //PageableResult<Assistant> enumerable = client.GetAssistants(ListOrder.OldestFirst, pageSize: 100);
        //List<Assistant> assistantList = enumerable.ToList();
        //int totalCount = assistantList.Count;

        // Get the collection in smaller pages so we can traverse the pages.
        PageableResult<Assistant> assistants = client.GetAssistants(
            ListOrder.OldestFirst,
            pageSize: 2);

        IEnumerable<ClientPage<Assistant>> pages = assistants.AsPages();

        // Get first page
        ClientPage<Assistant> firstPage = default;
        ClientPage<Assistant> secondPage = default;
        ClientPage<Assistant> thirdPage = default;
        int pageCount = 0;
        foreach (var page in pages)
        {
            if (pageCount == 0)
            {
                firstPage = page;
            }

            if (pageCount == 1)
            {
                secondPage = page;
            }

            if (pageCount== 2)
            {
                thirdPage = page;
                break;
            }

            pageCount++;
        }

        // Get previous page (from second page) -- this should be the first page
        pages = assistants.AsPages(secondPage.PreviousPageToken);
        ClientPage<Assistant> secondPrevPage = default;
        foreach (var page in pages)
        {
            secondPrevPage = page;
            break;
        }

        // Get previous page (from third page) -- this should be the second page
        pages = assistants.AsPages(thirdPage.PreviousPageToken);
        ClientPage<Assistant> thirdPrevPage = default;
        foreach (var page in pages)
        {
            thirdPrevPage = page;
            break;
        }

        Assert.AreEqual(firstPage.Values[0].Id, secondPrevPage.Values[0].Id);
        Assert.AreEqual(firstPage.Values[^1].Id, secondPrevPage.Values[^1].Id);

        Assert.AreEqual(secondPage.Values[0].Id, thirdPrevPage.Values[0].Id);
        Assert.AreEqual(secondPage.Values[^1].Id, thirdPrevPage.Values[^1].Id);

        // Because we're constructing this a priori.
        Assert.IsNotNull(secondPage.PreviousPageToken);

        // These should both point to the second page
        Assert.AreEqual(thirdPage.PreviousPageToken, firstPage.NextPageToken);
    }


    [Test]
    public void CanGetPrevPageOfAssistants()
    {
        AssistantClient client = GetTestClient();

        //// Create assistant collection
        //for (int i = 0; i < 10; i++)
        //{
        //    Assistant assistant = client.CreateAssistant("gpt-3.5-turbo", new AssistantCreationOptions()
        //    {
        //        Name = $"Test Assistant {i}",
        //    });
        //    Validate(assistant);
        //    Assert.That(assistant.Name, Is.EqualTo($"Test Assistant {i}"));
        //}

        //// Get the full list of assistants in the order they were created.
        //PageableResult<Assistant> enumerable = client.GetAssistants(ListOrder.OldestFirst, pageSize: 100);
        //List<Assistant> assistantList = enumerable.ToList();
        //int totalCount = assistantList.Count;

        // Get the collection in smaller pages so we can traverse the pages.
        PageableResult<Assistant> assistants = client.GetAssistants(
            ListOrder.OldestFirst,
            pageSize: 2);

        IEnumerable<ClientPage<Assistant>> pages = assistants.AsPages();

        // Get first page
        ClientPage<Assistant> firstPage = default;
        foreach (var page in pages)
        {
            firstPage = page;
            break;
        }

        // Get second page
        pages = assistants.AsPages(firstPage.NextPageToken);
        ClientPage<Assistant> secondPage = default;
        foreach (var page in pages)
        {
            secondPage = page;
            break;
        }

        // Get third page
        pages = assistants.AsPages(secondPage.NextPageToken);
        ClientPage<Assistant> thirdPage = default;
        foreach (var page in pages)
        {
            thirdPage = page;
            break;
        }

        // Get previous page (from second page) -- this should be the first page
        pages = assistants.AsPages(secondPage.PreviousPageToken);
        ClientPage<Assistant> secondPrevPage = default;
        foreach (var page in pages)
        {
            secondPrevPage = page;
            break;
        }

        // Get previous page (from third page) -- this should be the second page
        pages = assistants.AsPages(thirdPage.PreviousPageToken);
        ClientPage<Assistant> thirdPrevPage = default;
        foreach (var page in pages)
        {
            thirdPrevPage = page;
            break;
        }

        Assert.AreEqual(firstPage.Values[0].Id, secondPrevPage.Values[0].Id);
        Assert.AreEqual(firstPage.Values[^1].Id, secondPrevPage.Values[^1].Id);

        Assert.AreEqual(secondPage.Values[0].Id, thirdPrevPage.Values[0].Id);
        Assert.AreEqual(secondPage.Values[^1].Id, thirdPrevPage.Values[^1].Id);

        // Because we're constructing this a priori.
        Assert.IsNotNull(secondPage.PreviousPageToken);

        // These should both point to the second page
        Assert.AreEqual(thirdPage.PreviousPageToken, firstPage.NextPageToken);
    }

    [TearDown]
    protected void Cleanup()
    {
        AssistantClient client = new();
        FileClient fileClient = new();
        VectorStoreClient vectorStoreClient = new();
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
        foreach (OpenAIFileInfo file in _filesToDelete)
        {
            Console.WriteLine($"Cleanup: {file.Id} -> {fileClient.DeleteFile(file.Id, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (string vectorStoreId in _vectorStoreIdsToDelete)
        {
            Console.WriteLine($"Cleanup: {vectorStoreId} => {vectorStoreClient.DeleteVectorStore(vectorStoreId, requestOptions)?.GetRawResponse().Status}");
        }
        _messagesToDelete.Clear();
        _assistantsToDelete.Clear();
        _threadsToDelete.Clear();
        _filesToDelete.Clear();
        _vectorStoreIdsToDelete.Clear();
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
        else if (target is OpenAIFileInfo file)
        {
            Assert.That(file?.Id, Is.Not.Null);
            _filesToDelete.Add(file);
        }
        else
        {
            throw new NotImplementedException($"{nameof(Validate)} helper not implemented for: {typeof(T)}");
        }
    }

    private readonly List<Assistant> _assistantsToDelete = [];
    private readonly List<AssistantThread> _threadsToDelete = [];
    private readonly List<ThreadMessage> _messagesToDelete = [];
    private readonly List<OpenAIFileInfo> _filesToDelete = [];
    private readonly List<string> _vectorStoreIdsToDelete = [];

    private static AssistantClient GetTestClient() => GetTestClient<AssistantClient>(TestScenario.Assistants);

    private static readonly DateTimeOffset s_2024 = new(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
    private static readonly string s_testAssistantName = $".NET SDK Test Assistant - Please Delete Me";
    private static readonly string s_cleanupMetadataKey = $"test_metadata_cleanup_eligible";
}

#pragma warning restore OPENAI001
