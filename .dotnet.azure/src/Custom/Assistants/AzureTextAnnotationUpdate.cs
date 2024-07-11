// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Assistants;
using Azure.AI.OpenAI.Internal;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Assistants;

public static partial class TextAnnotationUpdateExtensions
{
    /// <summary>
    /// Gets a value indicating whether the text annotation represents one provided by an Azure OpenAI Bing Search
    /// <c>browser</c> tool.
    /// </summary>
    /// <param name="baseAnnotation"> The annotation being evaluated. </param>
    /// <returns> True if the annotation has a <c>browser</c> tool <c>url_citation</c>, false otherwise. </returns>
    [Experimental("AOAI001")]
    public static bool IsBingSearchAnnotation(this TextAnnotationUpdate baseAnnotation)
    {
        return GetInternalUrlCitationFrom(baseAnnotation) != null;
    }

    /// <summary>
    /// If applicable, gets the page title from an Azure OpenAI Bing Search <c>browser</c> tool's text content
    /// annotation.
    /// </summary>
    /// <param name="baseAnnotation"> The annotation being evaluated. </param>
    /// <returns> If present, the <c>title</c> from a <c>browser</c> tool annotation; null otherwise. </returns>
    [Experimental("AOAI001")]
    public static string GetBingSearchTitle(this TextAnnotationUpdate baseAnnotation)
    {
        return GetInternalUrlCitationFrom(baseAnnotation)?.Title;
    }

    /// <summary>
    /// If applicable, gets the page URL from an Azure OpenAI Bing Search <c>browser</c> tool's text content
    /// annotation.
    /// </summary>
    /// <param name="baseAnnotation"> The annotation being evaluated. </param>
    /// <returns> If present, the <c>url</c> from a <c>browser</c> tool annotation; null otherwise. </returns>
    [Experimental("AOAI001")]
    public static Uri GetBingSearchUrl(this TextAnnotationUpdate baseAnnotation)
    {
        return GetInternalUrlCitationFrom(baseAnnotation)?.Url;
    }

    private static InternalMessageDeltaContentTextAnnotationsBingSearchUrlCitationUrlCitation
        GetInternalUrlCitationFrom(TextAnnotationUpdate baseAnnotation)
    {
        return baseAnnotation?._internalAnnotation?
            ._serializedAdditionalRawData?.TryGetValue("url_citation", out BinaryData citationData) == true
                ? ModelReaderWriter.Read<InternalMessageDeltaContentTextAnnotationsBingSearchUrlCitationUrlCitation>(citationData)
                : null;
    }
}
