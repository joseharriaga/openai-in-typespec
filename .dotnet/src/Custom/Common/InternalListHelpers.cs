using System.ClientModel;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OpenAI;

internal static class InternalListHelpers
{
    internal delegate Task<ClientResult> AsyncListResponseFunc(string continuationToken);
    internal delegate ClientResult ListResponseFunc(string continuationToken);

    internal static AsyncPageableCollection<T> CreateAsyncPageable<T, U>(AsyncListResponseFunc listResponseFunc)
        where U : IJsonModel<U>, IInternalListResponse<T>
    {
        async Task<PageResult<T>> pageFunc(string continuationToken)
            => GetPageFromProtocol<T,U>(await listResponseFunc(continuationToken).ConfigureAwait(false));
        return PageableResultHelpers.Create(() => pageFunc(null), pageFunc);
    }

    internal static PageableCollection<T> CreatePageable<T, U>(ListResponseFunc listResponseFunc)
        where U : IJsonModel<U>, IInternalListResponse<T>
    {
        PageResult<T> pageFunc(string continuationToken)
            => GetPageFromProtocol<T, U>(listResponseFunc(continuationToken));
        return PageableResultHelpers.Create(() => pageFunc(null), pageFunc);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static PageResult<TInstance> GetPageFromProtocol<TInstance, UInternalList>(ClientResult protocolResult)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
    {
        PipelineResponse response = protocolResult.GetRawResponse();
        IInternalListResponse<TInstance> values = ModelReaderWriter.Read<UInternalList>(response.Content);
        return PageResult<TInstance>.Create(values.Data, values.HasMore ? values.LastId : null, response);
    }
}
