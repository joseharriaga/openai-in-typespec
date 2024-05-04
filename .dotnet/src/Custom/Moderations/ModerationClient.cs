using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.Moderations;

/// <summary>
///     The service client for OpenAI moderation operations.
/// </summary>
public partial class ModerationClient
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly OpenAIClientConnector _clientConnector;
    private Internal.Moderations Shim => _clientConnector.InternalClient.GetModerationsClient();

    /// <inheritdoc cref="OpenAIClient.Pipeline"/>
    public ClientPipeline Pipeline => _pipeline;

    /// <summary>
    /// Initializes a new instance of <see cref="ModerationClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public ModerationClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              OpenAIClient.GetEndpoint(options),
              options)
    {
        // Temporary pending codegen integration
        _clientConnector = new(model: null, credential, options);
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ModerationClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="ModerationClient(ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public ModerationClient(OpenAIClientOptions options = null)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              OpenAIClient.GetEndpoint(options),
              options)
    {
        // Temporary pending codegen integration
        _clientConnector = new(model: null, OpenAIClient.GetApiKey(), options);
    }

    /// <summary> Initializes a new instance of FineTuningClient. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    protected internal ModerationClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }
}
