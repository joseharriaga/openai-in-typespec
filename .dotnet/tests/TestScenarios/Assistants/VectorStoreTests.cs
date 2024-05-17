using NUnit.Framework;
using OpenAI.Assistants;
using OpenAI.Files;
using OpenAI.VectorStores;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.VectorStores;

#pragma warning disable OPENAI001
public partial class VectorStoreTests
{
    [Test]
    public void CanCreateGetAndDeleteVectorStores()
    {
        VectorStoreClient client = GetTestClient();

        VectorStore vectorStore = client.CreateVectorStore();
        Validate(vectorStore);
        bool deleted = client.DeleteVectorStore(vectorStore);
        Assert.That(deleted, Is.True);
        _vectorStoresToDelete.RemoveAt(_vectorStoresToDelete.Count - 1);

        IReadOnlyList<OpenAIFileInfo> testFiles = GetNewTestFiles(5);

        vectorStore = client.CreateVectorStore(new()
        {
            FileIds = { testFiles[0].Id },
            Name = "test vector store",
            ExpiresAfter = new VectorStoreExpirationPolicy()
            {
                Anchor = VectorStoreExpirationAnchor.LastActiveAt,
                Days = 3,
            },
            Metadata =
            {
                ["test-key"] = "test-value",
            },
        });
        Validate(vectorStore);
        Assert.Multiple(() =>
        {
            Assert.That(vectorStore.Name, Is.EqualTo("test vector store"));
            Assert.That(vectorStore.ExpirationPolicy?.Anchor, Is.EqualTo(VectorStoreExpirationAnchor.LastActiveAt));
            Assert.That(vectorStore.ExpirationPolicy?.Days, Is.EqualTo(3));
            Assert.That(vectorStore.FileCounts.Total, Is.EqualTo(1));
            Assert.That(vectorStore.CreatedAt, Is.GreaterThan(s_2024));
            Assert.That(vectorStore.ExpiresAt, Is.GreaterThan(s_2024));
            Assert.That(vectorStore.Status, Is.EqualTo(VectorStoreStatus.InProgress));
            Assert.That(vectorStore.Metadata?.TryGetValue("test-key", out string metadataValue) == true && metadataValue == "test-value");
        });
        vectorStore = client.GetVectorStore(vectorStore);
        Assert.Multiple(() =>
        {
            Assert.That(vectorStore.Name, Is.EqualTo("test vector store"));
            Assert.That(vectorStore.ExpirationPolicy?.Anchor, Is.EqualTo(VectorStoreExpirationAnchor.LastActiveAt));
            Assert.That(vectorStore.ExpirationPolicy?.Days, Is.EqualTo(3));
            Assert.That(vectorStore.FileCounts.Total, Is.EqualTo(1));
            Assert.That(vectorStore.CreatedAt, Is.GreaterThan(s_2024));
            Assert.That(vectorStore.ExpiresAt, Is.GreaterThan(s_2024));
            Assert.That(vectorStore.Metadata?.TryGetValue("test-key", out string metadataValue) == true && metadataValue == "test-value");
        });

        deleted = client.DeleteVectorStore(vectorStore.Id);
        Assert.That(deleted, Is.True);
        _vectorStoresToDelete.RemoveAt(_vectorStoresToDelete.Count - 1);

        vectorStore = client.CreateVectorStore(new()
        {
            FileIds = testFiles.Select(file => file.Id).ToList()
        });
        Validate(vectorStore);
        Assert.Multiple(() =>
        {
            Assert.That(vectorStore.Name, Is.Null.Or.Empty);
            Assert.That(vectorStore.FileCounts.Total, Is.EqualTo(5));
        });
    }

