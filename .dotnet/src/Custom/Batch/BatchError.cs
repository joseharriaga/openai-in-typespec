namespace OpenAI.Batch;

[CodeGenModel("BatchErrorsDatum")]
public partial class BatchError
{
    // Customization: renamed

    /// <summary> The name of the parameter that caused the error, if applicable. </summary>
    public string ParameterName { get; }
}
