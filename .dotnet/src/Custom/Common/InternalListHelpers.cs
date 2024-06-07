using OpenAI.Assistants;
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
    //    async Task<ClientPage<T>> pageFunc(string? pageToken)
    //        => GetPageFromProtocol<T,U>(pageToken, await listResponseFunc(pageToken).ConfigureAwait(false));
    //    return PageableResultHelpers.Create(pageFunc, pageFunc);
    //}

    //internal static AsyncPageableResult<T> CreateAsyncPageable<T, U>(
    //AsyncListResponseFunc firstListResponseFunc,
    //AsyncListResponseFunc nextListResponseFunc)
    //where U : IJsonModel<U>, IInternalListResponse<T>
    //{
    //    async Task<ClientPage<T>> firstPageFunc(string? pageToken)
    //        => GetPageFromProtocol<T, U>(pageToken, await firstListResponseFunc(pageToken).ConfigureAwait(false));
    //    async Task<ClientPage<T>> nextPageFunc(string? pageToken)
    //        => GetPageFromProtocol<T, U>(pageToken, await nextListResponseFunc(pageToken).ConfigureAwait(false));
    //    return PageableResultHelpers.Create(firstPageFunc, nextPageFunc);
    //}

    //internal static PageableResult<T> CreatePageable<T, U>(ListResponseFunc listResponseFunc)
    //    where U : IJsonModel<U>, IInternalListResponse<T>
    //{
    //    ClientPage<T> pageFunc(string? pageToken)
    //        => GetPageFromProtocol<T, U>(pageToken, listResponseFunc(pageToken));
    //    return PageableResultHelpers.Create(pageFunc, pageFunc);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //private static ClientPage<TInstance> GetPageFromProtocol<TInstance, UInternalList>(
    //    string? pageToken, ClientResult protocolResult) 
    //    where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
    //{
    //    PageToken token = ToPageToken(pageToken);

    //    PipelineResponse response = protocolResult.GetRawResponse();
    //    IInternalListResponse<TInstance> values = ModelReaderWriter.Read<UInternalList>(response.Content)!;

    //    PageToken nextPageToken = new(token.Order, values.LastId, token.Before, values.HasMore);
    //    PageToken prevPageToken = new(token.Order, token.After, values.FirstId, values.HasMore);

    //    return ClientPage<TInstance>.Create(values.Data, response, 
    //        FromPageToken(nextPageToken), 
    //        FromPageToken(prevPageToken));
    //}

}
