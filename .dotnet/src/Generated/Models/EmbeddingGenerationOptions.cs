// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Embeddings
{
    public partial class EmbeddingGenerationOptions
    {
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal EmbeddingGenerationOptions(BinaryData input, InternalCreateEmbeddingRequestModel model, InternalEmbeddingGenerationOptionsEncodingFormat? encodingFormat, int? dimensions, string user, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Input = input;
            Model = model;
            EncodingFormat = encodingFormat;
            Dimensions = dimensions;
            User = user;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
        public int? Dimensions { get; set; }
        public string User { get; set; }
    }
}
