#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings	
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class RunDocs
{
    //[Test]
    public void CreateRun()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<ThreadRun> run = client.CreateRun("thread_abc123", "asst_abc123");
        Console.WriteLine(run.Value.Id);

        #endregion
    }
}
