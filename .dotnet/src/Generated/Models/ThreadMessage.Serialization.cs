// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Models;

namespace OpenAI.Internal.Models
{
    internal partial class ThreadMessage : IJsonModel<ThreadMessage>
    {
        void IJsonModel<ThreadMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ThreadMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ThreadMessage)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("object"u8);
            writer.WriteObjectValue<object>(Object, options);
            writer.WritePropertyName("created_at"u8);
            writer.WriteNumberValue(CreatedAt, "U");
            writer.WritePropertyName("thread_id"u8);
            writer.WriteStringValue(ThreadId);
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status.ToString());
            if (IncompleteDetails != null)
            {
                writer.WritePropertyName("incomplete_details"u8);
                writer.WriteObjectValue(IncompleteDetails, options);
            }
            else
            {
                writer.WriteNull("incomplete_details");
            }
            if (CompletedAt != null)
            {
                writer.WritePropertyName("completed_at"u8);
                writer.WriteStringValue(CompletedAt.Value, "O");
            }
            else
            {
                writer.WriteNull("completed_at");
            }
            if (IncompleteAt != null)
            {
                writer.WritePropertyName("incomplete_at"u8);
                writer.WriteStringValue(IncompleteAt.Value, "O");
            }
            else
            {
                writer.WriteNull("incomplete_at");
            }
            writer.WritePropertyName("role"u8);
            writer.WriteStringValue(Role.ToString());
            writer.WritePropertyName("content"u8);
            writer.WriteStartArray();
            foreach (var item in Content)
            {
                if (item == null)
                {
                    writer.WriteNullValue();
                    continue;
                }
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item);
#else
                using (JsonDocument document = JsonDocument.Parse(item))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            writer.WriteEndArray();
            if (AssistantId != null)
            {
                writer.WritePropertyName("assistant_id"u8);
                writer.WriteStringValue(AssistantId);
            }
            else
            {
                writer.WriteNull("assistant_id");
            }
            if (RunId != null)
            {
                writer.WritePropertyName("run_id"u8);
                writer.WriteStringValue(RunId);
            }
            else
            {
                writer.WriteNull("run_id");
            }
            if (Attachments != null && Optional.IsCollectionDefined(Attachments))
            {
                writer.WritePropertyName("attachments"u8);
                writer.WriteStartArray();
                foreach (var item in Attachments)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("attachments");
            }
            if (Metadata != null && Optional.IsCollectionDefined(Metadata))
            {
                writer.WritePropertyName("metadata"u8);
                writer.WriteStartObject();
                foreach (var item in Metadata)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNull("metadata");
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
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
            writer.WriteEndObject();
        }

        ThreadMessage IJsonModel<ThreadMessage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ThreadMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ThreadMessage)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeThreadMessage(document.RootElement, options);
        }

        internal static ThreadMessage DeserializeThreadMessage(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            object @object = default;
            DateTimeOffset createdAt = default;
            string threadId = default;
            ThreadMessageStatus status = default;
            MessageObjectIncompleteDetails incompleteDetails = default;
            DateTimeOffset? completedAt = default;
            DateTimeOffset? incompleteAt = default;
            ThreadMessageRole role = default;
            IReadOnlyList<BinaryData> content = default;
            string assistantId = default;
            string runId = default;
            IReadOnlyList<MessageObjectAttachment> attachments = default;
            IReadOnlyDictionary<string, string> metadata = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = property.Value.GetObject();
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("thread_id"u8))
                {
                    threadId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new ThreadMessageStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("incomplete_details"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        incompleteDetails = null;
                        continue;
                    }
                    incompleteDetails = MessageObjectIncompleteDetails.DeserializeMessageObjectIncompleteDetails(property.Value, options);
                    continue;
                }
                if (property.NameEquals("completed_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        completedAt = null;
                        continue;
                    }
                    completedAt = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("incomplete_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        incompleteAt = null;
                        continue;
                    }
                    incompleteAt = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("role"u8))
                {
                    role = new ThreadMessageRole(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("content"u8))
                {
                    List<BinaryData> array = new List<BinaryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(BinaryData.FromString(item.GetRawText()));
                        }
                    }
                    content = array;
                    continue;
                }
                if (property.NameEquals("assistant_id"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        assistantId = null;
                        continue;
                    }
                    assistantId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("run_id"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        runId = null;
                        continue;
                    }
                    runId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("attachments"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        attachments = new ChangeTrackingList<MessageObjectAttachment>();
                        continue;
                    }
                    List<MessageObjectAttachment> array = new List<MessageObjectAttachment>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MessageObjectAttachment.DeserializeMessageObjectAttachment(item, options));
                    }
                    attachments = array;
                    continue;
                }
                if (property.NameEquals("metadata"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        metadata = new ChangeTrackingDictionary<string, string>();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    metadata = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ThreadMessage(
                id,
                @object,
                createdAt,
                threadId,
                status,
                incompleteDetails,
                completedAt,
                incompleteAt,
                role,
                content,
                assistantId,
                runId,
                attachments,
                metadata,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<ThreadMessage>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ThreadMessage>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ThreadMessage)} does not support writing '{options.Format}' format.");
            }
        }

        ThreadMessage IPersistableModel<ThreadMessage>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ThreadMessage>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeThreadMessage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ThreadMessage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ThreadMessage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static ThreadMessage FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeThreadMessage(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
