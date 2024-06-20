namespace OpenAI;

[CodeGenModel("ChatCompletionOptionsServiceTier")]
public readonly partial struct ServiceLatencyTierChoice
{
    [CodeGenMember("Auto")]
    public static ServiceLatencyTierChoice ApplyScaleCredits { get; } = new(ApplyScaleCreditsValue);
}
