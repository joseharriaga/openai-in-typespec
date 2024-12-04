using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAI.FineTuning;

[CodeGenModel("ListFineTuningJobEventsRequest")]
public class ListEventsOptions
{
    [CodeGenMember("JobId")]
    internal string JobId { get; set; }

    [CodeGenMember("After")]
    public string AfterEventId { get; set; }

    [CodeGenMember("Limit")]
    public int? PageSize { get; set; }
}
