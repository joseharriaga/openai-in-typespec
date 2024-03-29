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
        Purpose = internalFile.Purpose.ToString();
        Filename = internalFile.Filename;
        Size = internalFile.Bytes;
        CreatedAt = internalFile.CreatedAt;
    }
}
