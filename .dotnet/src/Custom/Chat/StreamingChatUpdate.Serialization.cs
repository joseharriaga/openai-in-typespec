using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

public partial class StreamingChatUpdate : IJsonModel<IEnumerable<StreamingChatUpdate>>
{
    IEnumerable<StreamingChatUpdate> IJsonModel<IEnumerable<StreamingChatUpdate>>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeStreamingChatUpdates, ref reader, options);

    IEnumerable<StreamingChatUpdate> IPersistableModel<IEnumerable<StreamingChatUpdate>>.Create(BinaryData data, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.DeserializeNewInstance(this, DeserializeStreamingChatUpdates, data, options);

    void IJsonModel<IEnumerable<StreamingChatUpdate>>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance<IEnumerable<StreamingChatUpdate>, StreamingChatUpdate>(this, SerializeStreamingChatUpdates, writer, options);

    BinaryData IPersistableModel<IEnumerable<StreamingChatUpdate>>.Write(ModelReaderWriterOptions options)
        => ModelSerializationHelpers.SerializeInstance<IEnumerable<StreamingChatUpdate>, StreamingChatUpdate>(this, options);

    string IPersistableModel<IEnumerable<StreamingChatUpdate>>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static IEnumerable<StreamingChatUpdate> DeserializeStreamingChatUpdates(
        JsonElement sseDataJson,
        ModelReaderWriterOptions options = default)
    {
        List<StreamingChatUpdate> results = [];
        if (sseDataJson.ValueKind == JsonValueKind.Null)
        {
            return results;
        }
        string id = default;
        DateTimeOffset created = default;
        string systemFingerprint = null;
        foreach (JsonProperty property in sseDataJson.EnumerateObject())
        {
            if (property.NameEquals("id"u8))
            {
                id = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("created"u8))
            {
                created = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                continue;
            }
            if (property.NameEquals("system_fingerprint"))
            {
                systemFingerprint = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("choices"u8))
            {
                foreach (JsonElement choiceElement in property.Value.EnumerateArray())
                {
                    ChatRole? role = null;
                    string contentUpdate = null;
                    string functionName = null;
                    string functionArgumentsUpdate = null;
                    int choiceIndex = 0;
                    ChatFinishReason? finishReason = null;
                    List<StreamingToolCallUpdate> toolCallUpdates = [];
                    ChatLogProbabilityCollection logProbabilities = new([]);

                    foreach (JsonProperty choiceProperty in choiceElement.EnumerateObject())
                    {
                        if (choiceProperty.NameEquals("index"u8))
                        {
                            choiceIndex = choiceProperty.Value.GetInt32();
                            continue;
                        }
                        if (choiceProperty.NameEquals("finish_reason"u8))
                        {
                            if (choiceProperty.Value.ValueKind == JsonValueKind.Null)
                            {
                                finishReason = null;
                                continue;
                            }
                            finishReason = choiceProperty.Value.GetString() switch
                            {
                                "stop" => ChatFinishReason.Stopped,
                                "length" => ChatFinishReason.Length,
                                "tool_calls" => ChatFinishReason.ToolCalls,
                                "function_call" => ChatFinishReason.FunctionCall,
                                "content_filter" => ChatFinishReason.ContentFilter,
                                _ => throw new ArgumentException(nameof(finishReason)),
                            };
                            continue;
                        }
                        if (choiceProperty.NameEquals("delta"u8))
                        {
                            foreach (JsonProperty deltaProperty in choiceProperty.Value.EnumerateObject())
                            {
                                if (deltaProperty.NameEquals("role"u8))
                                {
                                    role = deltaProperty.Value.GetString() switch
                                    {
                                        "system" => ChatRole.System,
                                        "user" => ChatRole.User,
                                        "assistant" => ChatRole.Assistant,
                                        "tool" => ChatRole.Tool,
                                        "function" => ChatRole.Function,
                                        _ => throw new ArgumentException(nameof(role)),
                                    };
                                    continue;
                                }
                                if (deltaProperty.NameEquals("content"u8))
                                {
                                    contentUpdate = deltaProperty.Value.GetString();
                                    continue;
                                }
                                if (deltaProperty.NameEquals("function_call"u8))
                                {
                                    foreach (JsonProperty functionProperty in deltaProperty.Value.EnumerateObject())
                                    {
                                        if (functionProperty.NameEquals("name"u8))
                                        {
                                            functionName = functionProperty.Value.GetString();
                                            continue;
                                        }
                                        if (functionProperty.NameEquals("arguments"u8))
                                        {
                                            functionArgumentsUpdate = functionProperty.Value.GetString();
                                        }
                                    }
                                }
                                if (deltaProperty.NameEquals("tool_calls"))
                                {
                                    foreach (JsonElement toolCallElement in deltaProperty.Value.EnumerateArray())
                                    {
                                        toolCallUpdates.Add(
                                            StreamingToolCallUpdate.DeserializeStreamingToolCallUpdate(toolCallElement));
                                    }
                                }
                            }
                        }
                        if (choiceProperty.NameEquals("logprobs"u8))
                        {
                            Internal.Models.CreateChatCompletionResponseChoiceLogprobs internalLogprobs
                                = Internal.Models.CreateChatCompletionResponseChoiceLogprobs.DeserializeCreateChatCompletionResponseChoiceLogprobs(
                                    choiceProperty.Value);
                            logProbabilities = ChatLogProbabilityCollection.FromInternalData(internalLogprobs);
                        }
                    }
                    // In the unlikely event that more than one tool call arrives on a single chunk, we'll generate
                    // separate updates just like for choices. Adding a "null" if empty lets us avoid a separate loop.
                    if (toolCallUpdates.Count == 0)
                    {
                        toolCallUpdates.Add(null);
                    }
                    foreach (StreamingToolCallUpdate toolCallUpdate in toolCallUpdates)
                    {
                        results.Add(new StreamingChatUpdate(
                            id,
                            created,
                            systemFingerprint,
                            choiceIndex,
                            role,
                            contentUpdate,
                            finishReason,
                            functionName,
                            functionArgumentsUpdate,
                            toolCallUpdate));
                    }
                }
                continue;
            }
        }
        if (results.Count == 0)
        {
            results.Add(new StreamingChatUpdate(id, created, systemFingerprint));
        }
        return results;
    }

    internal static void SerializeStreamingChatUpdates(StreamingChatUpdate StreamingChatUpdate, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotSupportedException(nameof(StreamingChatUpdate));
    }
}
