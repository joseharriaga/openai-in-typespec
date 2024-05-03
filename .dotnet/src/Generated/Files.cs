// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using OpenAI.Internal.Models;

namespace OpenAI.Internal
{
    // Data plane generated sub-client.
    /// <summary> The Files sub-client. </summary>
    internal partial class Files
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of Files for mocking. </summary>
        protected Files()
        {
        }

        /// <summary> Initializes a new instance of Files. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> OpenAI Endpoint. </param>
        internal Files(ClientPipeline pipeline, ApiKeyCredential keyCredential, Uri endpoint)
        {
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        /// <summary>
        /// Upload a file that can be used across various endpoints. The size of all the files uploaded by
        /// one organization can be up to 100 GB.
        ///
        /// The size of individual files can be a maximum of 512 MB or 2 million tokens for Assistants. See
        /// the [Assistants Tools guide](/docs/assistants/tools) to learn more about the types of files
        /// supported. The Fine-tuning API only supports `.jsonl` files.
        ///
        /// Please [contact us](https://help.openai.com/) if you need to increase these storage limits.
        /// </summary>
        /// <param name="file"> The <see cref="CreateFileRequest"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
        /// <remarks> Create file. </remarks>
        public virtual async Task<ClientResult<OpenAIFile>> CreateFileAsync(CreateFileRequest file)
        {
            Argument.AssertNotNull(file, nameof(file));

            using MultipartFormDataBinaryContent content = file.ToMultipartBinaryBody();
            ClientResult result = await CreateFileAsync(content, content.ContentType, (RequestOptions)null).ConfigureAwait(false);
            return ClientResult.FromValue(OpenAIFile.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// Upload a file that can be used across various endpoints. The size of all the files uploaded by
        /// one organization can be up to 100 GB.
        ///
        /// The size of individual files can be a maximum of 512 MB or 2 million tokens for Assistants. See
        /// the [Assistants Tools guide](/docs/assistants/tools) to learn more about the types of files
        /// supported. The Fine-tuning API only supports `.jsonl` files.
        ///
        /// Please [contact us](https://help.openai.com/) if you need to increase these storage limits.
        /// </summary>
        /// <param name="file"> The <see cref="CreateFileRequest"/> to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="file"/> is null. </exception>
        /// <remarks> Create file. </remarks>
        public virtual ClientResult<OpenAIFile> CreateFile(CreateFileRequest file)
        {
            Argument.AssertNotNull(file, nameof(file));

            using MultipartFormDataBinaryContent content = file.ToMultipartBinaryBody();
            ClientResult result = CreateFile(content, content.ContentType, (RequestOptions)null);
            return ClientResult.FromValue(OpenAIFile.FromResponse(result.GetRawResponse()), result.GetRawResponse());
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
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateFileAsync(CreateFileRequest)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> The <see cref="string"/> to use. Allowed values: "multipart/form-data". </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> CreateFileAsync(BinaryContent content, string contentType, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

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
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateFile(CreateFileRequest)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> The <see cref="string"/> to use. Allowed values: "multipart/form-data". </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult CreateFile(BinaryContent content, string contentType, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateFileRequest(content, contentType, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Returns a list of files that belong to the user's organization. </summary>
        /// <param name="purpose"> Only return files with the given purpose. </param>
        /// <remarks> List files. </remarks>
        public virtual async Task<ClientResult<ListFilesResponse>> GetFilesAsync(string purpose = null)
        {
            ClientResult result = await GetFilesAsync(purpose, null).ConfigureAwait(false);
            return ClientResult.FromValue(ListFilesResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Returns a list of files that belong to the user's organization. </summary>
        /// <param name="purpose"> Only return files with the given purpose. </param>
        /// <remarks> List files. </remarks>
        public virtual ClientResult<ListFilesResponse> GetFiles(string purpose = null)
        {
            ClientResult result = GetFiles(purpose, null);
            return ClientResult.FromValue(ListFilesResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Returns a list of files that belong to the user's organization.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFilesAsync(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="purpose"> Only return files with the given purpose. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> GetFilesAsync(string purpose, RequestOptions options)
        {
            using PipelineMessage message = CreateGetFilesRequest(purpose, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Returns a list of files that belong to the user's organization.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetFiles(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="purpose"> Only return files with the given purpose. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult GetFiles(string purpose, RequestOptions options)
        {
            using PipelineMessage message = CreateGetFilesRequest(purpose, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Returns information about a specific file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Retrieve file. </remarks>
        public virtual async Task<ClientResult<OpenAIFile>> RetrieveFileAsync(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = await RetrieveFileAsync(fileId, null).ConfigureAwait(false);
            return ClientResult.FromValue(OpenAIFile.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Returns information about a specific file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Retrieve file. </remarks>
        public virtual ClientResult<OpenAIFile> RetrieveFile(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = RetrieveFile(fileId, null);
            return ClientResult.FromValue(OpenAIFile.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Returns information about a specific file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RetrieveFileAsync(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> RetrieveFileAsync(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateRetrieveFileRequest(fileId, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Returns information about a specific file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RetrieveFile(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult RetrieveFile(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateRetrieveFileRequest(fileId, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Delete a file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Delete file. </remarks>
        public virtual async Task<ClientResult<DeleteFileResponse>> DeleteFileAsync(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = await DeleteFileAsync(fileId, null).ConfigureAwait(false);
            return ClientResult.FromValue(DeleteFileResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Delete a file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Delete file. </remarks>
        public virtual ClientResult<DeleteFileResponse> DeleteFile(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = DeleteFile(fileId, null);
            return ClientResult.FromValue(DeleteFileResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Delete a file
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DeleteFileAsync(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> DeleteFileAsync(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateDeleteFileRequest(fileId, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Delete a file
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DeleteFile(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult DeleteFile(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateDeleteFileRequest(fileId, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        /// <summary> Returns the contents of the specified file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Download file. </remarks>
        public virtual async Task<ClientResult<string>> DownloadFileAsync(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = await DownloadFileAsync(fileId, null).ConfigureAwait(false);
            return ClientResult.FromValue(result.GetRawResponse().Content.ToObjectFromJson<string>(), result.GetRawResponse());
        }

        /// <summary> Returns the contents of the specified file. </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks> Download file. </remarks>
        public virtual ClientResult<string> DownloadFile(string fileId)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            ClientResult result = DownloadFile(fileId, null);
            return ClientResult.FromValue(result.GetRawResponse().Content.ToObjectFromJson<string>(), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Returns the contents of the specified file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DownloadFileAsync(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<ClientResult> DownloadFileAsync(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateDownloadFileRequest(fileId, options);
            return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        /// <summary>
        /// [Protocol Method] Returns the contents of the specified file.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="DownloadFile(string)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fileId"> The ID of the file to use for this request. </param>
        /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fileId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fileId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual ClientResult DownloadFile(string fileId, RequestOptions options)
        {
            Argument.AssertNotNullOrEmpty(fileId, nameof(fileId));

            using PipelineMessage message = CreateDownloadFileRequest(fileId, options);
            return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
        }

        internal PipelineMessage CreateCreateFileRequest(BinaryContent content, string contentType, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "POST";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/files", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("content-type", contentType);
            request.Content = content;
            if (options != null) { message.Apply(options); }
            return message;
        }

        internal PipelineMessage CreateGetFilesRequest(string purpose, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/files", false);
            if (purpose != null)
            {
                uri.AppendQuery("purpose", purpose, true);
            }
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            if (options != null) { message.Apply(options); }
            return message;
        }

        internal PipelineMessage CreateRetrieveFileRequest(string fileId, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/files/", false);
            uri.AppendPath(fileId, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            if (options != null) { message.Apply(options); }
            return message;
        }

        internal PipelineMessage CreateDeleteFileRequest(string fileId, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "DELETE";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/files/", false);
            uri.AppendPath(fileId, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            if (options != null) { message.Apply(options); }
            return message;
        }

        internal PipelineMessage CreateDownloadFileRequest(string fileId, RequestOptions options)
        {
            var message = _pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            var request = message.Request;
            request.Method = "GET";
            var uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/files/", false);
            uri.AppendPath(fileId, true);
            uri.AppendPath("/content", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            if (options != null) { message.Apply(options); }
            return message;
        }

        private static PipelineMessageClassifier _pipelineMessageClassifier200;
        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
    }
}
