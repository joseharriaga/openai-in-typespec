// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.OpenAI;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary></summary>
    public partial class ChatMessageContext : IJsonModel<ChatMessageContext>
    {
        void IJsonModel<ChatMessageContext>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatMessageContext>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatMessageContext)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Intent) && _additionalBinaryDataProperties?.ContainsKey("intent") != true)
            {
                writer.WritePropertyName("intent"u8);
                writer.WriteStringValue(Intent);
            }
            if (Optional.IsCollectionDefined(Citations) && _additionalBinaryDataProperties?.ContainsKey("citations") != true)
            {
                writer.WritePropertyName("citations"u8);
                writer.WriteStartArray();
                foreach (ChatCitation item in Citations)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(RetrievedDocuments) && _additionalBinaryDataProperties?.ContainsKey("all_retrieved_documents") != true)
            {
                writer.WritePropertyName("all_retrieved_documents"u8);
                writer.WriteObjectValue<ChatRetrievedDocument>(RetrievedDocuments, options);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
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

        ChatMessageContext IJsonModel<ChatMessageContext>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ChatMessageContext JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatMessageContext>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ChatMessageContext)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeChatMessageContext(document.RootElement, options);
        }

        internal static ChatMessageContext DeserializeChatMessageContext(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string intent = default;
            IList<ChatCitation> citations = default;
            ChatRetrievedDocument retrievedDocuments = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("intent"u8))
                {
                    intent = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("citations"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatCitation> array = new List<ChatCitation>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ChatCitation.DeserializeChatCitation(item, options));
                    }
                    citations = array;
                    continue;
                }
                if (prop.NameEquals("all_retrieved_documents"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    retrievedDocuments = ChatRetrievedDocument.DeserializeChatRetrievedDocument(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ChatMessageContext(intent, citations ?? new ChangeTrackingList<ChatCitation>(), retrievedDocuments, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ChatMessageContext>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatMessageContext>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ChatMessageContext)} does not support writing '{options.Format}' format.");
            }
        }

        ChatMessageContext IPersistableModel<ChatMessageContext>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ChatMessageContext PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ChatMessageContext>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeChatMessageContext(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ChatMessageContext)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ChatMessageContext>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <param name="chatMessageContext"> The <see cref="ChatMessageContext"/> to serialize into <see cref="BinaryContent"/>. </param>
        public static implicit operator BinaryContent(ChatMessageContext chatMessageContext)
        {
            if (chatMessageContext == null)
            {
                return null;
            }
            return BinaryContent.Create(chatMessageContext, ModelSerializationExtensions.WireOptions);
        }

        /// <param name="result"> The <see cref="ClientResult"/> to deserialize the <see cref="ChatMessageContext"/> from. </param>
        public static explicit operator ChatMessageContext(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeChatMessageContext(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
