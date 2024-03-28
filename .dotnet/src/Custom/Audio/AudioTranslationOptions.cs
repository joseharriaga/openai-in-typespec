using OpenAI.Internal;
using System;
using System.IO;

namespace OpenAI.Audio;

public partial class AudioTranslationOptions
{
    public string Prompt { get; set;  }
    public AudioTranscriptionFormat? ResponseFormat { get; set; }
    public float? Temperature { get; set; }

    internal MultipartFormDataBinaryContent ToMultipartContent(Stream file, string fileName, string model)
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(file, "file", fileName);
        content.Add(model, "model");

        if (Prompt is not null)
        {
            content.Add(Prompt, "prompt");
        }

        if (ResponseFormat is not null)
        {
            string value = ResponseFormat switch
            {
                AudioTranscriptionFormat.Simple => "json",
                AudioTranscriptionFormat.Verbose => "verbose_json",
                AudioTranscriptionFormat.Srt => "srt",
                AudioTranscriptionFormat.Vtt => "vtt",
                _ => throw new ArgumentException(nameof(ResponseFormat))
            };

            content.Add(value, "response_format");
        }

        return content;
    }
}