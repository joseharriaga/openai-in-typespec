#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateThreadAndRunApiReference {

    [Test]
    public void CreateThreadAndRun()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        ThreadCreationOptions options = new()
        {
            InitialMessages =
            {
                "Explain deep learning to a 5 year old."
            }
        };

        var run = client.CreateThreadAndRun(
            "asst_abc123",
            options
        );

		Console.WriteLine(run.Value.Id);

        #endregion
    }
}
