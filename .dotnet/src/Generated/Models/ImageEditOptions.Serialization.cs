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
    public partial class ImageEditOptions : IJsonModel<ImageEditOptions>
    {
        void IJsonModel<ImageEditOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ImageEditOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ImageEditOptions)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Model) && _additionalBinaryDataProperties?.ContainsKey("model") != true)
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
            if (_additionalBinaryDataProperties?.ContainsKey("image") != true)
            {
                writer.WritePropertyName("image"u8);
            }
            writer.WriteBase64StringValue(Image.ToArray(), "D");
            if (_additionalBinaryDataProperties?.ContainsKey("prompt") != true)
            {
                writer.WritePropertyName("prompt"u8);
            }
            writer.WriteStringValue(Prompt);
            if (Optional.IsDefined(Mask) && _additionalBinaryDataProperties?.ContainsKey("mask") != true)
            {
                writer.WritePropertyName("mask"u8);
                writer.WriteBase64StringValue(Mask.ToArray(), "D");
            }
            if (Optional.IsDefined(N) && _additionalBinaryDataProperties?.ContainsKey("n") != true)
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
            if (Optional.IsDefined(Size) && _additionalBinaryDataProperties?.ContainsKey("size") != true)
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
            if (Optional.IsDefined(ResponseFormat) && _additionalBinaryDataProperties?.ContainsKey("response_format") != true)
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
            if (Optional.IsDefined(EndUserId) && _additionalBinaryDataProperties?.ContainsKey("user") != true)
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(EndUserId);
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

        ImageEditOptions IJsonModel<ImageEditOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual ImageEditOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ImageEditOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ImageEditOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeImageEditOptions(document.RootElement, options);
        }

        internal static ImageEditOptions DeserializeImageEditOptions(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalCreateImageEditRequestModel? model = default;
            BinaryData image = default;
            string prompt = default;
            BinaryData mask = default;
            long? n = default;
            GeneratedImageSize? size = default;
            GeneratedImageFormat? responseFormat = default;
            string endUserId = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("model"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        model = null;
                        continue;
                    }
                    model = new InternalCreateImageEditRequestModel(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("image"u8))
                {
                    image = BinaryData.FromBytes(prop.Value.GetBytesFromBase64("D"));
                    continue;
                }
                if (prop.NameEquals("prompt"u8))
                {
                    prompt = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("mask"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    mask = BinaryData.FromBytes(prop.Value.GetBytesFromBase64("D"));
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
                if (prop.NameEquals("user"u8))
                {
                    endUserId = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new ImageEditOptions(
                model,
                image,
                prompt,
                mask,
                n,
                size,
                responseFormat,
                endUserId,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<ImageEditOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ImageEditOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(ImageEditOptions)} does not support writing '{options.Format}' format.");
            }
        }

        ImageEditOptions IPersistableModel<ImageEditOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual ImageEditOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<ImageEditOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeImageEditOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ImageEditOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ImageEditOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(ImageEditOptions imageEditOptions)
        {
            return BinaryContent.Create(imageEditOptions, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator ImageEditOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeImageEditOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
