using NUnit.Framework;
using OpenAI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OpenAI.Tests.Models;

public partial class ModelTests
{
    [Test]
    public async Task ListModels()
    {
        ModelClient client = new();

        OpenAIModelInfoCollection allModels = await client.GetModelsAsync();
        Assert.IsNotNull(allModels);
        Assert.Greater(allModels.Count, 0);
        Assert.That(allModels.Any(modelInfo => modelInfo.Id.Contains("whisper", StringComparison.InvariantCultureIgnoreCase)));
        Console.WriteLine($"Total model count: {allModels.Count}");
    }

    [Test]
    public async Task GetModelInfo()
    {
        ModelClient client = new();

        OpenAIModelInfo model = await client.GetModelAsync("gpt-3.5-turbo");
        Assert.IsNotNull(model);
        Assert.That(model.OwnedBy.ToLowerInvariant(), Contains.Substring("openai"));
    }

    [Test]
    public void SerializeModelCollection()
    {
        // TODO: Add this test.
    }
}
