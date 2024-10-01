// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Images;
using OpenAI.LegacyCompletions;
using OpenAI.Models;
using OpenAI.Moderations;
using OpenAI.RealtimeConversation;
using OpenAI.VectorStores;

namespace OpenAI
{
    // Data plane generated client.
    public partial class OpenAIClient
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        protected OpenAIClient()
        {
        }
    }
}
