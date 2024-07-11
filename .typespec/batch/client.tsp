import "@azure-tools/typespec-client-generator-core";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(BatchRequestInput, Access.public);
@@usage(BatchRequestInput, Usage.input);

@@access(BatchRequestOutput, Access.public);
@@usage(BatchRequestOutput, Usage.output);
