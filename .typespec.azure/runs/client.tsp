import "@azure-tools/typespec-client-generator-core";
import "./models.tsp";

using Azure.ClientGenerator.Core;

namespace AzureOpenAI;

@@access(OpenAI.RunStepDetailsToolCallsObjectToolCallsObject, Access.public);
@@usage(OpenAI.RunStepDetailsToolCallsObjectToolCallsObject, Usage.output);

@@access(RunStepDetailsToolCallsBingSearchObject, Access.public);
@@usage(RunStepDetailsToolCallsBingSearchObject, Usage.output);

@@access(RunStepDeltaStepDetailsToolCallsBingSearchObject, Access.public);
@@usage(RunStepDeltaStepDetailsToolCallsBingSearchObject, Usage.output);

@@access(RunStepDetailsToolCallsBingSearchObject, Access.public);
@@usage(RunStepDetailsToolCallsBingSearchObject, Usage.output);

@@access(RunStepDeltaStepDetailsToolCallsBingSearchObject, Access.public);
@@usage(RunStepDeltaStepDetailsToolCallsBingSearchObject, Usage.output);

@@withoutOmittedProperties(AzureRunStepObject, "step_details");
