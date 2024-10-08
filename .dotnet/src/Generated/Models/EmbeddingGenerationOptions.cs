// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Embeddings
{
    public partial class EmbeddingGenerationOptions
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal EmbeddingGenerationOptions(int? dimensions, BinaryData input, InternalCreateEmbeddingRequestModel model, Embeddings.OpenAI.Embeddings.InternalCreateEmbeddingRequestEncodingFormat<InternalCreateEmbeddingRequestEncodingFormat>? encodingFormat, string endUserId, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Dimensions = dimensions;
            Input = input;
            Model = model;
            EncodingFormat = encodingFormat;
            EndUserId = endUserId;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public int? Dimensions { get; set; }
    }
}
