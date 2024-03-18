namespace OpenAI.Assistants;

using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class StreamingMessageCompletion : StreamingRunUpdate
{
    public ThreadMessage Message { get; }

    internal StreamingMessageCompletion(ThreadMessage message)
    {
        Message = message;
    }
}
