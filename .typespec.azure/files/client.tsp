import "@azure-tools/typespec-client-generator-core";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using AzureOpenAI;

@@access(AzureOpenAIFile, Access.public);
@@usage(AzureOpenAIFile, Usage.output);
