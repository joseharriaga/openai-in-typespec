#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class DeleteThreadApiReference {

    //[Test]
    public void DeleteThread()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<ThreadDeletionResult> thread = client.DeleteThread("thread_abc123");
		Console.WriteLine(thread.Value);

        #endregion
    }
}
