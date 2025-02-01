using NUnit.Framework;

#region usings
using System;

using OpenAI.Chat;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateChatCompletion_LogprobsApiReference {

    [Test]
    public void CreateChatCompletion_Logprobs()
    {
        #region logic

        ChatClient client = new(
		    model: "gpt-4o",
		    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		ChatCompletion completion = client.CompleteChat(
		    [ 
				new UserChatMessage("Hello!") 
			],
		    new() 
			{ 
				IncludeLogProbabilities = true, 
				TopLogProbabilityCount = 2 
			}
		);
		
		Console.WriteLine($"[ASSISTANT]: {completion}");

		#endregion
	}
}
