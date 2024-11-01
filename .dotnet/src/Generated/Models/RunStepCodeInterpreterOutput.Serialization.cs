// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;

namespace OpenAI.Assistants
{
    [PersistableModelProxy(typeof(UnknownRunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject))]
    public abstract partial class RunStepCodeInterpreterOutput : IJsonModel<RunStepCodeInterpreterOutput>
    {
        internal RunStepCodeInterpreterOutput()
        {
        }

        void IJsonModel<RunStepCodeInterpreterOutput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunStepCodeInterpreterOutput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepCodeInterpreterOutput)} does not support writing '{format}' format.");
            }
            if (_additionalBinaryDataProperties?.ContainsKey("type") != true)
            {
                writer.WritePropertyName("type"u8);
                writer.WriteStringValue(Type);
            }
            if (true && _additionalBinaryDataProperties != null)
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

        RunStepCodeInterpreterOutput IJsonModel<RunStepCodeInterpreterOutput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual RunStepCodeInterpreterOutput JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunStepCodeInterpreterOutput>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RunStepCodeInterpreterOutput)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRunStepCodeInterpreterOutput(document.RootElement, options);
        }

        internal static RunStepCodeInterpreterOutput DeserializeRunStepCodeInterpreterOutput(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "logs":
                        return InternalRunStepCodeInterpreterLogOutput.DeserializeInternalRunStepCodeInterpreterLogOutput(element, options);
                    case "image":
                        return InternalRunStepDetailsToolCallsCodeOutputImageObject.DeserializeInternalRunStepDetailsToolCallsCodeOutputImageObject(element, options);
                }
            }
            return UnknownRunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject.DeserializeUnknownRunStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject(element, options);
        }

        BinaryData IPersistableModel<RunStepCodeInterpreterOutput>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunStepCodeInterpreterOutput>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(RunStepCodeInterpreterOutput)} does not support writing '{options.Format}' format.");
            }
        }

        RunStepCodeInterpreterOutput IPersistableModel<RunStepCodeInterpreterOutput>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual RunStepCodeInterpreterOutput PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<RunStepCodeInterpreterOutput>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeRunStepCodeInterpreterOutput(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RunStepCodeInterpreterOutput)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<RunStepCodeInterpreterOutput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(RunStepCodeInterpreterOutput runStepCodeInterpreterOutput)
        {
            if (runStepCodeInterpreterOutput == null)
            {
                return null;
            }
            return BinaryContent.Create(runStepCodeInterpreterOutput, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator RunStepCodeInterpreterOutput(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeRunStepCodeInterpreterOutput(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
