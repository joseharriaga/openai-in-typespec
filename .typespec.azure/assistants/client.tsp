import "@azure-tools/typespec-client-generator-core";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using AzureOpenAI;

@@access(BingSearchToolDefinition, Access.public);
@@usage(BingSearchToolDefinition, Usage.input);
