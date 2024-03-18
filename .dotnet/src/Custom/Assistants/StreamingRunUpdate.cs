namespace OpenAI.Assistants;

using System;
using System.Collections.Generic;
using System.Text.Json;

/// <summary>
/// Represents an incremental item of new data in a streaming response when running a thread with an assistant.
/// </summary>
public partial class StreamingRunUpdate
{
    private JsonElement _originalJson;
    public JsonElement GetRawSseEvent() => _originalJson;

    protected StreamingRunUpdate()
    {
    }
}
