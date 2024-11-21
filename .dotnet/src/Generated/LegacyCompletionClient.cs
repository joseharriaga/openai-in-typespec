// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;

namespace OpenAI.LegacyCompletions
{
    internal partial class LegacyCompletionClient
    {
        private readonly Uri _endpoint;
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";

        protected LegacyCompletionClient()
        {
        }

        public ClientPipeline Pipeline { get; }

        public virtual ClientResult CreateCompletion(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateCompletionRequest(content, options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }

        public virtual async Task<ClientResult> CreateCompletionAsync(BinaryContent content, RequestOptions options = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using PipelineMessage message = CreateCreateCompletionRequest(content, options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        public virtual ClientResult<InternalCreateCompletionResponse> CreateCompletion(InternalCreateCompletionRequest requestBody)
        {
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            ClientResult result = CreateCompletion(requestBody, options: null);
            return ClientResult.FromValue((InternalCreateCompletionResponse)result, result.GetRawResponse());
        }

        public virtual async Task<ClientResult<InternalCreateCompletionResponse>> CreateCompletionAsync(InternalCreateCompletionRequest requestBody, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(requestBody, nameof(requestBody));

            ClientResult result = await CreateCompletionAsync(requestBody, cancellationToken.CanBeCanceled ? new RequestOptions { CancellationToken = cancellationToken } : null).ConfigureAwait(false);
            return ClientResult.FromValue((InternalCreateCompletionResponse)result, result.GetRawResponse());
        }
    }
}
