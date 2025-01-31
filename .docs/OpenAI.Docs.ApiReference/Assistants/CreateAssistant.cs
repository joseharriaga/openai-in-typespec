#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;

public partial class AssistantsApiReference {

    [Test]
    public void CreateAssistant()
    { 
        AssistantClient assistantClient = new (new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

        Assistant assistant = assistantClient.CreateAssistant(
            model: "gpt-4o",
            new AssistantCreationOptions()
            {   Name = "Math Tutor",
                Instructions = "You are a personal math tutor. When asked a question, write and run .NET code to answer the question.",
                Tools = { new CodeInterpreterToolDefinition() }
            }
        );
    }

}