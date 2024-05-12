using NUnit.Framework;
using OpenAI.Assistants;
using System;

namespace OpenAI.Samples;
public partial class AssistantSamples
{
    [Test]
    [Ignore("Compilation validation only")]
    public void Sample03_ListAssistantsWithPagination()
    {
        // Assistants is a beta API and subject to change; acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
        AssistantClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

        string latestId = null;
        bool continueQuery = true;
        int count = 0;

        while (continueQuery)
        {
            ListQueryPage<Assistant> pagedAssistants = client.GetAssistants(previousId: latestId);

            foreach (Assistant assistant in pagedAssistants)
            {
                Console.WriteLine($"[{count,3}] {assistant.Id} {assistant.CreatedAt:s} {assistant.Name}");

                latestId = assistant.Id;
                count++;
            }

            continueQuery = pagedAssistants.HasMore;
        }
    }
}
