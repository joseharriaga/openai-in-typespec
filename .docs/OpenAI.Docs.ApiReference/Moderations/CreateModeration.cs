using NUnit.Framework;

#region usings
using System;

using OpenAI.Moderations;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateModerationApiReference {

    [Test]
    public void CreateModeration()
    {
		ModerationClient client = new (
            model: "gpt-4o",
            Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		var moderation = client.ClassifyText("I want to kill them.");
	}
}
