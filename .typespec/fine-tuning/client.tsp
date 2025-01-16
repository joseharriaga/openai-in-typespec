import "@azure-tools/typespec-client-generator-core";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(FineTuneChatRequestInput, Access.public);
@@usage(FineTuneChatRequestInput, Usage.input);

@@access(FineTuneCompletionRequestInput, Access.public);
@@usage(FineTuneCompletionRequestInput, Usage.input);
