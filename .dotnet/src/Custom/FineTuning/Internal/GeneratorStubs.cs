using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenAI.FineTuning;

// CUSTOM: Made internal.

[CodeGenModel("FineTuneChatCompletionRequestAssistantMessage")]
internal partial class InternalFineTuneChatCompletionRequestAssistantMessage { }

[CodeGenModel("FineTuningIntegration")]
internal partial class InternalFineTuningIntegration { }

[CodeGenModel("FineTuningIntegrationWandb")]
internal partial class InternalFineTuningIntegrationWandb { }

[CodeGenModel("CreateFineTuningJobRequestWandbIntegrationWandb")]
internal partial class InternalCreateFineTuningJobRequestWandbIntegrationWandb
{
    [CodeGenMember("Project")]
    public string Project { get; set; }
}

[CodeGenModel("CreateFineTuningJobRequestModel")]
internal readonly partial struct CreateFineTuningJobRequestModel { }

[CodeGenModel("FineTuningJobObject")]
internal readonly partial struct InternalFineTuningJobObject { }

[CodeGenModel("FineTuningJobEventObject")]

public readonly partial struct FineTuningJobEventObject { }


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

[CodeGenModel("UnknownCreateFineTuningJobRequestIntegration")]
internal partial class UnknownCreateFineTuningJobRequestIntegration { }

[CodeGenModel("UnknownFineTuningIntegration")]
internal partial class UnknownFineTuningIntegration { }

[CodeGenModel("ListFineTuningJobEventsResponseObject")]
internal readonly partial struct InternalListFineTuningJobEventsResponseObject { }

[CodeGenModel("FineTuningJobEventLevel")]
internal enum FineTuningJobEventLevel {Info, Warn, Error}

[CodeGenModel("FineTuningJobEventLevelExtensions")]
internal partial class FineTuningJobEventLevelExtensions { }

[CodeGenModel("FineTuneMethodType")]
internal readonly partial struct InternalFineTuneMethodType { }

[CodeGenModel("FineTuneSupervisedMethod")]
internal partial class InternalFineTuningJobRequestMethodSupervised { }


[CodeGenModel("FineTuneDPOMethod")]
internal partial class InternalFineTuningJobRequestMethodDpo { }

// TODO: not yet integrated

[CodeGenModel("FineTuneChatRequestInput")]
internal partial class InternalTodoFineTuneChatRequestInput { }

[CodeGenModel("FineTuneCompletionRequestInput")]
internal partial class InternalTodoFineTuneCompletionRequestInput { }

