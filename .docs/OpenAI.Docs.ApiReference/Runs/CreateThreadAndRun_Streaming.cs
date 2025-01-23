using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.Assistants;

namespace OpenAI.Docs.ApiReference;
public partial class CreateThreadAndRun_StreamingApiReference {

    [Test]
    public void CreateThreadAndRun_Streaming()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var streamingUpdates = assistantClient.CreateThreadAndRunStreaming("asst_abc123", new ThreadCreationOptions()
		{
		    InitialMessages = {
		        "Hello"
		    }
		});
		
		foreach (StreamingUpdate streamingUpdate in streamingUpdates) {
		    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated) {
		        Console.WriteLine($"--- Run started! ---");
		    }
		    if (streamingUpdate is MessageContentUpdate contentUpdate) {
		        Console.Write(contentUpdate.Text);
		    }
		}
	}
}
