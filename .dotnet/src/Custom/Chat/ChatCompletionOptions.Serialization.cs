using System;
using OpenAI.ClientShared.Internal;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

public partial class ChatCompletionOptions : IJsonModel<ChatCompletionOptions>
{
    void IJsonModel<ChatCompletionOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support '{format}' format.");
        }

        if (OptionalProperty.IsDefined(FrequencyPenalty))
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
        if (OptionalProperty.IsCollectionDefined(TokenSelectionBiases))
        {
            if (TokenSelectionBiases != null)
            {
                writer.WritePropertyName("logit_bias"u8);
                writer.WriteStartObject();
                foreach (var item in TokenSelectionBiases)
                {
                    writer.WritePropertyName($"{item.Key}");
                    writer.WriteNumberValue(item.Value);
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNull("logit_bias");
            }
        }
        if (OptionalProperty.IsDefined(IncludeLogProbabilities))
        {
            if (IncludeLogProbabilities != null)
            {
                writer.WritePropertyName("logprobs"u8);
                writer.WriteBooleanValue(IncludeLogProbabilities.Value);
            }
            else
            {
                writer.WriteNull("logprobs");
            }
        }
        if (OptionalProperty.IsDefined(LogProbabilityCount))
        {
            if (LogProbabilityCount != null)
            {
                writer.WritePropertyName("top_logprobs"u8);
                writer.WriteNumberValue(LogProbabilityCount.Value);
            }
            else
            {
                writer.WriteNull("top_logprobs");
            }
        }
        if (OptionalProperty.IsDefined(MaxTokens))
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
        if (OptionalProperty.IsDefined(PresencePenalty))
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
        if (OptionalProperty.IsDefined(ResponseFormat))
        {
            writer.WritePropertyName("response_format"u8);
            writer.WriteObjectValue(ResponseFormat);
        }
        if (OptionalProperty.IsDefined(Seed))
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
        if (OptionalProperty.IsCollectionDefined(StopSequences))
        {
            if (StopSequences != null)
            {
                writer.WritePropertyName("stop"u8);
                writer.WriteStartArray();
                foreach (string stopSequence in StopSequences)
                {
                    writer.WriteStringValue(stopSequence);
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteNull("stop");
            }
        }
        if (OptionalProperty.IsDefined(Temperature))
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
        if (OptionalProperty.IsDefined(NucleusSamplingFactor))
        {
            if (NucleusSamplingFactor != null)
            {
                writer.WritePropertyName("top_p"u8);
                writer.WriteNumberValue(NucleusSamplingFactor.Value);
            }
            else
            {
                writer.WriteNull("top_p");
            }
        }
        if (OptionalProperty.IsCollectionDefined(Tools))
        {
            writer.WritePropertyName("tools"u8);
            writer.WriteStartArray();
            foreach (var item in Tools)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
        }
        if (OptionalProperty.IsDefined(ToolConstraint))
        {
            writer.WritePropertyName("tool_choice"u8);
            IJsonModel<ChatToolConstraint> serializable = ToolConstraint as IJsonModel<ChatToolConstraint>;
            writer.WriteObjectValue(serializable);
        }
        if (OptionalProperty.IsDefined(User))
        {
            writer.WritePropertyName("user"u8);
            writer.WriteStringValue(User);
        }
        if (OptionalProperty.IsDefined(FunctionConstraint))
        {
            writer.WritePropertyName("function_call"u8);
            writer.WriteObjectValue(FunctionConstraint);
        }
        if (OptionalProperty.IsCollectionDefined(Functions))
        {
            writer.WritePropertyName("functions"u8);
            writer.WriteStartArray();
            foreach (var item in Functions)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
        }
        WriteAdditionalDataForDerivedTypes(writer, options);
    }

    protected virtual void WriteAdditionalDataForDerivedTypes(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
    }

    ChatCompletionOptions IJsonModel<ChatCompletionOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeChatCompletionOptions(document.RootElement, options);
    }

    internal static ChatCompletionOptions DeserializeChatCompletionOptions(JsonElement element, ModelReaderWriterOptions options = null)
    {
        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<ChatCompletionOptions>.Write(ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                return ModelReaderWriter.Write(this, options);
            default:
                throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support '{options.Format}' format.");
        }
    }

    ChatCompletionOptions IPersistableModel<ChatCompletionOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<ChatCompletionOptions>)this).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeChatCompletionOptions(document.RootElement, options);
                }
            default:
                throw new FormatException($"The model {nameof(ChatCompletionOptions)} does not support '{options.Format}' format.");
        }
    }

    string IPersistableModel<ChatCompletionOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}
