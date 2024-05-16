namespace OpenAI.Assistants;

[CodeGenModel("AssistantObject")]
public partial class Assistant
{
    // CUSTOM: hide non-discriminated object/type labels, as they're not necessary in the context of strongly typed
    //          representations
    private readonly object Object;

    /// <inheritdoc cref="AssistantResponseFormat"/>
    public AssistantResponseFormat ResponseFormat { get; }

    /// <summary>
    /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.
    ///
    /// We generally recommend altering this or temperature but not both.
    /// </summary>
    [CodeGenMember("TopP")]
    public float? NucleusSamplingFactor { get; }
}
