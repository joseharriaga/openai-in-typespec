using NUnit.Framework;

#region usings
using System;

using OpenAI.Moderations;
using System.ClientModel;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateModerationApiReference {

    [Test]
    public void CreateModeration()
    {
        #region logic

        ModerationClient client = new (
            model: "gpt-4o",
            Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		ClientResult<ModerationResult> moderation = client.ClassifyText("I want to kill them.");

        #endregion
    }
}