    [Test]
    public void CanEnumerateVectorStores()
    {
        VectorStoreClient client = GetTestClient();
        for (int i = 0; i < 10; i++)
        {
            VectorStore vectorStore = client.CreateVectorStore(new VectorStoreCreationOptions()
            {
                Name = $"Test Vector Store {i}",
            });
            Validate(vectorStore);
            Assert.That(vectorStore.Name, Is.EqualTo($"Test Vector Store {i}"));
        }

        int lastIdSeen = int.MaxValue;
        int count = 0;

        foreach (VectorStore vectorStore in client.GetVectorStores(ListOrder.NewestFirst))
        {
            Assert.That(vectorStore.Id, Is.Not.Null);
            if (vectorStore.Name?.StartsWith("Test Vector Store ") == true)
            {
                string idString = vectorStore.Name["Test Vector Store ".Length..];

                Assert.That(int.TryParse(idString, out int seenId), Is.True);
                Assert.That(seenId, Is.LessThan(lastIdSeen));
                lastIdSeen = seenId;
            }
            if (lastIdSeen == 0 || ++count >= 100)
            {
                break;
            }
        }

        Assert.That(lastIdSeen, Is.EqualTo(0));
    }

    [Test]
    public async Task CanEnumerateVectorStoresAsync()
    {
        VectorStoreClient client = GetTestClient();
        for (int i = 0; i < 10; i++)
        {
            VectorStore vectorStore = await client.CreateVectorStoreAsync(new VectorStoreCreationOptions()
            {
                Name = $"Test Vector Store {i}",
            });
            Validate(vectorStore);
            Assert.That(vectorStore.Name, Is.EqualTo($"Test Vector Store {i}"));
        }

        int lastIdSeen = int.MaxValue;
        int count = 0;

        await foreach (VectorStore vectorStore in client.GetVectorStoresAsync(ListOrder.NewestFirst))
        {
            Assert.That(vectorStore.Id, Is.Not.Null);
            if (vectorStore.Name?.StartsWith("Test Vector Store ") == true)
            {
                string idString = vectorStore.Name["Test Vector Store ".Length..];

                Assert.That(int.TryParse(idString, out int seenId), Is.True);
                Assert.That(seenId, Is.LessThan(lastIdSeen));
                lastIdSeen = seenId;
            }
            if (lastIdSeen == 0 || ++count >= 100)
            {
                break;
            }
        }

        Assert.That(lastIdSeen, Is.EqualTo(0));
    }

    private IReadOnlyList<OpenAIFileInfo> GetNewTestFiles(int count)
    {
        List<OpenAIFileInfo> files = [];

        FileClient client = new();
        for (int i = 0; i < count; i++)
        {
            OpenAIFileInfo file = client.UploadFile(
                BinaryData.FromString("This is a test file").ToStream(),
                $"test_file_{i.ToString().PadLeft(3, '0')}.txt",
                OpenAIFilePurpose.Assistants);
            Validate(file);
            files.Add(file);
        }

        return files;
    }
    [TearDown]
    protected void Cleanup()
    {
        FileClient fileClient = new();
        VectorStoreClient vectorStoreClient = new();
        RequestOptions requestOptions = new()
        {
            ErrorOptions = ClientErrorBehaviors.NoThrow,
        };
        foreach (OpenAIFileInfo file in _filesToDelete)
        {
            Console.WriteLine($"Cleanup: {file.Id} -> {fileClient.DeleteFile(file.Id, requestOptions)?.GetRawResponse().Status}");
        }
        foreach (VectorStore vectorStore in _vectorStoresToDelete)
        {
            Console.WriteLine($"Cleanup: {vectorStore.Id} => {vectorStoreClient.DeleteVectorStore(vectorStore.Id, requestOptions)?.GetRawResponse().Status}");
        }
        _filesToDelete.Clear();
        _vectorStoresToDelete.Clear();
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
        if (target is OpenAIFileInfo file)
        {
            Assert.That(file?.Id, Is.Not.Null);
            _filesToDelete.Add(file);
        }
        else if (target is VectorStore vectorStore)
        {
            Assert.That(vectorStore?.Id, Is.Not.Null);
            _vectorStoresToDelete.Add(vectorStore);
        }
        else
        {
            throw new NotImplementedException($"{nameof(Validate)} helper not implemented for: {typeof(T)}");
        }
    }

    private readonly List<OpenAIFileInfo> _filesToDelete = [];
    private readonly List<VectorStore> _vectorStoresToDelete = [];

    private static VectorStoreClient GetTestClient() => GetTestClient<VectorStoreClient>(TestScenario.VectorStores);

    private static readonly DateTimeOffset s_2024 = new(2024, 1, 1, 0, 0, 0, TimeSpan.Zero);
}

#pragma warning restore OPENAI001
