using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

[CodeGenModel("CreateMessageRequestAttachment")]
[CodeGenSerialization(nameof(Tools), "tools", SerializationValueHook = nameof(SerializeTools), DeserializationValueHook = nameof(DeserializeTools))]
public partial class MessageCreationAttachment
{
    /// <summary>
    /// The tools to which the attachment applies to.
    /// </summary>
    /// <remarks>
    /// These are <see cref="AssistantTool"/> instances that can be checked via downcast, e.g.:
    /// <code>
    /// if (message.Attachments[0].Tools[0] is <see cref="CodeInterpreterTool"/>)
    /// {
    ///     // The attachment applies to the code interpreter tool
    /// }
    /// </code>
    /// </remarks>
    [CodeGenMember("Tools")]
    public IReadOnlyList<AssistantTool> Tools { get; } = new ChangeTrackingList<AssistantTool>();

    private void SerializeTools(Utf8JsonWriter writer)
        => writer.WriteObjectValue(Tools);

    private static void DeserializeTools(JsonProperty property, ref IReadOnlyList<AssistantTool> tools)
    {
        if (property.Value.ValueKind == JsonValueKind.Null)
        {
            tools = null;
        }
        else
        {
            List<AssistantTool> deserializedTools = [];
            foreach (JsonElement toolElement in property.Value.EnumerateArray())
            {
                deserializedTools.Add(AssistantTool.DeserializeAssistantTool(toolElement));
            }
            tools = deserializedTools;
        }
    }
}