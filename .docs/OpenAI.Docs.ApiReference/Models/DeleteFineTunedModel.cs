using NUnit.Framework;

#region usings
using System;

using OpenAI.Models;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class DeleteFineTunedModelApiReference {

    [Test]
    public void DeleteFineTunedModel()
    {
		OpenAIModelClient client = new(
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		var success = client.DeleteModel("ft:gpt-4o-mini:acemeco:suffix:abc123");
		Console.WriteLine(success);

	}
}
