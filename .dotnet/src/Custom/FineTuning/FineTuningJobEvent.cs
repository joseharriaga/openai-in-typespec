using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobEvent")]
public partial class FineTuningJobEvent
{
    [CodeGenMember("FineTuningJobEventLevel")]
    public string Level;

    [CodeGenMember("FineTuningJobEventObject")]
    private string _object;
}