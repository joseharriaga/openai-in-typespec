// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Assistants;
using Azure.AI.OpenAI.Internal;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Assistants;

/// <inheritdoc/>
public partial class AzureTextAnnotation : TextAnnotation
{
    /// <inheritdoc/>
    private InternalMessageContentTextAnnotationsBingSearchUrlCitation _bingSearchCitation;

    /// <inheritdoc/>
    public override int StartIndex => _bingSearchCitation?.StartIndex ?? base.StartIndex;

    /// <inheritdoc/>
    public override int EndIndex => _bingSearchCitation?.EndIndex ?? base.EndIndex;

    /// <inheritdoc/>
    public override string TextToReplace => _bingSearchCitation?.Text ?? base.TextToReplace;

    /// <inheritdoc/>
    public string BingSearchTitle => _bingSearchCitation?.UrlCitation?.Title;

    /// <inheritdoc/>
    public Uri BingSearchUrl => _bingSearchCitation?.UrlCitation?.Url;

    internal AzureTextAnnotation(TextAnnotation baseAnnotation)
        : base(baseAnnotation._internalAnnotation)
    {
        if (baseAnnotation._internalAnnotation is UnknownMessageContentTextObjectAnnotation unknownAnnotation
            && unknownAnnotation.Type == "url_citation")
        {
            string text = unknownAnnotation._serializedAdditionalRawData["text"].ToString();
            int startIndex = int.Parse(unknownAnnotation._serializedAdditionalRawData["start_index"].ToString());
            int endIndex = int.Parse(unknownAnnotation._serializedAdditionalRawData["end_index"].ToString());
            InternalMessageContentTextAnnotationsBingSearchUrlCitationUrlCitation bingSearchCitationObject
                = ModelReaderWriter.Read<InternalMessageContentTextAnnotationsBingSearchUrlCitationUrlCitation>(
                    unknownAnnotation._serializedAdditionalRawData["url_citation"]);
            _bingSearchCitation = new InternalMessageContentTextAnnotationsBingSearchUrlCitation(text, bingSearchCitationObject, startIndex, endIndex);
        }
    }
}