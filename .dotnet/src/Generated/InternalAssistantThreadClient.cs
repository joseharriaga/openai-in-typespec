// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;

namespace OpenAI.Assistants
{
    internal partial class InternalAssistantThreadClient
    {
        private readonly Uri _endpoint;

        protected InternalAssistantThreadClient()
        {
        }

        internal InternalAssistantThreadClient(ClientPipeline pipeline, Uri endpoint)
        {
            _endpoint = endpoint;
            Pipeline = pipeline;
        }

        public ClientPipeline Pipeline { get; }
    }
}
