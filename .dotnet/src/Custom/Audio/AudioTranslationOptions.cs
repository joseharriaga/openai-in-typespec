using OpenAI.Internal;
using System;

namespace OpenAI.Audio;

public partial class AudioTranslationOptions
{
    public string Prompt { get; set;  }
    public AudioTranscriptionFormat? ResponseFormat { get; set; }
    public float? Temperature { get; set; }

    internal MultipartFormDataBinaryContent ToMultipartContent(BinaryData audioBytes, string filename, string model)
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(audioBytes, "file", filename);
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
                AudioTranscriptionFormat.Detailed => "verbose_json",
                AudioTranscriptionFormat.Srt => "srt",
                AudioTranscriptionFormat.Vtt => "vtt",
                _ => throw new ArgumentException(nameof(ResponseFormat))
            };

            content.Add(value, "response_format");
        }

        return content;
    }
}