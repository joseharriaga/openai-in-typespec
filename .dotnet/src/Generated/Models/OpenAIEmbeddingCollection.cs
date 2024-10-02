// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Embeddings
{
    public partial class OpenAIEmbeddingCollection
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal OpenAIEmbeddingCollection(string model, EmbeddingTokenUsage usage, InternalCreateEmbeddingResponseObject @object)
        {
            Model = model;
            Usage = usage;
            Object = @object;
        }

        internal OpenAIEmbeddingCollection(string model, EmbeddingTokenUsage usage, InternalCreateEmbeddingResponseObject @object, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Model = model;
            Usage = usage;
            Object = @object;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Model { get; set; }

        public EmbeddingTokenUsage Usage { get; set; }
    }
}
