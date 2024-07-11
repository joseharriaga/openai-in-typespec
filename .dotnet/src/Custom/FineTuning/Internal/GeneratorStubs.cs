using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OpenAI.Chat;

namespace OpenAI.FineTuning;

// CUSTOM: Made internal.

[CodeGenModel("CreateFineTuningJobRequest")]
internal partial class InternalCreateFineTuningJobRequest { }

[CodeGenModel("CreateFineTuningJobRequestHyperparameters")]
internal partial class InternalCreateFineTuningJobRequestHyperparameters { }

[CodeGenModel("CreateFineTuningJobRequestIntegration")]
internal partial class InternalCreateFineTuningJobRequestIntegration { }

[CodeGenModel("CreateFineTuningJobRequestIntegrationType")]
internal readonly partial struct InternalCreateFineTuningJobRequestIntegrationType { }

[CodeGenModel("CreateFineTuningJobRequestIntegrationWandb")]
internal partial class InternalCreateFineTuningJobRequestIntegrationWandb { }

[CodeGenModel("CreateFineTuningJobRequestModel")]
internal readonly partial struct InternalCreateFineTuningJobRequestModel { }

[CodeGenModel("FineTuningIntegration")]
internal partial class InternalFineTuningIntegration { }

[CodeGenModel("FineTuningIntegrationType")]
internal readonly partial struct InternalFineTuningIntegrationType { }

[CodeGenModel("FineTuningIntegrationWandb")]
internal partial class InternalFineTuningIntegrationWandb { }

[CodeGenModel("FineTuningJob")]
internal partial class InternalFineTuningJob { }

[CodeGenModel("FineTuningJobCheckpoint")]
internal partial class InternalFineTuningJobCheckpoint { }

[CodeGenModel("FineTuningJobCheckpointMetrics")]
internal partial class InternalFineTuningJobCheckpointMetrics { }

[CodeGenModel("FineTuningJobCheckpointObject")]
internal readonly partial struct InternalFineTuningJobCheckpointObject { }

[CodeGenModel("FineTuningJobError")]
internal partial class InternalFineTuningJobError { }

[CodeGenModel("FineTuningJobEvent")]
internal partial class InternalFineTuningJobEvent { }

[CodeGenModel("FineTuningJobEventLevel")]
internal readonly partial struct InternalFineTuningJobEventLevel { }

[CodeGenModel("FineTuningJobEventObject")]
internal readonly partial struct InternalFineTuningJobEventObject { }

[CodeGenModel("FineTuningJobHyperparameters")]
internal partial class InternalFineTuningJobHyperparameters { }

[CodeGenModel("FineTuningJobObject")]
internal readonly partial struct InternalFineTuningJobObject { }

[CodeGenModel("FineTuningJobStatus")]
internal readonly partial struct InternalFineTuningJobStatus { }

[CodeGenModel("ListFineTuningJobCheckpointsResponse")]
internal partial class InternalListFineTuningJobCheckpointsResponse { }

[CodeGenModel("ListFineTuningJobCheckpointsResponseObject")]
internal readonly partial struct InternalListFineTuningJobCheckpointsResponseObject { }

[CodeGenModel("ListFineTuningJobEventsResponse")]
internal partial class InternalListFineTuningJobEventsResponse { }

[CodeGenModel("ListFineTuningJobEventsResponseObject")]
internal readonly partial struct InternalListFineTuningJobEventsResponseObject { }

[CodeGenModel("ListPaginatedFineTuningJobsResponse")]
internal partial class InternalListPaginatedFineTuningJobsResponse { }

[CodeGenModel("ListPaginatedFineTuningJobsResponseObject")]
internal readonly partial struct InternalListPaginatedFineTuningJobsResponseObject { }

[CodeGenModel("FinetuneCompletionRequestInput")]
internal partial class InternalFinetuneCompletionRequestInput { }

[CodeGenModel("FinetuneChatRequestInput")]
internal partial class InternalFinetuneChatRequestInput { }

[CodeGenModel("FineTuneChatCompletionRequestAssistantMessage")]
internal partial class InternalFineTuneChatCompletionRequestAssistantMessage
{
    [SetsRequiredMembers] internal InternalFineTuneChatCompletionRequestAssistantMessage(string role, IList<ChatMessageContentPart> content, IDictionary<string, BinaryData> serializedAdditionalRawData, string participantName, IList<ChatToolCall> toolCalls, ChatFunctionCall functionCall) : base(role, content, serializedAdditionalRawData, participantName, toolCalls, functionCall) {}
}
