import "@azure-tools/typespec-client-generator-core";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using AzureOpenAI;

@@access(AzureImage, Access.public);
@@usage(AzureImage, Usage.output);
