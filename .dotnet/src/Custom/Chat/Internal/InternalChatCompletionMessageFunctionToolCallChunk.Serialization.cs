using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.InternalChatCompletionMessageFunctionToolCallChunk>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
internal partial class InternalChatCompletionMessageFunctionToolCallChunk : IJsonModel<InternalChatCompletionMessageFunctionToolCallChunk>
{
    void IJsonModel<InternalChatCompletionMessageFunctionToolCallChunk>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, WriteCore, writer, options);

    internal static void WriteCore(InternalChatCompletionMessageFunctionToolCallChunk instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.WriteCore(writer, options);

    internal override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        if (SerializedAdditionalRawData?.ContainsKey("index") != true)
        {
            writer.WritePropertyName("index"u8);
            writer.WriteNumberValue(Index);
        }
        if (SerializedAdditionalRawData?.ContainsKey("id") != true && Optional.IsDefined(Id))
        {
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
        }
        if (SerializedAdditionalRawData?.ContainsKey("function") != true && Optional.IsDefined(Function))
        {
            writer.WritePropertyName("function"u8);
            writer.WriteObjectValue(Function, options);
        }
        if (SerializedAdditionalRawData?.ContainsKey("type") != true)
        {
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Kind.ToString());
        }
        writer.WriteSerializedAdditionalRawData(SerializedAdditionalRawData, options);
        writer.WriteEndObject();
    }
}
