using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenAI.FineTuning;

// CUSTOM: Made internal.

[CodeGenType("FineTuneChatCompletionRequestAssistantMessage")]
internal partial class InternalFineTuneChatCompletionRequestAssistantMessage { }

[CodeGenType("FineTuningIntegration")]
internal partial class InternalFineTuningIntegration { }

[CodeGenType("FineTuningIntegrationType")]
internal readonly partial struct InternalFineTuningIntegrationType { }

[CodeGenType("FineTuningIntegrationWandb")]
internal partial class InternalFineTuningIntegrationWandb { }

[CodeGenType("CreateFineTuningJobRequestWandbIntegrationWandb")]
internal partial class InternalCreateFineTuningJobRequestWandbIntegrationWandb
{
    [CodeGenMember("Project")]
    public string Project { get; set; }
}

[CodeGenType("FineTuningJobObject")]
internal readonly partial struct InternalFineTuningJobObject { }

[CodeGenType("FineTuningJobCheckpointObject")]
internal readonly partial struct InternalFineTuningJobCheckpointObject { }

[CodeGenType("ListFineTuningJobCheckpointsResponse")]
internal partial class InternalListFineTuningJobCheckpointsResponse { }

[CodeGenType("ListFineTuningJobCheckpointsResponseObject")]
internal readonly partial struct InternalListFineTuningJobCheckpointsResponseObject { }

[CodeGenType("ListFineTuningJobEventsResponse")]
internal partial class InternalListFineTuningJobEventsResponse { }

[CodeGenType("ListPaginatedFineTuningJobsResponse")]
internal partial class InternalListPaginatedFineTuningJobsResponse { }

[CodeGenType("ListPaginatedFineTuningJobsResponseObject")]
internal readonly partial struct InternalListPaginatedFineTuningJobsResponseObject { }

[CodeGenType("FineTuningIntegrationWandbWandb")]
internal partial class FineTuningIntegrationWandbWandb { }

[CodeGenType("FineTuningJobHyperparametersBatchSizeChoiceEnum")]
internal readonly partial struct FineTuningJobHyperparametersBatchSizeChoiceEnum { }

[CodeGenType("FineTuningJobHyperparametersLearningRateMultiplierChoiceEnum")]
internal readonly partial struct FineTuningJobHyperparametersLearningRateMultiplierChoiceEnum { }

[CodeGenType("FineTuningJobHyperparametersNEpochsChoiceEnum")]
internal readonly partial struct FineTuningJobHyperparametersNEpochsChoiceEnum { }

[CodeGenType("UnknownCreateFineTuningJobRequestIntegration")]
internal partial class UnknownCreateFineTuningJobRequestIntegration { }

[CodeGenType("UnknownFineTuningIntegration")]
internal partial class UnknownFineTuningIntegration { }

[CodeGenType("FineTuningJobEventObject")]
internal readonly partial struct InternalFineTuningJobEventObject { }

[CodeGenType("ListFineTuningJobEventsResponseObject")]
internal readonly partial struct InternalListFineTuningJobEventsResponseObject { }

[CodeGenType("CreateFineTuningJobRequestModel")]
internal readonly partial struct InternalCreateFineTuningJobRequestModel { }

// Future public types follow

[CodeGenType("FineTuningJobEventLevel")]
internal enum FineTuningJobEventLevel
{
    Info,
    Warn,
    Error
}


[CodeGenType("FineTuneDPOMethod")]
internal partial class InternalFineTuningJobRequestMethodDpo { }

[CodeGenType("FineTuneMethodType")]
internal readonly partial struct InternalFineTuneMethodType { }

[CodeGenType("FineTuneSupervisedMethod")]
internal partial class InternalFineTuningJobRequestMethodSupervised { }

// TODO: not yet integrated

[CodeGenType("FineTuneChatRequestInput")]
internal partial class InternalTodoFineTuneChatRequestInput { }

[CodeGenType("FineTuneCompletionRequestInput")]
internal partial class InternalTodoFineTuneCompletionRequestInput { }
