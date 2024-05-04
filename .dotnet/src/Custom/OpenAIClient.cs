using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Images;
using OpenAI.Internal.Models;
using OpenAI.ModelManagement;
using OpenAI.Moderations;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace OpenAI;

/// <summary>
/// A top-level client factory that enables convenient creation of scenario-specific sub-clients while reusing shared
/// configuration details like endpoint, authentication, and pipeline customization.
/// </summary>
[CodeGenModel("OpenAIClient")]
[CodeGenSuppress("OpenAIClient", typeof(ApiKeyCredential))]
[CodeGenSuppress("OpenAIClient", typeof(Uri), typeof(ApiKeyCredential), typeof(OpenAIClientOptions))]
[CodeGenSuppress("GetAudioClientClient")]
// [CodeGenSuppress("GetAssistantsClient")]
[CodeGenSuppress("GetChatClient")]
[CodeGenSuppress("GetLegacyCompletionClientClient")]
[CodeGenSuppress("GetEmbeddingClientClient")]
[CodeGenSuppress("GetFineTuningClientClient")]
[CodeGenSuppress("GetImageClientClient")]
// [CodeGenSuppress("GetMessagesClient")]
// [CodeGenSuppress("GetModelsOpsClient")]
// [CodeGenSuppress("GetModerationsClient")]
// [CodeGenSuppress("GetRunsClient")]
// [CodeGenSuppress("GetThreadsClient")]
public partial class OpenAIClient
{
    private readonly OpenAIClientOptions _options;

    /// <summary>
    /// The configured connection endpoint.
    /// </summary>
    protected Uri Endpoint => _endpoint;

    /// <summary>
    /// Creates a new instance of <see cref="OpenAIClient"/>. This type is used to share common
    /// <see cref="ClientPipeline"/> and client configuration details across scenario client instances created via
    /// methods like <see cref="GetChatClient(string)"/>.
    /// </summary>
    /// <param name="credential"> The API key to use when authenticating the client. </param>
    /// <param name="options"> A common client options definition that all clients created by this <see cref="OpenAIClient"/> should use. </param>
    /// <exception cref="ArgumentNullException"> The provided <paramref name="credential"/> is <c>null</c>. </exception>
    public OpenAIClient(ApiKeyCredential credential, OpenAIClientOptions options = null)
        : this(CreatePipeline(GetApiKey(credential, requireExplicitCredential: true), options), GetEndpoint(options), options)
    {
        _keyCredential = credential;
    }

    /// <summary>
    /// Creates a new instance of <see cref="OpenAIClient"/>. This type is used to share common
    /// <see cref="ClientPipeline"/> and client configuration details across scenario client instances created via
    /// methods like <see cref="GetChatClient(string)"/>.
    /// <para>
    /// This constructor overload will use the value of the <c>OPENAI_API_KEY</c> environment variable as its
    /// authentication mechanism. To provide an explicit credential, use an alternate constructor like
    /// <see cref="OpenAIClient(ApiKeyCredential,OpenAIClientOptions)"/>.
    /// </para>
    /// </summary>
    /// <param name="options"> A common client options definition that all clients created by this <see cref="OpenAIClient"/> should use. </param>
    public OpenAIClient(OpenAIClientOptions options = default)
        : this(CreatePipeline(GetApiKey(), options), GetEndpoint(options), options)
    {}

