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
    private readonly OpenAIPageOptions _firstPageOptions;

    public AssistantPageCollection(AssistantClient client, OpenAIPageOptions firstPageOptions)
        : base(GetFirstPageToken(firstPageOptions))
    {
        _client = client;
        _firstPageOptions = firstPageOptions;
    }

    private static OpenAIPageToken FromOptions(OpenAIPageOptions options, string? currentPageAfter)
        => new(options.PageSize, options.Order?.ToString(), options.AfterItemId, currentPageAfter, options.BeforeItemId);

    private static OpenAIPageToken GetFirstPageToken(OpenAIPageOptions options)
        => FromOptions(options, options.AfterItemId);

    private static OpenAIPageToken? GetNextPageToken(OpenAIPageOptions options, bool hasMore, string? lastId)
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

    //private readonly ListOrder? _order;
    //private readonly string? _after;
    //private readonly string? _before;
    //private readonly int? _pageSize;

    //public AssistantPageCollection(AssistantClient client, ListOrder? order, string? after, string? before, int? pageSize)
    //{
    //    _client = client;
    //    _order = order;
    //    _after = after;
    //    _before = before;
    //    _pageSize = pageSize;
    //}

    //protected override ClientPage<Assistant> GetPageCore(string pageToken)
    //{
    //    string? after = pageToken is ClientPage<Assistant>.DefaultFirstPageToken ?
    //        _after :
    //        pageToken;

    //    ClientResult result = _client.GetAssistants(
    //        limit: _pageSize,
    //        order: _order?.ToString(),
    //        after: after,
    //        before: _before,
    //        options: null);

    //    PipelineResponse response = result.GetRawResponse();
    //    InternalListAssistantsResponse list = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content)!;

    //    return ClientPage<Assistant>.Create(list.Data, response, nextPageToken: list.HasMore ? list.LastId : default);
    //}
}
#pragma warning restore OPENAI001