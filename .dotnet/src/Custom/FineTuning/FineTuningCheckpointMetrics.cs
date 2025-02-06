using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OpenAI.FineTuning;

[Experimental("OPENAI001")]
[CodeGenModel("FineTuningJobCheckpointMetrics")]
public partial class FineTuningCheckpointMetrics
{
    [CodeGenMember("Step")]
    public int StepNumber { get; }

}
