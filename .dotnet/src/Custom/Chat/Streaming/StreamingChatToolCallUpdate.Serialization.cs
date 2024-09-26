using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.StreamingChatToolCallUpdate>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class StreamingChatToolCallUpdate : IJsonModel<StreamingChatToolCallUpdate>
{
    void IJsonModel<StreamingChatToolCallUpdate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, WriteCore, writer, options);

    internal static void WriteCore(StreamingChatToolCallUpdate instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.WriteCore(writer, options);

    internal abstract void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);

    internal static StreamingChatToolCallUpdate DeserializeStreamingChatToolCallUpdate(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        if (element.TryGetProperty("type", out JsonElement discriminator))
        {
            switch (discriminator.GetString())
            {
                case "function": return InternalChatCompletionMessageFunctionToolCallChunk.DeserializeInternalChatCompletionMessageFunctionToolCallChunk(element, options);
            }
        }
        else if (element.TryGetProperty("function", out JsonElement _))
        {
            return InternalChatCompletionMessageFunctionToolCallChunk.DeserializeInternalChatCompletionMessageFunctionToolCallChunk(element, options);
        }
        return InternalUnknownChatCompletionMessageToolCallChunk.DeserializeInternalUnknownChatCompletionMessageToolCallChunk(element, options);
    }
}
