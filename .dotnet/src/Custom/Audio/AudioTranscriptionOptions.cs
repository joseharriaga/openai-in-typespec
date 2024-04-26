using OpenAI.Internal;
using System;
using System.IO;

namespace OpenAI.Audio;

public partial class AudioTranscriptionOptions
{
    public string Language { get; init; }
    public string Prompt { get; init; }
    public AudioTranscriptionFormat? ResponseFormat { get; init; }
    public float? Temperature { get; init; }
    public AudioTimestampGranularity TimestampGranularityFlags { get; init; }

    internal MultipartFormDataBinaryContent ToMultipartContent(Stream file, string fileName, string model)
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(file, "file", fileName);
        content.Add(model, "model");

        if (Language is not null)
        {
            content.Add(Language, "language");
        }

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

        if (Temperature is not null)
        {
            content.Add(Temperature.Value, "temperature");
        }

        if (TimestampGranularityFlags.HasFlag(AudioTimestampGranularity.Word))
        {
            content.Add("word", "timestamp_granularities[]");
        }

        if (TimestampGranularityFlags.HasFlag(AudioTimestampGranularity.Segment))
        {
            content.Add("segment", "timestamp_granularities[]");
        }

        return content;
    }
}
