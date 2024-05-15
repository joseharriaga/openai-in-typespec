using System;
using System.Collections;
using System.Collections.Generic;
using OpenAI.Models;

namespace OpenAI.Assistants;

/// <inheritdoc cref="Assistant.ToolResources"/>
[CodeGenModel("CreateAssistantRequestToolResources")]
public partial class ToolResourceDefinitionCollection : IList<ToolResourceDefinition>
{
    private readonly object CodeInterpreter;
    private readonly object FileSearch;

    private readonly ChangeTrackingList<ToolResourceDefinition> _definitions = new();

    internal ToolResourceDefinitionCollection(IEnumerable<ToolResourceDefinition> definitions = null)
    {
        foreach (ToolResourceDefinition definition in definitions ?? [])
        {
            _definitions.Add(definition);
        }
    }

    public ToolResourceDefinition this[int index]
    {
        get => _definitions[index];
        set => _definitions[index] = value;
    }

    public int Count => _definitions.Count;

    public bool IsReadOnly => _definitions.IsReadOnly;

    public void Add(ToolResourceDefinition item) => _definitions.Add(item);

    public void Clear() => _definitions.Clear();

    public bool Contains(ToolResourceDefinition item) => _definitions.Contains(item);

    public void CopyTo(ToolResourceDefinition[] array, int arrayIndex) => _definitions.CopyTo(array, arrayIndex);

    public IEnumerator<ToolResourceDefinition> GetEnumerator() => _definitions.GetEnumerator();

    public int IndexOf(ToolResourceDefinition item) => _definitions.IndexOf(item);

    public void Insert(int index, ToolResourceDefinition item) => _definitions.Insert(index, item);

    public bool Remove(ToolResourceDefinition item) => _definitions.Remove(item);

    public void RemoveAt(int index) => _definitions.RemoveAt(index);

    IEnumerator IEnumerable.GetEnumerator() => _definitions.GetEnumerator();
}

