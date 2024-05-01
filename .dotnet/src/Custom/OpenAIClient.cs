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

namespace OpenAI;

/// <summary>
/// A top-level client factory that enables convenient creation of scenario-specific sub-clients while reusing shared
/// configuration details like endpoint, authentication, and pipeline customization.
/// </summary>
[CodeGenModel("OpenAIClient")]
[CodeGenSuppress("OpenAIClient", typeof(Uri), typeof(ApiKeyCredential), typeof(OpenAIClientOptions))]
[CodeGenSuppress("GetAudioClientClient")]
[CodeGenSuppress("GetEmbeddingClientClient")]
[CodeGenSuppress("GetFineTuningClientClient")]
[CodeGenSuppress("GetImageClientClient")]
[CodeGenSuppress("GetLegacyCompletionClientClient")]
public partial class OpenAIClient
{
    internal static readonly string s_OpenAIEndpointEnvironmentVariable = "OPENAI_ENDPOINT";
    internal static readonly string s_OpenAIApiKeyEnvironmentVariable = "OPENAI_API_KEY";
    internal static readonly string s_defaultOpenAIV1Endpoint = "https://api.openai.com/v1";

    private readonly OpenAIClientOptions _cachedOptions = null;

    /// <summary> Initializes a new instance of OpenAIClient. </summary>
    /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
    public OpenAIClient(ApiKeyCredential credential = default) : this(credential, new OpenAIClientOptions())
    {
    }

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
    {
        options ??= new OpenAIClientOptions();

        _keyCredential = credential ?? new(Environment.GetEnvironmentVariable(s_OpenAIApiKeyEnvironmentVariable) ?? string.Empty);
        _pipeline = ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), new PipelinePolicy[] { ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, Array.Empty<PipelinePolicy>());
        _endpoint = options.Endpoint ?? new(Environment.GetEnvironmentVariable(s_OpenAIEndpointEnvironmentVariable) ?? s_defaultOpenAIV1Endpoint);

        _cachedOptions = options;
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
    public virtual AssistantClient GetAssistantClient() => new(_keyCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="AudioClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="AudioClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="AudioClient"/>. </returns>
    public virtual AudioClient GetAudioClient(string model) => new(_pipeline, model, _keyCredential, _endpoint);

    /// <summary>
    /// Gets a new instance of <see cref="ChatClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ChatClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ChatClient"/>. </returns>
    public virtual ChatClient GetChatClient(string model) => new(model, _keyCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="EmbeddingClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="EmbeddingClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="EmbeddingClient"/>. </returns>
    public virtual EmbeddingClient GetEmbeddingClient(string model) => new(_pipeline, model, _keyCredential, _endpoint);

    /// <summary>
    /// Gets a new instance of <see cref="FileClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="FileClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="FileClient"/>. </returns>
    public virtual FileClient GetFileClient() => new(_keyCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="FineTuningClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="FineTuningClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="FineTuningClient"/>. </returns>
    public virtual FineTuningClient GetFineTuningClient() => new(_pipeline, _keyCredential, _endpoint);

    /// <summary>
    /// Gets a new instance of <see cref="ImageClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ImageClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ImageClient"/>. </returns>
    public virtual ImageClient GetImageClient(string model) => new(_pipeline, model, _keyCredential, _endpoint);

    /// <summary>
    /// Gets a new instance of <see cref="ModelManagementClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ModelManagementClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ModelManagementClient"/>. </returns>
    public virtual ModelManagementClient GetModelManagementClient() => new(_keyCredential, _cachedOptions);

    /// <summary>
    /// Gets a new instance of <see cref="ModerationClient"/> that reuses the client configuration details provided to
    /// the <see cref="OpenAIClient"/> instance.
    /// </summary>
    /// <remarks>
    /// This method is functionally equivalent to using the <see cref="ModerationClient"/> constructor directly with
    /// the same configuration details.
    /// </remarks>
    /// <returns> A new <see cref="ModerationClient"/>. </returns>
    public virtual ModerationClient GetModerationClient() => new(_keyCredential, _cachedOptions);
}
