using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace OpenAI.Files;

public partial class IncrementalUploadJob
{
    public virtual Task<ClientResult> AddDataPartAsync(string jobId, BinaryContent content, string contentType, RequestOptions options)
        => _internalClient.AddDataPartToUploadJobAsync(jobId, content, contentType, options);

    public virtual ClientResult AddDataPart(string jobId, BinaryContent content, string contentType, RequestOptions options)
        => _internalClient.AddDataPartToUploadJob(jobId, content, contentType, options);

    public virtual Task<ClientResult> CompleteAsync(string jobId, BinaryContent content, RequestOptions options)
        => _internalClient.CompleteUploadJobAsync(jobId, content, options);

    public virtual ClientResult Complete(string jobId, BinaryContent content, RequestOptions options)
        => _internalClient.CompleteUploadJob(jobId, content, options);

    public virtual Task<ClientResult> CancelAsync(string jobId, RequestOptions options)
        => _internalClient.CancelUploadJobAsync(jobId, options);

    public virtual ClientResult Cancel(string jobId, RequestOptions options)
        => _internalClient.CancelUploadJob(jobId, options);
}