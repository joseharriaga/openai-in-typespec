// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Chat
{
    public partial class FunctionChatMessage : IJsonModel<FunctionChatMessage>
    {
        internal FunctionChatMessage()
        {
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FunctionChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FunctionChatMessage)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (_additionalBinaryDataProperties?.ContainsKey("name") != true)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(FunctionName);
            }
        }

        FunctionChatMessage IJsonModel<FunctionChatMessage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (FunctionChatMessage)JsonModelCreateCore(ref reader, options);

        protected override ChatMessage JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FunctionChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(FunctionChatMessage)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFunctionChatMessage(document.RootElement, options);
        }

        internal static FunctionChatMessage DeserializeFunctionChatMessage(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string functionName = default;
            Chat.ChatMessageRole role = default;
            ChatMessageContent content = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    functionName = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("role"u8))
                {
                    role = prop.Value.GetString().ToChatMessageRole();
                    continue;
                }
                if (prop.NameEquals("content"u8))
                {
                    DeserializeContentValue(prop, ref content);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new FunctionChatMessage(functionName, role, content, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<FunctionChatMessage>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FunctionChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(FunctionChatMessage)} does not support writing '{options.Format}' format.");
            }
        }

        FunctionChatMessage IPersistableModel<FunctionChatMessage>.Create(BinaryData data, ModelReaderWriterOptions options) => (FunctionChatMessage)PersistableModelCreateCore(data, options);

        protected override ChatMessage PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<FunctionChatMessage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeFunctionChatMessage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(FunctionChatMessage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<FunctionChatMessage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(FunctionChatMessage functionChatMessage)
        {
            if (functionChatMessage == null)
            {
                return null;
            }
            return BinaryContent.Create(functionChatMessage, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator FunctionChatMessage(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeFunctionChatMessage(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
