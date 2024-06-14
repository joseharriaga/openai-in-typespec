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
        _firstPageToken = OpenAIPageToken.FromOptions(firstPageOptions);
    }

    // rehydration method constructor
    public AssistantPageCollection(AssistantClient client, OpenAIPageToken pageToken)
    {
        _client = client;
        _firstPageToken = OpenAIPageToken.FromToken(pageToken, default);
    }

    public override PageToken FirstPageToken => _firstPageToken;

    public override ClientPage<Assistant> GetPage(PageToken pageToken, RequestOptions? options)
    {
        if (pageToken is not OpenAIPageToken oaiToken)
        {
            throw new ArgumentException("Invalid page token.");
        }

        ClientResult result = pageToken.HasResponseValues ?

             // Call the method that gets a page using client-only values
             _client.GetAssistantsPage(
                limit: oaiToken.PageSize,
                order: oaiToken.Order,
                after: oaiToken.After,
                before: oaiToken.Before,
                options: options)
             :
             // Call the method that gets a page using a combination of service and client values
             _client.GetAssistantsPage(
                limit: oaiToken.PageSize,
                order: oaiToken.Order,
                after: oaiToken.LastSeenId,
                before: oaiToken.Before,
                options: options);

        PipelineResponse response = result.GetRawResponse();
        InternalListAssistantsResponse list = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content)!;

        OpenAIPageToken? nextPageToken = OpenAIPageToken.GetNextPageToken(_firstPageToken, list.HasMore, list.LastId);
        return ClientPage<Assistant>.Create(list.Data, pageToken, nextPageToken, response);
    }

}
#pragma warning restore OPENAI001