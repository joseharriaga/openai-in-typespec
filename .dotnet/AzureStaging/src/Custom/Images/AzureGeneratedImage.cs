// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Internal;
using OpenAI.Images;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Images;

public static class AzureGeneratedImageExtensions
{
    [Experimental("OPENAI002")]
    public static ImageResponseContentFilterResult GetResponseContentFilterResults(this GeneratedImage image)
        => AdditionalPropertyHelpers.TryGetAdditionalProperty(image.SerializedAdditionalRawData,
            "content_filter_results",
            out ImageResponseContentFilterResult result)
                ? result
                : null;

    [Experimental("OPENAI002")]
    public static ImagePromptContentFilterResult GetPromptContentFilterResults(this GeneratedImage image)
        => AdditionalPropertyHelpers.TryGetAdditionalProperty(image.SerializedAdditionalRawData,
            "prompt_filter_results",
            out ImagePromptContentFilterResult result)
                ? result
                : null;
}