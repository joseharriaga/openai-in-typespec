

using OpenAI.Chat;
using OpenAI.ClientShared.Internal;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI.Chat;

public partial class AzureChatCompletionOptions
{
    protected override void WriteAdditionalDataForDerivedTypes(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        base.WriteAdditionalDataForDerivedTypes(writer, options);
        if (OptionalProperty.IsCollectionDefined(DataSources))
        {
            writer.WritePropertyName("data_sources"u8);
            writer.WriteStartArray();
            foreach (AzureChatDataSource dataSource in DataSources)
            {
                writer.WriteObjectValue(dataSource);
            }
            writer.WriteEndArray();
        }
    }
}