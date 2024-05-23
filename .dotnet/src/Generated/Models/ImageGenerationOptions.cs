// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Images
{
    /// <summary> The CreateImageRequest. </summary>
    public partial class ImageGenerationOptions
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ImageGenerationOptions"/>. </summary>
        /// <param name="prompt"> A text description of the desired image(s). The maximum length is 1000 characters for `dall-e-2` and 4000 characters for `dall-e-3`. </param>
        /// <param name="model"> The model to use for image generation. </param>
        /// <param name="n"> The number of images to generate. Must be between 1 and 10. For `dall-e-3`, only `n=1` is supported. </param>
        /// <param name="quality"> The quality of the image that will be generated. `hd` creates images with finer details and greater consistency across the image. This param is only supported for `dall-e-3`. </param>
        /// <param name="responseFormat"> The format in which the generated images are returned. Must be one of `url` or `b64_json`. URLs are only valid for 60 minutes after the image has been generated. </param>
        /// <param name="size"> The size of the generated images. Must be one of `256x256`, `512x512`, or `1024x1024` for `dall-e-2`. Must be one of `1024x1024`, `1792x1024`, or `1024x1792` for `dall-e-3` models. </param>
        /// <param name="style"> The style of the generated images. Must be one of `vivid` or `natural`. Vivid causes the model to lean towards generating hyper-real and dramatic images. Natural causes the model to produce more natural, less hyper-real looking images. This param is only supported for `dall-e-3`. </param>
        /// <param name="user"> A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. [Learn more](/docs/guides/safety-best-practices/end-user-ids). </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ImageGenerationOptions(string prompt, InternalCreateImageRequestModel? model, long? n, GeneratedImageQuality? quality, GeneratedImageFormat? responseFormat, GeneratedImageSize? size, GeneratedImageStyle? style, string user, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Prompt = prompt;
            Model = model;
            N = n;
            Quality = quality;
            ResponseFormat = responseFormat;
            Size = size;
            Style = style;
            User = user;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
        /// <summary> The quality of the image that will be generated. `hd` creates images with finer details and greater consistency across the image. This param is only supported for `dall-e-3`. </summary>
        public GeneratedImageQuality? Quality { get; init; }
        /// <summary> The format in which the generated images are returned. Must be one of `url` or `b64_json`. URLs are only valid for 60 minutes after the image has been generated. </summary>
        public GeneratedImageFormat? ResponseFormat { get; init; }
        /// <summary> The size of the generated images. Must be one of `256x256`, `512x512`, or `1024x1024` for `dall-e-2`. Must be one of `1024x1024`, `1792x1024`, or `1024x1792` for `dall-e-3` models. </summary>
        public GeneratedImageSize? Size { get; init; }
        /// <summary> The style of the generated images. Must be one of `vivid` or `natural`. Vivid causes the model to lean towards generating hyper-real and dramatic images. Natural causes the model to produce more natural, less hyper-real looking images. This param is only supported for `dall-e-3`. </summary>
        public GeneratedImageStyle? Style { get; init; }
        /// <summary> A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. [Learn more](/docs/guides/safety-best-practices/end-user-ids). </summary>
        public string User { get; init; }
    }
}
