using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobCheckpointMetrics")]
public partial class FineTuningCheckpointMetrics
{
    [CodeGenMember("Step")]
    public int StepNumber { get; }

}
