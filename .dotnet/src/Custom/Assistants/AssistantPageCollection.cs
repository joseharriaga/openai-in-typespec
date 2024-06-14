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
    private readonly OpenAIPageToken _firstPageToken;

    // service method constructor
    public AssistantPageCollection(AssistantClient client, OpenAIPageCollectionOptions firstPageOptions)
    {
        _client = client;
        _firstPageToken = GetFirstPageToken(firstPageOptions);
    }

    // rehydration method constructor
    public AssistantPageCollection(AssistantClient client, OpenAIPageToken pageToken)
    {
        _client = client;
        _firstPageToken = GetFirstPageToken(pageToken);
    }

    public override PageToken FirstPageToken => _firstPageToken;

    public override ClientPage<Assistant> GetPage(PageToken pageToken, RequestOptions? options)
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
            options: options);

        PipelineResponse response = result.GetRawResponse();
        InternalListAssistantsResponse list = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content)!;

        OpenAIPageToken? nextPageToken = GetNextPageToken(_firstPageToken, list.HasMore, list.LastId);
        return ClientPage<Assistant>.Create(list.Data, pageToken, nextPageToken, response);
    }

    private static OpenAIPageToken FromOptions(OpenAIPageCollectionOptions options, string? currentPageAfter)
        => new(options.PageSize, options.Order?.ToString(), options.AfterItemId, currentPageAfter, options.BeforeItemId);

    private static OpenAIPageToken FromToken(OpenAIPageToken token, string? currentPageAfter)
        => new(token.PageSize, token.Order, token.FirstPageAfter, currentPageAfter, token.Before);

    private static OpenAIPageToken GetFirstPageToken(OpenAIPageCollectionOptions options)
        => FromOptions(options, options.AfterItemId);

    private static OpenAIPageToken GetFirstPageToken(OpenAIPageToken token)
        => FromToken(token, token.FirstPageAfter);

    private static OpenAIPageToken? GetNextPageToken(OpenAIPageToken token, bool hasMore, string? lastId)
    {
        if (!hasMore)
        {
            return null;
        }

        return FromToken(token, lastId);
    }
}
#pragma warning restore OPENAI001