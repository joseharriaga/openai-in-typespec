using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

/// <summary>
/// The update type presented when the status of a run has changed.
/// </summary>
public class RunUpdate : StreamingUpdate<ThreadRun>
{
    internal RunUpdate(ThreadRun run, StreamingUpdateReason updateKind) : base(run, updateKind)
    { }

    internal static IEnumerable<StreamingUpdate<ThreadRun>> DeserializeRunUpdates(
        JsonElement element,
        StreamingUpdateReason updateKind,
        ModelReaderWriterOptions options = null)
    {
        ThreadRun run = ThreadRun.DeserializeThreadRun(element, options);
        return updateKind switch
        {
            _ => [new RunUpdate(run, updateKind)],
        };
    }
}
