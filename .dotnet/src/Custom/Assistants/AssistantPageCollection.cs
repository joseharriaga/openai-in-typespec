using OpenAI.Assistants;
using System.ClientModel;
using System.ClientModel.Primitives;
using System;

#nullable enable

namespace OpenAI;

#pragma warning disable OPENAI001
internal class AssistantPageCollection : PageCollection<Assistant>
{
    private readonly AssistantClient _client;
    private readonly OpenAIPageCollectionOptions _firstPageOptions;

    public AssistantPageCollection(AssistantClient client, OpenAIPageCollectionOptions firstPageOptions)
        : base(GetFirstPageToken(firstPageOptions))
    {
        _client = client;
        _firstPageOptions = firstPageOptions;
    }

    private static OpenAIPageToken FromOptions(OpenAIPageCollectionOptions options, string? currentPageAfter)
        => new(options.PageSize, options.Order?.ToString(), options.AfterItemId, currentPageAfter, options.BeforeItemId);

    private static OpenAIPageToken GetFirstPageToken(OpenAIPageCollectionOptions options)
        => FromOptions(options, options.AfterItemId);

    private static OpenAIPageToken? GetNextPageToken(OpenAIPageCollectionOptions options, bool hasMore, string? lastId)
    {
        if (!hasMore)
        {
            return null;
        }

        return FromOptions(options, lastId);
    }

    public override ClientPage<Assistant> GetPage(PageToken pageToken)
    {
        if (pageToken is not OpenAIPageToken oaiToken)
        {
            throw new ArgumentException("Invalid page token.");
        }

        // Call the protocol method using values stored in page token.
        ClientResult result = _client.GetAssistantsPage(
            limit: oaiToken.PageSize,
            order: oaiToken.Order,
            after: oaiToken.CurrentPageAfter,
            before: oaiToken.Before,
            options: null);

        PipelineResponse response = result.GetRawResponse();
        InternalListAssistantsResponse list = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content)!;

        OpenAIPageToken? nextPageToken = GetNextPageToken(_firstPageOptions, list.HasMore, list.LastId);
        return ClientPage<Assistant>.Create(list.Data, pageToken, nextPageToken, response);
    }
}
#pragma warning restore OPENAI001