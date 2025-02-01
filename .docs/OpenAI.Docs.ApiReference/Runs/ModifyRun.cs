#pragma warning disable OPENAI001
using NUnit.Framework;

#region usings
using System;
using System.ClientModel;
using System.Collections.Generic;

using OpenAI.Assistants;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ModifyRunApiReference {

    [Test]
    public void ModifyRun()
    {
        #region logic

        AssistantClient client = new(
            apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
        );

        BinaryContent content = BinaryContent.Create(
		    BinaryData.FromObjectAsJson(new
		    {
		        metadata = new Dictionary<string, string>
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
		    })
		);
		
		var run = client.ModifyRun("thread_abc123", "run_abc123", content);
		Console.WriteLine(run);

        #endregion
    }
}
