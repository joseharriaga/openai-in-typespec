using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Chat.ChatToolChoice>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public abstract partial class ChatToolChoice : IJsonModel<ChatToolChoice>
{
    void IJsonModel<ChatToolChoice>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, WriteCore, writer, options);

    internal static ChatToolChoice DeserializeChatToolChoice(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        if (element.ValueKind == JsonValueKind.String)
        {
            return new InternalClientOnlyChatCompletionToolChoiceOptionPredefined(element.GetString());
        }
        return InternalClientOnlyChatCompletionToolChoiceOptionNamed
            .DeserializeInternalClientOnlyChatCompletionToolChoiceOptionNamed(element, options);
    }

    internal static void WriteCore(ChatToolChoice instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        => instance.WriteCore(writer, options);

    internal abstract void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
}
