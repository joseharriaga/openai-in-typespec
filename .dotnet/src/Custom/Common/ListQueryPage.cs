using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using OpenAI.Assistants;

namespace OpenAI;

public abstract partial class ListQueryPage
{
    public string FirstId { get; }
    public string LastId { get; }
    public bool HasMore { get; }

    internal ListQueryPage(string firstId, string lastId, bool hasMore)
    {
        FirstId = firstId;
        LastId = lastId;
        HasMore = hasMore;
    }

    internal static ListQueryPage<Assistant> Create(Internal.Models.ListAssistantsResponse internalResponse)
    {
        ChangeTrackingList<Assistant> assistants = new();
        foreach (Internal.Models.AssistantObject internalAssistant in internalResponse.Data)
        {
            assistants.Add(new(internalAssistant));
        }
        return new(assistants, internalResponse.FirstId, internalResponse.LastId, internalResponse.HasMore);
    }

    internal static ListQueryPage<ThreadMessage> Create(Internal.Models.ListMessagesResponse internalResponse)
    {
        ChangeTrackingList<ThreadMessage> messages = new();
        foreach (Internal.Models.MessageObject internalMessage in internalResponse.Data)
        {
            messages.Add(new(internalMessage));
        }
        return new(messages, internalResponse.FirstId, internalResponse.LastId, internalResponse.HasMore);
    }

    internal static ListQueryPage<ThreadRun> Create(Internal.Models.ListRunsResponse internalResponse)
    {
        ChangeTrackingList<ThreadRun> runs = new();
        foreach (Internal.Models.RunObject internalRun in internalResponse.Data)
        {
            runs.Add(new(internalRun));
        }
        return new(runs, internalResponse.FirstId, internalResponse.LastId, internalResponse.HasMore);
    }

    internal static ListQueryPage Create<T>(T internalResponse)
        where T : class
    {
        return internalResponse switch
        {
            Internal.Models.ListAssistantsResponse internalAssistantsResponse => Create(internalAssistantsResponse),
            Internal.Models.ListMessagesResponse internalMessagesResponse => Create(internalMessagesResponse),
            Internal.Models.ListRunsResponse internalRunsResponse => Create(internalRunsResponse),
            _ => throw new ArgumentException(
                $"Unknown type for generic {nameof(ListQueryPage)} conversion: {internalResponse.GetType()}"),
        };
    }
}

public partial class ListQueryPage<T> : ListQueryPage, IReadOnlyList<T>
    where T : class, IJsonModel<T>
{
    public IReadOnlyList<T> Items { get; }

    /// <inheritdoc/>
    public int Count => Items.Count;

    /// <inheritdoc/>
    public T this[int index]
    {
        get => Items[index];
    }

    internal ListQueryPage(IEnumerable<T> items, string firstId, string lastId, bool hasMore)
        : base(firstId, lastId, hasMore)
    {
        Items = items.ToList();
    }

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator() => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();
}
