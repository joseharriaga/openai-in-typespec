// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class CreateCompletionRequest : IJsonModel<CreateCompletionRequest>
    {
        void IJsonModel<CreateCompletionRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateCompletionRequest)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("model"u8);
            writer.WriteStringValue(Model.ToString());
            if (Prompt != null)
            {
                writer.WritePropertyName("prompt"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Prompt);
#else
                using (JsonDocument document = JsonDocument.Parse(Prompt))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            else
            {
                writer.WriteNull("prompt");
            }
            if (Optional.IsDefined(BestOf))
            {
                if (BestOf != null)
                {
                    writer.WritePropertyName("best_of"u8);
                    writer.WriteNumberValue(BestOf.Value);
                }
                else
                {
                    writer.WriteNull("best_of");
                }
            }
            if (Optional.IsDefined(Echo))
            {
                if (Echo != null)
                {
                    writer.WritePropertyName("echo"u8);
                    writer.WriteBooleanValue(Echo.Value);
                }
                else
                {
                    writer.WriteNull("echo");
                }
            }
            if (Optional.IsDefined(FrequencyPenalty))
            {
                if (FrequencyPenalty != null)
                {
                    writer.WritePropertyName("frequency_penalty"u8);
                    writer.WriteNumberValue(FrequencyPenalty.Value);
                }
                else
                {
                    writer.WriteNull("frequency_penalty");
                }
            }
            if (Optional.IsCollectionDefined(LogitBias))
            {
                if (LogitBias != null)
                {
                    writer.WritePropertyName("logit_bias"u8);
                    writer.WriteStartObject();
                    foreach (var item in LogitBias)
                    {
                        writer.WritePropertyName(item.Key);
                        writer.WriteNumberValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
                else
                {
                    writer.WriteNull("logit_bias");
                }
            }
            if (Optional.IsDefined(Logprobs))
            {
                if (Logprobs != null)
                {
                    writer.WritePropertyName("logprobs"u8);
                    writer.WriteNumberValue(Logprobs.Value);
                }
                else
                {
                    writer.WriteNull("logprobs");
                }
            }
            if (Optional.IsDefined(MaxTokens))
            {
                if (MaxTokens != null)
                {
                    writer.WritePropertyName("max_tokens"u8);
                    writer.WriteNumberValue(MaxTokens.Value);
                }
                else
                {
                    writer.WriteNull("max_tokens");
                }
            }
            if (Optional.IsDefined(N))
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
            if (Optional.IsDefined(PresencePenalty))
            {
                if (PresencePenalty != null)
                {
                    writer.WritePropertyName("presence_penalty"u8);
                    writer.WriteNumberValue(PresencePenalty.Value);
                }
                else
                {
                    writer.WriteNull("presence_penalty");
                }
            }
            if (Optional.IsDefined(Seed))
            {
                if (Seed != null)
                {
                    writer.WritePropertyName("seed"u8);
                    writer.WriteNumberValue(Seed.Value);
                }
                else
                {
                    writer.WriteNull("seed");
                }
            }
            if (Optional.IsDefined(Stop))
            {
                if (Stop != null)
                {
                    writer.WritePropertyName("stop"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Stop);
#else
                    using (JsonDocument document = JsonDocument.Parse(Stop))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                else
                {
                    writer.WriteNull("stop");
                }
            }
            if (Optional.IsDefined(Stream))
            {
                if (Stream != null)
                {
                    writer.WritePropertyName("stream"u8);
                    writer.WriteBooleanValue(Stream.Value);
                }
                else
                {
                    writer.WriteNull("stream");
                }
            }
            if (Optional.IsDefined(Suffix))
            {
                if (Suffix != null)
                {
                    writer.WritePropertyName("suffix"u8);
                    writer.WriteStringValue(Suffix);
                }
                else
                {
                    writer.WriteNull("suffix");
                }
            }
            if (Optional.IsDefined(Temperature))
            {
                if (Temperature != null)
                {
                    writer.WritePropertyName("temperature"u8);
                    writer.WriteNumberValue(Temperature.Value);
                }
                else
                {
                    writer.WriteNull("temperature");
                }
            }
            if (Optional.IsDefined(TopP))
            {
                if (TopP != null)
                {
                    writer.WritePropertyName("top_p"u8);
                    writer.WriteNumberValue(TopP.Value);
                }
                else
                {
                    writer.WriteNull("top_p");
                }
            }
            if (Optional.IsDefined(User))
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(User);
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

        CreateCompletionRequest IJsonModel<CreateCompletionRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateCompletionRequest)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateCompletionRequest(document.RootElement, options);
        }

        internal static CreateCompletionRequest DeserializeCreateCompletionRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            CreateCompletionRequestModel model = default;
            BinaryData prompt = default;
            int? bestOf = default;
            bool? echo = default;
            double? frequencyPenalty = default;
            IDictionary<string, int> logitBias = default;
            int? logprobs = default;
            int? maxTokens = default;
            int? n = default;
            double? presencePenalty = default;
            long? seed = default;
            BinaryData stop = default;
            bool? stream = default;
            string suffix = default;
            double? temperature = default;
            double? topP = default;
            string user = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("model"u8))
                {
                    model = new CreateCompletionRequestModel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("prompt"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        prompt = null;
                        continue;
                    }
                    prompt = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("best_of"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        bestOf = null;
                        continue;
                    }
                    bestOf = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("echo"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        echo = null;
                        continue;
                    }
                    echo = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("frequency_penalty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        frequencyPenalty = null;
                        continue;
                    }
                    frequencyPenalty = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("logit_bias"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetInt32());
                    }
                    logitBias = dictionary;
                    continue;
                }
                if (property.NameEquals("logprobs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        logprobs = null;
                        continue;
                    }
                    logprobs = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("max_tokens"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxTokens = null;
                        continue;
                    }
                    maxTokens = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("n"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        n = null;
                        continue;
                    }
                    n = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("presence_penalty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        presencePenalty = null;
                        continue;
                    }
                    presencePenalty = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("seed"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        seed = null;
                        continue;
                    }
                    seed = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("stop"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        stop = null;
                        continue;
                    }
                    stop = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("stream"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        stream = null;
                        continue;
                    }
                    stream = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("suffix"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        suffix = null;
                        continue;
                    }
                    suffix = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("temperature"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        temperature = null;
                        continue;
                    }
                    temperature = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("top_p"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        topP = null;
                        continue;
                    }
                    topP = property.Value.GetDouble();
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
            return new CreateCompletionRequest(
                model,
                prompt,
                bestOf,
                echo,
                frequencyPenalty,
                logitBias ?? new ChangeTrackingDictionary<string, int>(),
                logprobs,
                maxTokens,
                n,
                presencePenalty,
                seed,
                stop,
                stream,
                suffix,
                temperature,
                topP,
                user,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateCompletionRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CreateCompletionRequest)} does not support writing '{options.Format}' format.");
            }
        }

        CreateCompletionRequest IPersistableModel<CreateCompletionRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateCompletionRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateCompletionRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateCompletionRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateCompletionRequest FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateCompletionRequest(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestBody. </summary>
        internal virtual BinaryContent ToBinaryBody()
        {
            return BinaryContent.Create(this, new ModelReaderWriterOptions("W"));
        }
    }
}
