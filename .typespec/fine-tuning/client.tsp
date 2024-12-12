import "@azure-tools/typespec-client-generator-core";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(FinetuneChatRequestInput, Access.public);
@@usage(FinetuneChatRequestInput, Usage.input);

@@access(FinetuneCompletionRequestInput, Access.public);
@@usage(FinetuneCompletionRequestInput, Usage.input);

@@access(FineTuningJobsPageToken, Access.public);
@@usage(FineTuningJobsPageToken, Usage.input);
