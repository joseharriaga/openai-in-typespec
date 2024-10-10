using OpenAI.Chat;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.RealtimeConversation;

internal partial class ClientWebSocketPipelineTransport : PipelineTransport
{
    private readonly ClientWebSocket _clientWebSocket;

    protected override PipelineMessage CreateMessageCore()
    {
        throw new NotImplementedException();
    }

    protected override void ProcessCore(PipelineMessage message)
    {
        throw new NotImplementedException();
    }

    protected override ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        throw new NotImplementedException();
    }
}