namespace OpenAI.Assistants;

using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class StreamingRunCreation : StreamingRunUpdate
{
    public ThreadRun Run { get; }

    internal StreamingRunCreation(ThreadRun run)
    {
        Run = run;
    }
}
