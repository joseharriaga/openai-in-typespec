#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListAssistantsApiReference {

    [Test]
    public void ListAssistants()
    {
		AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		assistantClient.GetAssistants(new AssistantCollectionOptions()
		{
		    Order = AssistantCollectionOrder.Descending,
		    PageSizeLimit = 20
		});
	}
}
