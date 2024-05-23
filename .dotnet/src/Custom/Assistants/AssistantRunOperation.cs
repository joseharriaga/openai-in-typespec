using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.Assistants;

internal class AssistantRunOperation : ResultOperation<ThreadRun>
{
    private readonly string _threadId;
    private readonly string _runId;

    private readonly Func<ClientResult<ThreadRun>> _getRun;
    private readonly Func<Task<ClientResult<ThreadRun>>> _getRunAsync;

    public AssistantRunOperation(ClientResult<ThreadRun> createResult, 
        Func<ClientResult<ThreadRun>> getRun,
        Func<Task<ClientResult<ThreadRun>>> getRunAsync) :
        base(GetIdFromResult(createResult), GetResponseFromResult(createResult))
    {
        _threadId = createResult.Value.ThreadId;
        _runId = createResult.Value.Id;

        _getRun = getRun;
        _getRunAsync = getRunAsync;
    }

    private static string GetIdFromResult(ClientResult<ThreadRun> result)
    {
        // TODO: validate this is reversible -- i.e. it will parse
        return $"{result.Value.ThreadId};{result.Value.Id}";
    }

    private static PipelineResponse GetResponseFromResult(ClientResult<ThreadRun> result)
        => result.GetRawResponse();

    public override PipelineResponse UpdateStatus()
    {
        if (HasCompleted)
        {
            return GetRawResponse();
        }

        ClientResult<ThreadRun> result = _getRun();

        PipelineResponse response = result.GetRawResponse();
        Value = result.Value;

        if (result.Value.Status.IsTerminal)
        {
            HasCompleted = true;
        }

        SetRawResponse(response);

        return response;
    }

    public override async ValueTask<PipelineResponse> UpdateStatusAsync()
    {
        if (HasCompleted)
        {
            return GetRawResponse();
        }

        ClientResult<ThreadRun> result = await _getRunAsync().ConfigureAwait(false);

        PipelineResponse response = result.GetRawResponse();
        Value = result.Value;

        if (result.Value.Status.IsTerminal)
        {
            HasCompleted = true;
        }

        SetRawResponse(response);

        return response;
    }

    public override ClientResult<ThreadRun> WaitForCompletion()
    {
        throw new NotImplementedException();
    }

    public override ClientResult<ThreadRun> WaitForCompletion(TimeSpan pollingInterval)
    {
        throw new NotImplementedException();
    }

    public override Task<ClientResult<ThreadRun>> WaitForCompletionAsync()
    {
        throw new NotImplementedException();
    }

    public override Task<ClientResult<ThreadRun>> WaitForCompletionAsync(TimeSpan pollingInterval)
    {
        throw new NotImplementedException();
    }

    public override PipelineResponse WaitForCompletionResponse(TimeSpan pollingInterval)
    {
        throw new NotImplementedException();
    }

    public override PipelineResponse WaitForCompletionResponse()
    {
        throw new NotImplementedException();
    }

    public override ValueTask<PipelineResponse> WaitForCompletionResponseAsync(TimeSpan pollingInterval)
    {
        throw new NotImplementedException();
    }

    public override ValueTask<PipelineResponse> WaitForCompletionResponseAsync()
    {
        throw new NotImplementedException();
    }
}
