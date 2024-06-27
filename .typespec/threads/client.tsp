import "@azure-tools/typespec-client-generator-core";
import "./custom.tsp";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(ListThreadsResponse, Access.public);
@@usage(ListThreadsResponse, Usage.output);

@@access(CreateThreadRequestToolResourcesFileSearchBase, Access.public);
@@usage(CreateThreadRequestToolResourcesFileSearchBase, Usage.input);