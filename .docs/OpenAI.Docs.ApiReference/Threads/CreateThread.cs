#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateThreadApiReference {

    [Test]
    public void CreateThread()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<AssistantThread> thread = client.CreateThread(new ThreadCreationOptions()
		{
		    InitialMessages = 
            {
		        "Hello, what is AI?",
		        "How does AI work? Explain it in simple terms."
		    }
		});
		Console.WriteLine(thread.Value.Id);

        #endregion
    }
}
