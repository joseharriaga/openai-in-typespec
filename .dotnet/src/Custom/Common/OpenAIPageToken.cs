using System;
using System.ClientModel;
using System.ClientModel.Primitives;

#nullable enable

namespace OpenAI;

internal class OpenAIPageToken : PageToken
{
    public OpenAIPageToken(int? pageSize, string? order, string? firstPageAfter, string? currentPageAfter, string? before)
    {
        PageSize = pageSize;
        Order = order;
        FirstPageAfter = firstPageAfter;
        CurrentPageAfter = currentPageAfter;
        Before = before;
    }

    public int? PageSize { get; }

    public string? Order { get; }

    public string? FirstPageAfter { get; }

    public string? CurrentPageAfter { get; }

    public string? Before { get; }

    public override PageToken FirstCollectionPage
        => new OpenAIPageToken(PageSize, Order, FirstPageAfter, FirstPageAfter, Before);

    public override PageToken Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    public override string GetFormatFromOptions(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    public override BinaryData Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }
}
