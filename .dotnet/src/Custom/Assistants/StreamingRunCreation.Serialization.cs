namespace OpenAI.Assistants;

using System.ClientModel.Primitives;
using System.Text.Json;

public partial class StreamingRunCreation
{
    internal static StreamingUpdate DeserializeStreamingRunCreation(JsonElement element, ModelReaderWriterOptions options = null)
    {
        Internal.Models.RunObject internalRun = Internal.Models.RunObject.DeserializeRunObject(element, options);
        ThreadRun run = new(internalRun);
        return new StreamingRunCreation(run);
    }
}
