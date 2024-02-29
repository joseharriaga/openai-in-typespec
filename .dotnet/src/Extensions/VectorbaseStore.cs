// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;

namespace OpenAI.Embeddings;

public abstract class VectorbaseStore
{
    public abstract IEnumerable<VectorbaseEntry> Find(ReadOnlyMemory<float> vector, FindOptions options);

    public abstract int Add(VectorbaseEntry entry);
}

public readonly struct VectorbaseEntry
{
    readonly ReadOnlyMemory<float> _vector;
    readonly int? _id;
    readonly BinaryData _data;

    public VectorbaseEntry(ReadOnlyMemory<float> vector, BinaryData data, int? id = default)
    {
        _vector = vector;
        _data = data;
        _id = id;
    }

    public BinaryData Data => _data;
    public ReadOnlyMemory<float> Vector => _vector;
    public int? Id => _id;
}