    /// <summary>
    /// Creates a new instance of <see cref="OpenAIClient"/>.
    /// </summary>
    /// <param name="pipeline"> The common client pipeline that should be used for all created scenario clients. </param>
    /// <param name="endpoint"> The HTTP endpoint to use. </param>
    /// <param name="options"> The common client options that should be used for all created scenario clients. </param>
    protected OpenAIClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _options = options;
    }

    /// <summary>
    /// Gets a new instance of <see cref="AssistantClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="AssistantClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="AssistantClient"/>. </returns>
    [Experimental("OPENAI001")]
    public virtual AssistantClient GetAssistantClient() => new(_pipeline, _endpoint, _options);

    /// <summary>
    /// Gets a new instance of <see cref="AudioClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="AudioClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="AudioClient"/>. </returns>
    public virtual AudioClient GetAudioClient(string model) => new(_pipeline, model, _endpoint, _options);

    /// <summary>
    /// Gets a new instance of <see cref="ChatClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ChatClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ChatClient"/>. </returns>
    public virtual ChatClient GetChatClient(string model) => new(Pipeline, model, _endpoint, _options);

    /// <summary>
    /// Gets a new instance of <see cref="EmbeddingClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="EmbeddingClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="EmbeddingClient"/>. </returns>
    public virtual EmbeddingClient GetEmbeddingClient(string model) => new(_pipeline, model, _endpoint, _options);

    /// <summary>
    /// Gets a new instance of <see cref="FileClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="FileClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="FileClient"/>. </returns>
    public virtual FileClient GetFileClient() => new(_pipeline, _endpoint, _options);

    /// <summary>
    /// Gets a new instance of <see cref="FineTuningClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="FineTuningClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="FineTuningClient"/>. </returns>
    public virtual FineTuningClient GetFineTuningClient() => new(_pipeline, _endpoint, _options);

    /// <summary>
    /// Gets a new instance of <see cref="ImageClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ImageClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ImageClient"/>. </returns>
    public virtual ImageClient GetImageClient(string model) => new(_pipeline, model, _endpoint, _options);

    /// <summary>
    /// Gets a new instance of <see cref="ModelManagementClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ModelManagementClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ModelManagementClient"/>. </returns>
    public virtual ModelManagementClient GetModelManagementClient() => new(_pipeline, _endpoint, _options);

    /// <summary>
    /// Gets a new instance of <see cref="ModerationClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ModerationClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ModerationClient"/>. </returns>
    public virtual ModerationClient GetModerationClient() => new(_pipeline, _endpoint, _options);

    internal static ClientPipeline CreatePipeline(ApiKeyCredential credential, OpenAIClientOptions options = null)
    {
        return ClientPipeline.Create(
            options ?? new(),
            perCallPolicies: [],
            perTryPolicies:
            [
                ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, "Authorization", "Bearer"),
                new GenericActionPipelinePolicy((m) => m.Request?.Headers.Set(s_OpenAIBetaFeatureHeader, s_OpenAIBetaAssistantsV1HeaderValue)),
            ],
            beforeTransportPolicies: []);
    }

    internal static Uri GetEndpoint(OpenAIClientOptions options)
    {
        return options?.Endpoint ?? new(Environment.GetEnvironmentVariable(s_OpenAIEndpointEnvironmentVariable) ?? s_defaultOpenAIV1Endpoint);
    }

    internal static ApiKeyCredential GetApiKey(ApiKeyCredential explicitCredential = null, bool requireExplicitCredential = false)
    {
        if (explicitCredential is not null)
        {
            return explicitCredential;
        }
        else if (requireExplicitCredential)
        {
            throw new ArgumentNullException(nameof(explicitCredential), $"A non-null credential value is required.");
        }
        else
        {
            string environmentApiKey = Environment.GetEnvironmentVariable(s_OpenAIApiKeyEnvironmentVariable);
            if (string.IsNullOrEmpty(environmentApiKey))
            {
                throw new InvalidOperationException(
                    $"No environment variable value was found for {s_OpenAIApiKeyEnvironmentVariable}. "
                    + "Please either populate this environment variable or provide authentication information directly "
                    + "to the client constructor.");
            }
            return new(environmentApiKey);
        }
    }

    private static readonly string s_OpenAIBetaFeatureHeader = "OpenAI-Beta";
    private static readonly string s_OpenAIBetaAssistantsV1HeaderValue = "assistants=v1";
    private static readonly string s_OpenAIEndpointEnvironmentVariable = "OPENAI_ENDPOINT";
    private static readonly string s_OpenAIApiKeyEnvironmentVariable = "OPENAI_API_KEY";
    private static readonly string s_defaultOpenAIV1Endpoint = "https://api.openai.com/v1";
    private static PipelineMessageClassifier s_pipelineMessageClassifier200;
    internal static PipelineMessageClassifier PipelineMessageClassifier200
        => s_pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
}
