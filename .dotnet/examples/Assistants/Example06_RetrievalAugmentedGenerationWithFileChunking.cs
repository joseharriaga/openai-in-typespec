using NUnit.Framework;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Chat;
using OpenAI.Files;
using OpenAI.VectorStores;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Examples;

public partial class AssistantExamples
{
    [Test]
    public async Task Example01_RetrievalAugmentedGenerationWithFileChunking()
    {
        // Assistants is a beta API and subject to change; acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
        if (Environment.GetEnvironmentVariable("OPENAI_API_KEY") == null)
        {
            throw new InvalidOperationException("Please set the OPENAI_API_KEY environment variable.");
        }
        OpenAIClient openAIClient = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
        FileClient fileClient = openAIClient.GetFileClient();
        AssistantClient assistantClient = openAIClient.GetAssistantClient();

        // First, let's contrive a document we'll use retrieval with and upload it.
        using Stream document = BinaryData.FromString("""
            {
                "description": "This document contains the sale history data for Contoso products.",
                "sales": [
                    {
                        "month": "January",
                        "by_product": {
                            "113043": 15,
                            "113045": 12,
                            "113049": 2
                        }
                    },
                    {
                        "month": "February",
                        "by_product": {
                            "113045": 22
                        }
                    },
                    {
                        "month": "March",
                        "by_product": {
                            "113045": 16,
                            "113055": 5
                        }
                    }
                ]
            }
            """).ToStream();

        OpenAIFileInfo salesFile = fileClient.UploadFile(
            document,
            "monthly_sales.json",
            FileUploadPurpose.Assistants);

        VectorStoreClient vectorStoreClient = new();
        // Set the chunk size to whatever you want
        FileChunkingStrategy chunkingStrategy = FileChunkingStrategy.CreateStaticStrategy(100, 30);
        // Now, we'll create a vector store with the file
        VectorStore vectorStore = await vectorStoreClient.CreateVectorStoreAsync(new VectorStoreCreationOptions()
        {
            FileIds = { salesFile.Id },
            ChunkingStrategy = chunkingStrategy,
        });


        // Now, we'll create a client intended to help with that data
        AssistantCreationOptions assistantOptions = new()
        {
            Name = "Example: Contoso sales RAG",
            Instructions =
                "You are an assistant that looks up sales data and helps visualize the information based"
                + " on user queries. When asked to generate a graph, chart, or other visualization, use"
                + " the code interpreter tool to do so.",
            Tools =
            {
                new FileSearchToolDefinition(),
                new CodeInterpreterToolDefinition(),
            },
            ToolResources = new()
            {
                FileSearch = new()
                {
                    // Add the vector store to the assistant's resources
                    VectorStoreIds = { vectorStore.Id },
                }
            },
        };

        Assistant assistant = assistantClient.CreateAssistant("gpt-4o-mini", assistantOptions);

        // Now we'll create a thread with a user query about the data already associated with the assistant, then run it
        ThreadCreationOptions threadOptions = new()
        {
            InitialMessages = { "How well did product 113045 sell in February? Graph its trend over time." }
        };

        AssistantThread thread = assistantClient.CreateThread(new ThreadCreationOptions()
        {
            InitialMessages =
            {
                new ThreadInitializationMessage(
                    MessageRole.User,
                [
                    "How well did product 113045 sell in February? Graph its trend over time."
                ]),
            }
        });

        CollectionResult<StreamingUpdate> streamingUpdates = assistantClient.CreateRunStreaming(
            thread,
            assistant,
            new RunCreationOptions()
            {
                AdditionalInstructions = "When possible, try to sneak in puns if you're asked to compare things.",
            }
        );


        foreach (StreamingUpdate streamingUpdate in streamingUpdates)
        {
            if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
            {
                Console.WriteLine($"--- Run started! ---");
            }
            if (streamingUpdate is MessageContentUpdate contentUpdate)
            {
                Console.Write(contentUpdate.Text);
            }
        }

        // Optionally, delete any persistent resources you no longer need.
        _ = assistantClient.DeleteThread(thread.Id);
        _ = assistantClient.DeleteAssistant(assistant);
        _ = fileClient.DeleteFile(salesFile);
    }
}
