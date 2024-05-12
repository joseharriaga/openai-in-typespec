using OpenAI.Internal.Models;
using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI.Assistants;

/*
 NOTE:
    This whole class is temporary and not meant to be merged as-is.
    It's merely intended to prototype possible patterns and facilitate
    discussion.
*/

/// <summary>
/// Represents a single item of streamed Assistants API data.
/// </summary>
/// <remarks>
/// Please note that this is the abstract base type. To access data, downcast an instance of this type to an
/// appropriate, derived update type:
/// <para>
/// For messages: <see cref="MessageUpdate"/>, <see cref="MessageTextUpdate"/>, <see cref="MessageImageFileUpdate"/>,
/// <see cref="MessageImageUrlUpdate"/>, <see cref="MessageStatusUpdate"/>
/// </para>
/// <para>
/// For runs and run steps: <see cref="RunUpdate"/>, <see cref="RunStepUpdate"/>, <see cref="RunStepDetailsUpdate"/>,
/// <see cref="RunRequiredActionUpdate"/>
/// </para>
/// <para>
/// For threads, <see cref="ThreadCreationUpdate"/>
/// </para>
/// </remarks>
public abstract partial class StreamingUpdate
{
    /// <summary>
    /// A value indicating what type of event this update represents.
    /// </summary>
    /// <remarks>
    /// Many events share the same response type. For example, <see cref="StreamingUpdateKind.RunCreated"/> and
    /// <see cref="StreamingUpdateKind.RunCompleted"/> are both associated with a <see cref="ThreadRun"/> instance.
    /// You can use the value of <see cref="UpdateKind"/> to differentiate between these events when the type is not
    /// sufficient to do so.
    /// </remarks>
    public StreamingUpdateKind UpdateKind { get; }

    internal StreamingUpdate(StreamingUpdateKind updateKind)
    {
        UpdateKind = updateKind;
    }

    internal static async Task<IEnumerable<StreamingUpdate>> TemporaryCreateFromReaderAsync(StreamReader reader)
        => TemporaryCreateFromLines(await reader.ReadLineAsync(), await reader.ReadLineAsync(), await reader.ReadLineAsync());

    internal static IEnumerable<StreamingUpdate> TemporaryCreateFromReader(StreamReader reader)
        => TemporaryCreateFromLines(reader.ReadLine(), reader.ReadLine(), reader.ReadLine());

    private static IEnumerable<StreamingUpdate> TemporaryCreateFromLines(string eventLine, string dataLine, string emptyLine)
    {
        if (eventLine?.StartsWith("event: ") != true || dataLine?.StartsWith("data: ") != true || emptyLine != string.Empty)
        {
            throw new InvalidOperationException();
        }

        if (eventLine == "event: done" && dataLine == "data: [DONE]") return null;

        string eventName = eventLine.Substring("event: ".Length);
        string data = dataLine.Substring("data: ".Length);
        JsonDocument dataDocument = JsonDocument.Parse(data);
        JsonElement e = dataDocument.RootElement;

        StreamingUpdateKind updateKind = StreamingUpdateKindExtensions.FromSseEventLabel(eventName);

        return updateKind switch
        {
            StreamingUpdateKind.ThreadCreated => ThreadCreationUpdate.DeserializeThreadCreationUpdates(e, updateKind),
            StreamingUpdateKind.RunCreated
            or StreamingUpdateKind.RunQueued
            or StreamingUpdateKind.RunInProgress
            or StreamingUpdateKind.RunRequiresAction
            or StreamingUpdateKind.RunCompleted
            or StreamingUpdateKind.RunFailed
            or StreamingUpdateKind.RunCancelling
            or StreamingUpdateKind.RunCancelled
            or StreamingUpdateKind.RunExpired => RunUpdate.DeserializeRunUpdates(e, updateKind),
            StreamingUpdateKind.RunStepCreated
            or StreamingUpdateKind.RunStepInProgress
            or StreamingUpdateKind.RunStepCompleted
            or StreamingUpdateKind.RunStepFailed
            or StreamingUpdateKind.RunStepCancelled
            or StreamingUpdateKind.RunStepExpired => RunStepUpdate.DeserializeRunStepUpdates(e, updateKind),
            StreamingUpdateKind.MessageCreated
            or StreamingUpdateKind.MessageInProgress
            or StreamingUpdateKind.MessageCompleted
            or StreamingUpdateKind.MessageFailed => MessageStatusUpdate.DeserializeMessageStatusUpdates(e, updateKind),
            StreamingUpdateKind.RunStepUpdated => RunStepDetailsUpdate.DeserializeRunStepDetailsUpdates(e, updateKind),
            StreamingUpdateKind.MessageUpdated => MessageUpdate.DeserializeMessageUpdates(e, updateKind),
            _ => null,
        };
    }
}

