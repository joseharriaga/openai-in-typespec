
namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureSearchChatDataSource")]
public partial class AzureSearchChatDataSource : AzureChatDataSource
{
    [CodeGenMember("Parameters")]
    internal InternalAzureSearchChatDataSourceParameters InternalParameters { get; }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.Authentication"/>
    public AzureChatDataSourceAuthenticationOptions Authentication
    {
        get => InternalParameters.Authentication;
        init => InternalParameters.Authentication = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.TopNDocuments"/>
    public int? TopNDocuments
    {
        get => InternalParameters.TopNDocuments;
        init => InternalParameters.TopNDocuments = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.InScope"/>
    public bool? InScope
    {
        get => InternalParameters.InScope;
        init => InternalParameters.InScope = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.Strictness"/>
    public int? Strictness
    {
        get => InternalParameters.Strictness;
        init => InternalParameters.Strictness = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.RoleInformation"/>
    public string RoleInformation
    {
        get => InternalParameters.RoleInformation;
        init => InternalParameters.RoleInformation = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.MaxSearchQueries"/>
    public int? MaxSearchQueries
    {
        get => InternalParameters.MaxSearchQueries;
        init => InternalParameters.MaxSearchQueries = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.AllowPartialResult"/>
    public bool? AllowPartialResult
    {
        get => InternalParameters.AllowPartialResult;
        init => InternalParameters.AllowPartialResult = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.Endpoint"/>
    public Uri Endpoint
    {
        get => InternalParameters.Endpoint;
        init => InternalParameters.Endpoint = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.IndexName"/>
    public string IndexName
    {
        get => InternalParameters.IndexName;
        init => InternalParameters.IndexName = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.OutputContextFlags"/>
    DataSourceOutputContextFlags? OutputContextFlags
    {
        get => InternalParameters.OutputContextFlags;
        init => InternalParameters.OutputContextFlags = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.FieldsMapping"/>
    public AzureSearchChatDataSourceParametersFieldsMapping FieldsMapping
    {
        get => InternalParameters.FieldsMapping;
        init => InternalParameters.FieldsMapping = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.QueryType"/>
    public string QueryType
    {
        get => InternalParameters.QueryType;
        init => InternalParameters.QueryType = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.SemanticConfiguration"/>
    public string SemanticConfiguration
    {
        get => InternalParameters.SemanticConfiguration;
        init => InternalParameters.SemanticConfiguration = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.EmbeddingDependency"/>
    public string Filter
    {
        get => InternalParameters.Filter;
        init => InternalParameters.Filter = value;
    }

    /// <inheritdoc cref="InternalAzureSearchChatDataSourceParameters.EmbeddingDependency"/>
    public AzureChatDataSourceVectorizationSource EmbeddingDependency
    {
        get => InternalParameters.EmbeddingDependency;
        init => InternalParameters.EmbeddingDependency = value;
    }

    public AzureSearchChatDataSource()
    {
        InternalParameters = new();
        _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
    }
}
