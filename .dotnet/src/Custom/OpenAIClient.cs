using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuningManagement;
using OpenAI.Images;
using OpenAI.ModelManagement;
using OpenAI.Moderations;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI;

/// <summary>
/// A top-level client factory that enables convenient creation of scenario-specific sub-clients while reusing shared
/// configuration details like endpoint, authentication, and pipeline customization.
/// </summary>
public partial class OpenAIClient
{
    public ClientPipeline Pipeline { get; }
    protected readonly ApiKeyCredential _cachedCredential = null;
    protected readonly OpenAIClientOptions _cachedOptions = null;

    /// <summary>
    /// Creates a new instance of <see cref="OpenAIClient"/> will store common client configuration details to permit
    /// easy reuse and propagation to multiple, scenario-specific subclients.
    /// </summary>
    /// <remarks>
    /// This client does not provide any model functionality directly and is purely a helper to facilitate the creation
    /// of the scenario-specific subclients like <see cref="ChatClient"/>.
    /// </remarks>
    /// <param name="credential"> An explicitly defined credential that all clients created by this <see cref="OpenAIClient"/> should use. </param>
    /// <param name="options"> A common client options definition that all clients created by this <see cref="OpenAIClient"/> should use. </param>
    public OpenAIClient(ApiKeyCredential credential = default, OpenAIClientOptions options = default)
        : this(CreatePipeline(credential, options), options)
    {
        _cachedCredential = credential;
    }

    protected OpenAIClient(ClientPipeline pipeline, OpenAIClientOptions options)
    {
        Pipeline = pipeline;
        _cachedOptions = options;
    }

    protected OpenAIClient()
    { }

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
    public virtual AssistantClient GetAssistantClient() => new(_cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="AudioClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="AudioClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="AudioClient"/>. </returns>
    public virtual AudioClient GetAudioClient(string model) => new(model, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="ChatClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ChatClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ChatClient"/>. </returns>
    public virtual ChatClient GetChatClient(string model) => new(model, Pipeline, GetEndpoint(_cachedOptions));

    /// <summary>
    /// Gets a new instance of <see cref="EmbeddingClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="EmbeddingClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="EmbeddingClient"/>. </returns>
    public virtual EmbeddingClient GetEmbeddingClient(string model) => new(model, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="FileClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="FileClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="FileClient"/>. </returns>
    public virtual FileClient GetFileClient() => new(_cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="FineTuningManagementClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="FineTuningManagementClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="FineTuningManagementClient"/>. </returns>
    public virtual FineTuningManagementClient GetFineTuningManagementClient() => new(_cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="ImageClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ImageClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ImageClient"/>. </returns>
    public virtual ImageClient GetImageClient(string model) => new(model, _cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="ModelManagementClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ModelManagementClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ModelManagementClient"/>. </returns>
    public virtual ModelManagementClient GetModelManagementClient() => new(_cachedCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="ModerationClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ModerationClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ModerationClient"/>. </returns>
    public virtual ModerationClient GetModerationClient() => new(_cachedCredential, _cachedOptions);

    internal static ClientPipeline CreatePipeline(ApiKeyCredential credential, OpenAIClientOptions options = null)
    {
        credential ??= new(Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? string.Empty);
        return ClientPipeline.Create(
            options ?? new(),
            perCallPolicies: [],
            perTryPolicies:
            [
                ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(credential, "Authorization", "Bearer"),
            ],
            beforeTransportPolicies: []);
    }

    internal static Uri GetEndpoint(OpenAIClientOptions options)
    {
        return options?.Endpoint ?? new(Environment.GetEnvironmentVariable("OPENAI_ENDPOINT") ?? "https://api.openai.com/v1");
    }
}
