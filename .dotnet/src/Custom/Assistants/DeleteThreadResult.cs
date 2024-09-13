namespace OpenAI.Assistants;

[CodeGenModel("DeleteThreadResponse")]
public partial class DeleteThreadResult
{
    // CUSTOM: Made internal.
    /// <summary> The object type, which is always `thread.deleted`. </summary>
    [CodeGenMember("Object")]
    internal InternalDeleteThreadResponseObject Object { get; } = InternalDeleteThreadResponseObject.ThreadDeleted;
}
