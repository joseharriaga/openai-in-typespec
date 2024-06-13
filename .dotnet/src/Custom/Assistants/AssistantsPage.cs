//using OpenAI.Assistants;
//using System.ClientModel;
//using System.ClientModel.Primitives;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//#nullable enable

//namespace OpenAI;

//#pragma warning disable OPENAI001
//internal class AssistantsPage : ClientPage<Assistant>
//{
//    private readonly AssistantClient _client;

//    // This is everything I need to request the next page in the collection,
//    // plus whatever comes back in the response for the next page.

//    private readonly int? _limit;
//    private readonly string? _order;
//    private readonly string? _after;
//    private readonly string? _before;

//    //Note: you could also do it with a closure if you wanted to
//    //Func<ClientResult> getPageResult,
//    //Func<Task<ClientResult>> getPageResultAsync,

//    AssistantsPage(AssistantClient client,

//        int? limit,
//        string? order,
//        string? after,
//        string? before,

//        IReadOnlyList<Assistant> values, bool hasNext, PipelineResponse response)
//        : base(values, hasNext, response)
//    {
//        _client = client;

//        _limit = limit;
//        _order = order;
//        _after = after;
//        _before = before;
//    }

//    public static AssistantsPage FromInputs(AssistantClient client,
//        int? limit,
//        string? order,
//        string? after,
//        string? before,
//        RequestOptions? options = null)
//    {
//        ClientResult result = client.GetAssistants(limit, order, after, before, options);
//        PipelineResponse response = result.GetRawResponse();
//        InternalListAssistantsResponse list = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content)!;
//        return new AssistantsPage(client, limit, order, after, before, list.Data, list.HasMore, response);
//    }

//    public static async Task<AssistantsPage> FromInputsAsync(AssistantClient client,
//        int? limit,
//        string? order,
//        string? after,
//        string? before,
//        RequestOptions? options = null)
//    {
//        ClientResult result = await client.GetAssistantsAsync(limit, order, after, before, options).ConfigureAwait(false);
//        PipelineResponse response = result.GetRawResponse();
//        InternalListAssistantsResponse list = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content)!;
//        return new AssistantsPage(client, limit, order, after, before, list.Data, list.HasMore, response);
//    }

//    protected override ClientPage<Assistant> GetNext(RequestOptions? options = null)
//    {
//        return FromInputs(_client, _limit, _order, _after, _before, options);
//    }

//    protected override async Task<ClientPage<Assistant>> GetNextAsync(RequestOptions? options = null)
//    {
//        return await FromInputsAsync(_client, _limit, _order, _after, _before, options).ConfigureAwait(false);
//    }

//    //protected override ClientPage<Assistant> GetNext(RequestOptions? options = null)
//    //{
//    //    ClientResult result = _client.GetAssistants(_limit, _order, _after, _before, options);
//    //    PipelineResponse response = result.GetRawResponse();
//    //    InternalListAssistantsResponse list = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content)!;
//    //    return new AssistantsPage(_client, _limit, _order, _after, _before, list.Data, list.HasMore, response);
//    //}

//    //protected override async Task<ClientPage<Assistant>> GetNextAsync(RequestOptions? options = null)
//    //{
//    //    ClientResult result = await _client.GetAssistantsAsync(_limit, _order, _after, _before, options).ConfigureAwait(false);
//    //    PipelineResponse response = result.GetRawResponse();
//    //    InternalListAssistantsResponse list = ModelReaderWriter.Read<InternalListAssistantsResponse>(response.Content)!;
//    //    return new AssistantsPage(_client, _limit, _order, _after, _before, list.Data, list.HasMore, response);
//    //}
//}
//#pragma warning restore OPENAI001