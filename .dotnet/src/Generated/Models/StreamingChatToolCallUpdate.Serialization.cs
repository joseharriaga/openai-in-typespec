// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat
{
    [PersistableModelProxy(typeof(InternalUnknownChatCompletionMessageToolCallChunk))]
    public partial class StreamingChatToolCallUpdate : IJsonModel<StreamingChatToolCallUpdate>
    {
        StreamingChatToolCallUpdate IJsonModel<StreamingChatToolCallUpdate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StreamingChatToolCallUpdate>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(StreamingChatToolCallUpdate)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeStreamingChatToolCallUpdate(document.RootElement, options);
        }

        BinaryData IPersistableModel<StreamingChatToolCallUpdate>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StreamingChatToolCallUpdate>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(StreamingChatToolCallUpdate)} does not support writing '{options.Format}' format.");
            }
        }

        StreamingChatToolCallUpdate IPersistableModel<StreamingChatToolCallUpdate>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<StreamingChatToolCallUpdate>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeStreamingChatToolCallUpdate(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(StreamingChatToolCallUpdate)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<StreamingChatToolCallUpdate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static StreamingChatToolCallUpdate FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeStreamingChatToolCallUpdate(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
