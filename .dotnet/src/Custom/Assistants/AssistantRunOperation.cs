using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.Assistants;

// TODO: add hooks for cancel run?

internal class AssistantRunOperation : StatusBasedOperation<RunStatus, ThreadRun>
{
    private static readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(2);

    private readonly string _threadId;
    private readonly string _runId;

    private readonly Func<string, string, ClientResult<ThreadRun>> _getRun;
    private readonly Func<string, string, Task<ClientResult<ThreadRun>>> _getRunAsync;

    private ClientResult<ThreadRun> _lastSeenResult;

    private bool _statusChanged;
    private bool _paused;

    public AssistantRunOperation(ClientResult<ThreadRun> createResult,
        Func<string, string, ClientResult<ThreadRun>> getRun,
        Func<string, string, Task<ClientResult<ThreadRun>>> getRunAsync) :
        base(GetIdFromResult(createResult), createResult.Value.Status, GetResponseFromResult(createResult))
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

        // Compute delta between result and _lastSeenResult
        if (_lastSeenResult.Value.Status != result.Value.Status)
        {
            Status = result.Value.Status;
            _statusChanged = true;
        }

        _lastSeenResult = result;

        Value = result.Value;

        if (result.Value.Status.IsTerminal)
        {
            HasCompleted = true;
        }

        SetRawResponse(result.GetRawResponse());

        return result;
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

    public override ClientResult<ThreadRun> WaitForCompletion(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!_paused)
            {
                UpdateStatus();

                if (HasCompleted)
                {
                    return _lastSeenResult;
                }
            }

            // TODO: note pollling interval logic may change for e.g. exponential
            // backoff if the operation is paused.
            cancellationToken.WaitHandle.WaitOne(pollingInterval.Value);
        }
    }

    public override async ValueTask<ClientResult<ThreadRun>> WaitForCompletionAsync(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!_paused)
            {
                await UpdateStatusAsync().ConfigureAwait(false);

                if (HasCompleted)
                {
                    return _lastSeenResult;
                }
            }

            await Task.Delay(pollingInterval.Value, cancellationToken).ConfigureAwait(false);
        }
    }

    public override ClientResult WaitForCompletionResult(CancellationToken cancellationToken = default)
        => WaitForCompletion(DefaultPollingInterval, cancellationToken);

    public override ClientResult WaitForCompletionResult(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        => WaitForCompletion(pollingInterval, cancellationToken);

    public override async ValueTask<ClientResult> WaitForCompletionResultAsync(CancellationToken cancellationToken = default)
        => await WaitForCompletionAsync(DefaultPollingInterval, cancellationToken).ConfigureAwait(false);


    public override async ValueTask<ClientResult> WaitForCompletionResultAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default)
        => await WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);

    public override async ValueTask<ClientResult<(RunStatus Status, ThreadRun? Value)>> WaitForStatusUpdateAsync(TimeSpan? pollingInterval = null, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!_paused)
            {
                ClientResult result = await UpdateStatusAsync().ConfigureAwait(false);

                if (_statusChanged)
                {
                    (RunStatus Status, ThreadRun? Value) tuple = new(_lastSeenResult.Value.Status, _lastSeenResult.Value);
                    return FromValue(tuple, result.GetRawResponse());
                }
            }

            await Task.Delay(pollingInterval.Value, cancellationToken).ConfigureAwait(false);
        }
    }

    public override ClientResult<(RunStatus Status, ThreadRun? Value)> WaitForStatusUpdate(TimeSpan? pollingInterval = null, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (!_paused)
            {
                ClientResult result = UpdateStatus();

                if (_statusChanged)
                {
                    (RunStatus Status, ThreadRun? Value) tuple = new(_lastSeenResult.Value.Status, _lastSeenResult.Value);
                    return FromValue(tuple, result.GetRawResponse());
                }
            }

            cancellationToken.WaitHandle.WaitOne(pollingInterval.Value);
        }
    }

    public override void Pause() => _paused = true;

    public override void Resume() => _paused = false;
}
