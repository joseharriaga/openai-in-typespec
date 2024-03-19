namespace OpenAI.Assistants;

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

public partial class StreamingRunCreation
{
    internal static StreamingRunUpdate DeserializeStreamingRunCreation(JsonElement element, ModelReaderWriterOptions options = null)
    {
        Internal.Models.RunObject internalRun = Internal.Models.RunObject.DeserializeRunObject(element, options);
        ThreadRun run = new(internalRun);
        return new StreamingRunCreation(run);
    }
}
