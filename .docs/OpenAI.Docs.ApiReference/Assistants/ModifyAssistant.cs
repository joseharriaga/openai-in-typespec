#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ModifyAssistantApiReference {

    [Test]
    public void ModifyAssistant()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		var response = assistantClient.ModifyAssistant(
		    "asst_abc123",
		    new AssistantModificationOptions()
		    {
		        Instructions = "You are an HR bot, and you have access to files to answer employee questions about company policies. Always response with info from either of the files.",
		        Name = "HR Helper",
		        Model = "gpt-4o",
		        DefaultTools = { new FileSearchToolDefinition() }
		    });
		Console.WriteLine(response.Value.Id);
	}
}
