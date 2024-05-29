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
    /// the [Assistants Tools guide](/docs/assistants/tools) to learn more about the types of files
    /// supported. The Fine-tuning API only supports `.jsonl` files.
    ///
    /// Please [contact us](https://help.openai.com/) if you need to increase these storage limits.
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
    /// the [Assistants Tools guide](/docs/assistants/tools) to learn more about the types of files
    /// supported. The Fine-tuning API only supports `.jsonl` files.
    ///
    /// Please [contact us](https://help.openai.com/) if you need to increase these storage limits.
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
    /// [Protocol Method] Returns a list of files that belong to the user's organization.
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
    /// [Protocol Method] Returns a list of files that belong to the user's organization.
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
    /// [Protocol Method] Returns information about a specific file.
    /// </summary>
    /// <param name="fileId"> The ID of the file to use for this request. </param>
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
    /// [Protocol Method] Returns information about a specific file.
    /// </summary>
    /// <param name="fileId"> The ID of the file to use for this request. </param>
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
    /// [Protocol Method] Delete a file
    /// </summary>
    /// <param name="fileId"> The ID of the file to use for this request. </param>
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
    /// [Protocol Method] Delete a file
    /// </summary>
    /// <param name="fileId"> The ID of the file to use for this request. </param>
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
    /// [Protocol Method] Returns the contents of the specified file.
    /// </summary>
    /// <param name="fileId"> The ID of the file to use for this request. </param>
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
    /// [Protocol Method] Returns the contents of the specified file.
    /// </summary>
    /// <param name="fileId"> The ID of the file to use for this request. </param>
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
}
