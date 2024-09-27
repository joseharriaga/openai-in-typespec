using System;
using System.IO;

namespace OpenAI.Audio;

[CodeGenModel("CreateTranslationRequest")]
[CodeGenSuppress("AudioTranslationOptions", typeof(BinaryData), typeof(InternalCreateTranslationRequestModel))]
public partial class AudioTranslationOptions
{
    // CUSTOM: Made internal. This value comes from a parameter on the client method.
    internal BinaryData File { get; }

    // CUSTOM:
    // - Made internal. The model is specified by the client.
    // - Added setter.
    internal InternalCreateTranslationRequestModel Model { get; set; }

    // CUSTOM: Made public now that there are no required properties.
    /// <summary> Initializes a new instance of <see cref="AudioTranslationOptions"/>. </summary>
    public AudioTranslationOptions()
    {
    }

    internal MultipartFormDataBinaryContent ToMultipartContent(Stream audio, string audioFilename)
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(audio, "file", audioFilename);
        content.Add(Model.ToString(), "model");

        if (Prompt is not null)
        {
            content.Add(Prompt, "prompt");
        }

        if (ResponseFormat is not null)
        {
            string value = ResponseFormat switch
            {
                AudioTranslationFormat.Simple => "json",
                AudioTranslationFormat.Verbose => "verbose_json",
                AudioTranslationFormat.Srt => "srt",
                AudioTranslationFormat.Vtt => "vtt",
                _ => throw new ArgumentException(nameof(ResponseFormat))
            };

            content.Add(value, "response_format");
        }

        return content;
    }
}