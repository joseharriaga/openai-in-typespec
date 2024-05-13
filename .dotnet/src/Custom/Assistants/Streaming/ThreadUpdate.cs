using OpenAI.Internal.Models;
using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI.Assistants;



/// <summary>
/// The update type presented when a streamed event indicates a thread was created.
/// </summary>
public class ThreadUpdate : StreamingUpdate<AssistantThread>
{
    /// <see cref="AssistantThread.Id"/>
    public string Id => Value.Id;
    /// <see cref="AssistantThread.Metadata"/>
    public IReadOnlyDictionary<string, string> Metadata => Value.Metadata;
    /// <see cref="AssistantThread.CreatedAt"/>
    public DateTimeOffset CreatedAt => Value.CreatedAt;
    /// <see cref="AssistantThread.ToolResources"/>
    public ToolResources ToolResources => Value.ToolResources;

    internal ThreadUpdate(AssistantThread thread) : base(thread, StreamingUpdateReason.ThreadCreated)
    { }

    internal static IEnumerable<StreamingUpdate<AssistantThread>> DeserializeThreadCreationUpdates(
        JsonElement element,
        StreamingUpdateReason updateKind,
        ModelReaderWriterOptions options = null)
    {
        AssistantThread thread = AssistantThread.DeserializeAssistantThread(element, options);
        return updateKind switch
        {
            StreamingUpdateReason.ThreadCreated => [new ThreadUpdate(thread)],
            _ => [new StreamingUpdate<AssistantThread>(thread, updateKind)],
        };
    }
}
