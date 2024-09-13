namespace OpenAI.Assistants;

[CodeGenModel("DeleteAssistantResponse")]
public partial class DeleteAssistantResult
{
    // CUSTOM: Made internal.
    /// <summary> The object type, which is always `assistant.deleted`. </summary>
    [CodeGenMember("Object")]
    internal InternalDeleteAssistantResponseObject Object { get; } = InternalDeleteAssistantResponseObject.AssistantDeleted;
}
