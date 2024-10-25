// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Assistants
{
    internal partial class InternalCreateThreadAndRunRequest : IJsonModel<InternalCreateThreadAndRunRequest>
    {
        internal InternalCreateThreadAndRunRequest()
        {
        }

        void IJsonModel<InternalCreateThreadAndRunRequest>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadAndRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateThreadAndRunRequest)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("assistant_id") != true)
            {
                writer.WritePropertyName("assistant_id"u8);
            }
            writer.WriteStringValue(AssistantId);
            if (Optional.IsDefined(Thread) && _additionalBinaryDataProperties?.ContainsKey("thread") != true)
            {
                writer.WritePropertyName("thread"u8);
                writer.WriteObjectValue(Thread, options);
            }
            if (Optional.IsDefined(Instructions) && _additionalBinaryDataProperties?.ContainsKey("instructions") != true)
            {
                if (Instructions != null)
                {
                    writer.WritePropertyName("instructions"u8);
                    writer.WriteStringValue(Instructions);
                }
                else
                {
                    writer.WriteNull("instructions"u8);
                }
            }
            if (Optional.IsCollectionDefined(Tools) && _additionalBinaryDataProperties?.ContainsKey("tools") != true)
            {
                if (Tools != null)
                {
                    writer.WritePropertyName("tools"u8);
                    writer.WriteStartArray();
                    foreach (ToolDefinition item in Tools)
                    {
                        writer.WriteObjectValue(item, options);
                    }
                    writer.WriteEndArray();
                }
                else
                {
                    writer.WriteNull("tools"u8);
                }
            }
            if (Optional.IsCollectionDefined(Metadata) && _additionalBinaryDataProperties?.ContainsKey("metadata") != true)
            {
                if (Metadata != null)
                {
                    writer.WritePropertyName("metadata"u8);
                    writer.WriteStartObject();
                    foreach (var item in Metadata)
                    {
                        writer.WritePropertyName(item.Key);
                        if (item.Value == null)
                        {
                            writer.WriteNullValue();
                            continue;
                        }
                        writer.WriteStringValue(item.Value);
                    }
                    writer.WriteEndObject();
                }
                else
                {
                    writer.WriteNull("metadata"u8);
                }
            }
            if (Optional.IsDefined(Temperature) && _additionalBinaryDataProperties?.ContainsKey("temperature") != true)
            {
                if (Temperature != null)
                {
                    writer.WritePropertyName("temperature"u8);
                    writer.WriteNumberValue(Temperature.Value);
                }
                else
                {
                    writer.WriteNull("temperature"u8);
                }
            }
            if (Optional.IsDefined(TopP) && _additionalBinaryDataProperties?.ContainsKey("top_p") != true)
            {
                if (TopP != null)
                {
                    writer.WritePropertyName("top_p"u8);
                    writer.WriteNumberValue(TopP.Value);
                }
                else
                {
                    writer.WriteNull("topP"u8);
                }
            }
            if (Optional.IsDefined(Stream) && _additionalBinaryDataProperties?.ContainsKey("stream") != true)
            {
                if (Stream != null)
                {
                    writer.WritePropertyName("stream"u8);
                    writer.WriteBooleanValue(Stream.Value);
                }
                else
                {
                    writer.WriteNull("stream"u8);
                }
            }
            if (Optional.IsDefined(MaxPromptTokens) && _additionalBinaryDataProperties?.ContainsKey("max_prompt_tokens") != true)
            {
                if (MaxPromptTokens != null)
                {
                    writer.WritePropertyName("max_prompt_tokens"u8);
                    writer.WriteNumberValue(MaxPromptTokens.Value);
                }
                else
                {
                    writer.WriteNull("maxPromptTokens"u8);
                }
            }
            if (Optional.IsDefined(MaxCompletionTokens) && _additionalBinaryDataProperties?.ContainsKey("max_completion_tokens") != true)
            {
                if (MaxCompletionTokens != null)
                {
                    writer.WritePropertyName("max_completion_tokens"u8);
                    writer.WriteNumberValue(MaxCompletionTokens.Value);
                }
                else
                {
                    writer.WriteNull("maxCompletionTokens"u8);
                }
            }
            if (Optional.IsDefined(TruncationStrategy) && _additionalBinaryDataProperties?.ContainsKey("truncation_strategy") != true)
            {
                if (TruncationStrategy != null)
                {
                    writer.WritePropertyName("truncation_strategy"u8);
                    writer.WriteObjectValue(TruncationStrategy, options);
                }
                else
                {
                    writer.WriteNull("truncationStrategy"u8);
                }
            }
            if (Optional.IsDefined(ParallelToolCalls) && _additionalBinaryDataProperties?.ContainsKey("parallel_tool_calls") != true)
            {
                writer.WritePropertyName("parallel_tool_calls"u8);
                writer.WriteBooleanValue(ParallelToolCalls.Value);
            }
            if (Optional.IsDefined(Model) && _additionalBinaryDataProperties?.ContainsKey("model") != true)
            {
                if (Model != null)
                {
                    writer.WritePropertyName("model"u8);
                    writer.WriteStringValue(Model);
                }
                else
                {
                    writer.WriteNull("model"u8);
                }
            }
            if (Optional.IsDefined(ToolResources) && _additionalBinaryDataProperties?.ContainsKey("tool_resources") != true)
            {
                if (ToolResources != null)
                {
                    writer.WritePropertyName("tool_resources"u8);
                    writer.WriteObjectValue(ToolResources, options);
                }
                else
                {
                    writer.WriteNull("toolResources"u8);
                }
            }
            if (Optional.IsDefined(ResponseFormat) && _additionalBinaryDataProperties?.ContainsKey("response_format") != true)
            {
                if (ResponseFormat != null)
                {
                    writer.WritePropertyName("response_format"u8);
                    writer.WriteObjectValue<AssistantResponseFormat>(ResponseFormat, options);
                }
                else
                {
                    writer.WriteNull("responseFormat"u8);
                }
            }
            if (Optional.IsDefined(ToolChoice) && _additionalBinaryDataProperties?.ContainsKey("tool_choice") != true)
            {
                if (ToolChoice != null)
                {
                    writer.WritePropertyName("tool_choice"u8);
                    writer.WriteObjectValue<ToolConstraint>(ToolChoice, options);
                }
                else
                {
                    writer.WriteNull("toolChoice"u8);
                }
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

        InternalCreateThreadAndRunRequest IJsonModel<InternalCreateThreadAndRunRequest>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalCreateThreadAndRunRequest JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadAndRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalCreateThreadAndRunRequest)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalCreateThreadAndRunRequest(document.RootElement, options);
        }

        internal static InternalCreateThreadAndRunRequest DeserializeInternalCreateThreadAndRunRequest(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string assistantId = default;
            ThreadCreationOptions thread = default;
            string instructions = default;
            IList<ToolDefinition> tools = default;
            IDictionary<string, string> metadata = default;
            float? temperature = default;
            float? topP = default;
            bool? stream = default;
            int? maxPromptTokens = default;
            int? maxCompletionTokens = default;
            RunTruncationStrategy truncationStrategy = default;
            bool? parallelToolCalls = default;
            string model = default;
            ToolResources toolResources = default;
            AssistantResponseFormat responseFormat = default;
            ToolConstraint toolChoice = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("assistant_id"u8))
                {
                    assistantId = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("thread"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    thread = ThreadCreationOptions.DeserializeThreadCreationOptions(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("instructions"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        instructions = null;
                        continue;
                    }
                    instructions = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("tools"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ToolDefinition> array = new List<ToolDefinition>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(ToolDefinition.DeserializeToolDefinition(item, options));
                    }
                    tools = array;
                    continue;
                }
                if (prop.NameEquals("metadata"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var prop0 in prop.Value.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(prop0.Name, prop0.Value.GetString());
                        }
                    }
                    metadata = dictionary;
                    continue;
                }
                if (prop.NameEquals("temperature"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        temperature = null;
                        continue;
                    }
                    temperature = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("top_p"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        topP = null;
                        continue;
                    }
                    topP = prop.Value.GetSingle();
                    continue;
                }
                if (prop.NameEquals("stream"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        stream = null;
                        continue;
                    }
                    stream = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("max_prompt_tokens"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxPromptTokens = null;
                        continue;
                    }
                    maxPromptTokens = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("max_completion_tokens"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        maxCompletionTokens = null;
                        continue;
                    }
                    maxCompletionTokens = prop.Value.GetInt32();
                    continue;
                }
                if (prop.NameEquals("truncation_strategy"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        truncationStrategy = null;
                        continue;
                    }
                    truncationStrategy = RunTruncationStrategy.DeserializeRunTruncationStrategy(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("parallel_tool_calls"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    parallelToolCalls = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("model"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        model = null;
                        continue;
                    }
                    model = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("tool_resources"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        toolResources = null;
                        continue;
                    }
                    toolResources = ToolResources.DeserializeToolResources(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("response_format"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        responseFormat = null;
                        continue;
                    }
                    responseFormat = AssistantResponseFormat.DeserializeAssistantResponseFormat(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("tool_choice"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        toolChoice = null;
                        continue;
                    }
                    toolChoice = ToolConstraint.DeserializeToolConstraint(prop.Value, options);
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalCreateThreadAndRunRequest(
                assistantId,
                thread,
                instructions,
                tools ?? new ChangeTrackingList<ToolDefinition>(),
                metadata ?? new ChangeTrackingDictionary<string, string>(),
                temperature,
                topP,
                stream,
                maxPromptTokens,
                maxCompletionTokens,
                truncationStrategy,
                parallelToolCalls,
                model,
                toolResources,
                responseFormat,
                toolChoice,
                additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalCreateThreadAndRunRequest>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadAndRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalCreateThreadAndRunRequest)} does not support writing '{options.Format}' format.");
            }
        }

        InternalCreateThreadAndRunRequest IPersistableModel<InternalCreateThreadAndRunRequest>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalCreateThreadAndRunRequest PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalCreateThreadAndRunRequest>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalCreateThreadAndRunRequest(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalCreateThreadAndRunRequest)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalCreateThreadAndRunRequest>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalCreateThreadAndRunRequest internalCreateThreadAndRunRequest)
        {
            return BinaryContent.Create(internalCreateThreadAndRunRequest, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalCreateThreadAndRunRequest(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalCreateThreadAndRunRequest(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
