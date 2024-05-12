using System.Collections.Generic;

namespace OpenAI.Assistants;

[CodeGenModel("ThreadRunStatus")]
public readonly partial struct RunStatus
{
    /// <summary>
    /// [Helper property] Gets a value indicating whether this run status represents a condition wherein the run can
    /// no longer continue.
    /// </summary>
    /// <remarks>
    /// For more information, please refer to:
    /// https://platform.openai.com/docs/assistants/how-it-works/run-lifecycle
    /// </remarks>
    public bool IsTerminal
    {
        get
        {
            foreach (RunStatus terminalStatus in s_terminalStatuses)
            {
                if (_value == terminalStatus._value)
                {
                    return true;
                }
            }
            return false;
        }
    }

    private static List<RunStatus> s_terminalStatuses =
    [
        Expired,
        Completed,
        Failed,
        Incomplete,
        Cancelled,
    ];
}