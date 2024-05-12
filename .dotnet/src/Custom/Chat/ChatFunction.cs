using System;

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
    /// Creates a new instance of <see cref="FunctionChatTool"/>.
    /// </summary>
    /// <param name="functionName"> The <c>name</c> of the function. </param>
    /// <param name="description"> The <c>description</c> of the function. </param>
    /// <param name="parameters"> The <c>parameters</c> into the function, in JSON Schema format. </param>
    public ChatFunction(string functionName, string description = null, BinaryData parameters = null)
    {
        Argument.AssertNotNull(functionName, nameof(functionName));

        FunctionName = functionName;
        Description = description;
        Parameters = parameters;
    }

    // CUSTOM: Renamed.
    /// <summary> The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 64. </summary>
    [CodeGenMember("Name")]
    public string FunctionName { get; }

    // CUSTOM: Changed type to BinarayData.
    /// <summary> Gets or sets the parameters. </summary>
    [CodeGenMember("Parameters")]
    public BinaryData Parameters { get; set; }
}