// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Chat;
using Azure.AI.OpenAI.Internal;

namespace Azure.AI.OpenAI.Chat;

public static partial class AzureChatCompletionOptionsExtensions
{
    [Experimental("AOAI001")]
    public static void AddDataSource(this ChatCompletionOptions options, AzureChatDataSource dataSource)
    {
        options.SerializedAdditionalRawData ??= new Dictionary<string, BinaryData>();

        IList<AzureChatDataSource> existingSources
            = AdditionalPropertyHelpers.GetAdditionalListProperty<AzureChatDataSource>(
                options.SerializedAdditionalRawData,
                "data_sources")
            ?? new ChangeTrackingList<AzureChatDataSource>();
        existingSources.Add(dataSource);
        AdditionalPropertyHelpers.SetAdditionalProperty(
            options.SerializedAdditionalRawData,
            "data_sources",
            existingSources);
    }

    [Experimental("AOAI001")]
    public static IReadOnlyList<AzureChatDataSource> GetDataSources(this ChatCompletionOptions options)
    {
        return AdditionalPropertyHelpers.GetAdditionalListProperty<AzureChatDataSource>(
            options.SerializedAdditionalRawData,
            "data_sources") as IReadOnlyList<AzureChatDataSource>;
    }

    /// <summary>
    /// <para>[Temporary extension method for o1 model support]</para>
    /// </summary>
    /// 
    /// <param name="options"></param>
    [Experimental("AOAI001")]
    public static void ToggleMaxTokensJsonPropertyName(this ChatCompletionOptions options)
    {
        if (options?.MaxTokens is null && options?.InternalMaxTokens is null)
        {
            throw new InvalidOperationException(
                $"{nameof(ToggleMaxTokensJsonPropertyName)} must be called after setting a MaxTokens value and before calling "
                + "a chat completion method. Note that this will transfer the value from 'max_tokens' to 'max_completion_tokens' "
                + "and is not compatible with service API versions older than 2024-09-01-preview when using non-o1 models.");
        }
        int? newMaxTokens = options.MaxTokens;
        int? oldMaxTokens = options.InternalMaxTokens;
        options.MaxTokens = oldMaxTokens;
        options.InternalMaxTokens = newMaxTokens;
    }
}
