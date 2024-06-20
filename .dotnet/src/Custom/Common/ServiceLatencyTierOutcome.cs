namespace OpenAI;

[CodeGenModel("ChatCompletionServiceTier")]
public readonly partial struct ServiceLatencyTierOutcome
{
    [CodeGenMember("Scale")]
    public static ServiceLatencyTierOutcome ScaleCreditsApplied { get; } = new(ScaleCreditsAppliedValue);
}
