using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OpenAI.FineTuning;

[Experimental("OPENAI001")]
[CodeGenType("FineTuningJobEvent")]
public partial class FineTuningEvent
{
    [CodeGenMember("FineTuningJobEventLevel")]
    public string Level;

    [CodeGenMember("Type")]
    public FineTuningJobEventKind? Kind { get; }

    [CodeGenMember("Object")]
    private string _object;
}