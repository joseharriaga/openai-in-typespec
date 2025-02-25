#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class RunStepDocs
{
    //[Test]
    public void RetrieveRunStep()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ClientResult<RunStep> runStep = client.GetRunStep("thread_abc123", "run_abc123", "step_abc123");
        Console.WriteLine(runStep.Value.Id);

        #endregion
    }
}
