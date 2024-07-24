// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Files
{
    internal partial class InternalUploadJobInfo : IJsonModel<InternalUploadJobInfo>
    {
        void IJsonModel<InternalUploadJobInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalUploadJobInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalUploadJobInfo)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (SerializedAdditionalRawData?.ContainsKey("created_at") != true)
            {
                writer.WritePropertyName("created_at"u8);
                writer.WriteNumberValue(CreatedAt, "U");
            }
            if (SerializedAdditionalRawData?.ContainsKey("filename") != true)
            {
                writer.WritePropertyName("filename"u8);
                writer.WriteStringValue(Filename);
            }
            if (SerializedAdditionalRawData?.ContainsKey("bytes") != true)
            {
                writer.WritePropertyName("bytes"u8);
                writer.WriteNumberValue(TotalSize);
            }
            if (SerializedAdditionalRawData?.ContainsKey("purpose") != true)
            {
                writer.WritePropertyName("purpose"u8);
                writer.WriteStringValue(Purpose.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("status") != true)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("expires_at") != true)
            {
                writer.WritePropertyName("expires_at"u8);
                writer.WriteNumberValue(ExpiresAt, "U");
            }
            if (SerializedAdditionalRawData?.ContainsKey("object") != true && Optional.IsDefined(Object))
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object.Value.ToString());
            }
            if (SerializedAdditionalRawData?.ContainsKey("file") != true && Optional.IsDefined(File))
            {
                if (File != null)
                {
                    writer.WritePropertyName("file"u8);
                    writer.WriteObjectValue(File, options);
                }
                else
                {
                    writer.WriteNull("file");
                }
            }
            if (SerializedAdditionalRawData != null)
            {
                foreach (var item in SerializedAdditionalRawData)
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
            writer.WriteEndObject();
        }

        InternalUploadJobInfo IJsonModel<InternalUploadJobInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalUploadJobInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalUploadJobInfo)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalUploadJobInfo(document.RootElement, options);
        }

        internal static InternalUploadJobInfo DeserializeInternalUploadJobInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            DateTimeOffset createdAt = default;
            string filename = default;
            long bytes = default;
            InternalCreateUploadRequestPurpose purpose = default;
            InternalUploadStatus status = default;
            DateTimeOffset expiresAt = default;
            InternalUploadObject? @object = default;
            OpenAIFileInfo file = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("filename"u8))
                {
                    filename = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("bytes"u8))
                {
                    bytes = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("purpose"u8))
                {
                    purpose = new InternalCreateUploadRequestPurpose(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new InternalUploadStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("expires_at"u8))
                {
                    expiresAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    @object = new InternalUploadObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("file"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        file = null;
                        continue;
                    }
                    file = OpenAIFileInfo.DeserializeOpenAIFileInfo(property.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalUploadJobInfo(
                id,
                createdAt,
                filename,
                bytes,
                purpose,
                status,
                expiresAt,
                @object,
                file,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalUploadJobInfo>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalUploadJobInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalUploadJobInfo)} does not support writing '{options.Format}' format.");
            }
        }

        InternalUploadJobInfo IPersistableModel<InternalUploadJobInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalUploadJobInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalUploadJobInfo(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalUploadJobInfo)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalUploadJobInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalUploadJobInfo FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalUploadJobInfo(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
