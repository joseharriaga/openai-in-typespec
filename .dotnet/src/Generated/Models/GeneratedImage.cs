// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Images
{
    public partial class GeneratedImage
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        internal GeneratedImage()
        {
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal GeneratedImage(BinaryData imageBytes, Uri imageUri, string revisedPrompt, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ImageBytes = imageBytes;
            ImageUri = imageUri;
            RevisedPrompt = revisedPrompt;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }
        public string RevisedPrompt { get; }
    }
}
