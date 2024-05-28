using System;
using System.ClientModel;
using System.Threading;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.Assistants;

internal class ThreadRunStatusResult : StatusBasedResult<RunStatus, ThreadRun>
{
    private static readonly TimeSpan DefaultPollingInterval = TimeSpan.FromSeconds(2);

    private readonly AssistantRunOperation _operation;

    private bool _statusChanged;

    public ThreadRunStatusResult(ThreadRun run, AssistantRunOperation operation) : base(run.Status)
    {
        Value = run;
        _operation = operation;
    }

    public override async ValueTask<ClientResult<StatusBasedResult<RunStatus, ThreadRun>>> WaitForStatusUpdateAsync(TimeSpan? pollingInterval = null, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ClientResult result = await _operation.UpdateStatusAsync().ConfigureAwait(false);
            ClientResult<ThreadRun> valueResult = (result as ClientResult<ThreadRun>)!;

            if (Status != valueResult.Value.Status)
            {
                Status = valueResult.Value.Status;
                _statusChanged = true;
            }

            Value = valueResult.Value;

            if (_statusChanged)
            {
                StatusBasedResult<RunStatus, ThreadRun> value = this;
                return ClientResult.FromValue(value, result.GetRawResponse());
            }

            await Task.Delay(pollingInterval.Value, cancellationToken).ConfigureAwait(false);
        }
    }

    public override ClientResult<StatusBasedResult<RunStatus, ThreadRun>> WaitForStatusUpdate(TimeSpan? pollingInterval = null, CancellationToken cancellationToken = default)
    {
        pollingInterval ??= DefaultPollingInterval;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            ClientResult result = _operation.UpdateStatus();
            ClientResult<ThreadRun> valueResult = (result as ClientResult<ThreadRun>)!;

            if (Status != valueResult.Value.Status)
            {
                Status = valueResult.Value.Status;
                _statusChanged = true;
            }

            Value = valueResult.Value;

            if (_statusChanged)
            {
                StatusBasedResult<RunStatus, ThreadRun> value = this;
                return ClientResult.FromValue(value, result.GetRawResponse());
            }

            cancellationToken.WaitHandle.WaitOne(pollingInterval.Value);
        }
    }
}
