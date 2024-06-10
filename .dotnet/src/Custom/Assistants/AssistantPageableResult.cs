using OpenAI.Assistants;
using System.ClientModel;
using System.ClientModel.Primitives;

#nullable enable


namespace OpenAI;

#pragma warning disable OPENAI001
internal class AssistantPageableResult : ClientPageable<Assistant>
{
    private readonly AssistantClient _client;

    private readonly ListOrder? _order;
    private readonly string? _after;
    private readonly string? _before;
    private readonly int? _pageSize;

    public AssistantPageableResult(AssistantClient client, ListOrder? order, string? after, string? before, int? pageSize)
    {
        _client = client;
        _order = order;
        _after = after;
        _before = before;
        _pageSize = pageSize;
    }

    protected override ClientPage<Assistant> GetPageCore(string pageToken)
    {
        string? after = pageToken is ClientPage<Assistant>.DefaultFirstPageToken ?
            _after :
            pageToken;

        ClientResult result = _client.GetAssistants(
            limit: _pageSize,
            order: _order?.ToString(),
            after: after,
            before: _before,
            options: null);

        PipelineResponse response = result.GetRawResponse();
        InternalListAssistantsResponse list = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content)!;

        return ClientPage<Assistant>.Create(list.Data, response, nextPageToken: list.HasMore ? list.LastId : default);
    }
}
#pragma warning restore OPENAI001