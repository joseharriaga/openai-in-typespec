namespace OpenAI.Batch;

/// <summary>
/// Represents error information related to a single input operation (JSON-L line) in a batch.
/// </summary>
public readonly partial struct BatchErrorInfo
{
    /// <summary>
    /// The machine-readable error code for the failure.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// A human-readable error message for the failure.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// If applicable, provides the name of the parameter responsible for the failure.
    /// </summary>
    public string ParameterName { get; }

    /// <summary>
    /// If applicable, provides the line number in the input associated with the failure.
    /// </summary>
    public int? InputLineNumber { get; }

    internal BatchErrorInfo(string code, string message, string parameterName, int? inputLineNumber)
    {
        Code = code;
        Message = message;
        ParameterName = parameterName;
        InputLineNumber = inputLineNumber;
    }
}