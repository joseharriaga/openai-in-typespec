using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace OpenAI.Embeddings;

[CodeGenSuppress("CreateEmbeddingAsync", typeof(BinaryContent), typeof(RequestOptions))]
[CodeGenSuppress("CreateEmbedding", typeof(BinaryContent), typeof(RequestOptions))]
public partial class EmbeddingClient
{
    protected internal static RequestOptions DefaultRequestContext = new RequestOptions();

    // CUSTOM:
    // - Renamed.
    // - Edited the cref in the doc comment to point to the correct convenience overload after it was also renamed.
    // - Added the EditorBrowsable attribute to hide protocol methods from IntelliSense when a convenience overload is available.
    /// <summary>
    /// [Protocol Method] Creates an embedding vector representing the input text.
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Please try the simpler <see cref="GenerateEmbeddings(IEnumerable{string}, EmbeddingOptions)"/> convenience overload with strongly typed models first.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> GenerateEmbeddingAsync(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateEmbeddingRequest(content, options);
        return ClientResult.FromResponse(await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
    }

    // CUSTOM:
    // - Renamed.
    // - Edited the cref in the doc comment to point to the correct convenience overload after it was also renamed.
    // - Added the EditorBrowsable attribute to hide protocol methods from IntelliSense when a convenience overload is available.
    /// <summary>
    /// [Protocol Method] Creates an embedding vector representing the input text.
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Please try the simpler <see cref="GenerateEmbeddingsAsync(IEnumerable{string}, EmbeddingOptions)"/> convenience overload with strongly typed models first.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult GenerateEmbedding(BinaryContent content, RequestOptions options = null)
    {
        Argument.AssertNotNull(content, nameof(content));

        using PipelineMessage message = CreateCreateEmbeddingRequest(content, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }
}