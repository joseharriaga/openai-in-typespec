using NUnit.Framework;
using OpenAI.Moderations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAI.Tests.Moderations;

public partial class ModerationTests
{
    [Test]
    public async Task ClassifySingleInput()
    {
        ModerationClient client = new("text-moderation-stable");

        Moderation moderation = await client.ClassifyTextInputAsync("I am killing all my houseplants!");
        Assert.IsNotNull(moderation);
        Assert.IsTrue(moderation.Flagged);
        Assert.IsTrue(moderation.Categories.Violence);
        Assert.Greater(moderation.CategoryScores.Violence, 0.5);
    }

    [Test]
    public async Task ClassifyMultipleInputs()
    {
        ModerationClient client = new("text-moderation-stable");

        List<string> inputs =
            [
                "I forgot to water my houseplants!",
                "I am killing all my houseplants!"
            ];

        ModerationCollection moderations = await client.ClassifyTextInputsAsync(inputs);
        Assert.IsNotNull(moderations);
        Assert.AreEqual(2, moderations.Count);
        Assert.IsTrue(moderations.Model.StartsWith("text-moderation"));
        Assert.IsNotEmpty(moderations.Id);

        Assert.IsNotNull(moderations[0]);
        Assert.IsFalse(moderations[0].Flagged);

        Assert.IsNotNull(moderations[1]);
        Assert.IsTrue(moderations[1].Flagged);
        Assert.IsTrue(moderations[1].Categories.Violence);
        Assert.Greater(moderations[1].CategoryScores.Violence, 0.5);
    }

    [Test]
    public void SerializeModerationCollection()
    {
        // TODO: Add this test.
    }
}
