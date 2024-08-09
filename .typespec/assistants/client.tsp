import "@azure-tools/typespec-client-generator-core";
import "./custom.tsp";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(AssistantsApiResponseFormatOption, Access.public);
@@usage(AssistantsApiResponseFormatOption, Usage.input);

@@access(AssistantResponseFormat, Access.public);
@@usage(AssistantResponseFormat, Usage.input);

@@access(ToolResourcesFileSearchVectorStoreCreationHelper, Access.public);
@@usage(ToolResourcesFileSearchVectorStoreCreationHelper, Usage.input);
