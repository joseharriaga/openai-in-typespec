using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAI.FineTuning;

[CodeGenModel("FineTuningJobEvent")]
public partial class FineTuningEvent
{
    [CodeGenMember("FineTuningJobEventLevel")]
    public string Level;

    [CodeGenMember("Object")]
    private string _object;
}