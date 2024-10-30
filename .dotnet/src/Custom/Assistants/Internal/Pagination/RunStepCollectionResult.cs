using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

#nullable enable

namespace OpenAI.Assistants;

internal class RunStepCollectionResult : CollectionResult<RunStep>
{
    private readonly InternalAssistantRunClient _runClient;
    private readonly RequestOptions? _options;

    // Initial values
    private readonly string _threadId;
    private readonly string _runId;
    private readonly int? _limit;
    private readonly string? _order;
    private readonly string? _after;
    private readonly string? _before;
    private readonly IList<string>? _include;

    public RunStepCollectionResult(InternalAssistantRunClient runClient,
        RequestOptions? options,
        string threadId, string runId,
        int? limit, string? order, string? after, string? before, IEnumerable<string>? include)
    {
        _runClient = runClient;
        _options = options;

        _threadId = threadId;
        _runId = runId;
        _limit = limit;
        _order = order;
        _after = after;
        _before = before;
        _include = include?.ToList();
    }

    public override IEnumerable<ClientResult> GetRawPages()
    {
        ClientResult page = GetFirstPage();
        yield return page;

        while (HasNextPage(page))
        {
            page = GetNextPage(page);
            yield return page;
        }
    }

    protected override IEnumerable<RunStep> GetValuesFromPage(ClientResult page)
    {
        Argument.AssertNotNull(page, nameof(page));

        PipelineResponse response = page.GetRawResponse();
        InternalListRunStepsResponse list = ModelReaderWriter.Read<InternalListRunStepsResponse>(response.Content)!;
        return list.Data;
    }

    public override ContinuationToken? GetContinuationToken(ClientResult page)
    {
        Argument.AssertNotNull(page, nameof(page));

        return RunStepCollectionPageToken.FromResponse(page, _threadId, _runId, _limit, _order, _before, _include);
    }

    public ClientResult GetFirstPage()
        => _runClient.GetRunSteps(_threadId, _runId, _limit, _order, _after, _before, _include?.Select(s => new IncludedRunStepProperty(s)), _options);

    public ClientResult GetNextPage(ClientResult result)
    {
        Argument.AssertNotNull(result, nameof(result));

        PipelineResponse response = result.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        string lastId = doc.RootElement.GetProperty("last_id"u8).GetString()!;

        return _runClient.GetRunSteps(_threadId, _runId, _limit, _order, lastId, _before, _include?.Select(s => new IncludedRunStepProperty(s)), _options);
    }

    public static bool HasNextPage(ClientResult result)
    {
        Argument.AssertNotNull(result, nameof(result));

        PipelineResponse response = result.GetRawResponse();

        using JsonDocument doc = JsonDocument.Parse(response.Content);
        bool hasMore = doc.RootElement.GetProperty("has_more"u8).GetBoolean();

        return hasMore;
    }
}
