using System.Collections;
using System.Collections.Generic;

namespace OpenAI;

public class RangeInitializableList<T> : IList<T>
{
    private readonly IList<T> _list = [];

    /// <summary>
    /// Adds a collection of items to the list.
    /// </summary>
    /// <remarks>
    /// The presence of this method enables the use of list initializers with collections, e.g.
    /// <code>
    /// public class Foo { public <see cref="RangeInitializableList{string}"/> GetOnlyList { get; } = new(); }
    /// 
    /// List&lt;string&gt; itemsForList = GetItemsForList();
    /// Foo foo = new()
    /// {
    ///     GetOnlyList = { itemsForList },
    /// };
    /// </code>
    /// </remarks>
    /// <param name="collection"></param>
    public void Add(IEnumerable<T> collection)
    {
        foreach (T item in collection)
        {
            Add(item);
        }
    }

    /// <inheritdoc/>
    public T this[int index] { get => _list[index]; set => _list[index] = value; }

    /// <inheritdoc/>
    public int Count => _list.Count;

    /// <inheritdoc/>
    public bool IsReadOnly => _list.IsReadOnly;

    /// <inheritdoc/>
    public void Add(T item) => _list.Add(item);

    /// <inheritdoc/>
    public void Clear() => _list.Clear();

    /// <inheritdoc/>
    public bool Contains(T item) => _list.Contains(item);

    /// <inheritdoc/>
    public void CopyTo(T[] array, int arrayIndex) =>  _list.CopyTo(array, arrayIndex);

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

    /// <inheritdoc/>
    public int IndexOf(T item) => _list.IndexOf(item);

    /// <inheritdoc/>
    public void Insert(int index, T item) => _list.Insert(index, item);

    /// <inheritdoc/>
    public bool Remove(T item) => _list.Remove(item);

    /// <inheritdoc/>
    public void RemoveAt(int index) => _list.RemoveAt(index);

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_list).GetEnumerator();
}