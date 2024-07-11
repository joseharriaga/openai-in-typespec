import "@azure-tools/typespec-client-generator-core";
import "./models.oyd.auth.tsp";
import "./models.oyd.vectorization.tsp";
import "./models.request.tsp";
import "./models.response.tsp";

using Azure.ClientGenerator.Core;
using AzureOpenAI;

@@access(AzureChatMessageContext, Access.public);
@@usage(AzureChatMessageContext, Usage.output);

//
@@access(AzureChatDataSource, Access.public);
@@usage(AzureChatDataSource, Usage.input);

@@access(AzureCosmosDBChatDataSource, Access.public);
@@usage(AzureCosmosDBChatDataSource, Usage.input);

@@access(AzureMachineLearningIndexChatDataSource, Access.public);
@@usage(AzureMachineLearningIndexChatDataSource, Usage.input);

@@access(AzureSearchChatDataSource, Access.public);
@@usage(AzureSearchChatDataSource, Usage.input);

@@access(ElasticsearchChatDataSource, Access.public);
@@usage(ElasticsearchChatDataSource, Usage.input);

@@access(PineconeChatDataSource, Access.public);
@@usage(PineconeChatDataSource, Usage.input);

//
@@access(AzureChatDataSourceVectorizationSource, Access.public);
@@usage(AzureChatDataSourceVectorizationSource, Usage.output);

@@access(AzureChatDataSourceEndpointVectorizationSource, Access.public);
@@usage(AzureChatDataSourceEndpointVectorizationSource, Usage.output);

@@access(AzureChatDataSourceDeploymentNameVectorizationSource, Access.public);
@@usage(AzureChatDataSourceDeploymentNameVectorizationSource, Usage.output);

@@access(AzureChatDataSourceModelIdVectorizationSource, Access.public);
@@usage(AzureChatDataSourceModelIdVectorizationSource, Usage.output);
