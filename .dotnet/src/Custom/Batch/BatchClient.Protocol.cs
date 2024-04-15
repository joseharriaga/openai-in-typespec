using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading.Tasks;

namespace OpenAI.Batch;

public partial class BatchClient
{
    /// <inheritdoc cref="Internal.Batch.CreateBatch(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult CreateBatch(BinaryContent content, RequestOptions options = null)
        => Shim.CreateBatch(content, options);

    /// <inheritdoc cref="Internal.Batch.CreateBatchAsync(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> CreateBatchAsync(BinaryContent content, RequestOptions options = null)
        => Shim.CreateBatchAsync(content, options);

    /// <inheritdoc cref="Internal.Batch.RetrieveBatch(string, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GetBatch(string batchId, RequestOptions options)
        => Shim.RetrieveBatch(batchId, options);

    /// <inheritdoc cref="Internal.Batch.RetrieveBatchAsync(string, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> GetBatchAsync(string batchId, RequestOptions options)
        => Shim.RetrieveBatchAsync(batchId, options);

    /// <inheritdoc cref="Internal.Batch.CancelBatch(string, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult CancelBatch(string batchId, RequestOptions options)
        => Shim.CancelBatch(batchId, options);

    /// <inheritdoc cref="Internal.Batch.CancelBatchAsync(string, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual Task<ClientResult> CancelBatchAsync(string batchId, RequestOptions options)
        => Shim.CancelBatchAsync(batchId, options);
}
