using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Embeddings;

/// <summary> The service client for the OpenAI Embeddings endpoint. </summary>
[CodeGenClient("Embeddings")]
[CodeGenSuppress("EmbeddingClient", typeof(ClientPipeline), typeof(ApiKeyCredential), typeof(Uri))]
[CodeGenSuppress("CreateEmbedding", typeof(EmbeddingOptions), typeof(CancellationToken))]
[CodeGenSuppress("CreateEmbeddingAsync", typeof(EmbeddingOptions), typeof(CancellationToken))]
public partial class EmbeddingClient
{
    private readonly string _model;

    // CUSTOM:
    // - Added `model` parameter.
    // - Added support for retrieving credential and endpoint from environment variables.
    /// <summary> Initializes a new instance of EmbeddingClient. </summary>
    /// <param name="model"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="credential"> The key credential to copy. </param>
    /// <param name="options"> OpenAI Endpoint. </param>
    public EmbeddingClient(string model, ApiKeyCredential credential = default, OpenAIClientOptions options = default)
    {
        Argument.AssertNotNullOrEmpty(model, nameof(model));
        options ??= new OpenAIClientOptions();

        _model = model;
        _keyCredential = credential ?? new(Environment.GetEnvironmentVariable(OpenAIClient.s_OpenAIApiKeyEnvironmentVariable) ?? string.Empty);
        _pipeline = ClientPipeline.Create(options, Array.Empty<PipelinePolicy>(), new PipelinePolicy[] { ApiKeyAuthenticationPolicy.CreateHeaderApiKeyPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) }, Array.Empty<PipelinePolicy>());
        _endpoint = options.Endpoint ?? new(Environment.GetEnvironmentVariable(OpenAIClient.s_OpenAIEndpointEnvironmentVariable) ?? OpenAIClient.s_defaultOpenAIV1Endpoint);
    }

    // CUSTOM:
    // - Added `model` parameter.
    /// <summary> Initializes a new instance of EmbeddingClient. </summary>
    /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="model"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
    /// <param name="credential"> The key credential to copy. </param>
    /// <param name="endpoint"> OpenAI Endpoint. </param>
    internal EmbeddingClient(ClientPipeline pipeline, string model, ApiKeyCredential credential, Uri endpoint)
    {
        _pipeline = pipeline;
        _model = model;
        _keyCredential = credential;
        _endpoint = endpoint;
    }

    // CUSTOM: Added to simplify generating a single embedding from a string input.
    /// <summary> Creates an embedding vector representing the input text. </summary>
    /// <param name="input"> The string that will be turned into an embedding. </param>
    /// <param name="options"> The <see cref="EmbeddingOptions"/> to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="input"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<Embedding>> GenerateEmbeddingAsync(string input, EmbeddingOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(input, nameof(input));

        options ??= new();
        CreateEmbeddingOptions(BinaryData.FromString(input), ref options);

        using BinaryContent content = options.ToBinaryBody();
        ClientResult result = await GenerateEmbeddingAsync(content, DefaultRequestContext).ConfigureAwait(false);
        return ClientResult.FromValue(EmbeddingCollection.FromResponse(result.GetRawResponse()).FirstOrDefault(), result.GetRawResponse());
    }

    // CUSTOM: Added to simplify generating a single embedding from a string input.
    /// <summary> Creates an embedding vector representing the input text. </summary>
    /// <param name="input"> The string that will be turned into an embedding. </param>
    /// <param name="options"> The <see cref="EmbeddingOptions"/> to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="input"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="input"/> is an empty string, and was expected to be non-empty. </exception>
    public virtual ClientResult<Embedding> GenerateEmbedding(string input, EmbeddingOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(input, nameof(input));

        options ??= new();
        CreateEmbeddingOptions(BinaryData.FromObjectAsJson(input), ref options);

        using BinaryContent content = options.ToBinaryBody();
        ClientResult result = GenerateEmbedding(content, DefaultRequestContext);
        return ClientResult.FromValue(EmbeddingCollection.FromResponse(result.GetRawResponse()).FirstOrDefault(), result.GetRawResponse());
    }

    // CUSTOM: Added to simplify passing the input as a collection of strings instead of BinaryData.
    /// <summary> Creates an embedding vector representing the input text. </summary>
    /// <param name="inputs"> The strings that will be turned into embeddings. </param>
    /// <param name="options"> The <see cref="EmbeddingOptions"/> to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="inputs"/> is an empty collection, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<EmbeddingCollection>> GenerateEmbeddingsAsync(IEnumerable<string> inputs, EmbeddingOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(inputs, nameof(inputs));

        options ??= new();
        CreateEmbeddingOptions(BinaryData.FromObjectAsJson(inputs), ref options);

        using BinaryContent content = options.ToBinaryBody();
        ClientResult result = await GenerateEmbeddingAsync(content, DefaultRequestContext).ConfigureAwait(false);
        return ClientResult.FromValue(EmbeddingCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    // CUSTOM: Added to simplify passing the input as a collection of strings instead of BinaryData.
    /// <summary> Creates an embedding vector representing the input text. </summary>
    /// <param name="inputs"> The strings that will be turned into embeddings. </param>
    /// <param name="options"> The <see cref="EmbeddingOptions"/> to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="inputs"/> is an empty collection, and was expected to be non-empty. </exception>
    public virtual ClientResult<EmbeddingCollection> GenerateEmbeddings(IEnumerable<string> inputs, EmbeddingOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(inputs, nameof(inputs));

        options ??= new();
        CreateEmbeddingOptions(BinaryData.FromObjectAsJson(inputs), ref options);

        using BinaryContent content = options.ToBinaryBody();
        ClientResult result = GenerateEmbedding(content, DefaultRequestContext);
        return ClientResult.FromValue(EmbeddingCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    // CUSTOM: Added to simplify passing the input as a collection of a collection of tokens instead of BinaryData.
    /// <summary> Creates an embedding vector representing the input text. </summary>
    /// <param name="inputs"> The strings that will be turned into embeddings. </param>
    /// <param name="options"> The <see cref="EmbeddingOptions"/> to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="inputs"/> is an empty collection, and was expected to be non-empty. </exception>
    public virtual async Task<ClientResult<EmbeddingCollection>> GenerateEmbeddingsAsync(IEnumerable<IEnumerable<int>> inputs, EmbeddingOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(inputs, nameof(inputs));

        options ??= new();
        CreateEmbeddingOptions(BinaryData.FromObjectAsJson(inputs), ref options);

        using BinaryContent content = options.ToBinaryBody();
        ClientResult result = await GenerateEmbeddingAsync(content, DefaultRequestContext).ConfigureAwait(false);
        return ClientResult.FromValue(EmbeddingCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    // CUSTOM: Added to simplify passing the input as a collection of a collection of tokens instead of BinaryData.
    /// <summary> Creates an embedding vector representing the input text. </summary>
    /// <param name="inputs"> The strings that will be turned into embeddings. </param>
    /// <param name="options"> The <see cref="EmbeddingOptions"/> to use. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="inputs"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="inputs"/> is an empty collection, and was expected to be non-empty. </exception>
    public virtual ClientResult<EmbeddingCollection> GenerateEmbeddings(IEnumerable<IEnumerable<int>> inputs, EmbeddingOptions options = null)
    {
        Argument.AssertNotNullOrEmpty(inputs, nameof(inputs));

        options ??= new();
        CreateEmbeddingOptions(BinaryData.FromObjectAsJson(inputs), ref options);

        using BinaryContent content = options.ToBinaryBody();
        ClientResult result = GenerateEmbedding(content, DefaultRequestContext);
        return ClientResult.FromValue(EmbeddingCollection.FromResponse(result.GetRawResponse()), result.GetRawResponse());
    }

    private void CreateEmbeddingOptions(BinaryData input, ref EmbeddingOptions options)
    {
        options ??= new();
        options.Input = input;
        options.Model = _model;
        options.EncodingFormat = EmbeddingOptionsEncodingFormat.Base64;
    }
}
