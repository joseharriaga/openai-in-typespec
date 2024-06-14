using System;
using System.ClientModel;
using System.ClientModel.Primitives;

#nullable enable

namespace OpenAI;

internal class OpenAIPageToken : PageToken
{
    private readonly OpenAIPageToken _firstPageToken;

    public OpenAIPageToken(int? pageSize, string? order, string? firstPageAfter, string? currentPageAfter, string? before)
        : base()
    {
        PageSize = pageSize;
        Order = order;
        FirstPageAfter = firstPageAfter;
        CurrentPageAfter = currentPageAfter;
        Before = before;

        _firstPageToken = GetFirstPageToken(pageSize, order, firstPageAfter, before);
    }

    public int? PageSize { get; }

    public string? Order { get; }

    public string? FirstPageAfter { get; }

    public string? CurrentPageAfter { get; }

    public string? Before { get; }

    protected override PageToken FirstPageToken => _firstPageToken;

    private static OpenAIPageToken GetFirstPageToken(int? pageSize, string? order, string? after, string? before)
        => new OpenAIPageToken(pageSize, order, after, after, before);

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
