// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;

namespace OpenAI.Embeddings
{
    public partial class EmbeddingClient
    {
        private readonly Uri _endpoint;

        protected EmbeddingClient()
        {
        }

        internal EmbeddingClient(ClientPipeline pipeline, Uri endpoint)
        {
            _endpoint = endpoint;
            Pipeline = pipeline;
        }

        public ClientPipeline Pipeline { get; }
    }
}
