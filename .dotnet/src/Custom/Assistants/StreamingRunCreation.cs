namespace OpenAI.Assistants;

public partial class StreamingRunCreation : StreamingUpdate
{
    public ThreadRun Run { get; }

    internal StreamingRunCreation(ThreadRun run)
    {
        Run = run;
    }
}
