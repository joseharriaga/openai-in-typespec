﻿using System;
using System.ClientModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

#nullable enable

namespace OpenAI.FineTuning;

internal class FineTuningJobEventsPageToken : ContinuationToken
{
    protected FineTuningJobEventsPageToken(string jobId, string? after, int? limit)
    {
        JobId = jobId;
        After = after;
        Limit = limit;
    }

    public string JobId { get; }
    public string? After { get; }
    public int? Limit { get; }

    public override BinaryData ToBytes()
    {
        using MemoryStream stream = new();
        using Utf8JsonWriter writer = new(stream);

        writer.WriteStartObject();

        writer.WriteString("fine_tuning_job_id", JobId);

        if (Limit.HasValue)
        {
            writer.WriteNumber("limit", Limit.Value);
        }

        if (After is not null)
        {
            writer.WriteString("after", After);
        }

        writer.WriteEndObject();

        writer.Flush();
        stream.Position = 0;

        return BinaryData.FromStream(stream);
    }

    public FineTuningJobEventsPageToken? GetNextPageToken(bool hasMore)
    {
        return hasMore
            ? new FineTuningJobEventsPageToken(JobId, After, Limit)
            : null;

    }

    public static FineTuningJobEventsPageToken FromToken(ContinuationToken token)
    {
        if (token is FineTuningJobEventsPageToken pageToken)
        {
            return pageToken;
        }

        BinaryData data = token.ToBytes();

        if (data.ToMemory().Length == 0)
        {
            throw new ArgumentException(
                $"Failed to create {nameof(FineTuningJobEventsPageToken)} from provided token.",
                nameof(token));
        }

        Utf8JsonReader reader = new(data);

        string jobId = "";
        string? after = null;
        int? limit = null;

        reader.Read();

        Debug.Assert(reader.TokenType == JsonTokenType.StartObject);

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            Debug.Assert(reader.TokenType == JsonTokenType.PropertyName);

            string propertyName = reader.GetString()!;

            switch (propertyName)
            {
                case "fine_tuning_job_id":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    jobId = reader.GetString()!;
                    break;
                case "after":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.String);
                    after = reader.GetString();
                    break;
                case "limit":
                    reader.Read();
                    Debug.Assert(reader.TokenType == JsonTokenType.Number);
                    limit = reader.GetInt32();
                    break;
                default:
                    throw new JsonException($"Unrecognized property '{propertyName}'.");
            }
        }

        return new(jobId, after, limit);
    }

    public static FineTuningJobEventsPageToken FromOptions(string jobId, string? after, int? limit)
        => new FineTuningJobEventsPageToken(jobId, after, limit);
}