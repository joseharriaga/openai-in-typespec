using System;
using System.ClientModel.Primitives;

#nullable enable

namespace OpenAI;

internal class OpenAIPageToken : PageToken
{
    private readonly OpenAIPageToken _firstPageToken;

    public OpenAIPageToken(int? pageSize, 
        string? order, 
        string? after, 
        string? before,
        string? lastSeenId)
        : base(lastSeenId != null)
    {
        PageSize = pageSize;
        Order = order;
        After = after;
        Before = before;
        LastSeenId = lastSeenId;

        _firstPageToken = new OpenAIPageToken(pageSize, order, after, before, null);
    }

    public int? PageSize { get; }

    public string? Order { get; }

    public string? After { get; }

    public string? Before { get; }

    public string? LastSeenId { get; }

    protected override PageToken FirstPageToken => _firstPageToken;

    public static OpenAIPageToken FromOptions(OpenAIPageCollectionOptions options)
        => new(options.PageSize, options.Order?.ToString(), options.AfterItemId, options.BeforeItemId, default);

    public static OpenAIPageToken FromToken(OpenAIPageToken token, string? lastSeenId)
        => new(token.PageSize, token.Order, token.After, token.Before, lastSeenId);

    public static OpenAIPageToken? GetNextPageToken(OpenAIPageToken token, bool hasMore, string? lastId)
    {
        if (!hasMore)
        {
            return null;
        }

        return FromToken(token, lastId);
    }

    protected override PageToken CreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    protected override string GetFormatFromOptionsCore(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    protected override BinaryData WriteCore(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }
}
