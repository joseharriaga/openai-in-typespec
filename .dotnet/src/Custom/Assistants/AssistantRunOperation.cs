using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.Assistants;

// TODO: add hooks for cancel run?

internal class AssistantRunOperation : ResultOperation<ThreadRun>
{
    private static readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(2);

    private readonly string _threadId;
    private readonly string _runId;

    private readonly Func<string, string, ClientResult<ThreadRun>> _getRun;
    private readonly Func<string, string, Task<ClientResult<ThreadRun>>> _getRunAsync;

    private ClientResult<ThreadRun> _lastSeenResult;

    private bool _statusChanged;

    public AssistantRunOperation(ClientResult<ThreadRun> createResult,
        Func<string, string, ClientResult<ThreadRun>> getRun,
        Func<string, string, Task<ClientResult<ThreadRun>>> getRunAsync) :
        base(GetIdFromResult(createResult), GetResponseFromResult(createResult))
    {
        _lastSeenResult = createResult;
        _getRun = getRun;
        _getRunAsync = getRunAsync;

        Value = createResult.Value;
        Status = createResult.Value.Status.ToString();

        _threadId = createResult.Value.ThreadId;
        _runId = createResult.Value.Id;
    }

    private static string GetIdFromResult(ClientResult<ThreadRun> result)
    {
        // TODO: validate this is reversible -- i.e. it will parse
        return $"{result.Value.ThreadId};{result.Value.Id}";
    }

    private static PipelineResponse GetResponseFromResult(ClientResult<ThreadRun> result)
        => result.GetRawResponse();

    public override async ValueTask<ClientResult> UpdateStatusAsync()
    {
        if (HasCompleted)
        {
            return _lastSeenResult;
        }

        ClientResult<ThreadRun> result = await _getRunAsync(_threadId, _runId).ConfigureAwait(false);

        if (_lastSeenResult.Value.Status != result.Value.Status)
        {
            Status = result.Value.Status.ToString();
            _statusChanged = true;
        }

        _lastSeenResult = result;
        Value = result.Value;

        if (Value.Status.IsTerminal)
        {
            HasCompleted = true;
        }

        SetRawResponse(result.GetRawResponse());

        return result;
    }

    public override ClientResult UpdateStatus()
    {
        if (HasCompleted)
        {
            return _lastSeenResult;
        }

        ClientResult<ThreadRun> result = _getRun(_threadId, _runId);

        if (_lastSeenResult.Value.Status != result.Value.Status)
        {
            Status = result.Value.Status.ToString();
            _statusChanged = true;
        }

        _lastSeenResult = result;
        Value = result.Value;

        if (Value.Status.IsTerminal)
        {
            HasCompleted = true;
        }

        SetRawResponse(result.GetRawResponse());

        return result;
    }

    public override async ValueTask<ClientResult<ThreadRun>> WaitForCompletionAsync(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await UpdateStatusAsync().ConfigureAwait(false);

            if (HasCompleted)
            {
                return _lastSeenResult;
            }

            await Task.Delay(pollingInterval.Value, cancellationToken).ConfigureAwait(false);
        }
    }

    public override ClientResult<ThreadRun> WaitForCompletion(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            UpdateStatus();

            if (HasCompleted)
            {
                return _lastSeenResult;
            }

            // TODO: note pollling interval logic may change for e.g. exponential
            // backoff if the operation is paused.
            cancellationToken.WaitHandle.WaitOne(pollingInterval.Value);
        }
    }

    public override async ValueTask<ClientResult> WaitForCompletionResultAsync(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default)
        => await WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);

    public override ClientResult WaitForCompletionResult(TimeSpan? pollingInterval = default, CancellationToken cancellationToken = default)
        => WaitForCompletion(pollingInterval, cancellationToken);

    public override async ValueTask<ClientResult<(string Status, ThreadRun? Value)>> WaitForStatusChangeAsync(TimeSpan? pollingInterval = null, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ClientResult result = await UpdateStatusAsync().ConfigureAwait(false);

            if (_statusChanged)
            {
                (string Status, ThreadRun? Value) tuple = new(_lastSeenResult.Value.Status.ToString(), _lastSeenResult.Value);
                return FromValue(tuple, result.GetRawResponse());
            }

            await Task.Delay(pollingInterval.Value, cancellationToken).ConfigureAwait(false);
        }
    }

    public override ClientResult<(string Status, ThreadRun? Value)> WaitForStatusChange(TimeSpan? pollingInterval = null, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ClientResult result = UpdateStatus();

            if (_statusChanged)
            {
                (string Status, ThreadRun? Value) tuple = new(_lastSeenResult.Value.Status.ToString(), _lastSeenResult.Value);
                return FromValue(tuple, result.GetRawResponse());
            }

            cancellationToken.WaitHandle.WaitOne(pollingInterval.Value);
        }
    }

    public override async ValueTask<ClientResult<string>> WaitForStatusChangeResultAsync(TimeSpan? pollingInterval = null, CancellationToken cancellationToken = default)
    {
        ClientResult<(string Status, ThreadRun? Value)> result = await WaitForStatusChangeAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
        return FromValue(result.Value.Status, result.GetRawResponse());
    }

    public override ClientResult<string> WaitForStatusChangeResult(TimeSpan? pollingInterval = null, CancellationToken cancellationToken = default)
    {
        ClientResult<(string Status, ThreadRun? Value)> result = WaitForStatusChange(pollingInterval, cancellationToken);
        return FromValue(result.Value.Status, result.GetRawResponse());
    }
}
