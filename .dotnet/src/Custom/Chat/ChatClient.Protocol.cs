using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace OpenAI.Chat;

/// <summary> The service client for the OpenAI Chat Completions endpoint. </summary>
public partial class ChatClient
{
    public virtual ClientResult CompleteChat(BinaryContent content, RequestOptions options = null)
        => Shim.CreateChatCompletion(content, options);

    public virtual async Task<ClientResult> CompleteChatAsync(BinaryContent content, RequestOptions options = null)
        => await Shim.CreateChatCompletionAsync(content, options).ConfigureAwait(false);
}
