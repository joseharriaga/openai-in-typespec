// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace OpenAI.Models
{
    public partial class OpenAIModelClient
    {
        private readonly Uri _endpoint;
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";

        protected OpenAIModelClient()
        {
        }

        public ClientPipeline Pipeline { get; }

        public virtual ClientResult ListModels(RequestOptions options)
        {
            using PipelineMessage message = CreateListModelsRequest(options);
            return ClientResult.FromResponse(Pipeline.ProcessMessage(message, options));
        }

        public virtual async Task<ClientResult> ListModelsAsync(RequestOptions options)
        {
            using PipelineMessage message = CreateListModelsRequest(options);
            return ClientResult.FromResponse(await Pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }

        public virtual ClientResult<OpenAIModelCollection> ListModels()
        {
            ClientResult result = ListModels(null);
            return ClientResult.FromValue((OpenAIModelCollection)result, result.GetRawResponse());
        }

        public virtual async Task<ClientResult<OpenAIModelCollection>> ListModelsAsync()
        {
            ClientResult result = await ListModelsAsync(null).ConfigureAwait(false);
            return ClientResult.FromValue((OpenAIModelCollection)result, result.GetRawResponse());
        }
    }
}
