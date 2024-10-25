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
    public partial class ThreadMessage : IJsonModel<ThreadMessage>
    {
        internal ThreadMessage()
        {
        }

        void IJsonModel<ThreadMessage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ThreadMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ThreadMessage)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
            }
            writer.WriteStringValue(Id);
            if (_additionalBinaryDataProperties?.ContainsKey("created_at") != true)
            {
                writer.WritePropertyName("created_at"u8);
            }
            writer.WriteNumberValue(CreatedAt, "U");
            if (_additionalBinaryDataProperties?.ContainsKey("thread_id") != true)
            {
                writer.WritePropertyName("thread_id"u8);
            }
            writer.WriteStringValue(ThreadId);
            if (_additionalBinaryDataProperties?.ContainsKey("status") != true)
            {
                writer.WritePropertyName("status"u8);
            }
            writer.WriteStringValue(Status.ToString());
            if (_additionalBinaryDataProperties?.ContainsKey("incomplete_details") != true)
            {
                if (IncompleteDetails != null)
                {
                    writer.WritePropertyName("incomplete_details"u8);
                    writer.WriteObjectValue(IncompleteDetails, options);
                }
                else
                {
                    writer.WriteNull("incompleteDetails"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("completed_at") != true)
            {
                if (CompletedAt != null)
                {
                    writer.WritePropertyName("completed_at"u8);
                    writer.WriteNumberValue(CompletedAt.Value, "U");
                }
                else
                {
                    writer.WriteNull("completedAt"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("incomplete_at") != true)
            {
                if (IncompleteAt != null)
                {
                    writer.WritePropertyName("incomplete_at"u8);
                    writer.WriteNumberValue(IncompleteAt.Value, "U");
                }
                else
                {
                    writer.WriteNull("incompleteAt"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("content") != true)
            {
                writer.WritePropertyName("content"u8);
            }
            writer.WriteStartArray();
            foreach (MessageContent item in Content)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
            if (_additionalBinaryDataProperties?.ContainsKey("assistant_id") != true)
            {
                if (AssistantId != null)
                {
                    writer.WritePropertyName("assistant_id"u8);
                    writer.WriteStringValue(AssistantId);
                }
                else
                {
                    writer.WriteNull("assistantId"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("run_id") != true)
            {
                if (RunId != null)
                {
                    writer.WritePropertyName("run_id"u8);
                    writer.WriteStringValue(RunId);
                }
                else
                {
                    writer.WriteNull("runId"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("metadata") != true)
            {
                if (Metadata != null && Optional.IsCollectionDefined(Metadata))
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
                else
                {
                    writer.WriteNull("metadata"u8);
                }
            }
            if (_additionalBinaryDataProperties?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
            }
            writer.WriteStringValue(this.Object.ToString());
            if (_additionalBinaryDataProperties?.ContainsKey("role") != true)
            {
                writer.WritePropertyName("role"u8);
            }
            writer.WriteStringValue(Role.ToSerialString());
            if (_additionalBinaryDataProperties?.ContainsKey("attachments") != true)
            {
                if (Attachments != null && Optional.IsCollectionDefined(Attachments))
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

        ThreadMessage IJsonModel<ThreadMessage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ThreadMessage JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ThreadMessage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ThreadMessage)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeThreadMessage(document.RootElement, options);
        }

        internal static ThreadMessage DeserializeThreadMessage(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            DateTimeOffset createdAt = default;
            string threadId = default;
            MessageStatus status = default;
            MessageFailureDetails incompleteDetails = default;
            DateTimeOffset? completedAt = default;
            DateTimeOffset? incompleteAt = default;
            IList<MessageContent> content = default;
            string assistantId = default;
            string runId = default;
            IDictionary<string, string> metadata = default;
            InternalMessageObjectObject @object = default;
            Assistants.MessageRole role = default;
            IReadOnlyList<MessageCreationAttachment> attachments = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    continue;
                }
                if (prop.NameEquals("thread_id"u8))
                {
                    threadId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("status"u8))
                {
                    status = new MessageStatus(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("incomplete_details"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        incompleteDetails = null;
                        continue;
                    }
                    incompleteDetails = MessageFailureDetails.DeserializeMessageFailureDetails(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("completed_at"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        completedAt = null;
                        continue;
                    }
                    completedAt = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
                    continue;
                }
                if (prop.NameEquals("incomplete_at"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        incompleteAt = null;
                        continue;
                    }
                    incompleteAt = DateTimeOffset.FromUnixTimeSeconds(prop.Value.GetInt64());
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
                if (prop.NameEquals("assistant_id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        assistantId = null;
                        continue;
                    }
                    assistantId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("run_id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        runId = null;
                        continue;
                    }
                    runId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("metadata"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        metadata = new ChangeTrackingDictionary<string, string>();
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
                if (prop.NameEquals("object"u8))
                {
                    @object = new InternalMessageObjectObject(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("role"u8))
                {
                    role = prop.Value.GetString().ToMessageRole();
                    continue;
                }
                if (prop.NameEquals("attachments"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        attachments = new ChangeTrackingList<MessageCreationAttachment>();
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
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ThreadMessage(
                id,
                createdAt,
                threadId,
                status,
                incompleteDetails,
                completedAt,
                incompleteAt,
                content,
                assistantId,
                runId,
                metadata,
                @object,
                role,
                attachments,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ThreadMessage>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ThreadMessage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ThreadMessage)} does not support writing '{options.Format}' format.");
            }
        }

        ThreadMessage IPersistableModel<ThreadMessage>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ThreadMessage PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ThreadMessage>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeThreadMessage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ThreadMessage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ThreadMessage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ThreadMessage threadMessage)
        {
            return BinaryContent.Create(threadMessage, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ThreadMessage(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeThreadMessage(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
