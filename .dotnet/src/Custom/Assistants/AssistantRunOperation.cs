using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.Assistants;

// TODO: add hooks for cancel run?

internal class AssistantRunOperation : ResultOperation<StatusBasedResult<RunStatus, ThreadRun>>
{
    private static readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(2);

    private readonly string _threadId;
    private readonly string _runId;

    private readonly Func<string, string, ClientResult<ThreadRun>> _getRun;
    private readonly Func<string, string, Task<ClientResult<ThreadRun>>> _getRunAsync;

    private ClientResult<ThreadRun> _lastSeenResult;

    public AssistantRunOperation(ClientResult<ThreadRun> createResult,
        Func<string, string, ClientResult<ThreadRun>> getRun,
        Func<string, string, Task<ClientResult<ThreadRun>>> getRunAsync) :
        base(GetIdFromResult(createResult), GetResponseFromResult(createResult))
    {
        _lastSeenResult = createResult;
        Value = new ThreadRunStatusResult(createResult.Value, this);

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

        _lastSeenResult = _getRun(_threadId, _runId);

        // TODO: we can probably avoid an allocation, but might need to make
        // status setter protected
        Value = new ThreadRunStatusResult(_lastSeenResult.Value, this);

        if (Value.Status.IsTerminal)
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

        Value = new ThreadRunStatusResult(_lastSeenResult.Value, this);

        if (Value.Status.IsTerminal)
        {
            HasCompleted = true;
        }

        SetRawResponse(_lastSeenResult.GetRawResponse());

        return _lastSeenResult;
    }

    public override ClientResult<StatusBasedResult<RunStatus, ThreadRun>> WaitForCompletion(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            UpdateStatus();

            if (HasCompleted)
            {
                StatusBasedResult<RunStatus, ThreadRun> value = new ThreadRunStatusResult(_lastSeenResult.Value, this);
                return FromValue(value, _lastSeenResult.GetRawResponse());
            }

            // TODO: note pollling interval logic may change for e.g. exponential
            // backoff if the operation is paused.
            cancellationToken.WaitHandle.WaitOne(pollingInterval.Value);
        }
    }

    public override async ValueTask<ClientResult<StatusBasedResult<RunStatus, ThreadRun>>> WaitForCompletionAsync(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await UpdateStatusAsync().ConfigureAwait(false);

            if (HasCompleted)
            {
                StatusBasedResult<RunStatus, ThreadRun> value = new ThreadRunStatusResult(_lastSeenResult.Value, this);
                return FromValue(value, _lastSeenResult.GetRawResponse());
            }

            await Task.Delay(pollingInterval.Value, cancellationToken).ConfigureAwait(false);
        }
    }

    public override ClientResult WaitForCompletionResult(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default)
        => WaitForCompletion(pollingInterval, cancellationToken);

    public override async ValueTask<ClientResult> WaitForCompletionResultAsync(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default)
        => await WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
}
