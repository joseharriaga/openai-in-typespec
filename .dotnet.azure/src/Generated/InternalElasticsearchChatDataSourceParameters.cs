// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary> The ElasticsearchChatDataSourceParameters. </summary>
    internal partial class InternalElasticsearchChatDataSourceParameters
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
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        /// <summary> Initializes a new instance of <see cref="InternalElasticsearchChatDataSourceParameters"/>. </summary>
        /// <param name="endpoint"></param>
        /// <param name="indexName"></param>
        /// <param name="authentication">
        /// Please note <see cref="DataSourceAuthentication"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/>, <paramref name="indexName"/> or <paramref name="authentication"/> is null. </exception>
        internal InternalElasticsearchChatDataSourceParameters(Uri endpoint, string indexName, DataSourceAuthentication authentication)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(indexName, nameof(indexName));
            Argument.AssertNotNull(authentication, nameof(authentication));

            _internalIncludeContexts = new ChangeTrackingList<string>();
            Endpoint = endpoint;
            IndexName = indexName;
            Authentication = authentication;
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="InternalElasticsearchChatDataSourceParameters"/>. </summary>
        /// <param name="topNDocuments"> The configured number of documents to feature in the query. </param>
        /// <param name="inScope"> Whether queries should be restricted to use of the indexed data. </param>
        /// <param name="strictness">
        /// The configured strictness of the search relevance filtering.
        /// Higher strictness will increase precision but lower recall of the answer.
        /// </param>
        /// <param name="roleInformation">
        /// Additional instructions for the model to inform how it should behave and any context it should reference when
        /// generating a response. You can describe the assistant's personality and tell it how to format responses.
        /// This is limited to 100 tokens and counts against the overall token limit.
        /// </param>
        /// <param name="maxSearchQueries">
        /// The maximum number of rewritten queries that should be sent to the search provider for a single user message.
        /// By default, the system will make an automatic determination.
        /// </param>
        /// <param name="allowPartialResult">
        /// If set to true, the system will allow partial search results to be used and the request will fail if all
        /// partial queries fail. If not specified or specified as false, the request will fail if any search query fails.
        /// </param>
        /// <param name="internalIncludeContexts">
        /// The output context properties to include on the response.
        /// By default, citations and intent will be requested.
        /// </param>
        /// <param name="endpoint"></param>
        /// <param name="indexName"></param>
        /// <param name="authentication">
        /// Please note <see cref="DataSourceAuthentication"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </param>
        /// <param name="fieldMappings"></param>
        /// <param name="queryType"></param>
        /// <param name="vectorizationSource">
        /// Please note <see cref="DataSourceVectorizer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalElasticsearchChatDataSourceParameters(int? topNDocuments, bool? inScope, int? strictness, string roleInformation, int? maxSearchQueries, bool? allowPartialResult, IList<string> internalIncludeContexts, Uri endpoint, string indexName, DataSourceAuthentication authentication, DataSourceFieldMappings fieldMappings, DataSourceQueryType? queryType, DataSourceVectorizer vectorizationSource, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TopNDocuments = topNDocuments;
            InScope = inScope;
            Strictness = strictness;
            RoleInformation = roleInformation;
            MaxSearchQueries = maxSearchQueries;
            AllowPartialResult = allowPartialResult;
            _internalIncludeContexts = internalIncludeContexts;
            Endpoint = endpoint;
            IndexName = indexName;
            Authentication = authentication;
            FieldMappings = fieldMappings;
            QueryType = queryType;
            VectorizationSource = vectorizationSource;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="InternalElasticsearchChatDataSourceParameters"/> for deserialization. </summary>
        internal InternalElasticsearchChatDataSourceParameters()
        {
        }

        /// <summary> The configured number of documents to feature in the query. </summary>
        internal int? TopNDocuments { get; set; }
        /// <summary> Whether queries should be restricted to use of the indexed data. </summary>
        internal bool? InScope { get; set; }
        /// <summary>
        /// The configured strictness of the search relevance filtering.
        /// Higher strictness will increase precision but lower recall of the answer.
        /// </summary>
        internal int? Strictness { get; set; }
        /// <summary>
        /// Additional instructions for the model to inform how it should behave and any context it should reference when
        /// generating a response. You can describe the assistant's personality and tell it how to format responses.
        /// This is limited to 100 tokens and counts against the overall token limit.
        /// </summary>
        internal string RoleInformation { get; set; }
        /// <summary>
        /// The maximum number of rewritten queries that should be sent to the search provider for a single user message.
        /// By default, the system will make an automatic determination.
        /// </summary>
        internal int? MaxSearchQueries { get; set; }
        /// <summary>
        /// If set to true, the system will allow partial search results to be used and the request will fail if all
        /// partial queries fail. If not specified or specified as false, the request will fail if any search query fails.
        /// </summary>
        internal bool? AllowPartialResult { get; set; }
        /// <summary> Gets the endpoint. </summary>
        internal Uri Endpoint { get; set; }
        /// <summary> Gets the index name. </summary>
        internal string IndexName { get; set; }
    }
}

