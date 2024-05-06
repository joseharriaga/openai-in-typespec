namespace OpenAI.Files;

// CUSTOM: Renamed.
[CodeGenModel("OpenAIFileInfoPurpose")]
public readonly partial struct OpenAIFilePurpose
{
    // Customization: hand-added batch pending spec update
    private const string BatchValue = "batch";
    private const string BatchOutputValue = "batch_output";

    /// <summary>
    /// The purpose for files that are input into a batch operation.
    /// </summary>
    public static OpenAIFilePurpose BatchInput { get; } = new OpenAIFilePurpose(BatchValue);
    /// <summary>
    /// The purpose for files that are output from batch operations.
    /// </summary>
    public static OpenAIFilePurpose BatchOutput { get; } = new OpenAIFilePurpose(BatchOutputValue);
}