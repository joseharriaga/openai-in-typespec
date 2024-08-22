// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Files
{
    public partial class OpenAIFileInfo : IJsonModel<OpenAIFileInfo>
    {
        void IJsonModel<OpenAIFileInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OpenAIFileInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OpenAIFileInfo)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("id") != true)
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(Id);
            }
            if (SerializedAdditionalRawData?.ContainsKey("bytes") != true)
            {
                if (SizeInBytes != null)
                {
                    writer.WritePropertyName("bytes"u8);
                    writer.WriteNumberValue(SizeInBytes.Value);
                }
                else
                {
                    writer.WriteNull("bytes");
                }
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
            if (SerializedAdditionalRawData?.ContainsKey("object") != true)
            {
                writer.WritePropertyName("object"u8);
                writer.WriteStringValue(Object.ToString());
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
            if (SerializedAdditionalRawData?.ContainsKey("status_details") != true && Optional.IsDefined(StatusDetails))
            {
                writer.WritePropertyName("status_details"u8);
                writer.WriteStringValue(StatusDetails);
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

        OpenAIFileInfo IJsonModel<OpenAIFileInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OpenAIFileInfo>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OpenAIFileInfo)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOpenAIFileInfo(document.RootElement, options);
        }

        internal static OpenAIFileInfo DeserializeOpenAIFileInfo(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            long? bytes = default;
            DateTimeOffset createdAt = default;
            string filename = default;
            InternalOpenAIFileObject @object = default;
            OpenAIFilePurpose purpose = default;
            OpenAIFileStatus status = default;
            string statusDetails = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("bytes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        bytes = null;
                        continue;
                    }
                    bytes = property.Value.GetInt64();
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
                if (property.NameEquals("object"u8))
                {
                    @object = new InternalOpenAIFileObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("purpose"u8))
                {
                    purpose = new OpenAIFilePurpose(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = new OpenAIFileStatus(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("status_details"u8))
                {
                    statusDetails = property.Value.GetString();
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new OpenAIFileInfo(
                id,
                bytes,
                createdAt,
                filename,
                @object,
                purpose,
                status,
                statusDetails,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<OpenAIFileInfo>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OpenAIFileInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(OpenAIFileInfo)} does not support writing '{options.Format}' format.");
            }
        }

        OpenAIFileInfo IPersistableModel<OpenAIFileInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OpenAIFileInfo>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeOpenAIFileInfo(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OpenAIFileInfo)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<OpenAIFileInfo>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static OpenAIFileInfo FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeOpenAIFileInfo(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
