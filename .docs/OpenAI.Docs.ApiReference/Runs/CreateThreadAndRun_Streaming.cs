#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateThreadAndRun_StreamingApiReference {

    //[Test]
    public void CreateThreadAndRun_Streaming()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ThreadCreationOptions options = new()
        {
            InitialMessages =
            {
                "Hello"
            }
        };

        var streamingUpdates = client.CreateThreadAndRunStreaming("asst_abc123", options);
		
		foreach (StreamingUpdate streamingUpdate in streamingUpdates) 
        {
		    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated) 
            {
		        Console.WriteLine($"--- Run started! ---");
		    }
		    if (streamingUpdate is MessageContentUpdate contentUpdate) 
            {
		        Console.Write(contentUpdate.Text);
		    }
		}

        #endregion
    }
}
