using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Threading.Tasks;

namespace OpenAI.Files;

[CodeGenSuppress("CreateFileAsync", typeof(BinaryContent), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("CreateFile", typeof(BinaryContent), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetFilesAsync",  typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetFiles", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("RetrieveFileAsync", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("RetrieveFile", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("DeleteFileAsync", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("DeleteFile", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("DownloadFileAsync", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("DownloadFile", typeof(string), typeof(RequestOptions))]
public partial class FileClient
{
    /// <summary>
    /// [Protocol Method] Upload a file that can be used across various endpoints. The size of all the files uploaded by
    /// one organization can be up to 100 GB.
    ///
    /// The size of individual files can be a maximum of 512 MB or 2 million tokens for Assistants. See
    /// the <see href="https://platform.openai.com/docs/assistants/tools">Assistants Tools guide</see> to
    /// learn more about the types of files supported. The Fine-tuning API only supports `.jsonl` files.
    ///
    /// Please <see href="https://help.openai.com/">contact us</see> if you need to increase these
    /// storage limits.
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="contentType"> The content type of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> or <paramref name="contentType"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="contentType"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> UploadFileAsync(BinaryContent content, string contentType, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        using PipelineMessage message = CreateCreateFileRequest(content, contentType, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <summary>
    /// [Protocol Method] Upload a file that can be used across various endpoints. The size of all the files uploaded by
    /// one organization can be up to 100 GB.
    ///
    /// The size of individual files can be a maximum of 512 MB or 2 million tokens for Assistants. See
    /// the <see href="https://platform.openai.com/docs/assistants/tools">Assistants Tools guide</see> to
    /// learn more about the types of files supported. The Fine-tuning API only supports `.jsonl` files.
    ///
    /// Please <see href="https://help.openai.com/">contact us</see> if you need to increase these
    /// storage limits.
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="contentType"> The content type of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> or <paramref name="contentType"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="contentType"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult UploadFile(BinaryContent content, string contentType, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));
        Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

        using PipelineMessage message = CreateCreateFileRequest(content, contentType, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    /// <summary>
    /// [Protocol Method] Retrieves a list of files that belong to the user's organization.
    /// </summary>
    /// <param name="purpose"> Only return files with the given purpose. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> GetFilesAsync(string purpose, RequestOptions options)
    {
        using PipelineMessage message = CreateGetFilesRequest(purpose, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <summary>
    /// [Protocol Method] Retrieves a list of files that belong to the user's organization.
    /// </summary>
    /// <param name="purpose"> Only return files with the given purpose. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GetFiles(string purpose, RequestOptions options)
    {
        using PipelineMessage message = CreateGetFilesRequest(purpose, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    /// <summary>
    /// [Protocol Method] Retrieves information about a specified file.
    /// </summary>
    /// <param name="fileId"> The ID of the file to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> GetFileAsync(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateRetrieveFileRequest(fileId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <summary>
    /// [Protocol Method] Retrieves information about a specified file.
    /// </summary>
    /// <param name="fileId"> The ID of the file to retrieve. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GetFile(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateRetrieveFileRequest(fileId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    /// <summary>
    /// [Protocol Method] Deletes a previously uploaded file.
    /// </summary>
    /// <param name="fileId"> The ID of the file to delete. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> DeleteFileAsync(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDeleteFileRequest(fileId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <summary>
    /// [Protocol Method] Deletes a previously uploaded file.
    /// </summary>
    /// <param name="fileId"> The ID of the file to delete. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult DeleteFile(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDeleteFileRequest(fileId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    /// <summary>
    /// [Protocol Method] Downloads the binary content of the specified file.
    /// </summary>
    /// <param name="fileId"> The ID of the file to download. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> DownloadFileAsync(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDownloadFileRequest(fileId, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    /// <summary>
    /// [Protocol Method] Downloads the binary content of the specified file.
    /// </summary>
    /// <param name="fileId"> The ID of the file to download. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult DownloadFile(string fileId, RequestOptions options)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        using PipelineMessage message = CreateDownloadFileRequest(fileId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    /// <summary>
    /// <para>[Protocol Method]</para>
    /// Creates a new <see cref="IncrementalUploadJob"/> that can be used to incrementally create a file, uploading
    /// individual data parts with arbitrary ordering and parallelism before being assembled by a final completion.
    /// </summary>
    /// <param name="content">
    /// <para>
    /// The request content describing the job to create. This is a JSON object with required <c>filename</c>,
    /// <c>purpose</c>, <c>bytes</c>, and <c>mime_type</c> properties.
    /// </para>
    /// Example:
    /// <code>
    /// BinaryContent.Create(BinaryData.FromString($$"""
    ///     {
    ///         "purpose": "fine-tune",
    ///         "filename": ""{{filenameToCreate}}"",
    ///         "bytes": ""{{totalSizeOfFile}}"",
    ///         "mime_type": "text/jsonl"
    ///     }));
    /// </code>
    /// </param>
    /// <param name="options">
    /// Additional options for the protocol request, including cancellation and error behavior.
    /// </param>
    /// <returns>
    /// A new instance of <see cref="IncrementalUploadJob"/> that can be used to add data parts and complete the upload.
    /// A successfully completed upload will provide an assembled file with an ID that can be used in other operations.
    /// </returns>
    public virtual async Task<IncrementalUploadJob> CreateIncrementalUploadJobAsync(BinaryContent content, RequestOptions options)
    {
        ClientResult result = await _internalUploadClient.CreateUploadJobAsync(content, options).ConfigureAwait(false);
        InternalUploadJobInfo jobInfo = InternalUploadJobInfo.FromResponse(result.GetRawResponse());
        return new IncrementalUploadJob(jobInfo, _internalUploadClient, result.GetRawResponse());
    }

    /// <summary>
    /// <para>[Protocol Method]</para>
    /// Creates a new <see cref="IncrementalUploadJob"/> that can be used to incrementally create a file, uploading
    /// individual data parts with arbitrary ordering and parallelism before being assembled by a final completion.
    /// </summary>
    /// <param name="content">
    /// <para>
    /// The request content describing the job to create. This is a JSON object with required <c>filename</c>,
    /// <c>purpose</c>, <c>bytes</c>, and <c>mime_type</c> properties.
    /// </para>
    /// Example:
    /// <code>
    /// BinaryContent.Create(BinaryData.FromString($$"""
    ///     {
    ///         "purpose": "fine-tune",
    ///         "filename": ""{{filenameToCreate}}"",
    ///         "bytes": ""{{totalSizeOfFile}}"",
    ///         "mime_type": "text/jsonl"
    ///     }));
    /// </code>
    /// </param>
    /// <param name="options">
    /// Additional options for the protocol request, including cancellation and error behavior.
    /// </param>
    /// <returns>
    /// A new instance of <see cref="IncrementalUploadJob"/> that can be used to add data parts and complete the upload.
    /// A successfully completed upload will provide an assembled file with an ID that can be used in other operations.
    /// </returns>
    public virtual IncrementalUploadJob CreateIncrementalUploadJob(BinaryContent content, RequestOptions options)
    {
        ClientResult result = _internalUploadClient.CreateUploadJob(content, options);
        InternalUploadJobInfo jobInfo = InternalUploadJobInfo.FromResponse(result.GetRawResponse());
        return new IncrementalUploadJob(jobInfo, _internalUploadClient, result.GetRawResponse());
    }
}
