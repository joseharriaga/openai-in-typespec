// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Images
{
    /// <summary> The CreateImageEditRequest. </summary>
    public partial class ImageEditOptions
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
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ImageEditOptions"/>. </summary>
        /// <param name="image">
        /// The image to edit. Must be a valid PNG file, less than 4MB, and square. If mask is not
        /// provided, image must have transparency, which will be used as the mask.
        /// </param>
        /// <param name="prompt"> A text description of the desired image(s). The maximum length is 1000 characters. </param>
        /// <param name="mask">
        /// An additional image whose fully transparent areas (e.g. where alpha is zero) indicate where
        /// `image` should be edited. Must be a valid PNG file, less than 4MB, and have the same
        /// dimensions as `image`.
        /// </param>
        /// <param name="model"> The model to use for image generation. Only `dall-e-2` is supported at this time. </param>
        /// <param name="n"> The number of images to generate. Must be between 1 and 10. </param>
        /// <param name="size"> The size of the generated images. Must be one of `256x256`, `512x512`, or `1024x1024`. </param>
        /// <param name="responseFormat">
        /// The format in which the generated images are returned. Must be one of `url` or `b64_json`.
        /// URLs are only valid for 60 minutes after the image has been generated.
        /// </param>
        /// <param name="user">
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect
        /// abuse. [Learn more](/docs/guides/safety-best-practices/end-user-ids).
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ImageEditOptions(BinaryData image, string prompt, BinaryData mask, CreateImageEditRequestModel? model, long? n, GeneratedImageSize? size, GeneratedImageFormat? responseFormat, string user, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Image = image;
            Prompt = prompt;
            Mask = mask;
            Model = model;
            N = n;
            Size = size;
            ResponseFormat = responseFormat;
            User = user;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect
        /// abuse. [Learn more](/docs/guides/safety-best-practices/end-user-ids).
        /// </summary>
        public string User { get; set; }
    }
}
