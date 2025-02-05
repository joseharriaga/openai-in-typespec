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
    public void CancelRun()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<ThreadRun> result = client.CancelRun("thread_abc123", "run_abc123");
        Console.WriteLine(result.Value);

        #endregion
    }
}
