// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace OpenAI.Images
{
    public partial class ImageEditOptions : IJsonModel<ImageEditOptions>
    {
        void IJsonModel<ImageEditOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ImageEditOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ImageEditOptions)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (!SerializedAdditionalRawData.ContainsKey("image"))
            {
                writer.WritePropertyName("image"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Image);
#else
                using (JsonDocument document = JsonDocument.Parse(Image))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (!SerializedAdditionalRawData.ContainsKey("prompt"))
            {
                writer.WritePropertyName("prompt"u8);
                writer.WriteStringValue(Prompt);
            }
            if (!SerializedAdditionalRawData.ContainsKey("mask") && Optional.IsDefined(Mask))
            {
                writer.WritePropertyName("mask"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Mask);
#else
                using (JsonDocument document = JsonDocument.Parse(Mask))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (!SerializedAdditionalRawData.ContainsKey("model") && Optional.IsDefined(Model))
            {
                if (Model != null)
                {
                    writer.WritePropertyName("model"u8);
                    writer.WriteStringValue(Model.Value.ToString());
                }
                else
                {
                    writer.WriteNull("model");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("n") && Optional.IsDefined(N))
            {
                if (N != null)
                {
                    writer.WritePropertyName("n"u8);
                    writer.WriteNumberValue(N.Value);
                }
                else
                {
                    writer.WriteNull("n");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("size") && Optional.IsDefined(Size))
            {
                if (Size != null)
                {
                    writer.WritePropertyName("size"u8);
                    writer.WriteStringValue(Size.Value.ToString());
                }
                else
                {
                    writer.WriteNull("size");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("response_format") && Optional.IsDefined(ResponseFormat))
            {
                if (ResponseFormat != null)
                {
                    writer.WritePropertyName("response_format"u8);
                    writer.WriteStringValue(ResponseFormat.Value.ToSerialString());
                }
                else
                {
                    writer.WriteNull("response_format");
                }
            }
            if (!SerializedAdditionalRawData.ContainsKey("user") && Optional.IsDefined(User))
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(User);
            }
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
            writer.WriteEndObject();
        }

        ImageEditOptions IJsonModel<ImageEditOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ImageEditOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ImageEditOptions)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeImageEditOptions(document.RootElement, options);
        }

        internal static ImageEditOptions DeserializeImageEditOptions(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BinaryData image = default;
            string prompt = default;
            BinaryData mask = default;
            InternalCreateImageEditRequestModel? model = default;
            long? n = default;
            GeneratedImageSize? size = default;
            GeneratedImageFormat? responseFormat = default;
            string user = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("image"u8))
                {
                    image = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("prompt"u8))
                {
                    prompt = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("mask"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    mask = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        model = null;
                        continue;
                    }
                    model = new InternalCreateImageEditRequestModel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("n"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        n = null;
                        continue;
                    }
                    n = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("size"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        size = null;
                        continue;
                    }
                    size = new GeneratedImageSize(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("response_format"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        responseFormat = null;
                        continue;
                    }
                    responseFormat = property.Value.GetString().ToGeneratedImageFormat();
                    continue;
                }
                if (property.NameEquals("user"u8))
                {
                    user = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ImageEditOptions(
                image,
                prompt,
                mask,
                model,
                n,
                size,
                responseFormat,
                user,
                serializedAdditionalRawData);
        }

        private BinaryData SerializeMultipart(ModelReaderWriterOptions options)
        {
            using MultipartFormDataBinaryContent content = ToMultipartBinaryBody();
            using MemoryStream stream = new MemoryStream();
            content.WriteTo(stream);
            if (stream.Position > int.MaxValue)
            {
                return BinaryData.FromStream(stream);
            }
            else
            {
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
        }

        internal virtual MultipartFormDataBinaryContent ToMultipartBinaryBody()
        {
            MultipartFormDataBinaryContent content = new MultipartFormDataBinaryContent();
            content.Add(Image, "image", "image");
            content.Add(Prompt, "prompt");
            if (Optional.IsDefined(Mask))
            {
                content.Add(Mask, "mask", "mask");
            }
            if (Optional.IsDefined(Model))
            {
                if (Model != null)
                {
                    content.Add(Model.Value.ToString(), "model");
                }
            }
            if (Optional.IsDefined(N))
            {
                if (N != null)
                {
                    content.Add(N.Value, "n");
                }
            }
            if (Optional.IsDefined(Size))
            {
                if (Size != null)
                {
                    content.Add(Size.Value.ToString(), "size");
                }
            }
            if (Optional.IsDefined(ResponseFormat))
            {
                if (ResponseFormat != null)
                {
                    content.Add(ResponseFormat.Value.ToSerialString(), "response_format");
                }
            }
            if (Optional.IsDefined(User))
            {
                content.Add(User, "user");
            }
            return content;
        }

        BinaryData IPersistableModel<ImageEditOptions>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ImageEditOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "MFD":
                    return SerializeMultipart(options);
                default:
                    throw new FormatException($"The model {nameof(ImageEditOptions)} does not support writing '{options.Format}' format.");
            }
        }

        ImageEditOptions IPersistableModel<ImageEditOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ImageEditOptions>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeImageEditOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ImageEditOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ImageEditOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "MFD";

        internal static ImageEditOptions FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeImageEditOptions(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
