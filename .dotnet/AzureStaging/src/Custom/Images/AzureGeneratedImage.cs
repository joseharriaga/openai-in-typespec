// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Internal;
using OpenAI.Images;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Images;

public static class AzureGeneratedImageExtensions
{
    public static ImageResponseContentFilterResult GetResponseContentFilterResults(this GeneratedImage image)
        => image.TryGetSardValue("content_filter_results", out ImageResponseContentFilterResult result) ? result : null;
    public static ImagePromptContentFilterResult GetPromptContentFilterResults(this GeneratedImage image)
        => image.TryGetSardValue("prompt_filter_results", out ImagePromptContentFilterResult result) ? result : null;
}