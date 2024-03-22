using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace OpenAI.LegacyCompletions;

public partial class LegacyCompletionClient
{
    /// <inheritdoc cref="Internal.Completions.CreateCompletion(BinaryContent, RequestOptions)"/>
    public virtual ClientResult GenerateLegacyCompletions(BinaryContent content, RequestOptions? options = default)
        => Shim.CreateCompletion(content, options);

    /// <inheritdoc cref="Internal.Completions.CreateCompletionAsync(BinaryContent, RequestOptions)"/>
    public virtual async Task<ClientResult> GenerateLegacyCompletionsAsync(BinaryContent content, RequestOptions? options = default)
        => await Shim.CreateCompletionAsync(content, options).ConfigureAwait(false);
}
