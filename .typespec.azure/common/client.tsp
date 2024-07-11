import "@azure-tools/typespec-client-generator-core";
import "./models.errors.tsp";
import "./models.rai.tsp";

using Azure.ClientGenerator.Core;
using AzureOpenAI;

@@access(AzureContentFilterBlocklistResult, Access.public);
@@usage(AzureContentFilterBlocklistResult, Usage.output);

@@access(AzureContentFilterResultForChoice, Access.public);
@@usage(AzureContentFilterResultForChoice, Usage.output);

@@access(AzureContentFilterBlocklistIdResult, Access.public);
@@usage(AzureContentFilterBlocklistIdResult, Usage.output);

@@access(AzureOpenAIError, Access.public);
@@usage(AzureOpenAIError, Usage.output);

@@access(AzureOpenAIErrorResponse, Access.public);
@@usage(AzureOpenAIErrorResponse, Usage.output);

@@access(AzureOpenAIChatError, Access.public);
@@usage(AzureOpenAIChatError, Usage.output);

@@access(AzureOpenAIDalleError, Access.public);
@@usage(AzureOpenAIDalleError, Usage.output);

@@access(AzureOpenAIChatErrorResponse, Access.public);
@@usage(AzureOpenAIChatErrorResponse, Usage.output);

@@access(AzureOpenAIDalleErrorResponse, Access.public);
@@usage(AzureOpenAIDalleErrorResponse, Usage.output);
