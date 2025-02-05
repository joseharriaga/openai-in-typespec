#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class MessageDocs
{
    //[Test]
    public void RetrieveMessage()
    {
        #region logic

        AssistantClient assistantClient = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        var message = assistantClient.GetMessage("thread_abc123", "msg_abc123");
        Console.WriteLine(message.Value.Id);

        #endregion
    }
}