/// <summary>
/// Represents a single item of streamed data that encapsulates an underlying response value type.
/// </summary>
/// <typeparam name="T"> The response value type of the "delta" payload. </typeparam>
public partial class StreamingUpdate<T> : StreamingUpdate
    where T : class
{
    /// <summary>
    /// The underlying response value received with the streaming event. Use this value to access the full detail of
    /// the event if a specific derived type does not provide it.
    /// </summary>
    public T Value { get; }

    internal StreamingUpdate(T value, StreamingUpdateKind updateKind)
        : base(updateKind)
    {
        Value = value;
    }
}

/// <summary>
/// The update type presented when a streamed event indicates a thread was created.
/// </summary>
public class ThreadCreationUpdate : StreamingUpdate<AssistantThread>
{
    /// <see cref="AssistantThread.Id"/>
    public string Id => Value.Id;
    /// <see cref="AssistantThread.Metadata"/>
    public IReadOnlyDictionary<string, string> Metadata => Value.Metadata;
    /// <see cref="AssistantThread.CreatedAt"/>
    public DateTimeOffset CreatedAt => Value.CreatedAt;
    /// <see cref="AssistantThread.ToolResources"/>
    public ToolResources ToolResources => Value.ToolResources;

    internal ThreadCreationUpdate(AssistantThread thread) : base(thread, StreamingUpdateKind.ThreadCreated)
    { }

    internal static IEnumerable<StreamingUpdate<AssistantThread>> DeserializeThreadCreationUpdates(
        JsonElement element,
        StreamingUpdateKind updateKind,
        ModelReaderWriterOptions options = null)
    {
        AssistantThread thread = AssistantThread.DeserializeAssistantThread(element, options);
        return updateKind switch
        {
            StreamingUpdateKind.ThreadCreated => [new ThreadCreationUpdate(thread)],
            _ => [new StreamingUpdate<AssistantThread>(thread, updateKind)],
        };
    }
}

/// <summary>
/// The update type presented when the status of a run changed.
/// </summary>
public class RunUpdate : StreamingUpdate<ThreadRun>
{
    internal RunUpdate(ThreadRun run, StreamingUpdateKind updateKind) : base(run, updateKind)
    { }

    internal static IEnumerable<StreamingUpdate<ThreadRun>> DeserializeRunUpdates(
        JsonElement element,
        StreamingUpdateKind updateKind,
        ModelReaderWriterOptions options = null)
    {
        ThreadRun run = ThreadRun.DeserializeThreadRun(element, options);
        return updateKind switch
        {
            StreamingUpdateKind.RunRequiresAction => [new RunRequiredActionUpdate(run)],
            _ => [new RunUpdate(run, updateKind)],
        };
    }
}

/// <summary>
/// The update type presented when the status of a run changed to <c>requires_action</c>, indicating tool output
/// submission or other intervention is needed for the run to continue.
/// </summary>
public class RunRequiredActionUpdate : RunUpdate
{
    /// <inheritdoc cref="ThreadRun.RequiredActions"/>
    public IReadOnlyList<RequiredAction> RequiredActions => Value.RequiredActions;

    internal RunRequiredActionUpdate(ThreadRun value) : base(value, StreamingUpdateKind.RunRequiresAction)
    { }
}

/// <summary>
/// The update type presented when the status of a run step changes.
/// </summary>
public class RunStepUpdate : StreamingUpdate<RunStep>
{
    internal RunStepUpdate(RunStep runStep, StreamingUpdateKind updateKind)
        : base(runStep, updateKind)
    { }

    internal static IEnumerable<StreamingUpdate<RunStep>> DeserializeRunStepUpdates(
        JsonElement element,
        StreamingUpdateKind updateKind,
        ModelReaderWriterOptions options = null)
    {
        RunStep runStep = RunStep.DeserializeRunStep(element, options);
        return updateKind switch
        {
            _ => [new RunStepUpdate(runStep, updateKind)],
        };
    }
}

/// <summary>
/// The update type presented when run step details, including tool call progress, have changed.
/// </summary>
public class RunStepDetailsUpdate : StreamingUpdate<RunStepDelta>
{
    /// <inheritdoc cref="RunStepDelta.StepDetails"/>
    public BinaryData StepDetails => Value.StepDetails;

    internal RunStepDetailsUpdate(RunStepDelta stepDelta, StreamingUpdateKind updateKind)
        : base(stepDelta, updateKind)
    { }

