using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning;

// CUSTOM: Made internal.

[CodeGenModel("FineTuneChatCompletionRequestAssistantMessage")]
internal partial class InternalFineTuneChatCompletionRequestAssistantMessage { }

[CodeGenModel("FinetuneChatRequestInput")]
internal partial class InternalFinetuneChatRequestInput { }

[CodeGenModel("FinetuneCompletionRequestInput")]
internal partial class InternalFinetuneCompletionRequestInput { }

[CodeGenModel("FineTuningIntegration")]
internal partial class InternalFineTuningIntegration { }

[CodeGenModel("FineTuningIntegrationType")]
internal readonly partial struct InternalFineTuningIntegrationType { }

[CodeGenModel("FineTuningIntegrationWandb")]
internal partial class InternalFineTuningIntegrationWandb { }

[CodeGenModel("CreateFineTuningJobRequestWandbIntegrationWandb")]
internal partial class InternalCreateFineTuningJobRequestWandbIntegrationWandb
{
    [CodeGenMember("Project")]
    public string Project { get; set; }
}

[CodeGenModel("FineTuningJobObject")]
internal readonly partial struct InternalFineTuningJobObject { }




[CodeGenModel("FineTuningJobCheckpointObject")]
internal readonly partial struct InternalFineTuningJobCheckpointObject { }

[CodeGenModel("ListFineTuningJobCheckpointsResponse")]
internal partial class InternalListFineTuningJobCheckpointsResponse { }

[CodeGenModel("ListFineTuningJobCheckpointsResponseObject")]
internal readonly partial struct InternalListFineTuningJobCheckpointsResponseObject { }

[CodeGenModel("ListFineTuningJobEventsResponse")]
internal partial class InternalListFineTuningJobEventsResponse { }

[CodeGenModel("ListPaginatedFineTuningJobsResponse")]
internal partial class InternalListPaginatedFineTuningJobsResponse { }

[CodeGenModel("ListPaginatedFineTuningJobsResponseObject")]
internal readonly partial struct InternalListPaginatedFineTuningJobsResponseObject { }

[CodeGenModel("FineTuningIntegrationWandbWandb")]
internal partial class FineTuningIntegrationWandbWandb { }

[CodeGenModel("FineTuningJobHyperparametersBatchSizeChoiceEnum")]
internal readonly partial struct FineTuningJobHyperparametersBatchSizeChoiceEnum { }

[CodeGenModel("FineTuningJobHyperparametersLearningRateMultiplierChoiceEnum")]
internal readonly partial struct FineTuningJobHyperparametersLearningRateMultiplierChoiceEnum { }

[CodeGenModel("FineTuningJobHyperparametersNEpochsChoiceEnum")]
internal readonly partial struct FineTuningJobHyperparametersNEpochsChoiceEnum { }

[CodeGenModel("UnknownCreateFineTuningJobRequestIntegration")]
internal partial class UnknownCreateFineTuningJobRequestIntegration { }

[CodeGenModel("UnknownFineTuningIntegration")]
internal partial class UnknownFineTuningIntegration { }

[CodeGenModel("ListFineTuningJobEventsResponseObject")]
internal readonly partial struct InternalListFineTuningJobEventsResponseObject { }