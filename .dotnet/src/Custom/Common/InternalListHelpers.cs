using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI;

internal static class InternalListHelpers
{
    internal delegate Task<ClientResult> AsyncListResponseFunc(string? pageToken);
    internal delegate ClientResult ListResponseFunc(string? pageToken);

    //internal static AsyncPageableResult<T> CreateAsyncPageable<T, U>(AsyncListResponseFunc listResponseFunc)
    //    where U : IJsonModel<U>, IInternalListResponse<T>
    //{
    //    async Task<PageResult<T>> pageFunc(string? pageToken)
    //        => GetPageFromProtocol<T,U>(pageToken, await listResponseFunc(pageToken).ConfigureAwait(false));
    //    return PageableResultHelpers.Create(pageFunc, pageFunc);
    //}

    //internal static AsyncPageableResult<T> CreateAsyncPageable<T, U>(
    //AsyncListResponseFunc firstListResponseFunc,
    //AsyncListResponseFunc nextListResponseFunc)
    //where U : IJsonModel<U>, IInternalListResponse<T>
    //{
    //    async Task<PageResult<T>> firstPageFunc(string? pageToken)
    //        => GetPageFromProtocol<T, U>(pageToken, await firstListResponseFunc(pageToken).ConfigureAwait(false));
    //    async Task<PageResult<T>> nextPageFunc(string? pageToken)
    //        => GetPageFromProtocol<T, U>(pageToken, await nextListResponseFunc(pageToken).ConfigureAwait(false));
    //    return PageableResultHelpers.Create(firstPageFunc, nextPageFunc);
    //}

    //internal static PageableResult<T> CreatePageable<T, U>(ListResponseFunc listResponseFunc)
    //    where U : IJsonModel<U>, IInternalListResponse<T>
    //{
    //    PageResult<T> pageFunc(string? pageToken)
    //        => GetPageFromProtocol<T, U>(pageToken, listResponseFunc(pageToken));
    //    return PageableResultHelpers.Create(pageFunc, pageFunc);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //private static PageResult<TInstance> GetPageFromProtocol<TInstance, UInternalList>(
    //    string? pageToken, ClientResult protocolResult) 
    //    where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
    //{
    //    PageToken token = ToPageToken(pageToken);

    //    PipelineResponse response = protocolResult.GetRawResponse();
    //    IInternalListResponse<TInstance> values = ModelReaderWriter.Read<UInternalList>(response.Content)!;

    //    PageToken nextPageToken = new(token.Order, values.LastId, token.Before, values.HasMore);
    //    PageToken prevPageToken = new(token.Order, token.After, values.FirstId, values.HasMore);

    //    return PageResult<TInstance>.Create(values.Data, response, 
    //        FromPageToken(nextPageToken), 
    //        FromPageToken(prevPageToken));
    //}

    internal static PageToken ToPageToken(string? pageToken)
    {
        if (pageToken is null)
        {
            return new PageToken(null, null, true);
        }

        PageToken? token = ModelReaderWriter.Read<PageToken>(BinaryData.FromString(pageToken));
        Debug.Assert(token is not null);
        return token!;
    }

    internal static string? FromPageToken(PageToken pageToken)
    {
        if (!(pageToken.HasMore == true))
        {
            return null;
        }

        BinaryData data = pageToken.Write(ModelReaderWriterOptions.Json);
        return data.ToString();
    }
}
