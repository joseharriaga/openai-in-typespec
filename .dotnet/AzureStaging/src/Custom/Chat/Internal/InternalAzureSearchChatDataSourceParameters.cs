namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureSearchChatDataSourceParameters")]
internal partial class InternalAzureSearchChatDataSourceParameters
{
    [CodeGenMember("IncludeContexts")]
    private IList<string> _internalIncludeContexts = new ChangeTrackingList<string>();
    private DataSourceOutputContextFlags? _outputContextFlags;

    /// <summary>
    /// The output context properties to include on the response.
    /// By default, citations and intent will be requested.
    /// </summary>
    public DataSourceOutputContextFlags? OutputContextFlags
    {
        get => DataSourceOutputContextFlagsExtensions.FromStringList(_internalIncludeContexts);
        internal set
        {
            _outputContextFlags = value;
            _internalIncludeContexts = _outputContextFlags?.ToStringList();
        }
    }

    /// <summary> The field mappings to use with the Azure Search resource. </summary>
    [CodeGenMember("FieldsMapping")]
    public DataSourceFieldMappings FieldMappings { get; set; }

    /// <summary> The query type for the Azure Search resource to use. </summary>
    [CodeGenMember("QueryType")]
    public DataSourceQueryType? QueryType { get; set; }

    /// <summary>
    /// Gets the embedding dependency
    /// </summary>
    [CodeGenMember("EmbeddingDependency")]
    internal DataSourceVectorizer VectorizationSource { get; set; }
}