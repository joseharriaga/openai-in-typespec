using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.Assistants;

// TODO: add hooks for cancel run?

internal class AssistantRunOperation : ResultOperation<ThreadRun>
{
    private readonly string _threadId;
    private readonly string _runId;

    private readonly Func<string, string, ClientResult<ThreadRun>> _getRun;
    private readonly Func<string, string, Task<ClientResult<ThreadRun>>> _getRunAsync;

    private TimeSpan _pollingInterval = TimeSpan.FromSeconds(2);
    private ClientResult<ThreadRun> _lastSeenResult;

    public AssistantRunOperation(ClientResult<ThreadRun> createResult, 
        Func<string, string, ClientResult<ThreadRun>> getRun,
        Func<string, string, Task<ClientResult<ThreadRun>>> getRunAsync) :
        base(GetIdFromResult(createResult), GetResponseFromResult(createResult))
    {
        _lastSeenResult = createResult;
        Value = _lastSeenResult.Value;

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

    public override ClientResult UpdateStatus()
    {
        if (HasCompleted)
        {
            return _lastSeenResult;
        }

        ClientResult<ThreadRun> result = _getRun(_threadId, _runId);

        // Compute delta between result and _lastResult

        Value = _lastSeenResult.Value;

        if (_lastSeenResult.Value.Status.IsTerminal)
        {
            HasCompleted = true;
        }

        SetRawResponse(_lastSeenResult.GetRawResponse());

        return _lastSeenResult;
    }

    public override async ValueTask<ClientResult> UpdateStatusAsync()
    {
        if (HasCompleted)
        {
            return _lastSeenResult;
        }

        _lastSeenResult = await _getRunAsync(_threadId, _runId).ConfigureAwait(false);

        Value = _lastSeenResult.Value;

        if (_lastSeenResult.Value.Status.IsTerminal)
        {
            HasCompleted = true;
        }

        SetRawResponse(_lastSeenResult.GetRawResponse());

        return _lastSeenResult;
    }

    public override ClientResult<ThreadRun> WaitForCompletion(CancellationToken cancellationToken = default)
        => WaitForCompletion(_pollingInterval, cancellationToken);

    public override ClientResult<ThreadRun> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
    {
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            UpdateStatus();

            if (HasCompleted)
            {
                return _lastSeenResult;
            }

            cancellationToken.WaitHandle.WaitOne(_pollingInterval);
        }
    }

    public override async Task<ClientResult<ThreadRun>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        => await WaitForCompletionAsync(_pollingInterval, cancellationToken).ConfigureAwait(false);

    public override async Task<ClientResult<ThreadRun>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
    {
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await UpdateStatusAsync().ConfigureAwait(false);

            if (HasCompleted)
            {
                return _lastSeenResult;
            }

            await Task.Delay(pollingInterval, cancellationToken).ConfigureAwait(false);
        }
    }

    public override ClientResult WaitForCompletionResult(CancellationToken cancellationToken = default)
        => WaitForCompletion(_pollingInterval, cancellationToken);

    public override ClientResult WaitForCompletionResult(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        => WaitForCompletion(pollingInterval, cancellationToken);

    public override async ValueTask<ClientResult> WaitForCompletionResultAsync(CancellationToken cancellationToken = default)
        => await WaitForCompletionAsync(_pollingInterval, cancellationToken).ConfigureAwait(false);


    public override async ValueTask<ClientResult> WaitForCompletionResultAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        => await WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
}
