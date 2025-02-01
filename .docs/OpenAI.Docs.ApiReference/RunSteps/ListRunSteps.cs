#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListRunStepsApiReference {

    //[Test]
    public void ListRunSteps()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        CollectionResult<RunStep> runSteps = client.GetRunSteps("thread_abc123", "run_abc123");
		Console.WriteLine(runSteps);

        #endregion
    }
}
