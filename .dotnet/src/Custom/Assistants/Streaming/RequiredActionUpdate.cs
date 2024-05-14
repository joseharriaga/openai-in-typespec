using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

/// <summary>
/// The update type presented when the status of a run changed to <c>requires_action</c>, indicating tool output
/// submission or other intervention is needed for the run to continue.
/// </summary>
public class RequiredActionUpdate : StreamingUpdate
{
    /// <inheritdoc cref="InternalRequiredFunctionToolCall.FunctionName"/>
    public string FunctionName => AsFunctionCall?.FunctionName;

    /// <inheritdoc cref="InternalRequiredFunctionToolCall.FunctionArguments"/>
    public string FunctionArguments => AsFunctionCall?.FunctionArguments;

    /// <inheritdoc cref="InternalRequiredFunctionToolCall.Id"/>
    public string ToolCallId => AsFunctionCall?.Id;

    private InternalRequiredFunctionToolCall AsFunctionCall => _requiredAction as InternalRequiredFunctionToolCall;

    private readonly ThreadRun _run;
    private readonly RequiredAction _requiredAction;

    internal RequiredActionUpdate(ThreadRun run, RequiredAction action)
        : base(StreamingUpdateReason.RunRequiresAction)
    {
        _run = run;
        _requiredAction = action;
    }

    /// <summary>
    /// Gets the full, deserialized <see cref="ThreadRun"/> instance associated with this streaming required action
    /// update.
    /// </summary>
    /// <returns></returns>
    public ThreadRun GetThreadRun() => _run;

    internal static IEnumerable<RequiredActionUpdate> DeserializeRequiredActionUpdates(JsonElement element)
    {
        ThreadRun run = ThreadRun.DeserializeThreadRun(element);
        List<RequiredActionUpdate> updates = [];
        foreach (RequiredAction action in run.RequiredActions ?? [])
        {
            updates.Add(new(run, action));
        }
        return updates;
    }
}