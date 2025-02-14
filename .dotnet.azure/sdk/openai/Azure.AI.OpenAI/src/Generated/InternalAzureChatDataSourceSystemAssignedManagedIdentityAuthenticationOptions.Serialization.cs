// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.OpenAI;

namespace Azure.AI.OpenAI.Chat
{
    internal partial class InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions : IJsonModel<InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions>
    {
        void IJsonModel<InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
        }

        InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions IJsonModel<InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => (InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions)JsonModelCreateCore(ref reader, options);

        protected override DataSourceAuthentication JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions)} does not support reading '{format}' format.");
            }
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions(document.RootElement, options);
        }

        internal static InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions DeserializeInternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string @type = "system_assigned_managed_identity";
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("type"u8))
                {
                    @type = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions(@type, additionalBinaryDataProperties);
        }

        BinaryData IPersistableModel<InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);

        protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions)} does not support writing '{options.Format}' format.");
            }
        }

        InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions IPersistableModel<InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions>.Create(BinaryData data, ModelReaderWriterOptions options) => (InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions)PersistableModelCreateCore(data, options);

        protected override DataSourceAuthentication PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    using (JsonDocument document = JsonDocument.Parse(data))
                    {
                        return DeserializeInternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public static implicit operator BinaryContent(InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions internalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions)
        {
            if (internalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions == null)
            {
                return null;
            }
            return BinaryContent.Create(internalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions, ModelSerializationExtensions.WireOptions);
        }

        public static explicit operator InternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions(ClientResult result)
        {
            using PipelineResponse response = result.GetRawResponse();
            using JsonDocument document = JsonDocument.Parse(response.Content);
            return DeserializeInternalAzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
