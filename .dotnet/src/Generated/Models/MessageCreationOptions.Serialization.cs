// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Assistants
{
    public partial class MessageCreationOptions : IJsonModel<MessageCreationOptions>
    {
        void IJsonModel<MessageCreationOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MessageCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageCreationOptions)} does not support writing '{format}' format.");
            }
            if (Optional.IsCollectionDefined(Attachments) && _additionalBinaryDataProperties?.ContainsKey("attachments") != true)
            {
                if (Attachments != null)
                {
                    writer.WritePropertyName("attachments"u8);
                    writer.WriteStartArray();
                    foreach (MessageCreationAttachment item in Attachments)
                    {
                        writer.WriteObjectValue(item, options);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("attachments"u8);
                }
            }
            if (Optional.IsCollectionDefined(Metadata) && _additionalBinaryDataProperties?.ContainsKey("metadata") != true)
            {
                writer.WritePropertyName("metadata"u8);
                writer.WriteStartObject();
                foreach (var item in Metadata)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (_additionalBinaryDataProperties?.ContainsKey("role") != true)
            {
                writer.WritePropertyName("role"u8);
                writer.WriteStringValue(Role.ToSerialString());
            }
            if (_additionalBinaryDataProperties?.ContainsKey("content") != true)
            {
                writer.WritePropertyName("content"u8);
                this.SerializeContent(writer, options);
            }
            if (true && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
                {
                    if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                    {
                        continue;
                    }
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        MessageCreationOptions IJsonModel<MessageCreationOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual MessageCreationOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MessageCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(MessageCreationOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeMessageCreationOptions(document.RootElement, options);
        }

        internal static MessageCreationOptions DeserializeMessageCreationOptions(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<MessageCreationAttachment> attachments = default;
            IDictionary<string, string> metadata = default;
            Assistants.MessageRole role = default;
            IList<MessageContent> content = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("attachments"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MessageCreationAttachment> array = new List<MessageCreationAttachment>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(MessageCreationAttachment.DeserializeMessageCreationAttachment(item, options));
                    }
                    attachments = array;
                    continue;
                }
                if (prop.NameEquals("metadata"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(prop0.Name, prop0.Value.GetString());
                        }
                    }
                    metadata = dictionary;
                    continue;
                }
                if (prop.NameEquals("role"u8))
                {
                    role = prop.Value.GetString().ToMessageRole();
                    continue;
                }
                if (prop.NameEquals("content"u8))
                {
                    List<MessageContent> array = new List<MessageContent>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(MessageContent.DeserializeMessageContent(item, options));
                    }
                    content = array;
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new MessageCreationOptions(attachments ?? new ChangeTrackingList<MessageCreationAttachment>(), metadata ?? new ChangeTrackingDictionary<string, string>(), role, content, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<MessageCreationOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MessageCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(MessageCreationOptions)} does not support writing '{options.Format}' format.");
            }
        }

        MessageCreationOptions IPersistableModel<MessageCreationOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual MessageCreationOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<MessageCreationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeMessageCreationOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(MessageCreationOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<MessageCreationOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(MessageCreationOptions messageCreationOptions)
        {
            if (messageCreationOptions == null)
            {
                return null;
            }
            return BinaryContent.Create(messageCreationOptions, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator MessageCreationOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeMessageCreationOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
