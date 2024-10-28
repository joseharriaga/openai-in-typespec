﻿using System;
using System.ClientModel.Primitives.TwoWayClient;
using System.Collections.Generic;
using System.Text;

#nullable enable

namespace OpenAI.RealtimeConversation;

public class AssistantConversationOptions : TwoWayPipelineOptions
{
    public ConversationSessionOptions? ConversationOptions { get; set; }
}
