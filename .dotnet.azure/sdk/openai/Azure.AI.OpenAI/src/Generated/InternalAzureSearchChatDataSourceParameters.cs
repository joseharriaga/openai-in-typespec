// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary> The AzureSearchChatDataSourceParameters. </summary>
    internal partial class InternalAzureSearchChatDataSourceParameters
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
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        /// <summary> Initializes a new instance of <see cref="InternalAzureSearchChatDataSourceParameters"/>. </summary>
        /// <param name="endpoint"></param>
        /// <param name="indexName"></param>
        /// <param name="authentication">
        /// Please note <see cref="DataSourceAuthentication"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="indexName"/> or <paramref name="authentication"/> is null. </exception>
        public InternalAzureSearchChatDataSourceParameters(Uri endpoint, string indexName, DataSourceAuthentication authentication)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(indexName, nameof(indexName));
            Argument.AssertNotNull(authentication, nameof(authentication));

            _internalIncludeContexts = new ChangeTrackingList<string>();
            Endpoint = endpoint;
            IndexName = indexName;
            Authentication = authentication;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureSearchChatDataSourceParameters"/>. </summary>
        /// <param name="topNDocuments"></param>
        /// <param name="inScope"></param>
        /// <param name="strictness"></param>
        /// <param name="maxSearchQueries"></param>
        /// <param name="allowPartialResult"></param>
        /// <param name="internalIncludeContexts"></param>
        /// <param name="endpoint"></param>
        /// <param name="indexName"></param>
        /// <param name="authentication">
        /// Please note <see cref="DataSourceAuthentication"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </param>
        /// <param name="fieldMappings"></param>
        /// <param name="queryType"></param>
        /// <param name="semanticConfiguration"></param>
        /// <param name="filter"></param>
        /// <param name="vectorizationSource">
        /// Please note <see cref="DataSourceVectorizer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalAzureSearchChatDataSourceParameters(int? topNDocuments, bool? inScope, int? strictness, int? maxSearchQueries, bool? allowPartialResult, IList<string> internalIncludeContexts, Uri endpoint, string indexName, DataSourceAuthentication authentication, DataSourceFieldMappings fieldMappings, DataSourceQueryType? queryType, string semanticConfiguration, string filter, DataSourceVectorizer vectorizationSource, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TopNDocuments = topNDocuments;
            InScope = inScope;
            Strictness = strictness;
            MaxSearchQueries = maxSearchQueries;
            AllowPartialResult = allowPartialResult;
            _internalIncludeContexts = internalIncludeContexts;
            Endpoint = endpoint;
            IndexName = indexName;
            Authentication = authentication;
            FieldMappings = fieldMappings;
            QueryType = queryType;
            SemanticConfiguration = semanticConfiguration;
            Filter = filter;
            VectorizationSource = vectorizationSource;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureSearchChatDataSourceParameters"/> for deserialization. </summary>
        internal InternalAzureSearchChatDataSourceParameters()
        {
        }

        /// <summary> Gets or sets the top n documents. </summary>
        public int? TopNDocuments { get; set; }
        /// <summary> Gets or sets the in scope. </summary>
        public bool? InScope { get; set; }
        /// <summary> Gets or sets the strictness. </summary>
        public int? Strictness { get; set; }
        /// <summary> Gets or sets the max search queries. </summary>
        public int? MaxSearchQueries { get; set; }
        /// <summary> Gets or sets the allow partial result. </summary>
        public bool? AllowPartialResult { get; set; }
        /// <summary> Gets the endpoint. </summary>
        internal Uri Endpoint { get; set; }
        /// <summary> Gets the index name. </summary>
        internal string IndexName { get; set; }
        /// <summary> Gets or sets the semantic configuration. </summary>
        public string SemanticConfiguration { get; set; }
        /// <summary> Gets or sets the filter. </summary>
        public string Filter { get; set; }
    }
}

