using NUnit.Framework;

#region usings
using System;

using OpenAI.Moderations;
using System.ClientModel;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class ModerationDocs
{
    [Test]
    public void CreateModeration()
    {
        #region logic

        ModerationClient client = new(
            model: "omni-moderation-latest",
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<ModerationResult> moderation = client.ClassifyText("I want to kill them.");

        #endregion
    }
}
