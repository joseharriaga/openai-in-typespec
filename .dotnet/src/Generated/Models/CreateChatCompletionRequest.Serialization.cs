// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Internal.Models
{
    internal partial class CreateChatCompletionRequest : IJsonModel<CreateChatCompletionRequest>
    {
        void IJsonModel<CreateChatCompletionRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateChatCompletionRequest)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("messages"u8);
            writer.WriteStartArray();
            foreach (var item in Messages)
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
            writer.WritePropertyName("model"u8);
            writer.WriteStringValue(Model.ToString());
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
                    writer.WriteBooleanValue(Logprobs.Value);
                }
                else
                {
                    writer.WriteNull("logprobs");
                }
            }
            if (Optional.IsDefined(TopLogprobs))
            {
                if (TopLogprobs != null)
                {
                    writer.WritePropertyName("top_logprobs"u8);
                    writer.WriteNumberValue(TopLogprobs.Value);
                }
                else
                {
                    writer.WriteNull("top_logprobs");
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
            if (Optional.IsDefined(ResponseFormat))
            {
                writer.WritePropertyName("response_format"u8);
                writer.WriteObjectValue(ResponseFormat, options);
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
            if (Optional.IsDefined(StreamOptions))
            {
                if (StreamOptions != null)
                {
                    writer.WritePropertyName("stream_options"u8);
                    writer.WriteObjectValue(StreamOptions, options);
                }
                else
                {
                    writer.WriteNull("stream_options");
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
            if (Optional.IsCollectionDefined(Tools))
            {
                writer.WritePropertyName("tools"u8);
                writer.WriteStartArray();
                foreach (var item in Tools)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ToolChoice))
            {
                writer.WritePropertyName("tool_choice"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(ToolChoice);
#else
                using (JsonDocument document = JsonDocument.Parse(ToolChoice))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (Optional.IsDefined(User))
            {
                writer.WritePropertyName("user"u8);
                writer.WriteStringValue(User);
            }
            if (Optional.IsDefined(FunctionCall))
            {
                writer.WritePropertyName("function_call"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(FunctionCall);
#else
                using (JsonDocument document = JsonDocument.Parse(FunctionCall))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
            if (Optional.IsCollectionDefined(Functions))
            {
                writer.WritePropertyName("functions"u8);
                writer.WriteStartArray();
                foreach (var item in Functions)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
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

        CreateChatCompletionRequest IJsonModel<CreateChatCompletionRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CreateChatCompletionRequest)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCreateChatCompletionRequest(document.RootElement, options);
        }

        internal static CreateChatCompletionRequest DeserializeCreateChatCompletionRequest(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            IList<BinaryData> messages = default;
            CreateChatCompletionRequestModel model = default;
            float? frequencyPenalty = default;
            IDictionary<string, int> logitBias = default;
            bool? logprobs = default;
            int? topLogprobs = default;
            int? maxTokens = default;
            int? n = default;
            float? presencePenalty = default;
            CreateChatCompletionRequestResponseFormat responseFormat = default;
            long? seed = default;
            BinaryData stop = default;
            bool? stream = default;
            InternalChatCompletionStreamOptions streamOptions = default;
            float? temperature = default;
            float? topP = default;
            IList<ChatCompletionTool> tools = default;
            BinaryData toolChoice = default;
            string user = default;
            BinaryData functionCall = default;
            IList<ChatCompletionFunctions> functions = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("messages"u8))
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
                    messages = array;
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    model = new CreateChatCompletionRequestModel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("frequency_penalty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        frequencyPenalty = null;
                        continue;
                    }
                    frequencyPenalty = property.Value.GetSingle();
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
                    logprobs = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("top_logprobs"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        topLogprobs = null;
                        continue;
                    }
                    topLogprobs = property.Value.GetInt32();
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
                    presencePenalty = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("response_format"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    responseFormat = CreateChatCompletionRequestResponseFormat.DeserializeCreateChatCompletionRequestResponseFormat(property.Value, options);
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
                if (property.NameEquals("stream_options"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        streamOptions = null;
                        continue;
                    }
                    streamOptions = InternalChatCompletionStreamOptions.DeserializeInternalChatCompletionStreamOptions(property.Value, options);
                    continue;
                }
                if (property.NameEquals("temperature"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        temperature = null;
                        continue;
                    }
                    temperature = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("top_p"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        topP = null;
                        continue;
                    }
                    topP = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("tools"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatCompletionTool> array = new List<ChatCompletionTool>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChatCompletionTool.DeserializeChatCompletionTool(item, options));
                    }
                    tools = array;
                    continue;
                }
                if (property.NameEquals("tool_choice"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    toolChoice = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("user"u8))
                {
                    user = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("function_call"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    functionCall = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("functions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ChatCompletionFunctions> array = new List<ChatCompletionFunctions>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChatCompletionFunctions.DeserializeChatCompletionFunctions(item, options));
                    }
                    functions = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new CreateChatCompletionRequest(
                messages,
                model,
                frequencyPenalty,
                logitBias ?? new ChangeTrackingDictionary<string, int>(),
                logprobs,
                topLogprobs,
                maxTokens,
                n,
                presencePenalty,
                responseFormat,
                seed,
                stop,
                stream,
                streamOptions,
                temperature,
                topP,
                tools ?? new ChangeTrackingList<ChatCompletionTool>(),
                toolChoice,
                user,
                functionCall,
                functions ?? new ChangeTrackingList<ChatCompletionFunctions>(),
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<CreateChatCompletionRequest>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(CreateChatCompletionRequest)} does not support writing '{options.Format}' format.");
            }
        }

        CreateChatCompletionRequest IPersistableModel<CreateChatCompletionRequest>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CreateChatCompletionRequest>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCreateChatCompletionRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CreateChatCompletionRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CreateChatCompletionRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static CreateChatCompletionRequest FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCreateChatCompletionRequest(document.RootElement);
        }

        /// <summary> Convert into a <see cref="BinaryContent"/>. </summary>
        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
