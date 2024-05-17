using System.ClientModel;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace OpenAI;

internal static class InternalListHelpers
{
    internal delegate Task<ClientResult> AsyncProtocolListMethod(int? limit, string order, string after, string before, RequestOptions options);
    internal delegate Task<ClientResult> AsyncProtocolListMethod2(string id, int? limit, string order, string after, string before, RequestOptions options);
    internal delegate Task<ClientResult> AsyncProtocolListMethod3(string id, string id2, int? limit, string order, string after, string before, RequestOptions options);
    internal delegate ClientResult ProtocolListMethod(int? limit, string order, string after, string before, RequestOptions options);
    internal delegate ClientResult ProtocolListMethod2(string id, int? limit, string order, string after, string before, RequestOptions options);
    internal delegate ClientResult ProtocolListMethod3(string id, string id2, int? limit, string order, string after, string before, RequestOptions options);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static async Task<ResultPage<TInstance>> GetFirstPageAsync<TInstance, UInternalList>(
        AsyncProtocolListMethod protocolMethod,
        ListOrder? resultOrder = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance,UInternalList>(
            await protocolMethod(
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: null,
                before: null,
                options: null).ConfigureAwait(false));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static async Task<ResultPage<TInstance>> GetFirstPageAsync<TInstance, UInternalList>(
        AsyncProtocolListMethod2 protocolMethod,
        string id,
        ListOrder? resultOrder = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance, UInternalList>(
            await protocolMethod(
                id: id,
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: null,
                before: null,
                options: null).ConfigureAwait(false));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static async Task<ResultPage<TInstance>> GetFirstPageAsync<TInstance, UInternalList>(
        AsyncProtocolListMethod3 protocolMethod,
        string id,
        string id2,
        ListOrder? resultOrder = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance, UInternalList>(
            await protocolMethod(
                id: id,
                id2: id2,
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: null,
                before: null,
                options: null).ConfigureAwait(false));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ResultPage<TInstance> GetFirstPage<TInstance, UInternalList>(
        ProtocolListMethod protocolMethod,
        ListOrder? resultOrder = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance, UInternalList>(
            protocolMethod(
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: null,
                before: null,
                options: null));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ResultPage<TInstance> GetFirstPage<TInstance, UInternalList>(
        ProtocolListMethod2 protocolMethod,
        string id,
        ListOrder? resultOrder = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance, UInternalList>(
            protocolMethod(
                id: id,
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: null,
                before: null,
                options: null));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ResultPage<TInstance> GetFirstPage<TInstance, UInternalList>(
        ProtocolListMethod3 protocolMethod,
        string id,
        string id2,
        ListOrder? resultOrder = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance, UInternalList>(
            protocolMethod(
                id: id,
                id2: id2,
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: null,
                before: null,
                options: null));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static async Task<ResultPage<TInstance>> GetNextPageAsync<TInstance, UInternalList>(
        AsyncProtocolListMethod protocolMethod,
        ListOrder? resultOrder = null,
        string continuationToken = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance,UInternalList>(
            await protocolMethod(
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: continuationToken,
                before: null,
                options: null).ConfigureAwait(false));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static async Task<ResultPage<TInstance>> GetNextPageAsync<TInstance, UInternalList>(
        AsyncProtocolListMethod2 protocolMethod,
        string id,
        ListOrder? resultOrder = null,
        string continuationToken = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance, UInternalList>(
            await protocolMethod(
                id: id,
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: continuationToken,
                before: null,
                options: null).ConfigureAwait(false));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static async Task<ResultPage<TInstance>> GetNextPageAsync<TInstance, UInternalList>(
        AsyncProtocolListMethod3 protocolMethod,
        string id,
        string id2,
        ListOrder? resultOrder = null,
        string continuationToken = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance, UInternalList>(
            await protocolMethod(
                id: id,
                id2: id2,
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: continuationToken,
                before: null,
                options: null).ConfigureAwait(false));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ResultPage<TInstance> GetNextPage<TInstance, UInternalList>(
        ProtocolListMethod protocolMethod,
        ListOrder? resultOrder = null,
        string continuationToken = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance, UInternalList>(
            protocolMethod(
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: continuationToken,
                before: null,
                options: null));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ResultPage<TInstance> GetNextPage<TInstance, UInternalList>(
        ProtocolListMethod2 protocolMethod,
        string id,
        ListOrder? resultOrder = null,
        string continuationToken = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance, UInternalList>(
            protocolMethod(
                id: id,
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: continuationToken,
                before: null,
                options: null));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ResultPage<TInstance> GetNextPage<TInstance, UInternalList>(
        ProtocolListMethod3 protocolMethod,
        string id,
        string id2,
        ListOrder? resultOrder = null,
        string continuationToken = null,
        int? pageSize = null)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
        => GetPageFromProtocol<TInstance, UInternalList>(
            protocolMethod(
                id: id,
                id2: id2,
                limit: pageSize,
                order: resultOrder?.ToString(),
                after: continuationToken,
                before: null,
                options: null));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ResultPage<TInstance> GetPageFromProtocol<TInstance,UInternalList>(ClientResult protocolResult)
            where UInternalList : IJsonModel<UInternalList>, IInternalListResponse<TInstance>
    {
        PipelineResponse response = protocolResult.GetRawResponse();
        IInternalListResponse<TInstance> values = ModelReaderWriter.Read<UInternalList>(response.Content);
        return ResultPage<TInstance>.Create(values.Data, values.HasMore ? values.LastId : null, response);
    }
}
