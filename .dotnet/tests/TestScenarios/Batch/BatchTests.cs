using NUnit.Framework;
using OpenAI.Assistants;
using OpenAI.Batch;
using OpenAI.Batch;
using System;
using System.IO;
using System.Threading.Tasks;
using static OpenAI.Tests.TestHelpers;

namespace OpenAI.Tests.Batch;

public partial class BatchTests
{
    [Test]
    public async Task ListBatches()
    {
        BatchClient client = GetTestClient();
        ListQueryPage<OpenAI.Batch.Batch> batches = await client.GetBatchesAsync();
        Assert.That(batches?.Count, Is.GreaterThan(0));
        Assert.That(batches[0].CreatedAt, Is.GreaterThan(new DateTimeOffset(2024, 01, 01, 0, 0, 0, TimeSpan.Zero)));
    }

    private static BatchClient GetTestClient() => GetTestClient<BatchClient>(TestScenario.Batch);
}