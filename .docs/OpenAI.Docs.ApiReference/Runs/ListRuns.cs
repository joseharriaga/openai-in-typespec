#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListRunsApiReference {

    //[Test]
    public void ListRuns()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        CollectionResult<ThreadRun> runs = client.GetRuns("thread_abc123");
		Console.WriteLine(runs);

        #endregion
    }
}
