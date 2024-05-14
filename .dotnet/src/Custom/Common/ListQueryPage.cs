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
