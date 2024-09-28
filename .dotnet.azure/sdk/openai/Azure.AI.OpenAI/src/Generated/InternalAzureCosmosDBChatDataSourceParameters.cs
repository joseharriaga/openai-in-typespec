// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary> The AzureCosmosDBChatDataSourceParameters. </summary>
    internal partial class InternalAzureCosmosDBChatDataSourceParameters
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
        /// <summary> Initializes a new instance of <see cref="InternalAzureCosmosDBChatDataSourceParameters"/>. </summary>
        /// <param name="containerName"></param>
        /// <param name="databaseName"></param>
        /// <param name="vectorizationSource">
        /// Please note <see cref="DataSourceVectorizer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </param>
        /// <param name="indexName"></param>
        /// <param name="authentication">
        /// Please note <see cref="DataSourceAuthentication"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </param>
        /// <param name="fieldMappings"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="containerName"/>, <paramref name="databaseName"/>, <paramref name="vectorizationSource"/>, <paramref name="indexName"/>, <paramref name="authentication"/> or <paramref name="fieldMappings"/> is null. </exception>
        public InternalAzureCosmosDBChatDataSourceParameters(string containerName, string databaseName, DataSourceVectorizer vectorizationSource, string indexName, DataSourceAuthentication authentication, DataSourceFieldMappings fieldMappings)
        {
            Argument.AssertNotNull(containerName, nameof(containerName));
            Argument.AssertNotNull(databaseName, nameof(databaseName));
            Argument.AssertNotNull(vectorizationSource, nameof(vectorizationSource));
            Argument.AssertNotNull(indexName, nameof(indexName));
            Argument.AssertNotNull(authentication, nameof(authentication));
            Argument.AssertNotNull(fieldMappings, nameof(fieldMappings));

            _internalIncludeContexts = new ChangeTrackingList<string>();
            ContainerName = containerName;
            DatabaseName = databaseName;
            VectorizationSource = vectorizationSource;
            IndexName = indexName;
            Authentication = authentication;
            FieldMappings = fieldMappings;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureCosmosDBChatDataSourceParameters"/>. </summary>
        /// <param name="topNDocuments"> The configured number of documents to feature in the query. </param>
        /// <param name="inScope"> Whether queries should be restricted to use of the indexed data. </param>
        /// <param name="strictness">
        /// The configured strictness of the search relevance filtering.
        /// Higher strictness will increase precision but lower recall of the answer.
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
        /// <param name="containerName"></param>
        /// <param name="databaseName"></param>
        /// <param name="vectorizationSource">
        /// Please note <see cref="DataSourceVectorizer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </param>
        /// <param name="indexName"></param>
        /// <param name="authentication">
        /// Please note <see cref="DataSourceAuthentication"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes..
        /// </param>
        /// <param name="fieldMappings"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalAzureCosmosDBChatDataSourceParameters(int? topNDocuments, bool? inScope, int? strictness, int? maxSearchQueries, bool? allowPartialResult, IList<string> internalIncludeContexts, string containerName, string databaseName, DataSourceVectorizer vectorizationSource, string indexName, DataSourceAuthentication authentication, DataSourceFieldMappings fieldMappings, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TopNDocuments = topNDocuments;
            InScope = inScope;
            Strictness = strictness;
            MaxSearchQueries = maxSearchQueries;
            AllowPartialResult = allowPartialResult;
            _internalIncludeContexts = internalIncludeContexts;
            ContainerName = containerName;
            DatabaseName = databaseName;
            VectorizationSource = vectorizationSource;
            IndexName = indexName;
            Authentication = authentication;
            FieldMappings = fieldMappings;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureCosmosDBChatDataSourceParameters"/> for deserialization. </summary>
        internal InternalAzureCosmosDBChatDataSourceParameters()
        {
        }

        /// <summary> The configured number of documents to feature in the query. </summary>
        public int? TopNDocuments { get; set; }
        /// <summary> Whether queries should be restricted to use of the indexed data. </summary>
        public bool? InScope { get; set; }
        /// <summary>
        /// The configured strictness of the search relevance filtering.
        /// Higher strictness will increase precision but lower recall of the answer.
        /// </summary>
        public int? Strictness { get; set; }
        /// <summary>
        /// The maximum number of rewritten queries that should be sent to the search provider for a single user message.
        /// By default, the system will make an automatic determination.
        /// </summary>
        public int? MaxSearchQueries { get; set; }
        /// <summary>
        /// If set to true, the system will allow partial search results to be used and the request will fail if all
        /// partial queries fail. If not specified or specified as false, the request will fail if any search query fails.
        /// </summary>
        public bool? AllowPartialResult { get; set; }
        /// <summary> Gets the container name. </summary>
        internal string ContainerName { get; set; }
        /// <summary> Gets the database name. </summary>
        internal string DatabaseName { get; set; }
        /// <summary> Gets the index name. </summary>
        internal string IndexName { get; set; }
    }
}



