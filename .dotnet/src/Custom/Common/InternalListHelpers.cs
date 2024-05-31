using System.ClientModel;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OpenAI;

internal static class InternalListHelpers
{
    internal delegate Task<ClientResult> AsyncListResponseFunc(string pageToken);
    internal delegate ClientResult ListResponseFunc(string pageToken);

    internal static AsyncPageableCollection<T> CreateAsyncPageable<T, U>(AsyncListResponseFunc listResponseFunc)
        where U : IJsonModel<U>, IInternalListResponse<T>
    {
        async Task<PageResult<T>> pageFunc(string pageToken)
            => GetPageFromProtocol<T,U>(await listResponseFunc(pageToken).ConfigureAwait(false));
        return PageableResultHelpers.Create(pageFunc, pageFunc);
    }

    internal static PageableCollection<T> CreatePageable<T, U>(ListResponseFunc listResponseFunc)
        where U : IJsonModel<U>, IInternalListResponse<T>
    {
        PageResult<T> pageFunc(string pageToken)
            => GetPageFromProtocol<T, U>(listResponseFunc(pageToken));
        return PageableResultHelpers.Create(pageFunc, pageFunc);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static PageResult<TInstance> GetPageFromProtocol<TInstance, UInternalList>(ClientResult protocolResult)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
    {
        PipelineResponse response = protocolResult.GetRawResponse();
        IInternalListResponse<TInstance> values = ModelReaderWriter.Read<UInternalList>(response.Content);
        return PageResult<TInstance>.Create(values.Data, values.LastId, response);
    }
}
