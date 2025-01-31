using NUnit.Framework;

#region usings
using System;

using OpenAI.Models;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListModelsApiReference {

    [Test]
    public void ListModels()
    {
		OpenAIModelClient client = new(
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		foreach (var model in client.GetModels().Value) {
		    Console.WriteLine(model.Id);
		}
	}
}
