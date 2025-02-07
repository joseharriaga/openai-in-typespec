// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;

namespace OpenAI.FineTuning
{
    internal partial class InternalTodoFineTuneSupervisedMethod : IJsonModel<InternalTodoFineTuneSupervisedMethod>
    {
        void IJsonModel<InternalTodoFineTuneSupervisedMethod>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalTodoFineTuneSupervisedMethod>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalTodoFineTuneSupervisedMethod)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(Hyperparameters) && _additionalBinaryDataProperties?.ContainsKey("hyperparameters") != true)
            {
                writer.WritePropertyName("hyperparameters"u8);
                writer.WriteObjectValue(Hyperparameters, options);
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

        InternalTodoFineTuneSupervisedMethod IJsonModel<InternalTodoFineTuneSupervisedMethod>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);

        protected virtual InternalTodoFineTuneSupervisedMethod JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalTodoFineTuneSupervisedMethod>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalTodoFineTuneSupervisedMethod)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalTodoFineTuneSupervisedMethod(document.RootElement, options);
        }

        internal static InternalTodoFineTuneSupervisedMethod DeserializeInternalTodoFineTuneSupervisedMethod(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            InternalFineTuneSupervisedMethodHyperparameters hyperparameters = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("hyperparameters"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    hyperparameters = InternalFineTuneSupervisedMethodHyperparameters.DeserializeInternalFineTuneSupervisedMethodHyperparameters(prop.Value, options);
                    continue;
                }
                if (true)
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalTodoFineTuneSupervisedMethod(hyperparameters, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalTodoFineTuneSupervisedMethod>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalTodoFineTuneSupervisedMethod>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalTodoFineTuneSupervisedMethod)} does not support writing '{options.Format}' format.");
            }
        }

        InternalTodoFineTuneSupervisedMethod IPersistableModel<InternalTodoFineTuneSupervisedMethod>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);

        protected virtual InternalTodoFineTuneSupervisedMethod PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalTodoFineTuneSupervisedMethod>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalTodoFineTuneSupervisedMethod(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalTodoFineTuneSupervisedMethod)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalTodoFineTuneSupervisedMethod>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalTodoFineTuneSupervisedMethod internalTodoFineTuneSupervisedMethod)
        {
            if (internalTodoFineTuneSupervisedMethod == null)
            {
                return null;
            }
            return BinaryContent.Create(internalTodoFineTuneSupervisedMethod, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalTodoFineTuneSupervisedMethod(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalTodoFineTuneSupervisedMethod(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
