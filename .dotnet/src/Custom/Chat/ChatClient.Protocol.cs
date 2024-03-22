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
    public virtual ClientResult CompleteChat(BinaryContent content, RequestOptions? options = default)
        => Shim.CreateChatCompletion(content, options);

    /// <inheritdoc cref="Internal.Chat.CreateChatCompletionAsync(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> CompleteChatAsync(BinaryContent content, RequestOptions? options = default)
        => await Shim.CreateChatCompletionAsync(content, options).ConfigureAwait(false);

    private PipelineMessage CreateCustomRequestMessage(BinaryContent content, bool? stream = null, RequestOptions? options = default)
    {
        options ??= new();

        PipelineMessage message = Shim.Pipeline.CreateMessage();
        message.ResponseClassifier = PipelineMessageClassifiers.ResponseErrorClassifier200;
        if (stream is not null)
        {
            message.BufferResponse = !stream.Value;
        }
        PipelineRequest request = message.Request;
        request.Method = "POST";
        UriBuilder uriBuilder = new(_clientConnector.Endpoint.AbsoluteUri);
        StringBuilder path = new();
        path.Append("/chat/completions");
        uriBuilder.Path += path.ToString();
        request.Uri = uriBuilder.Uri;
        request.Headers.Set("Accept", "application/json");
        request.Headers.Set("Content-Type", "application/json");
        request.Content = content;

        message.Apply(options);
        return message;
    }
}
