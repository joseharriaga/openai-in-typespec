using OpenAI.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace OpenAI.Audio;

public partial class AudioTranscriptionOptions
{
    public string Language { get; init; }
    public string Prompt { get; init; }
    public AudioTranscriptionFormat? ResponseFormat { get; init; }
    public float? Temperature { get; init; }
    public bool? EnableWordTimestamps { get; init; }
    public bool? EnableSegmentTimestamps { get; init; }

    internal MultipartFormDataBinaryContent ToMultipartContent(Stream fileStream, string fileName, string model)
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(fileStream, "file", fileName);

        AddContent(model, content);

        return content;
    }

    internal MultipartFormDataBinaryContent ToMultipartContent(BinaryData audioBytes, string fileName, string model)
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(audioBytes, "file", fileName);

        AddContent(model, content);

        return content;
    }

    private void AddContent(string model, MultipartFormDataBinaryContent content)
    {
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

        if (EnableWordTimestamps is not null || EnableSegmentTimestamps is not null)
        {
            List<string> granularities = [];
            if (EnableWordTimestamps.Value)
            {
                granularities.Add("word");
            }
            if (EnableSegmentTimestamps.Value)
            {
                granularities.Add("segment");
            }

            byte[] data = JsonSerializer.SerializeToUtf8Bytes(granularities);
            content.Add(data, "timestamp_granularities");
        }
    }
}
