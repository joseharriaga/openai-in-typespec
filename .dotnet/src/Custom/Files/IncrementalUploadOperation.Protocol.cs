using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace OpenAI.Files;

public partial class IncrementalUploadOperation
{
    public virtual Task<ClientResult> AddDataPartAsync(BinaryContent content, string contentType, RequestOptions options)
        => _internalClient.AddDataPartToUploadJobAsync(UploadJobId, content, contentType, options);

    public virtual ClientResult AddDataPart(BinaryContent content, string contentType, RequestOptions options)
        => _internalClient.AddDataPartToUploadJob(UploadJobId, content, contentType, options);

    public virtual Task<ClientResult> CompleteAsync(BinaryContent content, RequestOptions options)
        => _internalClient.CompleteUploadJobAsync(UploadJobId, content, options);

    public virtual ClientResult Complete(BinaryContent content, RequestOptions options)
        => _internalClient.CompleteUploadJob(UploadJobId, content, options);

    public virtual Task<ClientResult> CancelAsync(RequestOptions options)
        => _internalClient.CancelUploadJobAsync(UploadJobId, options);

    public virtual ClientResult Cancel(RequestOptions options)
        => _internalClient.CancelUploadJob(UploadJobId, options);
}