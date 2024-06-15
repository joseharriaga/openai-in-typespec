using System;

#nullable enable

namespace OpenAI;

internal class OpenAIPageToken
{
    public OpenAIPageToken(string? after)
    {
        After = after;
    }

    public string? After { get; }

    public BinaryData ToBytes()
        => BinaryData.FromString(After ?? string.Empty);

    public static OpenAIPageToken FromBytes(BinaryData data)
        => new(data.ToMemory().Length == 0 ? null : data.ToString());

    public static BinaryData? GetNextPageToken(bool hasMore, string? lastId)
    {
        if (!hasMore || lastId is null)
        {
            return null;
        }

        return new OpenAIPageToken(lastId).ToBytes();
    }
}
