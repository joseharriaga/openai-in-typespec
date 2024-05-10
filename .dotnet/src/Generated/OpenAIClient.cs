// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Batch;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Images;
using OpenAI.LegacyCompletions;
using OpenAI.Models;
using OpenAI.Moderations;
using OpenAI.VectorStores;

namespace OpenAI
{
    // Data plane generated client.
    /// <summary> The OpenAI service client. </summary>
    public partial class OpenAIClient
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of OpenAIClient for mocking. </summary>
        protected OpenAIClient()
        {
        }
        private OpenAI.Internal.AssistantClient _cachedAssistantClient;
        private OpenAI.Internal.Chat _cachedChat;
        private OpenAI.Internal.InternalAssistantMessageClient _cachedInternalAssistantMessageClient;
        private OpenAI.Internal.InternalAssistantRunClient _cachedInternalAssistantRunClient;
        private OpenAI.Internal.InternalAssistantThreadClient _cachedInternalAssistantThreadClient;

        /// <summary> Initializes a new instance of AssistantClient. </summary>
        internal OpenAI.Internal.AssistantClient GetAssistantClientClient()
        {
            return Volatile.Read(ref _cachedAssistantClient) ?? Interlocked.CompareExchange(ref _cachedAssistantClient, new OpenAI.Internal.AssistantClient(_pipeline, _keyCredential, _endpoint), null) ?? _cachedAssistantClient;
        }

        /// <summary> Initializes a new instance of InternalAssistantMessageClient. </summary>
        internal OpenAI.Internal.InternalAssistantMessageClient GetInternalAssistantMessageClientClient()
        {
            return Volatile.Read(ref _cachedInternalAssistantMessageClient) ?? Interlocked.CompareExchange(ref _cachedInternalAssistantMessageClient, new OpenAI.Internal.InternalAssistantMessageClient(_pipeline, _keyCredential, _endpoint), null) ?? _cachedInternalAssistantMessageClient;
        }

        /// <summary> Initializes a new instance of InternalAssistantRunClient. </summary>
        internal OpenAI.Internal.InternalAssistantRunClient GetInternalAssistantRunClientClient()
        {
            return Volatile.Read(ref _cachedInternalAssistantRunClient) ?? Interlocked.CompareExchange(ref _cachedInternalAssistantRunClient, new OpenAI.Internal.InternalAssistantRunClient(_pipeline, _keyCredential, _endpoint), null) ?? _cachedInternalAssistantRunClient;
        }

        /// <summary> Initializes a new instance of InternalAssistantThreadClient. </summary>
        internal OpenAI.Internal.InternalAssistantThreadClient GetInternalAssistantThreadClientClient()
        {
            return Volatile.Read(ref _cachedInternalAssistantThreadClient) ?? Interlocked.CompareExchange(ref _cachedInternalAssistantThreadClient, new OpenAI.Internal.InternalAssistantThreadClient(_pipeline, _keyCredential, _endpoint), null) ?? _cachedInternalAssistantThreadClient;
        }
    }
}
