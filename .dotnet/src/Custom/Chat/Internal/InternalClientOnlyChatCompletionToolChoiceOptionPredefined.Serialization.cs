using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.InternalClientOnlyChatCompletionToolChoiceOptionPredefined>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
internal partial class InternalClientOnlyChatCompletionToolChoiceOptionPredefined : IJsonModel<InternalClientOnlyChatCompletionToolChoiceOptionPredefined>
{
    void IJsonModel<InternalClientOnlyChatCompletionToolChoiceOptionPredefined>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, WriteCore, writer, options);

    internal static void WriteCore(InternalClientOnlyChatCompletionToolChoiceOptionPredefined instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.WriteCore(writer, options);

    internal override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (SerializedAdditionalRawData?.ContainsKey("value") != true)
        {
            writer.WriteStringValue(Value.ToString());
        }
    }
}
