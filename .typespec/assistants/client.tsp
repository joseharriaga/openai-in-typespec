import "@azure-tools/typespec-client-generator-core";
import "./custom.tsp";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(AssistantResponseFormat, Access.public);
@@usage(AssistantResponseFormat, Usage.input);

@@access(ToolResourcesFileSearchVectorStoreCreationHelper, Access.public);
@@usage(ToolResourcesFileSearchVectorStoreCreationHelper, Usage.input);

@@visibility(ListAssistantsResponse.data, "read");
@@visibility(ListRunStepsResponse.data, "read");
@@visibility(ListRunsResponse.data, "read");
