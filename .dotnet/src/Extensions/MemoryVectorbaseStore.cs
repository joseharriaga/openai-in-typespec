// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;

namespace OpenAI.Embeddings;

internal class MemoryVectorbaseStore : VectorbaseStore
{
    readonly List<VectorbaseEntry> _items = new List<VectorbaseEntry>();

    public override IEnumerable<VectorbaseEntry> Find(ReadOnlyMemory<float> vector, FindOptions options)
    {
        lock (_items)
        {
            var results = new List<VectorbaseEntry>();
            var distances = new List<(float Distance, int Index)>();
            for (int index = 0; index<_items.Count; index++)
            {
                var entry = _items[index];
                ReadOnlyMemory<float> dbVector = entry.Vector;
                float distance = 1.0f - CosineSimilarity(dbVector.Span, vector.Span);
                distances.Add((distance, index));
            }
            distances.Sort(((float d1, int i1) v1, (float d2, int i2) v2) => v1.d1.CompareTo(v2.d2));

            var top = Math.Min(options.MaxEntries, distances.Count);
            for (int i = 0; i<top; i++)
            {
                var distance = distances[i].Distance;
                if (distance > options.Threshold) break;
                var index = distances[i].Index;
                results.Add(_items[index]);
            }
            return results;
        }
    }

    public override int Add(VectorbaseEntry entry)
    {
        lock (_items)
        {
            var id = _items.Count;
            var newEntry = new VectorbaseEntry(entry.Vector, entry.Data, id);
            _items.Add(newEntry);
            return id;
        }
    }
    public static float CosineSimilarity(ReadOnlySpan<float> x, ReadOnlySpan<float> y)
    {
        float dot = 0, xSumSquared = 0, ySumSquared = 0;

        for (int i = 0; i < x.Length; i++)
        {
            dot += x[i] * y[i];
            xSumSquared += x[i] * x[i];
            ySumSquared += y[i] * y[i];
        }

        double result = dot / (Math.Sqrt(xSumSquared) * Math.Sqrt(ySumSquared));
        return (float)result;
    }
}

