using OpenAI.Chat;
using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.FineTuning;

[CodeGenSuppress("global::System.ClientModel.Primitives.IPersistableModel<OpenAI.FineTuning.InternalFineTuneChatCompletionRequestFunctionMessage>.Write", typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IPersistableModel<OpenAI.FineTuning.InternalFineTuneChatCompletionRequestFunctionMessage>.Create", typeof(BinaryData), typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IPersistableModel<OpenAI.FineTuning.InternalFineTuneChatCompletionRequestFunctionMessage>.GetFormatFromOptions", typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.FineTuning.InternalFineTuneChatCompletionRequestFunctionMessage>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.FineTuning.InternalFineTuneChatCompletionRequestFunctionMessage>.Create", typeof(Utf8JsonReader), typeof(ModelReaderWriterOptions))]
internal partial class InternalFineTuneChatCompletionRequestFunctionMessage : IJsonModel<InternalFineTuneChatCompletionRequestFunctionMessage>
{
    internal static void SerializeInternalFineTuneChatCompletionRequestFunctionMessage(InternalFineTuneChatCompletionRequestFunctionMessage instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => SerializeFunctionChatMessage(instance, writer, options);

    internal static InternalFineTuneChatCompletionRequestFunctionMessage DeserializeInternalFineTuneChatCompletionRequestFunctionMessage(JsonElement element, ModelReaderWriterOptions options = null)
    {
        FunctionChatMessage functionChatMessage = DeserializeFunctionChatMessage(element, options);
        return functionChatMessage == null
            ? null
            : new InternalFineTuneChatCompletionRequestFunctionMessage(
                functionChatMessage.Role,
                functionChatMessage.Content,
                new ChangeTrackingDictionary<string, BinaryData>(),
                functionChatMessage.FunctionName);
    }

    void IJsonModel<InternalFineTuneChatCompletionRequestFunctionMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, SerializeInternalFineTuneChatCompletionRequestFunctionMessage, writer, options);

    InternalFineTuneChatCompletionRequestFunctionMessage IJsonModel<InternalFineTuneChatCompletionRequestFunctionMessage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeInternalFineTuneChatCompletionRequestFunctionMessage, ref reader, options);

    BinaryData IPersistableModel<InternalFineTuneChatCompletionRequestFunctionMessage>.Write(ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, options);

    InternalFineTuneChatCompletionRequestFunctionMessage IPersistableModel<InternalFineTuneChatCompletionRequestFunctionMessage>.Create(BinaryData data, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeInternalFineTuneChatCompletionRequestFunctionMessage, data, options);

    string IPersistableModel<InternalFineTuneChatCompletionRequestFunctionMessage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}
