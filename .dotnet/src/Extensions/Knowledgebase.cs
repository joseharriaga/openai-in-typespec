// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.Embeddings;
using System.Collections.Generic;
using System;

namespace OpenAI.Chat;

public class Knowledgebase
{
    EmbeddingClient _client;
    string _embeddingsDeployment;
    List<string> _factsToProcess = new List<string>();

    List<ReadOnlyMemory<float>> _vectors = new List<ReadOnlyMemory<float>>();
    List<string> _facts = new List<string>();

    public Knowledgebase(EmbeddingClient client, string embeddingsDeployment)
    {
        _client = client;
        _embeddingsDeployment = embeddingsDeployment;
    }

    public void Add(string fact)
    {
        _factsToProcess.Add(fact);
        if (_factsToProcess.Count > 2) ProcessUnprocessedFacts();
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

    public List<ChatRequestMessage> FindRelevant(string text, float threshold = 0.25f, int top = 3)
    {
        List<ChatRequestMessage> result = new();
        List<Fact> relevant = FindRelevantFacts(text);
        foreach (Fact fact in relevant)
        {
            result.Add(ChatRequestMessage.CreateSystemMessage(fact.Text));
        }
        return result;
    }
    public List<Fact> FindRelevantFacts(string text, float threshold = 0.25f, int top = 3)
    {
        if (_factsToProcess.Count>0) ProcessUnprocessedFacts();

        ReadOnlyMemory<float> textVector = ProcessFact(text);

        var results = new List<Fact>();
        var distances = new List<(float Distance, int Index)>();
        for (int index = 0; index<_vectors.Count; index++)
        {
            ReadOnlyMemory<float> dbVector = _vectors[index];
            float distance = 1.0f - CosineSimilarity(dbVector.Span, textVector.Span);
            distances.Add((distance, index));
        }
        distances.Sort(((float d1, int i1) v1, (float d2, int i2) v2) => v1.d1.CompareTo(v2.d2));

        top = Math.Min(top, distances.Count);
        for (int i = 0; i<top; i++)
        {
            var distance = distances[i].Distance;
            if (distance > threshold) break;
            var index = distances[i].Index;
            results.Add(new Fact(_facts[index], index));
        }
        return results;
    }

    void ProcessUnprocessedFacts()
    {
        EmbeddingCollection embeddings = _client.GenerateEmbeddings(_factsToProcess);

        foreach (var embedding in embeddings)
        {
            _vectors.Add(embedding.Vector);
            _facts.Add(_factsToProcess[(int)embedding.Index]);
        }
        _factsToProcess.Clear();
    }

    ReadOnlyMemory<float> ProcessFact(string fact)
    {
        Embedding embedding = _client.GenerateEmbedding(fact);
        return embedding.Vector;
    }
}

public struct Fact
{
    public Fact(string text, int id)
    {
        Text= text;
        Id= id;
    }

    public string Text { get; private set; }
    public int Id { get; private set; }
}

