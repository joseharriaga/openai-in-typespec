// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.OpenAI.Assistants;
using Azure.AI.OpenAI.Internal;

#pragma warning disable AZC0112

namespace Azure.AI.OpenAI.Assistants;

/// <inheritdoc/>
public partial class AzureTextAnnotationUpdate : TextAnnotationUpdate
{
    private InternalMessageDeltaContentTextAnnotationsBingSearchUrlCitation _bingSearchCitation;

    /// <inheritdoc/>
    public override int ContentIndex => _bingSearchCitation?.Index ?? base.ContentIndex;

    /// <inheritdoc/>
    public override int? StartIndex => _bingSearchCitation?.StartIndex ?? base.StartIndex;

    /// <inheritdoc/>
    public override int? EndIndex => _bingSearchCitation?.EndIndex ?? base.EndIndex;

    /// <inheritdoc/>
    public override string TextToReplace => _bingSearchCitation?.Text ?? base.TextToReplace;

    /// <inheritdoc/>
    public string BingSearchTitle => _bingSearchCitation?.UrlCitation?.Title;

    /// <inheritdoc/>
    public Uri BingSearchUrl => _bingSearchCitation?.UrlCitation?.Url;

    internal AzureTextAnnotationUpdate(TextAnnotationUpdate baseAnnotationUpdate)
        : base(baseAnnotationUpdate._internalAnnotation)
    {
        if (baseAnnotationUpdate._internalAnnotation is UnknownMessageDeltaTextContentAnnotation unknownAnnotation
            && unknownAnnotation.Type == "url_citation")
        {
            int index = int.Parse(unknownAnnotation._serializedAdditionalRawData["index"].ToString());
            string text = unknownAnnotation._serializedAdditionalRawData.TryGetValue(
                "text",
                out BinaryData textData)
                    ? textData.ToString()
                    : null;
            int? startIndex = unknownAnnotation._serializedAdditionalRawData.TryGetValue(
                "start_index",
                out BinaryData startIndexData)
                    ? int.Parse(startIndexData.ToString())
                    : null;
            int? endIndex = unknownAnnotation._serializedAdditionalRawData.TryGetValue(
                "start_index",
                out BinaryData endIndexData)
                    ? int.Parse(startIndexData.ToString())
                    : null;
            InternalMessageDeltaContentTextAnnotationsBingSearchUrlCitationUrlCitation bingSearchCitationObject
                = unknownAnnotation._serializedAdditionalRawData.TryGetValue(
                    "url_citation",
                    out BinaryData urlCitationData)
                        ? ModelReaderWriter.Read<InternalMessageDeltaContentTextAnnotationsBingSearchUrlCitationUrlCitation>(urlCitationData)
                        : null;
            _bingSearchCitation = new InternalMessageDeltaContentTextAnnotationsBingSearchUrlCitation()
            {
                Index = index,
                Text = text,
                UrlCitation = bingSearchCitationObject,
                StartIndex = startIndex,
                EndIndex = endIndex,
            };
        }
    }
}