// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Images
{
    public partial class ImageGenerationOptions : IJsonModel<ImageGenerationOptions>
    {
        void IJsonModel<ImageGenerationOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ImageGenerationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ImageGenerationOptions)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Quality))
            {
                writer.WritePropertyName("quality"u8);
                writer.WriteStringValue(Quality.Value.ToString());
            }
            if (Optional.IsDefined(ResponseFormat))
            {
                if (ResponseFormat != null)
                {
                    writer.WritePropertyName("response_format"u8);
                    writer.WriteStringValue(ResponseFormat.Value.ToString());
                }
                else
                {
                    writer.WriteNull("responseFormat"u8);
                }
            }
            if (Optional.IsDefined(Size))
            {
                if (Size != null)
                {
                    writer.WritePropertyName("size"u8);
                    writer.WriteStringValue(Size.Value.ToString());
                }
                else
                {
                    writer.WriteNull("size"u8);
                }
            }
            if (Optional.IsDefined(Style))
            {
                if (Style != null)
                {
                    writer.WritePropertyName("style"u8);
                    writer.WriteStringValue(Style.Value.ToString());
                }
                else
                {
                    writer.WriteNull("style"u8);
                }
            }
            if (Optional.IsDefined(Model))
            {
                if (Model != null)
                {
                    writer.WritePropertyName("model"u8);
                    writer.WriteStringValue(Model.Value.ToString());
                }
                else
                {
                    writer.WriteNull("model"u8);
                }
            }
            writer.WritePropertyName("prompt"u8);
            writer.WriteStringValue(Prompt);
            if (Optional.IsDefined(N))
            {
                if (N != null)
                {
                    writer.WritePropertyName("n"u8);
                    writer.WriteNumberValue(N.Value);
                }
                else
                {
                    writer.WriteNull("n"u8);
                }
            }
            if (Optional.IsDefined(EndUserId))
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(EndUserId);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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
        }

        ImageGenerationOptions IJsonModel<ImageGenerationOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ImageGenerationOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ImageGenerationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ImageGenerationOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeImageGenerationOptions(document.RootElement, options);
        }

        internal static ImageGenerationOptions DeserializeImageGenerationOptions(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            GeneratedImageQuality? quality = default;
            GeneratedImageFormat? responseFormat = default;
            GeneratedImageSize? size = default;
            GeneratedImageStyle? style = default;
            InternalCreateImageRequestModel? model = default;
            string prompt = default;
            long? n = default;
            string endUserId = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("quality"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        quality = null;
                        continue;
                    }
                    quality = new GeneratedImageQuality(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("response_format"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        responseFormat = null;
                        continue;
                    }
                    responseFormat = new GeneratedImageFormat(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("size"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        size = null;
                        continue;
                    }
                    size = new GeneratedImageSize(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("style"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        style = null;
                        continue;
                    }
                    style = new GeneratedImageStyle(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("model"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        model = null;
                        continue;
                    }
                    model = new InternalCreateImageRequestModel(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("prompt"u8))
                {
                    prompt = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("n"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        n = null;
                        continue;
                    }
                    n = prop.Value.GetInt64();
                    continue;
                }
                if (prop.NameEquals("user"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        endUserId = null;
                        continue;
                    }
                    endUserId = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ImageGenerationOptions(
                quality,
                responseFormat,
                size,
                style,
                model,
                prompt,
                n,
                endUserId,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ImageGenerationOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ImageGenerationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ImageGenerationOptions)} does not support writing '{options.Format}' format.");
            }
        }

        ImageGenerationOptions IPersistableModel<ImageGenerationOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ImageGenerationOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ImageGenerationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeImageGenerationOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ImageGenerationOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ImageGenerationOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ImageGenerationOptions imageGenerationOptions)
        {
            return BinaryContent.Create(imageGenerationOptions, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ImageGenerationOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeImageGenerationOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
