using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.InternalChatCompletionMessageFunctionToolCall>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
internal partial class InternalChatCompletionMessageFunctionToolCall : IJsonModel<InternalChatCompletionMessageFunctionToolCall>
{
    void IJsonModel<InternalChatCompletionMessageFunctionToolCall>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, WriteCore, writer, options);

    internal static void WriteCore(InternalChatCompletionMessageFunctionToolCall instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.WriteCore(writer, options);

    internal override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        if (SerializedAdditionalRawData?.ContainsKey("id") != true)
        {
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
        }
        if (SerializedAdditionalRawData?.ContainsKey("function") != true)
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
