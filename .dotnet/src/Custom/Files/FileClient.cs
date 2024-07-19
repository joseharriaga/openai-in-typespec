using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Files;

/// <summary>
/// The service client for OpenAI file operations.
/// </summary>
[CodeGenClient("Files")]
[CodeGenSuppress("FileClient", typeof(ClientPipeline), typeof(ApiKeyCredential), typeof(Uri))]
[CodeGenSuppress("CreateFileAsync", typeof(InternalFileUploadOptions))]
[CodeGenSuppress("CreateFile", typeof(InternalFileUploadOptions))]
[CodeGenSuppress("GetFilesAsync", typeof(string))]
[CodeGenSuppress("GetFiles", typeof(string))]
[CodeGenSuppress("RetrieveFileAsync", typeof(string))]
[CodeGenSuppress("RetrieveFile", typeof(string))]
[CodeGenSuppress("DeleteFileAsync", typeof(string))]
[CodeGenSuppress("DeleteFile", typeof(string))]
[CodeGenSuppress("DownloadFileAsync", typeof(string))]
[CodeGenSuppress("DownloadFile", typeof(string))]
public partial class FileClient
{
    private readonly InternalUploadClient _internalUploadClient;

    /// <summary>
    /// Initializes a new instance of <see cref="FileClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public FileClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              OpenAIClient.GetEndpoint(options),
              options) 
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FileClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="FileClient(ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public FileClient(OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              OpenAIClient.GetEndpoint(options),
              options)
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="FileClient"/>.
    /// </summary>
    /// <param name="pipeline"> The client pipeline to use. </param>
    /// <param name="endpoint"> The endpoint to use. </param>
    protected internal FileClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _internalUploadClient = new(pipeline, endpoint, options);
    }

    /// <summary>
    /// Upload a file that can be used across various endpoints. The size of all the files uploaded by
    /// one organization can be up to 100 GB.
    ///
    /// The size of individual files can be a maximum of 512 MB or 2 million tokens for Assistants. See
    /// the <see href="https://platform.openai.com/docs/assistants/tools">Assistants Tools guide</see> to
    /// learn more about the types of files supported. The Fine-tuning API only supports `.jsonl` files.
    ///
    /// Please <see href="https://help.openai.com/">contact us</see> if you need to increase these
    /// storage limits.
    /// </summary>
    /// <param name="file"> The file to upload. </param>
    /// <param name="filename">
    /// The filename associated with the file stream. The filename's extension (for example: .json) will be used to
    /// validate the file format. The request may fail if the file extension and file format do not match.
    /// </param>
    /// <param name="purpose"> The intended purpose of the uploaded file. </param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <exception cref="ArgumentNullException"> <paramref name="file"/> or <paramref name="filename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="filename"/> is an empty string, and was expected to be non-empty. </exception>
    /// <returns> Information about the uploaded file. </returns>
    public virtual async Task<ClientResult<OpenAIFileInfo>> UploadFileAsync(Stream file, string filename, FileUploadPurpose purpose, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(file, nameof(file));
        Argument.AssertNotNullOrEmpty(filename, nameof(filename));

        InternalFileUploadOptions options = new()
        {
            Purpose = purpose
        };

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(file, filename);
        ClientResult result = await UploadFileAsync(content, content.ContentType, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(OpenAIFileInfo.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Upload a file that can be used across various endpoints. The size of all the files uploaded by
    /// one organization can be up to 100 GB.
    ///
    /// The size of individual files can be a maximum of 512 MB or 2 million tokens for Assistants. See
    /// the <see href="https://platform.openai.com/docs/assistants/tools">Assistants Tools guide</see> to
    /// learn more about the types of files supported. The Fine-tuning API only supports `.jsonl` files.
    ///
    /// Please <see href="https://help.openai.com/">contact us</see> if you need to increase these
    /// storage limits.
    /// </summary>
    /// <param name="file"> The file to upload. </param>
    /// <param name="filename">
    /// The filename associated with the file stream. The filename's extension (for example: .json) will be used to
    /// validate the file format. The request may fail if the file extension and file format do not match.
    /// </param>
    /// <param name="purpose"> The intended purpose of the uploaded file. </param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <exception cref="ArgumentNullException"> <paramref name="file"/> or <paramref name="filename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="filename"/> is an empty string, and was expected to be non-empty. </exception>
    /// <returns> Information about the uploaded file. </returns>
    public virtual ClientResult<OpenAIFileInfo> UploadFile(Stream file, string filename, FileUploadPurpose purpose, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(file, nameof(file));
        Argument.AssertNotNullOrEmpty(filename, nameof(filename));

        InternalFileUploadOptions options = new()
        {
            Purpose = purpose
        };

        using MultipartFormDataBinaryContent content = options.ToMultipartContent(file, filename);
        ClientResult result = UploadFile(content, content.ContentType, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(OpenAIFileInfo.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary>
    /// Upload a file that can be used across various endpoints. The size of all the files uploaded by
    /// one organization can be up to 100 GB.
    ///
    /// The size of individual files can be a maximum of 512 MB or 2 million tokens for Assistants. See
    /// the <see href="https://platform.openai.com/docs/assistants/tools">Assistants Tools guide</see> to
    /// learn more about the types of files supported. The Fine-tuning API only supports `.jsonl` files.
    ///
    /// Please <see href="https://help.openai.com/">contact us</see> if you need to increase these
    /// storage limits.
    /// </summary>
    /// <param name="file"> The file to upload. </param>
    /// <param name="filename">
    /// The filename associated with the file binary data. The filename's extension (for example: .json) will be used to
    /// validate the file format. The request may fail if the file extension and file format do not match.
    /// </param>
    /// <param name="purpose"> The intended purpose of the uploaded file. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="file"/> or <paramref name="filename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="filename"/> is an empty string, and was expected to be non-empty. </exception>
    /// <returns> Information about the uploaded file. </returns>
    public virtual Task<ClientResult<OpenAIFileInfo>> UploadFileAsync(BinaryData file, string filename, FileUploadPurpose purpose)
    {
        Argument.AssertNotNull(file, nameof(file));
        Argument.AssertNotNullOrEmpty(filename, nameof(filename));

        return UploadFileAsync(file?.ToStream(), filename, purpose);
    }

    /// <summary>
    /// Upload a file that can be used across various endpoints. The size of all the files uploaded by
    /// one organization can be up to 100 GB.
    ///
    /// The size of individual files can be a maximum of 512 MB or 2 million tokens for Assistants. See
    /// the <see href="https://platform.openai.com/docs/assistants/tools">Assistants Tools guide</see> to
    /// learn more about the types of files supported. The Fine-tuning API only supports `.jsonl` files.
    ///
    /// Please <see href="https://help.openai.com/">contact us</see> if you need to increase these
    /// storage limits.
    /// </summary>
    /// <param name="file"> The file to upload. </param>
    /// <param name="filename">
    /// The filename associated with the file binary data. The filename's extension (for example: .json) will be used to
    /// validate the file format. The request may fail if the file extension and file format do not match.
    /// </param>
    /// <param name="purpose"> The intended purpose of the uploaded file. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="file"/> or <paramref name="filename"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="filename"/> is an empty string, and was expected to be non-empty. </exception>
    ///
    public virtual ClientResult<OpenAIFileInfo> UploadFile(BinaryData file, string filename, FileUploadPurpose purpose)
    {
        Argument.AssertNotNull(file, nameof(file));
        Argument.AssertNotNullOrEmpty(filename, nameof(filename));

        return UploadFile(file?.ToStream(), filename, purpose);
    }

    /// <summary>
    /// Upload a file that can be used across various endpoints. The size of all the files uploaded by
    /// one organization can be up to 100 GB.
    ///
    /// The size of individual files can be a maximum of 512 MB or 2 million tokens for Assistants. See
    /// the <see href="https://platform.openai.com/docs/assistants/tools">Assistants Tools guide</see> to
    /// learn more about the types of files supported. The Fine-tuning API only supports `.jsonl` files.
    ///
    /// Please <see href="https://help.openai.com/">contact us</see> if you need to increase these
    /// storage limits.
    /// </summary>
    /// <param name="filePath">
    /// The path of the file to upload. The provided file path's extension (for example: .json) will be used
    /// to validate the file format. The request may fail if the file extension and file format do not match.
    /// </param>
    /// <param name="purpose"> The intended purpose of the uploaded file. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="filePath"/> was null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="filePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <returns> Information about the uploaded file. </returns>
    public virtual async Task<ClientResult<OpenAIFileInfo>> UploadFileAsync(string filePath, FileUploadPurpose purpose)
    {
        Argument.AssertNotNullOrEmpty(filePath, nameof(filePath));

        using FileStream stream = File.OpenRead(filePath);
        return await UploadFileAsync(stream, filePath, purpose).ConfigureAwait(false);
    }

    /// <summary>
    /// Upload a file that can be used across various endpoints. The size of all the files uploaded by
    /// one organization can be up to 100 GB.
    ///
    /// The size of individual files can be a maximum of 512 MB or 2 million tokens for Assistants. See
    /// the <see href="https://platform.openai.com/docs/assistants/tools">Assistants Tools guide</see> to
    /// learn more about the types of files supported. The Fine-tuning API only supports `.jsonl` files.
    ///
    /// Please <see href="https://help.openai.com/">contact us</see> if you need to increase these
    /// storage limits.
    /// </summary>
    /// <param name="filePath">
    /// The path of the file to upload. The provided file path's extension (for example: .json) will be used
    /// to validate the file format. The request may fail if the file extension and file format do not match.
    /// </param>
    /// <param name="purpose"> The intended purpose of the uploaded file. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="filePath"/> was null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="filePath"/> is an empty string, and was expected to be non-empty. </exception>
    /// <returns> Information about the uploaded file. </returns>
    public virtual ClientResult<OpenAIFileInfo> UploadFile(string filePath, FileUploadPurpose purpose)
    {
        Argument.AssertNotNullOrEmpty(filePath, nameof(filePath));

        using FileStream stream = File.OpenRead(filePath);
        return UploadFile(stream, filePath, purpose);
    }

    /// <summary> Retrieves a list of files that belong to the user's organization. </summary>
    /// <param name="purpose"> Only return files with the given purpose. </param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns> Information about the files in the user's organization. </returns>
    public virtual async Task<ClientResult<OpenAIFileInfoCollection>> GetFilesAsync(OpenAIFilePurpose? purpose = null, CancellationToken cancellationToken = default)
    {
        ClientResult result = await GetFilesAsync(purpose?.ToString(), cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(OpenAIFileInfoCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Retrieves a list of files that belong to the user's organization. </summary>
    /// <param name="purpose"> Only return files with the given purpose. </param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <returns> Information about the files in the user's organization. </returns>
    public virtual ClientResult<OpenAIFileInfoCollection> GetFiles(OpenAIFilePurpose? purpose = null, CancellationToken cancellationToken = default)
    {
        ClientResult result = GetFiles(purpose?.ToString(), cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(OpenAIFileInfoCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Retrieves information about a specified file. </summary>
    /// <param name="fileId"> The ID of the file to retrieve. </param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <returns> Information about the specified file. </returns>
    public virtual async Task<ClientResult<OpenAIFileInfo>> GetFileAsync(string fileId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        ClientResult result = await GetFileAsync(fileId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(OpenAIFileInfo.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Retrieves information about a specified file. </summary>
    /// <param name="fileId"> The ID of the file to retrieve. </param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <returns> Information about the specified file. </returns>
    public virtual ClientResult<OpenAIFileInfo> GetFile(string fileId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        ClientResult result = GetFile(fileId, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(OpenAIFileInfo.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    /// <summary> Deletes a previously uploaded file. </summary>
    /// <param name="fileId"> The ID of the file to delete. </param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <returns> A boolean value indicating whether the deletion request was successful. </returns>
    public virtual async Task<ClientResult<bool>> DeleteFileAsync(string fileId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        ClientResult result = await DeleteFileAsync(fileId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        InternalDeleteFileResponse internalDeletion = InternalDeleteFileResponse.FromResponse(result.GetRawResponse());
        return ClientResult.FromValue(internalDeletion.Deleted, result.GetRawResponse());
    }

    /// <summary> Deletes a previously uploaded file. </summary>
    /// <param name="fileId"> The ID of the file to delete. </param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <returns> A boolean value indicating whether the deletion request was successful. </returns>
    public virtual ClientResult<bool> DeleteFile(string fileId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        ClientResult result = DeleteFile(fileId, cancellationToken.ToRequestOptions());
        InternalDeleteFileResponse internalDeletion = InternalDeleteFileResponse.FromResponse(result.GetRawResponse());
        return ClientResult.FromValue(internalDeletion.Deleted, result.GetRawResponse());
    }

    /// <summary> Deletes a previously uploaded file. </summary>
    /// <param name="file"> The file to delete. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
    /// <returns> A boolean value indicating whether the deletion request was successful. </returns>
    public virtual Task<ClientResult<bool>> DeleteFileAsync(OpenAIFileInfo file)
    {
        Argument.AssertNotNull(file, nameof(file));
        return DeleteFileAsync(file.Id);
    }

    /// <summary> Deletes a previously uploaded file. </summary>
    /// <param name="file"> The file to delete. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
    /// <returns> A boolean value indicating whether the deletion request was successful. </returns>
    public virtual ClientResult<bool> DeleteFile(OpenAIFileInfo file)
    {
        Argument.AssertNotNull(file.Id, nameof(file));
        return DeleteFile(file.Id);
    }

    /// <summary> Downloads the binary content of the specified file. </summary>
    /// <param name="fileId"> The ID of the file to download. </param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <returns> The contents of the specified file. </returns>
    public virtual async Task<ClientResult<BinaryData>> DownloadFileAsync(string fileId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        ClientResult result = await DownloadFileAsync(fileId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        return ClientResult.FromValue(result.GetRawResponse().Content, result.GetRawResponse());
    }

    /// <summary> Downloads the binary content of the specified file. </summary>
    /// <param name="fileId"> The ID of the file to download. </param>
    /// <param name="cancellationToken">A token that can be used to cancel this method call.</param>
    /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <returns> The bionary content of the specified file. </returns>
    public virtual ClientResult<BinaryData> DownloadFile(string fileId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

        ClientResult result = DownloadFile(fileId, cancellationToken.ToRequestOptions());
        return ClientResult.FromValue(result.GetRawResponse().Content, result.GetRawResponse());
    }

    /// <summary> Downloads the binary content of the specified file. </summary>
    /// <param name="file"> The file to download. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
    /// <returns> The binary content of the uploaded file. </returns>
    public virtual Task<ClientResult<BinaryData>> DownloadFileAsync(OpenAIFileInfo file)
    {
        Argument.AssertNotNull(file, nameof(file));
        return DownloadFileAsync(file.Id);
    }

    /// <summary> Downloads the binary content of the specified file. </summary>
    /// <param name="file"> The file to download. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
    /// <returns> The binary content of the uploaded file. </returns>
    public virtual ClientResult<BinaryData> DownloadFile(OpenAIFileInfo file)
    {
        Argument.AssertNotNull(file, nameof(file));
        return DownloadFile(file.Id);
    }

    /// <summary>
    /// Creates a new file upload job that allows incremental, parallel, and out-of-order upload of multiple data parts.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Once an <see cref="UploadJob"/> is created, associate data parts with it by calling
    /// <see cref="AddDataPartToUploadJobAsync(string,Stream,CancellationToken)"/> before finishing by calling
    /// <see cref="CompleteUploadJobAsync(string,IEnumerable{string},UploadJobCompletionOptions,CancellationToken)"/>.
    /// </para>
    /// <para>
    /// Data parts may be uploaded concurrently and in any order, with the structure finalized when the job is completed
    /// and an <see cref="OpenAIFileInfo"/> becomes available. 
    /// </para>
    /// <para>
    /// An upload job can accept up to 8GB total from data parts and must be completed within one hour of creation.
    /// </para>
    /// <para>
    /// Some upload purposes require specific MIME types. Please refer to the documentation for supported types.
    /// </para>
    /// </remarks>
    /// <param name="filename"> The filename to use on the server when the job is completed. </param>
    /// <param name="size"> The total, combined size of all data parts that will be uploaded. </param>
    /// <param name="purpose"> The purpose of the file that will be created whe the job is completed. </param>
    /// <param name="mimeType"> The MIME type for the content parts that will be uploaded. </param>
    /// <param name="cancellationToken"> An optional token to control method cancellation. </param>
    /// <returns> An <see cref="UploadJob"/> instance representing the pending job. </returns>
    public virtual async Task<ClientResult<UploadJob>> CreateUploadJobAsync(
        string filename,
        int size,
        UploadJobCreationPurpose purpose,
        string mimeType,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(filename, nameof(filename));
        Argument.AssertNotNull(mimeType, nameof(mimeType));

        InternalUploadJobCreationOptions internalOptions = new(filename, purpose, size, mimeType);
        ClientResult result = await CreateUploadJobAsync(
            internalOptions.ToBinaryContent(),
            cancellationToken.ToRequestOptions())
                .ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();
        return ClientResult.FromValue(UploadJob.FromResponse(response), response); 
    }

    /// <summary>
    /// Creates a new file upload job that allows incremental, parallel, and out-of-order upload of multiple data parts.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Once an <see cref="UploadJob"/> is created, associate data parts with it by calling
    /// <see cref="AddDataPartToUploadJob(string,Stream,CancellationToken)"/> before finishing by calling
    /// <see cref="CompleteUploadJob(string,IEnumerable{string},UploadJobCompletionOptions,CancellationToken)"/>.
    /// </para>
    /// <para>
    /// Data parts may be uploaded concurrently and in any order, with the structure finalized when the job is completed
    /// and an <see cref="OpenAIFileInfo"/> becomes available. 
    /// </para>
    /// <para>
    /// An upload job can accept up to 8GB total from data parts and must be completed within one hour of creation.
    /// </para>
    /// <para>
    /// Some upload purposes require specific MIME types. Please refer to the documentation for supported types.
    /// </para>
    /// </remarks>
    /// <param name="filename"> The filename to use on the server when the job is completed. </param>
    /// <param name="size"> The total, combined size of all data parts that will be uploaded. </param>
    /// <param name="purpose"> The purpose of the file that will be created whe the job is completed. </param>
    /// <param name="mimeType"> The MIME type for the content parts that will be uploaded. </param>
    /// <param name="cancellationToken"> An optional token to control method cancellation. </param>
    /// <returns> An <see cref="UploadJob"/> instance representing the pending job. </returns>
    public virtual ClientResult<UploadJob> CreateUploadJob(
        string filename,
        int size,
        UploadJobCreationPurpose purpose,
        string mimeType,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(filename, nameof(filename));
        Argument.AssertNotNull(mimeType, nameof(mimeType));

        InternalUploadJobCreationOptions internalOptions = new(filename, purpose, size, mimeType);
        ClientResult result = CreateUploadJob(internalOptions.ToBinaryContent(), cancellationToken.ToRequestOptions());
        PipelineResponse response = result.GetRawResponse();
        return ClientResult.FromValue(UploadJob.FromResponse(response), response); 
    }

    /// <summary>
    /// Uploads binary data as a part of a job created via
    /// <see cref="CreateUploadJobAsync(string,int,UploadJobCreationPurpose,string,CancellationToken)"/>. 
    /// </summary>
    /// <param name="uploadJobId"> The ID of the upload job to associate the data with. </param>
    /// <param name="data"> The data to upload, with a format matching the MIME type of the job. </param>
    /// <param name="cancellationToken"> An optional token to control method cancellation. </param>
    /// <returns> An <see cref="UploadJobDataPart"/> instance representing the uploaded part. </returns>
    public virtual async Task<ClientResult<UploadJobDataPart>> AddDataPartToUploadJobAsync(
        string uploadJobId,
        Stream data,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));
        Argument.AssertNotNull(data, nameof(data));

        InternalUploadJobDataPartOptions internalOptions = new(data);
        using MultipartFormDataBinaryContent content = internalOptions.ToMultipartContent();
        ClientResult result = await AddDataPartToUploadJobAsync(uploadJobId, content, "application/octet-stream", cancellationToken.ToRequestOptions())
            .ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();
        return ClientResult.FromValue(UploadJobDataPart.FromResponse(response), response);
    }

    /// <summary>
    /// Uploads binary data as a part of a job created via
    /// <see cref="CreateUploadJob(string,int,UploadJobCreationPurpose,string,CancellationToken)"/>. 
    /// </summary>
    /// <param name="uploadJobId"> The ID of the upload job to associate the data with. </param>
    /// <param name="data"> The data to upload, with a format matching the MIME type of the job. </param>
    /// <param name="cancellationToken"> An optional token to control method cancellation. </param>
    /// <returns> An <see cref="UploadJobDataPart"/> instance representing the uploaded part. </returns>
    public virtual ClientResult<UploadJobDataPart> AddDataPartToUploadJob(
        string uploadJobId,
        Stream data,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));
        Argument.AssertNotNull(data, nameof(data));

        InternalUploadJobDataPartOptions internalOptions = new(data);
        using MultipartFormDataBinaryContent content = internalOptions.ToMultipartContent();
        ClientResult result = AddDataPartToUploadJob(uploadJobId, content, "application/octet-stream", cancellationToken.ToRequestOptions());
        PipelineResponse response = result.GetRawResponse();
        return ClientResult.FromValue(UploadJobDataPart.FromResponse(response), response);
    }

    /// <summary>
    /// Completes an in-progress <see cref="UploadJob"/>, sequencing the data parts and creating an file as if the
    /// entire contents had been uploaded at once via
    /// <see cref="UploadFileAsync(Stream,string,FileUploadPurpose,CancellationToken)"/>. 
    /// </summary>
    /// <param name="uploadJobId"> The ID of the upload job to complete. </param>
    /// <param name="dataPartIds">
    /// The ordered sequence of data part IDs, as obtained from <see cref="UploadJobDataPartId"/> instances after
    /// calling <see cref="AddDataPartToUploadJobAsync(string,Stream,CancellationToken)"/>, that describe the full
    /// file contents.
    /// </param>
    /// <param name="options"> Additional options for completing the upload job. </param>
    /// <param name="cancellationToken"> An optional token to control method cancellation. </param>
    /// <returns>
    /// A finished <see cref="UploadJob"/> instance that will, if successful, include an
    /// <see cref="OpenAIFileInfo"/> instance that can be used for other operations.
    /// </returns>
    public virtual async Task<ClientResult<UploadJob>> CompleteUploadJobAsync(
        string uploadJobId,
        IEnumerable<string> dataPartIds,
        UploadJobCompletionOptions options = null,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));
        Argument.AssertNotNullOrEmpty(dataPartIds, nameof(dataPartIds));

        options.DataPartIds = dataPartIds.ToList();
        ClientResult result = await CompleteUploadJobAsync(
            uploadJobId,
            options.ToBinaryContent(),
            cancellationToken.ToRequestOptions())
                .ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();
        return ClientResult.FromValue(UploadJob.FromResponse(response), response); 
    }

    /// <summary>
    /// Completes an in-progress <see cref="UploadJob"/>, sequencing the data parts and creating an file as if the
    /// entire contents had been uploaded at once via
    /// <see cref="UploadFile(Stream,string,FileUploadPurpose,CancellationToken)"/>. 
    /// </summary>
    /// <param name="uploadJobId"> The ID of the upload job to complete. </param>
    /// <param name="dataPartIds">
    /// The ordered sequence of data part IDs, as obtained from <see cref="UploadJobDataPartId"/> instances after
    /// calling <see cref="AddDataPartToUploadJob(string,Stream,CancellationToken)"/>, that describe the full
    /// file contents.
    /// </param>
    /// <param name="options"> Additional options for completing the upload job. </param>
    /// <param name="cancellationToken"> An optional token to control method cancellation. </param>
    /// <returns>
    /// A finished <see cref="UploadJob"/> instance that will, if successful, include an
    /// <see cref="OpenAIFileInfo"/> instance that can be used for other operations.
    /// </returns>
    public virtual ClientResult<UploadJob> CompleteUploadJob(
        string uploadJobId,
        IEnumerable<string> dataPartIds,
        UploadJobCompletionOptions options = null,
        CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));
        Argument.AssertNotNullOrEmpty(dataPartIds, nameof(dataPartIds));

        options.DataPartIds = dataPartIds.ToList();
        ClientResult result = CompleteUploadJob(uploadJobId, options.ToBinaryContent(), cancellationToken.ToRequestOptions());
        PipelineResponse response = result.GetRawResponse();
        return ClientResult.FromValue(UploadJob.FromResponse(response), response); 
    }

    /// <summary>
    /// Cancels a pending <see cref="UploadJob"/>, abandoning <see cref="UploadJobDataPart"/> instances already added
    /// and preventing further calls to <see cref="AddDataPartToUploadJobAsync(string,Stream,CancellationToken)"/> from
    /// adding more data. 
    /// </summary>
    /// <param name="uploadJobId"> The ID of the upload job to cancel. </param>
    /// <param name="cancellationToken"> An optional token to control method cancellation. </param>
    /// <returns> An updated <see cref="UploadJob"/> instance reflecting the cancelled state. </returns>
    public virtual async Task<ClientResult<UploadJob>> CancelUploadJobAsync(string uploadJobId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));

        ClientResult result = await CancelUploadJobAsync(uploadJobId, cancellationToken.ToRequestOptions()).ConfigureAwait(false);
        PipelineResponse response = result.GetRawResponse();
        return ClientResult.FromValue(UploadJob.FromResponse(response), response);
    } 

    /// <summary>
    /// Cancels a pending <see cref="UploadJob"/>, abandoning <see cref="UploadJobDataPart"/> instances already added
    /// and preventing further calls to <see cref="AddDataPartToUploadJob(string,Stream,CancellationToken)"/> from
    /// adding more data. 
    /// </summary>
    /// <param name="uploadJobId"> The ID of the upload job to cancel. </param>
    /// <param name="cancellationToken"> An optional token to control method cancellation. </param>
    /// <returns> An updated <see cref="UploadJob"/> instance reflecting the cancelled state. </returns>
    public virtual ClientResult<UploadJob> CancelUploadJob(string uploadJobId, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNull(uploadJobId, nameof(uploadJobId));

        ClientResult result = CancelUploadJob(uploadJobId, cancellationToken.ToRequestOptions());
        PipelineResponse response = result.GetRawResponse();
        return ClientResult.FromValue(UploadJob.FromResponse(response), response);
    } 
}
