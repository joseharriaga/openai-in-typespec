// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    public partial class Assistant : IJsonModel<Assistant>
    {
        void IJsonModel<Assistant>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Assistant>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Assistant)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("object"u8);
            writer.WriteStringValue(Object.ToString());
            writer.WritePropertyName("created_at"u8);
            writer.WriteNumberValue(CreatedAt, "U");
            if (Name != null)
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            else
            {
                writer.WriteNull("name");
            }
            if (Description != null)
            {
                writer.WritePropertyName("description"u8);
                writer.WriteStringValue(Description);
            }
            else
            {
                writer.WriteNull("description");
            }
            writer.WritePropertyName("model"u8);
            writer.WriteStringValue(Model);
            if (Instructions != null)
            {
                writer.WritePropertyName("instructions"u8);
                writer.WriteStringValue(Instructions);
            }
            else
            {
                writer.WriteNull("instructions");
            }
            writer.WritePropertyName("tools"u8);
            writer.WriteStartArray();
            foreach (var item in Tools)
            {
                writer.WriteObjectValue(item, options);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(ToolResources))
            {
                if (ToolResources != null)
                {
                    writer.WritePropertyName("tool_resources"u8);
                    writer.WriteObjectValue(ToolResources, options);
                }
                else
                {
                    writer.WriteNull("tool_resources");
                }
            }
            if (Metadata != null && Optional.IsCollectionDefined(Metadata))
            {
                writer.WritePropertyName("metadata"u8);
                writer.WriteStartObject();
                foreach (var item in Metadata)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNull("metadata");
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
            if (Optional.IsDefined(NucleusSamplingFactor))
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
            if (Optional.IsDefined(ResponseFormat))
            {
                writer.WritePropertyName("response_format"u8);
                writer.WriteObjectValue<AssistantResponseFormat>(ResponseFormat, options);
            }
            if (true && _serializedAdditionalRawData != null)
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

        Assistant IJsonModel<Assistant>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Assistant>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(Assistant)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAssistant(document.RootElement, options);
        }

        internal static Assistant DeserializeAssistant(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            InternalAssistantObjectObject @object = default;
            DateTimeOffset createdAt = default;
            string name = default;
            string description = default;
            string model = default;
            string instructions = default;
            IReadOnlyList<ToolDefinition> tools = default;
            ToolResources toolResources = default;
            IReadOnlyDictionary<string, string> metadata = default;
            float? temperature = default;
            float? topP = default;
            AssistantResponseFormat responseFormat = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = new InternalAssistantObjectObject(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        name = null;
                        continue;
                    }
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        description = null;
                        continue;
                    }
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("model"u8))
                {
                    model = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("instructions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        instructions = null;
                        continue;
                    }
                    instructions = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tools"u8))
                {
                    List<ToolDefinition> array = new List<ToolDefinition>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ToolDefinition.DeserializeToolDefinition(item, options));
                    }
                    tools = array;
                    continue;
                }
                if (property.NameEquals("tool_resources"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        toolResources = null;
                        continue;
                    }
                    toolResources = ToolResources.DeserializeToolResources(property.Value, options);
                    continue;
                }
                if (property.NameEquals("metadata"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        metadata = new ChangeTrackingDictionary<string, string>();
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    metadata = dictionary;
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
                if (property.NameEquals("response_format"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    responseFormat = AssistantResponseFormat.DeserializeAssistantResponseFormat(property.Value, options);
                    continue;
                }
                if (true)
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new Assistant(
                id,
                @object,
                createdAt,
                name,
                description,
                model,
                instructions,
                tools,
                toolResources,
                metadata,
                temperature,
                topP,
                responseFormat,
                serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<Assistant>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Assistant>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(Assistant)} does not support writing '{options.Format}' format.");
            }
        }

        Assistant IPersistableModel<Assistant>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<Assistant>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeAssistant(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(Assistant)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<Assistant>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static Assistant FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAssistant(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
