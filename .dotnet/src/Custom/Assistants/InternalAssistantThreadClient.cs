using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.Assistants;

[CodeGenClient("Threads")]
[CodeGenSuppress("InternalAssistantThreadClient", typeof(ClientPipeline), typeof(ApiKeyCredential), typeof(Uri))]
internal partial class InternalAssistantThreadClient
{
    /// <summary>
    /// Initializes a new instance of <see cref="InternalAssistantThreadClient"/> that will use an API key when authenticating.
    /// </summary>
    /// <param name="credential"> The API key used to authenticate with the service endpoint. </param>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> was null. </exception>
    public InternalAssistantThreadClient(ApiKeyCredential credential, OpenAIClientOptions options = default)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary>
    /// Initializes a new instance of <see cref="InternalAssistantThreadClient"/> that will use an API key from the OPENAI_API_KEY
    /// environment variable when authenticating.
    /// </summary>
    /// <remarks>
    /// To provide an explicit credential instead of using the environment variable, use an alternate constructor like
    /// <see cref="InternalAssistantThreadClient(ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </remarks>
    /// <param name="options"> Additional options to customize the client. </param>
    /// <exception cref="InvalidOperationException"> The OPENAI_API_KEY environment variable was not found. </exception>
    public InternalAssistantThreadClient(OpenAIClientOptions options = default)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    /// <summary> Initializes a new instance of <see cref="InternalAssistantThreadClient"/>. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    protected internal InternalAssistantThreadClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }
}
