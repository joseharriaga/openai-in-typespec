// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Batch
{
    internal partial class InternalBatchJob : IJsonModel<InternalBatchJob>
    {
        void IJsonModel<InternalBatchJob>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalBatchJob>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalBatchJob)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("object"u8);
            writer.WriteObjectValue<object>(Object, options);
            writer.WritePropertyName("endpoint"u8);
            writer.WriteStringValue(Endpoint);
            if (Optional.IsDefined(Errors))
            {
                writer.WritePropertyName("errors"u8);
                writer.WriteObjectValue(Errors, options);
            }
            writer.WritePropertyName("input_file_id"u8);
            writer.WriteStringValue(InputFileId);
            writer.WritePropertyName("completion_window"u8);
            writer.WriteStringValue(CompletionWindow);
            writer.WritePropertyName("status"u8);
            writer.WriteStringValue(Status.ToString());
            if (Optional.IsDefined(OutputFileId))
            {
                writer.WritePropertyName("output_file_id"u8);
                writer.WriteStringValue(OutputFileId);
            }
            if (Optional.IsDefined(ErrorFileId))
            {
                writer.WritePropertyName("error_file_id"u8);
                writer.WriteStringValue(ErrorFileId);
            }
            writer.WritePropertyName("created_at"u8);
            writer.WriteNumberValue(CreatedAt, "U");
            if (Optional.IsDefined(InProgressAt))
            {
                writer.WritePropertyName("in_progress_at"u8);
                writer.WriteNumberValue(InProgressAt.Value, "U");
            }
            if (Optional.IsDefined(ExpiresAt))
            {
                writer.WritePropertyName("expires_at"u8);
                writer.WriteNumberValue(ExpiresAt.Value, "U");
            }
            if (Optional.IsDefined(FinalizingAt))
            {
                writer.WritePropertyName("finalizing_at"u8);
                writer.WriteNumberValue(FinalizingAt.Value, "U");
            }
            if (Optional.IsDefined(CompletedAt))
            {
                writer.WritePropertyName("completed_at"u8);
                writer.WriteNumberValue(CompletedAt.Value, "U");
            }
            if (Optional.IsDefined(FailedAt))
            {
                writer.WritePropertyName("failed_at"u8);
                writer.WriteNumberValue(FailedAt.Value, "U");
            }
            if (Optional.IsDefined(ExpiredAt))
            {
                writer.WritePropertyName("expired_at"u8);
                writer.WriteNumberValue(ExpiredAt.Value, "U");
            }
            if (Optional.IsDefined(CancellingAt))
            {
                writer.WritePropertyName("cancelling_at"u8);
                writer.WriteNumberValue(CancellingAt.Value, "U");
            }
            if (Optional.IsDefined(CancelledAt))
            {
                writer.WritePropertyName("cancelled_at"u8);
                writer.WriteNumberValue(CancelledAt.Value, "U");
            }
            if (Optional.IsDefined(RequestCounts))
            {
                writer.WritePropertyName("request_counts"u8);
                writer.WriteObjectValue(RequestCounts, options);
            }
            if (Optional.IsCollectionDefined(Metadata))
            {
                if (Metadata != null)
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

        InternalBatchJob IJsonModel<InternalBatchJob>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalBatchJob>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalBatchJob)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalBatchJob(document.RootElement, options);
        }

        internal static InternalBatchJob DeserializeInternalBatchJob(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            object @object = default;
            string endpoint = default;
            InternalBatchErrors errors = default;
            string inputFileId = default;
            string completionWindow = default;
            InternalBatchJobStatus status = default;
            string outputFileId = default;
            string errorFileId = default;
            DateTimeOffset createdAt = default;
            DateTimeOffset? inProgressAt = default;
            DateTimeOffset? expiresAt = default;
            DateTimeOffset? finalizingAt = default;
            DateTimeOffset? completedAt = default;
            DateTimeOffset? failedAt = default;
            DateTimeOffset? expiredAt = default;
            DateTimeOffset? cancellingAt = default;
            DateTimeOffset? cancelledAt = default;
            InternalBatchRequestCounts? requestCounts = default;
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
                if (property.NameEquals("endpoint"u8))
                {
                    endpoint = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("errors"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    errors = InternalBatchErrors.DeserializeInternalBatchErrors(property.Value, options);
                    continue;
                }
                if (property.NameEquals("input_file_id"u8))
                {
                    inputFileId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("completion_window"u8))
                {
                    completionWindow = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new InternalBatchJobStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("output_file_id"u8))
                {
                    outputFileId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("error_file_id"u8))
                {
                    errorFileId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("in_progress_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    inProgressAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("expires_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    expiresAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("finalizing_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    finalizingAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("completed_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    completedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("failed_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failedAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("expired_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    expiredAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("cancelling_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cancellingAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("cancelled_at"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    cancelledAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("request_counts"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    requestCounts = InternalBatchRequestCounts.DeserializeInternalBatchRequestCounts(property.Value, options);
                    continue;
                }
                if (property.NameEquals("metadata"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
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
            return new InternalBatchJob(
                id,
                @object,
                endpoint,
                errors,
                inputFileId,
                completionWindow,
                status,
                outputFileId,
                errorFileId,
                createdAt,
                inProgressAt,
                expiresAt,
                finalizingAt,
                completedAt,
                failedAt,
                expiredAt,
                cancellingAt,
                cancelledAt,
                requestCounts,
                metadata ?? new ChangeTrackingDictionary<string, string>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalBatchJob>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalBatchJob>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalBatchJob)} does not support writing '{options.Format}' format.");
            }
        }

        InternalBatchJob IPersistableModel<InternalBatchJob>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalBatchJob>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalBatchJob(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalBatchJob)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalBatchJob>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static InternalBatchJob FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalBatchJob(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
