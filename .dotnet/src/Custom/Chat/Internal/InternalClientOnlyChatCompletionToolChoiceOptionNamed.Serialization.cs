using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.InternalClientOnlyChatCompletionToolChoiceOptionNamed>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
internal partial class InternalClientOnlyChatCompletionToolChoiceOptionNamed : IJsonModel<InternalClientOnlyChatCompletionToolChoiceOptionNamed>
{
    void IJsonModel<InternalClientOnlyChatCompletionToolChoiceOptionNamed>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, WriteCore, writer, options);

    internal static void WriteCore(InternalClientOnlyChatCompletionToolChoiceOptionNamed instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.WriteCore(writer, options);

    internal override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        if (SerializedAdditionalRawData?.ContainsKey("type") != true)
        {
            writer.WritePropertyName("type"u8);
            writer.WriteStringValue(Type.ToString());
        }
        if (SerializedAdditionalRawData?.ContainsKey("function") != true)
        {
            writer.WritePropertyName("function"u8);
            writer.WriteObjectValue(Function, options);
        }
        writer.WriteSerializedAdditionalRawData(SerializedAdditionalRawData, options);
        writer.WriteEndObject();
    }
}
