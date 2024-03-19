using OpenAI.Internal;
using OpenAI.Internal.Models;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI.Audio;

public partial class AudioTranscriptionOptions
{
    public string Language { get; set; }
    public string Prompt { get; set;  }
    public AudioTranscriptionFormat? ResponseFormat { get; set; }
    public float? Temperature { get; set; }
    public bool? EnableWordTimestamps { get; set; }
    public bool? EnableSegmentTimestamps { get; set; }

    internal MultipartFormDataBinaryContent ToMultipartContent(BinaryData audioBytes, string filename, string model)
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(audioBytes, "file", filename);
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
                AudioTranscriptionFormat.Detailed => "verbose_json",
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

        return content;
    }
}
