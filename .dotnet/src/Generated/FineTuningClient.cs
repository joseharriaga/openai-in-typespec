// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;

namespace OpenAI.FineTuning
{
    public partial class FineTuningClient
    {
        private readonly Uri _endpoint;

        protected FineTuningClient()
        {
        }

        internal FineTuningClient(ClientPipeline pipeline, Uri endpoint)
        {
            _endpoint = endpoint;
            Pipeline = pipeline;
        }

        public ClientPipeline Pipeline { get; }
    }
}
