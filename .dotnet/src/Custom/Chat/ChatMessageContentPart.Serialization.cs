using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.ChatMessageContentPart>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class ChatMessageContentPart : IJsonModel<ChatMessageContentPart>
{
    void IJsonModel<ChatMessageContentPart>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, WriteCore, writer, options);

    internal static void WriteCore(ChatMessageContentPart instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.WriteCore(writer, options);

    internal abstract void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);

    internal static void WriteCoreContentPartList(IList<ChatMessageContentPart> instances, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (!Optional.IsCollectionDefined(instances))
        {
            return;
        }

        writer.WritePropertyName("content"u8);
        if (instances.Count == 1 && !string.IsNullOrEmpty(instances[0].Text))
        {
            writer.WriteStringValue(instances[0].Text);
        }
        else
        {
            writer.WriteStartArray();
            foreach (var item in instances)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
        }
    }
}
