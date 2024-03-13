using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.Audio;

public partial class AudioTranscriptionOptions
{
    public string Language { get; set; }
    public string Prompt { get; set;  }
    public AudioTranscriptionFormat? ResponseFormat { get; set; }
    public float? Temperature { get; set; }
    public bool? EnableWordTimestamps { get; set; }
    public bool? EnableSegmentTimestamps { get; set; }

    // content-creation helper for TranscribeAudio convenience method
    internal async Task<(BinaryContent, RequestOptions)> CreateContentAsync(
        BinaryData audioBytes,
        string filename,
        string model)
    {
        // TODO: add boundary
        MultipartFormDataContent content = new();

        // file
        // TODO: Better to take the stream as an input parameter?
        // TODO: if we need to use BinaryData, is it better to call ToArray/ToStream/other for perf?

        // TODO: I think we need to add the content header manually because the
        // default implementation is adding a `filename*` parameter to the header,
        // which RFC 7578 says not to do -- I am following up with the BCL team
        // on this to learn more about when this is/isn't needed.
        HttpContent audioContent = new ByteArrayContent(audioBytes.ToArray());
        ContentDispositionHeaderValue header = new ContentDispositionHeaderValue("form-data")
        {
            Name = "file",
            FileName = filename
        };
        audioContent.Headers.ContentDisposition = header;
        content.Add(audioContent);

        // model
        content.Add(new StringContent(model), name: "model");

        // language - optional
        if (Language is not null)
        {
            content.Add(new StringContent(Language), name: "language");
        }

        // prompt - optional
        if (Prompt is not null)
        {
            content.Add(new StringContent(Prompt), name: "prompt");
        }

        // response_format - optional
        if (ResponseFormat is not null)
        {
            // TODO: another way to represent this in the model/enum?
            content.Add(new StringContent(ResponseFormat switch
            {
                AudioTranscriptionFormat.Simple => "json",
                AudioTranscriptionFormat.Detailed => "verbose_json",
                AudioTranscriptionFormat.Srt => "srt",
                AudioTranscriptionFormat.Vtt => "vtt",
                _ => throw new ArgumentException(nameof(ResponseFormat)),
            }),
            name: "response_format");
        }

        // temperature - optional
        if (Temperature is not null)
        {
            // TODO: preferred way to handle floats/numerics?
            content.Add(new StringContent($"{Temperature}"), name: "temperature");
        }

        // timestamp_granularities[] - optional
        if (EnableWordTimestamps is not null ||
            (EnableSegmentTimestamps is not null))
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

            // TODO: preferred way to serialize models?
            byte[] data = JsonSerializer.SerializeToUtf8Bytes(granularities);
            content.Add(new ByteArrayContent(data), name: "timestamp_granularities");
        }

        // multipart/form-data operations must transfer the headers from the
        // MultipartFormDataContent instance over to the request, using RequestOptions.
        RequestOptions requestOptions = new();

        // TODO: can we improve perf when transferring headers?
        if (content.Headers.ContentType is MediaTypeHeaderValue contentType)
        {
            requestOptions.SetHeader("Content-Type", contentType.ToString());
        }

        if (content.Headers.ContentLength is long contentLength)
        {
            requestOptions.SetHeader("Content-Length", contentLength.ToString());
        }

        Stream stream = await content.ReadAsStreamAsync().ConfigureAwait(false);

        return (BinaryContent.Create(stream), requestOptions);
    }
}