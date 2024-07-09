// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Assistants;
using Azure.AI.OpenAI.Internal;
using OpenAI.Chat;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI;

public static partial class AzureMessageContentExtensions
{
    [Experimental("AOAI001")]
    public static IReadOnlyList<AzureTextAnnotation> GetAzureTextAnnotations(this MessageContent messageContent)
    {
        List<AzureTextAnnotation> annotations = [];

        foreach (TextAnnotation baseAnnotation in messageContent.TextAnnotations)
        {
            annotations.Add(new AzureTextAnnotation(baseAnnotation));
        }
        return annotations;
    }
}
