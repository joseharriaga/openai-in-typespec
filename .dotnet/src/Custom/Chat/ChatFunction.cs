using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Chat;

/// <summary>
/// Represents the definition of a function that the model may call, as supplied in a chat completion request.
/// </summary>
[CodeGenModel("ChatCompletionFunctions")]
[CodeGenSuppress("ChatFunction", typeof(string))]
public partial class ChatFunction
{
    // CUSTOM: Added custom constructor.
    /// <summary>
    /// Creates a new instance of <see cref="ChatFunction"/>.
    /// </summary>
    /// <param name="functionName"> The <c>name</c> of the function. </param>
    [SetsRequiredMembers]
    public ChatFunction(string functionName)
    {
        Argument.AssertNotNull(functionName, nameof(functionName));

        FunctionName = functionName;
    }

    /// <summary>
    /// Creates a new instance of <see cref="ChatFunction"/>.
    /// </summary>
    public ChatFunction()
    {}

    [SetsRequiredMembers]
    internal ChatFunction(string functionDescription, string functionName, BinaryData functionParameters, IDictionary<string, BinaryData> serializedAdditionalRawData)
    {
        FunctionDescription = functionDescription;
        FunctionName = functionName;
        FunctionParameters = functionParameters;
        _serializedAdditionalRawData = serializedAdditionalRawData;
    }

    // CUSTOM: Renamed.
    /// <summary> The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 64. </summary>
    public required string FunctionName
    {
        get => _name;
        set => _name = value;
    }

    // CUSTOM: Renamed
    /// <summary> A description of what the function does, used by the model to choose when and how to call the function. </summary>
    [CodeGenMember("Description")]
    public string FunctionDescription { get; set; }

    // CUSTOM: Changed type to BinarayData.
    /// <summary> Gets or sets the parameters. </summary>
    [CodeGenMember("Parameters")]
    public BinaryData FunctionParameters { get; set; }

    [CodeGenMember("Name")]
    private string _name;
}