#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class AssistantDocs
{
    //[Test]
    public void ListAssistants()
    {
        #region logic
        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        OpenAIPageOptions options = new()
        {
            Order = OpenAIPageOrder.Descending,
            PageSizeLimit = 20
        };

        client.GetAssistants(options);
        #endregion
    }
}
