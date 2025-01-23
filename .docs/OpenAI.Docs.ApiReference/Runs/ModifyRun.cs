using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using System.Collections.Generic;
using OpenAI.Assistants;

namespace OpenAI.Docs.ApiReference;
public partial class ModifyRunApiReference {

    [Test]
    public void ModifyRun()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var content = BinaryContent.Create(
		    BinaryData.FromObjectAsJson(new
		    {
		        metadata = new Dictionary<string, string>
		        {
		            { "modified", "true" },
		            { "user", "abc123" }
		        }
		    })
		);
		
		var run = assistantClient.ModifyRun("thread_abc123", "run_abc123", content);
		Console.WriteLine(run);
	}
}
