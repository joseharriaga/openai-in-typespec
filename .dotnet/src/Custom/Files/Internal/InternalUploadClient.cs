using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.Files;

[CodeGenClient("Uploads")]
[CodeGenSuppress("Uploads", typeof(ClientPipeline), typeof(ApiKeyCredential), typeof(Uri))]
[CodeGenSuppress("CreateUploadAsync", typeof(InternalCreateUploadRequest))]
[CodeGenSuppress("CreateUploadAsync", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("CreateUpload", typeof(InternalCreateUploadRequest))]
[CodeGenSuppress("CreateUpload", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("AddUploadPartAsync", typeof(string), typeof(InternalAddUploadPartRequest))]
[CodeGenSuppress("AddUploadPartAsync", typeof(string), typeof(BinaryContent), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("AddUploadPart", typeof(string), typeof(InternalAddUploadPartRequest))]
[CodeGenSuppress("AddUploadPart", typeof(string), typeof(BinaryContent), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("CompleteUploadAsync", typeof(string), typeof(InternalCompleteUploadRequest))]
[CodeGenSuppress("CompleteUploadAsync", typeof(string), typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("CompleteUpload", typeof(string), typeof(InternalCompleteUploadRequest))]
[CodeGenSuppress("CompleteUpload", typeof(string), typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("CancelUploadAsync", typeof(string))]
[CodeGenSuppress("CancelUploadAsync", typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("CancelUpload", typeof(string))]
[CodeGenSuppress("CancelUpload", typeof(string), typeof(RequestOptions))]
internal partial class InternalUploadClient
{
    /// <summary>
    /// Initializes a new instance of <see cref="InternalUploadClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public InternalUploadClient(ApiKeyCredential credential, OpenAIClientOptions options = default)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="InternalUploadClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="InternalUploadClient(ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public InternalUploadClient(OpenAIClientOptions options = default)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary> Initializes a new instance of <see cref="InternalUploadClient"/>. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    protected internal InternalUploadClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }
}
