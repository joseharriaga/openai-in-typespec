// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Internal;
using OpenAI.Chat;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Azure.AI.OpenAI.Chat;
public static partial class AzureChatCompletionOptionsExtensions
{
    [Experimental("OPENAI002")]
    public static void AddDataSource(this ChatCompletionOptions options, AzureChatDataSource dataSource)
    {
        options._serializedAdditionalRawData ??= new ChangeTrackingDictionary<string, BinaryData>();
        IList<AzureChatDataSource> existingSources
            = AdditionalPropertyHelpers.GetAdditionalListProperty<AzureChatDataSource>(
                options._serializedAdditionalRawData,
                "data_sources")
            ?? new ChangeTrackingList<AzureChatDataSource>();
        existingSources.Add(dataSource);
        AdditionalPropertyHelpers.SetAdditionalProperty(
            options._serializedAdditionalRawData,
            "data_sources",
            existingSources);
    }

    [Experimental("OPENAI002")]
    public static IReadOnlyList<AzureChatDataSource> GetDataSources(this ChatCompletionOptions options)
    {
        return AdditionalPropertyHelpers.GetAdditionalListProperty<AzureChatDataSource>(
            options._serializedAdditionalRawData,
            "data_sources") as IReadOnlyList<AzureChatDataSource>;
    }
}
