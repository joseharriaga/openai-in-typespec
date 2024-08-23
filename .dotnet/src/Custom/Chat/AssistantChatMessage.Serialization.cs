using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.AssistantChatMessage>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class AssistantChatMessage : IJsonModel<AssistantChatMessage>
{
    void IJsonModel<AssistantChatMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeAssistantChatMessage, writer, options);

    internal static void SerializeAssistantChatMessage(AssistantChatMessage instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.WriteCore(writer, options);

    protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        if (Optional.IsDefined(ParticipantName))
        {
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(ParticipantName);
        }
        if (Optional.IsCollectionDefined(ToolCalls))
        {
            writer.WritePropertyName("tool_calls"u8);
            writer.WriteStartArray();
            foreach (var item in ToolCalls)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
        }
        if (Optional.IsDefined(FunctionCall))
        {
            if (FunctionCall != null)
            {
                writer.WritePropertyName("function_call"u8);
                writer.WriteObjectValue(FunctionCall, options);
            }
            else
            {
                writer.WriteNull("function_call");
            }
        }
        writer.WritePropertyName("role"u8);
        writer.WriteStringValue(Role);
        if (Optional.IsCollectionDefined(Content))
        {
            ChatMessageContentPart.WriteCoreContentPartList(Content, writer, options);
        }
        if (Optional.IsDefined(Refusal))
        {
            writer.WritePropertyName("refusal"u8);
            writer.WriteStringValue(Refusal);
        }
        writer.WriteSerializedAdditionalRawData(SerializedAdditionalRawData, options);
        writer.WriteEndObject();
    }
}
