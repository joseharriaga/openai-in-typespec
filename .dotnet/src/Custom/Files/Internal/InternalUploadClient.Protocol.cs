using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading.Tasks;

namespace OpenAI.Files;

internal partial class InternalUploadClient
{
    public virtual async Task<ClientResult> CreateUploadJobAsync(BinaryContent content, RequestOptions options)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateUploadRequest(content, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public virtual ClientResult CreateUploadJob(BinaryContent content, RequestOptions options)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateUploadRequest(content, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    public virtual async Task<ClientResult> AddDataPartToUploadJobAsync(string uploadJobId, BinaryContent content, string contentType, RequestOptions options)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNull(contentType, nameof(contentType));

        using PipelineMessage message = CreateAddUploadPartRequest(uploadJobId, content, contentType, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public virtual ClientResult AddDataPartToUploadJob(string uploadJobId, BinaryContent content, string contentType, RequestOptions options)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNull(contentType, nameof(contentType));

        using PipelineMessage message = CreateAddUploadPartRequest(uploadJobId, content, contentType, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    public virtual async Task<ClientResult> CompleteUploadJobAsync(string uploadJobId, BinaryContent content, RequestOptions options)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCompleteUploadRequest(uploadJobId, content, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public virtual ClientResult CompleteUploadJob(string uploadJobId, BinaryContent content, RequestOptions options)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCompleteUploadRequest(uploadJobId, content, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    public virtual async Task<ClientResult> CancelUploadJobAsync(string uploadJobId, RequestOptions options)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));

        using PipelineMessage message = CreateCancelUploadRequest(uploadJobId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    public virtual ClientResult CancelUploadJob(string uploadJobId, RequestOptions options)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));

        using PipelineMessage message = CreateCancelUploadRequest(uploadJobId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }
}