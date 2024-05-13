using OpenAI.Internal.Models;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
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
/// For messages: <see cref="MessageStatusUpdate"/>, <see cref="MessageContentUpdate"/>
/// </para>
/// <para>
/// For runs and run steps: <see cref="RunUpdate"/>, <see cref="RunStepUpdate"/>, <see cref="RunStepDetailsUpdate"/>,
/// <see cref="RequiredActionUpdate"/>
/// </para>
/// <para>
/// For threads, <see cref="ThreadUpdate"/>
/// </para>
/// </remarks>
public abstract partial class StreamingUpdate
{
    /// <summary>
    /// A value indicating what type of event this update represents.
    /// </summary>
    /// <remarks>
    /// Many events share the same response type. For example, <see cref="StreamingUpdateReason.RunCreated"/> and
    /// <see cref="StreamingUpdateReason.RunCompleted"/> are both associated with a <see cref="ThreadRun"/> instance.
    /// You can use the value of <see cref="UpdateKind"/> to differentiate between these events when the type is not
    /// sufficient to do so.
    /// </remarks>
    public StreamingUpdateReason UpdateKind { get; }

    internal StreamingUpdate(StreamingUpdateReason updateKind)
    {
        UpdateKind = updateKind;
    }

    private static async Task<IEnumerable<StreamingUpdate>> TemporaryCreateFromReaderAsync(StreamReader reader)
        => TemporaryCreateFromLines(await reader.ReadLineAsync(), await reader.ReadLineAsync(), await reader.ReadLineAsync());

    private static IEnumerable<StreamingUpdate> TemporaryCreateFromReader(StreamReader reader)
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

        StreamingUpdateReason updateKind = StreamingUpdateReasonExtensions.FromSseEventLabel(eventName);

        return updateKind switch
        {
            StreamingUpdateReason.ThreadCreated => ThreadUpdate.DeserializeThreadCreationUpdates(e, updateKind),
            StreamingUpdateReason.RunCreated
            or StreamingUpdateReason.RunQueued
            or StreamingUpdateReason.RunInProgress
            or StreamingUpdateReason.RunCompleted
            or StreamingUpdateReason.RunFailed
            or StreamingUpdateReason.RunCancelling
            or StreamingUpdateReason.RunCancelled
            or StreamingUpdateReason.RunExpired => RunUpdate.DeserializeRunUpdates(e, updateKind),
            StreamingUpdateReason.RunRequiresAction => RequiredActionUpdate.DeserializeRequiredActionUpdates(e),
            StreamingUpdateReason.RunStepCreated
            or StreamingUpdateReason.RunStepInProgress
            or StreamingUpdateReason.RunStepCompleted
            or StreamingUpdateReason.RunStepFailed
            or StreamingUpdateReason.RunStepCancelled
            or StreamingUpdateReason.RunStepExpired => RunStepUpdate.DeserializeRunStepUpdates(e, updateKind),
            StreamingUpdateReason.MessageCreated
            or StreamingUpdateReason.MessageInProgress
            or StreamingUpdateReason.MessageCompleted
            or StreamingUpdateReason.MessageFailed => MessageStatusUpdate.DeserializeMessageStatusUpdates(e, updateKind),
            StreamingUpdateReason.RunStepUpdated => RunStepDetailsUpdate.DeserializeRunStepDetailsUpdates(e, updateKind),
            StreamingUpdateReason.MessageUpdated => MessageContentUpdate.DeserializeMessageContentUpdates(e, updateKind),
            _ => null,
        };
    }

    internal static ClientResult<IAsyncEnumerable<StreamingUpdate>> CreateTemporaryResult(ClientResult protocolResult)
    {
        // NOTE: This is entirely temporary! Just for prototyping and discussion.

        async IAsyncEnumerable<StreamingUpdate> TemporaryEnumerateAsync(PipelineResponse response)
        {
            using StreamReader reader = new(response.ContentStream);
            while (true)
            {
                IEnumerable<StreamingUpdate> nextUpdates = await TemporaryCreateFromReaderAsync(reader);
                if (nextUpdates == null) break;
                foreach (StreamingUpdate update in nextUpdates)
                {
                    yield return update;
                }
            }
        }

        PipelineResponse response = protocolResult.GetRawResponse();
        IAsyncEnumerable<StreamingUpdate> asyncEnumerable = TemporaryEnumerateAsync(response);
        return ClientResult.FromValue(asyncEnumerable, response);
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
    /// The underlying response value received with the streaming event.
    /// </summary>
    public T Value { get; }

    internal StreamingUpdate(T value, StreamingUpdateReason updateKind)
        : base(updateKind)
    {
        Value = value;
    }
}
