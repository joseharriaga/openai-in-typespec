// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Embeddings
{
<<<<<<<< HEAD:.dotnet/src/Generated/Models/EmbeddingTokenUsage.Serialization.cs
    public partial class EmbeddingTokenUsage : IJsonModel<EmbeddingTokenUsage>
    {
        void IJsonModel<EmbeddingTokenUsage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EmbeddingTokenUsage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EmbeddingTokenUsage)} does not support writing '{format}' format.");
========
    internal partial class CreateEmbeddingResponseUsage : IJsonModel<CreateEmbeddingResponseUsage>
    {
        void IJsonModel<CreateEmbeddingResponseUsage>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateEmbeddingResponseUsage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateEmbeddingResponseUsage)} does not support writing '{format}' format.");
>>>>>>>> e9efc0a66a9c3a8e331b35c1fc5af3dac1e588f1:.dotnet/src/Generated/Models/CreateEmbeddingResponseUsage.Serialization.cs
            }

            writer.WriteStartObject();
            writer.WritePropertyName("prompt_tokens"u8);
            writer.WriteNumberValue(InputTokens);
            writer.WritePropertyName("total_tokens"u8);
            writer.WriteNumberValue(TotalTokens);
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

<<<<<<<< HEAD:.dotnet/src/Generated/Models/EmbeddingTokenUsage.Serialization.cs
        EmbeddingTokenUsage IJsonModel<EmbeddingTokenUsage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EmbeddingTokenUsage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EmbeddingTokenUsage)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeEmbeddingTokenUsage(document.RootElement, options);
        }

        internal static EmbeddingTokenUsage DeserializeEmbeddingTokenUsage(JsonElement element, ModelReaderWriterOptions options = null)
========
        CreateEmbeddingResponseUsage IJsonModel<CreateEmbeddingResponseUsage>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateEmbeddingResponseUsage>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateEmbeddingResponseUsage)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateEmbeddingResponseUsage(document.RootElement, options);
        }

        internal static CreateEmbeddingResponseUsage DeserializeCreateEmbeddingResponseUsage(JsonElement element, ModelReaderWriterOptions options = null)
>>>>>>>> e9efc0a66a9c3a8e331b35c1fc5af3dac1e588f1:.dotnet/src/Generated/Models/CreateEmbeddingResponseUsage.Serialization.cs
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            int promptTokens = default;
            int totalTokens = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("prompt_tokens"u8))
                {
                    promptTokens = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("total_tokens"u8))
                {
                    totalTokens = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
<<<<<<<< HEAD:.dotnet/src/Generated/Models/EmbeddingTokenUsage.Serialization.cs
            return new EmbeddingTokenUsage(promptTokens, totalTokens, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<EmbeddingTokenUsage>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EmbeddingTokenUsage>)this).GetFormatFromOptions(options) : options.Format;
========
            return new CreateEmbeddingResponseUsage(promptTokens, totalTokens, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateEmbeddingResponseUsage>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateEmbeddingResponseUsage>)this).GetFormatFromOptions(options) : options.Format;
>>>>>>>> e9efc0a66a9c3a8e331b35c1fc5af3dac1e588f1:.dotnet/src/Generated/Models/CreateEmbeddingResponseUsage.Serialization.cs

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
<<<<<<<< HEAD:.dotnet/src/Generated/Models/EmbeddingTokenUsage.Serialization.cs
                    throw new FormatException($"The model {nameof(EmbeddingTokenUsage)} does not support writing '{options.Format}' format.");
            }
        }

        EmbeddingTokenUsage IPersistableModel<EmbeddingTokenUsage>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EmbeddingTokenUsage>)this).GetFormatFromOptions(options) : options.Format;
========
                    throw new FormatException($"The model {nameof(CreateEmbeddingResponseUsage)} does not support writing '{options.Format}' format.");
            }
        }

        CreateEmbeddingResponseUsage IPersistableModel<CreateEmbeddingResponseUsage>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateEmbeddingResponseUsage>)this).GetFormatFromOptions(options) : options.Format;
>>>>>>>> e9efc0a66a9c3a8e331b35c1fc5af3dac1e588f1:.dotnet/src/Generated/Models/CreateEmbeddingResponseUsage.Serialization.cs

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
<<<<<<<< HEAD:.dotnet/src/Generated/Models/EmbeddingTokenUsage.Serialization.cs
                        return DeserializeEmbeddingTokenUsage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(EmbeddingTokenUsage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<EmbeddingTokenUsage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static EmbeddingTokenUsage FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeEmbeddingTokenUsage(document.RootElement);
========
                        return DeserializeCreateEmbeddingResponseUsage(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateEmbeddingResponseUsage)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateEmbeddingResponseUsage>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateEmbeddingResponseUsage FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateEmbeddingResponseUsage(document.RootElement);
>>>>>>>> e9efc0a66a9c3a8e331b35c1fc5af3dac1e588f1:.dotnet/src/Generated/Models/CreateEmbeddingResponseUsage.Serialization.cs
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
