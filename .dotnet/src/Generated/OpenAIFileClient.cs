// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.Files
{
    public partial class OpenAIFileClient
    {
        private readonly Uri _endpoint;
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";

        protected OpenAIFileClient()
        {
        }

        public ClientPipeline Pipeline { get; }
    }
}
