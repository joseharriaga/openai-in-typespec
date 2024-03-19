namespace OpenAI.Assistants;

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

public partial class StreamingRequiredAction
{
    internal static IEnumerable<StreamingRequiredAction> DeserializeStreamingRequiredActions(JsonElement sseDataJson, ModelReaderWriterOptions options = null)
    {
        ThreadRun run = new(Internal.Models.RunObject.DeserializeRunObject(sseDataJson, options));
        List<StreamingRequiredAction> results = [];
        foreach (RunRequiredAction deserializedAction in run.RequiredActions)
        {
            results.Add(new(deserializedAction));
        }
        return results;
    }
}
