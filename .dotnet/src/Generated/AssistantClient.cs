// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;

namespace OpenAI.Assistants
{
    public partial class AssistantClient
    {
        private readonly Uri _endpoint;

        protected AssistantClient()
        {
        }

        internal AssistantClient(ClientPipeline pipeline, Uri endpoint)
        {
            _endpoint = endpoint;
            Pipeline = pipeline;
        }

        public ClientPipeline Pipeline { get; }
    }
}
