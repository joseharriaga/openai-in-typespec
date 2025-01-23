using System;
using NUnit.Framework;


// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;
using System.ClientModel;

namespace OpenAI.Docs.ApiReference;
public partial class CreateRun_StreamingWithFunctionsApiReference {

    [Test]
    public void CreateRun_StreamingWithFunctions()
    {
		AssistantClient assistantClient = new(new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
		
		var getCurrentWeatherTool = ToolDefinition.CreateFunction(
		    name: nameof(GetCurrentWeather),
		    description: "Get the current weather in a given location",
		    parameters: BinaryData.FromString("""
		        {
		            "type": "object",
		            "properties": {
		                "location": {
		                    "type": "string",
		                    "description": "The city and state, e.g. Boston, MA"
		                },
		                "unit": {
		                    "type": "string",
		                    "enum": [ "celsius", "fahrenheit" ],
		                    "description": "The temperature unit to use. Infer this from the specified location."
		                }
		            },
		            "required": [ "location" ]
		        }
		        """)
		);
		
		var streamingUpdates = assistantClient.CreateRunStreaming("thread_abc123", "asst_abc123", new() { 
		    ToolsOverride = { getCurrentWeatherTool } 
		});
		
		foreach (StreamingUpdate streamingUpdate in streamingUpdates) {
		    if (streamingUpdate is MessageContentUpdate contentUpdate) {
		        Console.Write(contentUpdate.Text);
		    }
		}
		
		string GetCurrentWeather(string location, string unit = "celsius")
		{
		    return $"31 {unit}";
		}
	}
}
