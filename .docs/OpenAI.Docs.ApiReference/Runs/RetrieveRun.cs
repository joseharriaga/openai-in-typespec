#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class RetrieveRunApiReference {
    //[Test]
    public void RetrieveRun()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<ThreadRun> run = client.GetRun("thread_abc123", "run_abc123");
		Console.WriteLine(run.Value.Id);

        #endregion
    }
}
