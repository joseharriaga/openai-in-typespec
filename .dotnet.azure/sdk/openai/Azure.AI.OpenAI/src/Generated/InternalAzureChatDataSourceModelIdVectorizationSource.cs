// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary>
    /// Represents a vectorization source that makes service calls based on a search service model ID.
    /// This source type is currently only supported by Elasticsearch.
    /// </summary>
    internal partial class InternalAzureChatDataSourceModelIdVectorizationSource : DataSourceVectorizer
    {
        /// <summary> Initializes a new instance of <see cref="InternalAzureChatDataSourceModelIdVectorizationSource"/>. </summary>
        /// <param name="modelId"> The embedding model build ID to use for vectorization. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        internal InternalAzureChatDataSourceModelIdVectorizationSource(string modelId)
        {
            Argument.AssertNotNull(modelId, nameof(modelId));

            Type = "model_id";
            ModelId = modelId;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureChatDataSourceModelIdVectorizationSource"/>. </summary>
        /// <param name="type"> The differentiating identifier for the concrete vectorization source. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="modelId"> The embedding model build ID to use for vectorization. </param>
        internal InternalAzureChatDataSourceModelIdVectorizationSource(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, string modelId) : base(type, serializedAdditionalRawData)
        {
            ModelId = modelId;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureChatDataSourceModelIdVectorizationSource"/> for deserialization. </summary>
        internal InternalAzureChatDataSourceModelIdVectorizationSource()
        {
        }

        /// <summary> The embedding model build ID to use for vectorization. </summary>
        internal string ModelId { get; set; }
    }
}



