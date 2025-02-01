#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListMessagesApiReference {

    //[Test]
    public void ListMessages()
    {
        #region logic

        AssistantClient assistantClient = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        CollectionResult<ThreadMessage> messages = assistantClient.GetMessages("thread_abc123");
		Console.WriteLine(messages);

        #endregion
    }
}
