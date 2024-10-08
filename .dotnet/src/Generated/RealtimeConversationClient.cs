// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using OpenAI;

namespace OpenAI.RealtimeConversation
{
    public partial class RealtimeConversationClient
    {
        private readonly Uri _endpoint;
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";

        protected RealtimeConversationClient()
        {
        }

        internal RealtimeConversationClient(ClientPipeline pipeline, ApiKeyCredential keyCredential, Uri endpoint)
        {
            _endpoint = endpoint;
            Pipeline = pipeline;
            _keyCredential = keyCredential;
        }

        public ClientPipeline Pipeline { get; }

        public virtual ClientResult<IList<ConversationUpdate>> StartRealtimeSession(IList<InternalRealtimeRequestCommand> requestMessages)
        {
            Argument.AssertNotNull(requestMessages, nameof(requestMessages));

            using BinaryContent content = BinaryContentHelper.FromEnumerable(requestMessages);
            ClientResult result = this.StartRealtimeSession(content, null);
            IList<ConversationUpdate> value = new List<ConversationUpdate>();
            using JsonDocument document = JsonDocument.Parse(result.GetRawResponse().ContentStream);
            foreach (var item in document.RootElement.EnumerateArray())
            {
                value.Add(ConversationUpdate.DeserializeConversationUpdate(item, ModelSerializationExtensions.WireOptions));
            }
            return ClientResult.FromValue(value, result.GetRawResponse());
        }

        public virtual async Task<ClientResult<IList<ConversationUpdate>>> StartRealtimeSessionAsync(IList<InternalRealtimeRequestCommand> requestMessages)
        {
            Argument.AssertNotNull(requestMessages, nameof(requestMessages));

            using BinaryContent content = BinaryContentHelper.FromEnumerable(requestMessages);
            ClientResult result = await this.StartRealtimeSessionAsync(content, null).ConfigureAwait(false);
            IList<ConversationUpdate> value = new List<ConversationUpdate>();
            using JsonDocument document = await JsonDocument.ParseAsync(result.GetRawResponse().ContentStream, default, default).ConfigureAwait(false);
            foreach (var item in document.RootElement.EnumerateArray())
            {
                value.Add(ConversationUpdate.DeserializeConversationUpdate(item, ModelSerializationExtensions.WireOptions));
            }
            return ClientResult.FromValue(value, result.GetRawResponse());
        }
    }
}
