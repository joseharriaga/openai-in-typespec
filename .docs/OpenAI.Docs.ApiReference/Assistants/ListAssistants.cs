using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using System.ClientModel;
using OpenAI.Assistants;

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
