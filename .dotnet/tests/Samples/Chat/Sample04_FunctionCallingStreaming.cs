using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace OpenAI.Samples
{
    public partial class ChatSamples
    {
        [Test]
        [Ignore("Compilation validation only")]
        public void Sample04_FunctionCallingStreaming()
        {
            ChatClient client = new("gpt-3.5-turbo", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            #region
            List<ChatMessage> messages = [
                new SystemChatMessage(
                   "Don't make assumptions about what values to plug into functions."
                   + " Ask for clarification if a user request is ambiguous."),
                new UserChatMessage("What's the weather like today?"),
            ];

            ChatCompletionOptions options = new()
            {
                Tools = { getCurrentLocationFunction, getCurrentWeatherFunction },
            };
            #endregion

            #region
            bool requiresAction;

            do
            {
                Dictionary<int, string> indexToToolCallId = [];
                Dictionary<int, string> indexToFunctionName = [];
                Dictionary<int, StringBuilder> indexToFunctionArguments = [];
                StringBuilder contentBuilder = new();

                requiresAction = false;
                ResultCollection<StreamingChatCompletionUpdate> chatCompletionUpdates = client.CompleteChatStreaming(messages, options);

                foreach (StreamingChatCompletionUpdate chatCompletionUpdate in chatCompletionUpdates)
                {
                    // Accumulate the content string as new updates arrive.
                    if (chatCompletionUpdate.ContentUpdate.Count > 0)
                    {
                        contentBuilder.Append(chatCompletionUpdate.ContentUpdate[0].Text);
                    }

                    // Build the tool calls as new updates arrive.
                    foreach (StreamingChatToolCallUpdate toolCallUpdate in chatCompletionUpdate.ToolCallUpdates)
                    {
                        // Keep track of which tool call ID belongs to this update index.
                        if (toolCallUpdate.Id != null)
                        {
                            indexToToolCallId[toolCallUpdate.Index] = toolCallUpdate.Id;
                        }

                        // Keep track of which function name belongs to this update index.
                        if (toolCallUpdate.FunctionName != null)
                        {
                            indexToFunctionName[toolCallUpdate.Index] = toolCallUpdate.FunctionName;
                        }

                        // Keep track of which function arguments belong to this update index,
                        // and accumulate the arguments string as new updates arrive.
                        if (toolCallUpdate.FunctionArgumentsUpdate != null)
                        {
                            StringBuilder argumentsBuilder =
                                indexToFunctionArguments.TryGetValue(toolCallUpdate.Index, out StringBuilder builder)
                                    ? builder
                                    : new StringBuilder();

                            argumentsBuilder.Append(toolCallUpdate.FunctionArgumentsUpdate);

                            indexToFunctionArguments[toolCallUpdate.Index] = argumentsBuilder;
                        }
                    }

                    switch (chatCompletionUpdate.FinishReason)
                    {
                        case ChatFinishReason.Stop:
                            {
                                // Add the assistant message to the conversation history.
                                messages.Add(new AssistantChatMessage(contentBuilder.ToString()));
                                break;
                            }

                        case ChatFinishReason.ToolCalls:
                            {
                                // First, add the assistant message with tool calls to the conversation history.
                                List<ChatToolCall> toolCalls = new();

                                foreach (int index in indexToToolCallId.Keys)
                                {
                                    ChatToolCall toolCall = ChatToolCall.CreateFunctionToolCall(
                                        indexToToolCallId[index],
                                        indexToFunctionName[index],
                                        indexToFunctionArguments[index].ToString());

                                    toolCalls.Add(toolCall);
                                }

                                string content = contentBuilder.Length > 0
                                    ? contentBuilder.ToString()
                                    : null;

                                messages.Add(new AssistantChatMessage(toolCalls, content));

                                // Then, add a new tool message for each tool call that is resolved.
                                foreach (ChatToolCall toolCall in toolCalls)
                                {
                                    switch (toolCall.FunctionName)
                                    {
                                        case GetCurrentLocationFunctionName:
                                            {
                                                string toolResult = GetCurrentLocation();
                                                messages.Add(new ToolChatMessage(toolCall.Id, toolResult));
                                                break;
                                            }

                                        case GetCurrentWeatherFunctionName:
                                            {
                                                // The arguments that the model wants to use to call the function are specified as a
                                                // stringified JSON object based on the schema defined in the tool definition. Note that
                                                // the model may hallucinate arguments too. Consequently, it is important to do the
                                                // appropriate parsing and validation before calling the function.
                                                using JsonDocument argumentsJson = JsonDocument.Parse(toolCall.FunctionArguments);
                                                bool hasLocation = argumentsJson.RootElement.TryGetProperty("location", out JsonElement location);
                                                bool hasUnit = argumentsJson.RootElement.TryGetProperty("unit", out JsonElement unit);

                                                if (!hasLocation)
                                                {
                                                    throw new ArgumentNullException(nameof(location), "The location argument is required.");
                                                }

                                                string toolResult = hasUnit
                                                    ? GetCurrentWeather(location.GetString(), unit.GetString())
                                                    : GetCurrentWeather(location.GetString());
                                                messages.Add(new ToolChatMessage(toolCall.Id, toolResult));
                                                break;
                                            }

                                        default:
                                            {
                                                // Handle other unexpected calls.
                                                throw new NotImplementedException();
                                            }
                                    }
                                }

                                requiresAction = true;
                                break;
                            }

                        case ChatFinishReason.Length:
                            throw new NotImplementedException("Incomplete model output due to MaxTokens parameter or token limit exceeded.");

                        case ChatFinishReason.ContentFilter:
                            throw new NotImplementedException("Omitted content due to a content filter flag.");

                        case ChatFinishReason.FunctionCall:
                            throw new NotImplementedException("Deprecated in favor of tool calls.");

                        case null:
                            break;
                    }
                }
            } while (requiresAction);
            #endregion

            #region
            foreach (ChatMessage requestMessage in messages)
            {
                switch (requestMessage)
                {
                    case SystemChatMessage systemMessage:
                        Console.WriteLine($"[SYSTEM]:");
                        Console.WriteLine($"{systemMessage.Content[0].Text}");
                        Console.WriteLine();
                        break;

                    case UserChatMessage userMessage:
                        Console.WriteLine($"[USER]:");
                        Console.WriteLine($"{userMessage.Content[0].Text}");
                        Console.WriteLine();
                        break;

                    case AssistantChatMessage assistantMessage when assistantMessage.Content.Count > 0:
                        Console.WriteLine($"[ASSISTANT]:");
                        Console.WriteLine($"{assistantMessage.Content[0].Text}");
                        Console.WriteLine();
                        break;

                    case ToolChatMessage:
                        // Do not print any tool messages; let the assistant summarize the tool results instead.
                        break;

                    default:
                        break;
                }
            }
            #endregion
        }
    }
}
