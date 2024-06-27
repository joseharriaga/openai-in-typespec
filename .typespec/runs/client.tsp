import "@azure-tools/typespec-client-generator-core";
import "./custom.tsp";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(RunStepDeltaObject, Access.public);
@@usage(RunStepDeltaObject, Usage.output);

@@access(RunStepDeltaStepDetailsMessageCreationObject, Access.public);
@@usage(RunStepDeltaStepDetailsMessageCreationObject, Usage.output);

@@access(RunStepDeltaStepDetailsToolCallsObject, Access.public);
@@usage(RunStepDeltaStepDetailsToolCallsObject, Usage.output);

//
// @@access(RunStepDeltaStepDetailsToolCallsObjectToolCallsObject, Access.public);
// @@usage(RunStepDeltaStepDetailsToolCallsObjectToolCallsObject, Usage.output);

@@access(RunStepDeltaStepDetailsToolCallsCodeObject, Access.public);
@@usage(RunStepDeltaStepDetailsToolCallsCodeObject, Usage.output);

@@access(RunStepDeltaStepDetailsToolCallsFileSearchObject, Access.public);
@@usage(RunStepDeltaStepDetailsToolCallsFileSearchObject, Usage.output);

@@access(RunStepDeltaStepDetailsToolCallsFunctionObject, Access.public);
@@usage(RunStepDeltaStepDetailsToolCallsFunctionObject, Usage.output);

// 
// @@access(RunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject, Access.public);
// @@usage(RunStepDeltaStepDetailsToolCallsCodeObjectCodeInterpreterOutputsObject, Usage.output);

@@access(RunStepDeltaStepDetailsToolCallsCodeOutputImageObject, Access.public);
@@usage(RunStepDeltaStepDetailsToolCallsCodeOutputImageObject, Usage.output);

@@access(RunStepDeltaStepDetailsToolCallsCodeOutputLogsObject, Access.public);
@@usage(RunStepDeltaStepDetailsToolCallsCodeOutputLogsObject, Usage.output);