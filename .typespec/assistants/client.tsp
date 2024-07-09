import "@azure-tools/typespec-client-generator-core";
import "./custom.tsp";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(AssistantResponseFormat, Access.public);
@@usage(AssistantResponseFormat, Usage.input);

@@access(CreateAssistantRequestToolResourcesFileSearchBase, Access.public);
@@usage(CreateAssistantRequestToolResourcesFileSearchBase, Usage.input);
