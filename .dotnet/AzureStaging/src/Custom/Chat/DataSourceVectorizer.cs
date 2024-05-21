namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureChatDataSourceVectorizationSource")]
public abstract partial class DataSourceVectorizer
{
    public static DataSourceVectorizer FromEndpoint(Uri endpoint, DataSourceAuthentication authentication)
        => new InternalAzureChatDataSourceEndpointVectorizationSource(endpoint, authentication);
    public static DataSourceVectorizer FromDeploymentName(string deploymentName)
        => new InternalAzureChatDataSourceDeploymentNameVectorizationSource(deploymentName);
    public static DataSourceVectorizer FromModelId(string modelId)
        => new InternalAzureChatDataSourceModelIdVectorizationSource(modelId);
}