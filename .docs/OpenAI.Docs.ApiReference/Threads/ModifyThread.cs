#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;
using System.Collections.Generic;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class ThreadDocs
{
    //[Test]
    public void ModifyThread()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        var thread = client.ModifyThread("thread_abc123", new ThreadModificationOptions()
        {
            Metadata = new Dictionary<string, string>
            {
                {
                    "modified",
                    "true"
                },
                {
                    "user",
                    "abc123"
                }
            }
        });
        Console.WriteLine(thread.Value.Id);

        #endregion
    }
}
