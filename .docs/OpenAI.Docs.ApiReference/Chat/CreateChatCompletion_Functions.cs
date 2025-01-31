using NUnit.Framework;

#region usings
using System;

using OpenAI.Chat;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class CreateChatCompletion_FunctionsApiReference {

    [Test]
    public void CreateChatCompletion_Functions()
    {
		ChatTool getCurrentLocationTool = ChatTool.CreateFunctionTool(
		    functionName: nameof(GetCurrentLocation),
		    functionDescription: "Get the user's current location"
		);
		
		ChatTool getCurrentWeatherTool = ChatTool.CreateFunctionTool(
		    functionName: nameof(GetCurrentWeather),
		    functionDescription: "Get the current weather in a given location",
		    functionParameters: BinaryData.FromString("""
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
		
		ChatClient client = new(
		    model: "gpt-4o",
		    apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		ChatMessage[] messages = 
		[
		    new UserChatMessage("What's the weather like today?"),
		];
		
		ChatCompletionOptions options = new()
		{
		    Tools = { getCurrentLocationTool, getCurrentWeatherTool },
		};
		
		ChatCompletion chatCompletion = client.CompleteChat(messages, options);
		
		// DO NOT INCLUDE IN DOCS FROM THIS POINT ONWARDS
		
		string GetCurrentLocation()
		{
		    // Call the location API here.
		    return "San Francisco";
		}
		
		string GetCurrentWeather(string location, string unit = "celsius")
		{
		    // Call the weather API here.
		    return $"31 {unit}";
		}
		
		// Uncomment to test that it works
		//bool requiresAction;
		
		//do {
		//    requiresAction = false;
		//    ChatCompletion chatCompletion = client.CompleteChat(messages, options);
		//    Console.WriteLine(string.Join("\n", chatCompletion.Content));
		
		//    switch (chatCompletion.FinishReason) {
		//        case ChatFinishReason.Stop: {
		//                // Add the assistant message to the conversation history.
		//                messages.Add(new AssistantChatMessage(chatCompletion));
		//                break;
		//            }
		
		//        case ChatFinishReason.ToolCalls: {
		//                // First, add the assistant message with tool calls to the conversation history.
		//                messages.Add(new AssistantChatMessage(chatCompletion));
		
		//                // Then, add a new tool message for each tool call that is resolved.
		//                foreach (ChatToolCall toolCall in chatCompletion.ToolCalls) {
		//                    switch (toolCall.FunctionName) {
		//                        case nameof(GetCurrentLocation): {
		//                                string toolResult = GetCurrentLocation();
		//                                messages.Add(new ToolChatMessage(toolCall.Id, toolResult));
		//                                break;
		//                            }
		
		//                        case nameof(GetCurrentWeather): {
		//                                // The arguments that the model wants to use to call the function are specified as a
		//                                // stringified JSON object based on the schema defined in the tool definition. Note that
		//                                // the model may hallucinate arguments too. Consequently, it is important to do the
		//                                // appropriate parsing and validation before calling the function.
		//                                using JsonDocument argumentsJson = JsonDocument.Parse(toolCall.FunctionArguments);
		//                                bool hasLocation = argumentsJson.RootElement.TryGetProperty("location", out JsonElement location);
		//                                bool hasUnit = argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unit);
		
		//                                if (!hasLocation) {
		//                                    throw new ArgumentNullException(nameof(location), "The location argument is required.");
		//                                }
		
		//                                string toolResult = hasUnit
		//                                    ? GetCurrentWeather(location.GetString(), unit.GetString())
		//                                    : GetCurrentWeather(location.GetString());
		//                                messages.Add(new ToolChatMessage(toolCall.Id, toolResult));
		//                                break;
		//                            }
		
		//                        default: {
		//                                // Handle other unexpected calls.
		//                                throw new NotImplementedException();
		//                            }
		//                    }
		//                }
		
		//                requiresAction = true;
		//                break;
		//            }
		
		//        case ChatFinishReason.Length:
		//            throw new NotImplementedException("Incomplete model output due to MaxTokens parameter or token limit exceeded.");
		
		//        case ChatFinishReason.ContentFilter:
		//            throw new NotImplementedException("Omitted content due to a content filter flag.");
		
		//        case ChatFinishReason.FunctionCall:
		//            throw new NotImplementedException("Deprecated in favor of tool calls.");
		
		//        default:
		//            throw new NotImplementedException(chatCompletion.FinishReason.ToString());
		//    }
		//} while (requiresAction);

	}
}
