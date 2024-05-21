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
        if (!AdditionalPropertyHelpers.TryGetAdditionalProperty<IList<AzureChatDataSource>,AzureChatDataSource>(
            options.SerializedAdditionalRawData,
            "data_sources",
            out IList<AzureChatDataSource> existingDataSources))
        {
            existingDataSources = new ChangeTrackingList<AzureChatDataSource>();
        }
        existingDataSources.Add(dataSource);
        AdditionalPropertyHelpers.SetAdditionalProperty(options.SerializedAdditionalRawData, "data_sources", existingDataSources);
    }

    [Experimental("OPENAI002")]
    public static IReadOnlyList<AzureChatDataSource> GetDataSources(this ChatCompletionOptions options)
    {
        return AdditionalPropertyHelpers.TryGetAdditionalProperty<IList<AzureChatDataSource>,AzureChatDataSource>(
            options.SerializedAdditionalRawData,
            "data_sources",
            out IList<AzureChatDataSource> existingDataSources)
                ? existingDataSources as IReadOnlyList<AzureChatDataSource>
                : [];
    }
}
