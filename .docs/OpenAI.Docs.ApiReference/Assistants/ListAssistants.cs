#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListAssistantsApiReference {

    //[Test]
    public void ListAssistants()
    {
        #region logic
        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        client.GetAssistants(new AssistantCollectionOptions()
		    {
		        Order = AssistantCollectionOrder.Descending,
		        PageSizeLimit = 20
		    }
        );
        #endregion
    }
}