    internal static IEnumerable<StreamingUpdate<RunStepDelta>> DeserializeRunStepDetailsUpdates(
        JsonElement element,
        StreamingUpdateKind updateKind,
        ModelReaderWriterOptions options = null)
    {
        RunStepDelta stepDelta = RunStepDelta.DeserializeRunStepDelta(element, options);
        return updateKind switch
        {
            _ => [new RunStepDetailsUpdate(stepDelta, updateKind)],
        };
    }
}

/// <summary>
/// The update type presented when the status of a message changes.
/// </summary>
public class MessageStatusUpdate : StreamingUpdate<ThreadMessage>
{
    internal MessageStatusUpdate(ThreadMessage message, StreamingUpdateKind updateKind)
        : base(message, updateKind)
    { }

    internal static IEnumerable<MessageStatusUpdate> DeserializeMessageStatusUpdates(
        JsonElement element,
        StreamingUpdateKind updateKind,
        ModelReaderWriterOptions options = null)
    {
        ThreadMessage message = ThreadMessage.DeserializeThreadMessage(element, options);
        return updateKind switch
        {
            _ => [new MessageStatusUpdate(message, updateKind)],
        };
    }
}

/// <summary>
/// The update type presented when the content of a role changes.
/// </summary>
public class MessageUpdate : StreamingUpdate<MessageDelta>
{
    /// <inheritdoc cref="MessageDelta.Id"/>
    public string Id => Value.Id;
    /// <inheritdoc cref="MessageDelta.Role"/>
    public MessageRole Role => Value.Role;

    internal MessageUpdate(MessageDelta value)
        : base(value, StreamingUpdateKind.MessageUpdated)
    { }

    internal static IEnumerable<MessageUpdate> DeserializeMessageUpdates(
        JsonElement element,
        StreamingUpdateKind updateKind,
        ModelReaderWriterOptions options = null)
    {
        MessageDelta delta = MessageDelta.DeserializeMessageDelta(element, options);
        List<MessageUpdate> result = [];
        foreach (MessageDeltaContent content in delta.Content)
        {
            result.Add(content switch
            {
                MessageTextDeltaContent textContent => new MessageTextUpdate(delta, textContent),
                MessageImageFileDeltaContent imageFileContent => new MessageImageFileUpdate(delta, imageFileContent),
                MessageImageUrlDeltaContent imageUrlContent => new MessageImageUrlUpdate(delta, imageUrlContent),
                _ => new MessageUpdate(delta)
            });
        }
        return result;
    }
}

public class MessageTextUpdate : MessageUpdate
{
    /// <inheritdoc cref="MessageTextDeltaContent.Text"/>
    public string Text => _internalContent.Text;
    /// <inheritdoc cref="MessageTextDeltaContent.Annotations"/>
    public IReadOnlyList<MessageDeltaTextContentAnnotation> Annotations => _internalContent.Annotations;
    /// <inheritdoc cref="MessageTextDeltaContent.Index"/>
    public int ContentIndex => _internalContent.Index;

    private readonly MessageTextDeltaContent _internalContent;

    internal MessageTextUpdate(MessageDelta value, MessageTextDeltaContent content)
        : base(value)
    {
        _internalContent = content;
    }
}

public partial class MessageImageFileUpdate : MessageUpdate
{
    /// <inheritdoc cref="MessageImageFileDeltaContent.Index"/>
    public int ContentIndex => _internalContent.Index;
    /// <inheritdoc cref="MessageImageFileDeltaContent.FileId"/>
    public string FileId => _internalContent.FileId;
    /// <inheritdoc cref="MessageImageFileDeltaContent.Detail"/>
    public MessageImageDetail? Detail => _internalContent.Detail;

    private readonly MessageImageFileDeltaContent _internalContent;

    internal MessageImageFileUpdate(MessageDelta value, MessageImageFileDeltaContent content)
        : base(value)
    {
        _internalContent = content;
    }
}

public partial class MessageImageUrlUpdate : MessageUpdate
{
    /// <inheritdoc cref="MessageImageUrlDeltaContent.Index"/>
    public int ContentIndex => _internalContent.Index;
    /// <inheritdoc cref="MessageImageUrlDeltaContent.Url"/>
    public Uri Url => _internalContent.Url;
    /// <inheritdoc cref="MessageImageUrlDeltaContent.Detail"/>
    public MessageImageDetail? Detail => _internalContent.Detail;

    private readonly MessageImageUrlDeltaContent _internalContent;

    internal MessageImageUrlUpdate(MessageDelta value, MessageImageUrlDeltaContent content)
        : base(value)
    {
        _internalContent = content;
    }
}
