namespace OpenAI.Files;

[CodeGenModel("OpenAIFile")]
public partial class OpenAIFileInfo
{
    // CUSTOM: Made private. This property does not add value in the context of a strongly-typed class.
    /// <summary> The object type, which is always "file". </summary>
    private OpenAIFileObject Object { get; } = OpenAIFileObject.File;

    // CUSTOM: Renamed.
    /// <summary> The size of the file, in bytes. </summary>
    [CodeGenMember("Bytes")]
    public long? SizeInBytes { get; }
}
