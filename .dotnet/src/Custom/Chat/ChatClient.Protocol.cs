using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.Chat;

/// <summary> The service client for the OpenAI Chat Completions endpoint. </summary>
public partial class ChatClient
{
    /// <inheritdoc cref="Internal.Chat.CreateChatCompletion(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult CompleteChat(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateChatCompletionPipelineMessage(content, options);
        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="Internal.Chat.CreateChatCompletionAsync(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> CompleteChatAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateChatCompletionPipelineMessage(content, options);
        PipelineResponse response = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    /// <inheritdoc cref="Internal.Chat.CreateChatCompletion(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult CompleteChatStreaming(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateChatCompletionPipelineMessage(content, options);
        message.BufferResponse = false;
        _ = Pipeline.ProcessMessage(message, options);
        return ClientResult.FromResponse(message.ExtractResponse());
    }

    /// <inheritdoc cref="Internal.Chat.CreateChatCompletionAsync(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> CompleteChatStreamingAsync(BinaryContent content, RequestOptions options = null)
    {
        using PipelineMessage message = CreateChatCompletionPipelineMessage(content, options);
        message.BufferResponse = false;
        _ = await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(message.ExtractResponse());
    }
}
