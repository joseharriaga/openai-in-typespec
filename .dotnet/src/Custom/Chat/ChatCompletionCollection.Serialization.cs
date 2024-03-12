using System;
using OpenAI.ClientShared.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

public partial class ChatCompletionCollection : IJsonModel<ChatCompletionCollection>
{
    void IJsonModel<ChatCompletionCollection>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionCollection>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ChatCompletionCollection)} does not support '{format}' format.");
        }
        throw new NotImplementedException();
    }

    ChatCompletionCollection IJsonModel<ChatCompletionCollection>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionCollection>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ChatCompletionCollection)} does not support '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeChatCompletionCollection(document.RootElement, options);
    }

    BinaryData IPersistableModel<ChatCompletionCollection>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionCollection>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options);
            default:
                throw new FormatException($"The model {nameof(ChatCompletionCollection)} does not support '{options.Format}' format.");
        }

        throw new NotImplementedException();
    }

    ChatCompletionCollection IPersistableModel<ChatCompletionCollection>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionCollection>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeChatCompletionCollection(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(ChatCompletionCollection)} does not support '{options.Format}' format.");
        }
    }

    string IPersistableModel<ChatCompletionCollection>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    protected static virtual ChatCompletionCollection DeserializeChatCompletionCollection(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= new ModelReaderWriterOptions("W");

        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }

        Internal.Models.CreateChatCompletionResponse internalResponse
            = Internal.Models.CreateChatCompletionResponse.DeserializeCreateChatCompletionResponse(element, options);

        List<ChatCompletion> completions = [];
        for (int i = 0; i < internalResponse.Choices.Count; i++)
        {
            completions.Add(new(internalResponse, internalResponse.Choices[i].Index));
        }
        return new(completions);
    }
}
