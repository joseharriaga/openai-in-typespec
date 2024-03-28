using System;

namespace OpenAI.Files;

public partial class OpenAIFileInfo
{
    public string Id { get; }
    public OpenAIFilePurpose Purpose { get; }
    public string Filename { get; }
    public long? Size { get; }
    public DateTimeOffset CreatedAt { get; }

    internal OpenAIFileInfo(Internal.Models.OpenAIFile internalFile)
    {
        Id = internalFile.Id;
        Purpose = internalFile.Purpose.ToString() switch
        {
            "assistants" => OpenAIFilePurpose.Assistants,
            "assistants_output" => OpenAIFilePurpose.AssistantOutputs,
            "batch" => OpenAIFilePurpose.BatchInput,
            "batch_output" => OpenAIFilePurpose.BatchOutput,
            "fine-tune" => OpenAIFilePurpose.FineTuning,
            "fine-tune-results" => OpenAIFilePurpose.FineTuningResults,
            _ => throw new ArgumentException(nameof(internalFile)),
        };
        Filename = internalFile.Filename;
        Size = internalFile.Bytes;
        CreatedAt = internalFile.CreatedAt;
    }
}

public enum OpenAIFilePurpose
{
    Assistants,
    AssistantOutputs,
    BatchInput,
    BatchOutput,
    FineTuning,
    FineTuningResults,
}