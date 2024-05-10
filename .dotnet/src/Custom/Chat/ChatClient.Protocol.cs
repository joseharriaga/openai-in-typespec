using System.ClientModel;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI.Chat;

/// <summary> The service client for the OpenAI Chat Completions endpoint. </summary>
public partial class ChatClient
{
    /// <inheritdoc cref="Internal.Chat.CreateChatCompletion(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual ClientResult CompleteChat(BinaryContent content, RequestOptions? options = null)
    {
        using PipelineMessage message = CreateChatCompletionPipelineMessage(content, options);

        Pipeline.Send(message);

        if (message.Response!.IsError && 
            (options?.ErrorOptions & ClientErrorBehaviors.NoThrow) != ClientErrorBehaviors.NoThrow)
        {
            throw new ClientResultException(message.Response);
        }

        PipelineResponse? response = message.BufferResponse ?
            message.Response : 
            message.ExtractResponse();

        return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
    }

    /// <inheritdoc cref="Internal.Chat.CreateChatCompletionAsync(BinaryContent, RequestOptions)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public virtual async Task<ClientResult> CompleteChatAsync(BinaryContent content, RequestOptions? options = null)
    {
        using PipelineMessage message = CreateChatCompletionPipelineMessage(content, options);
        await Pipeline.SendAsync(message).ConfigureAwait(false);

        if (message.Response!.IsError && 
            (options?.ErrorOptions & ClientErrorBehaviors.NoThrow) != ClientErrorBehaviors.NoThrow)
        {
            throw await ClientResultException.CreateAsync(message.Response).ConfigureAwait(false);
        }

        PipelineResponse? response = message.BufferResponse ?
            message.Response : 
            message.ExtractResponse();

        // TODO: with this factoring, we need to address how OAI is creating custom
        // exception messages.

        Debug.Assert(response is not null);

        ClientResult result = ClientResult.FromResponse(response!);
        return result;
    }
}
