using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

/// <summary>
/// A requested invocation of a defined function tool, needed by an Assistants API run to continue.
/// </summary>
[CodeGenModel("RunToolCallObject")]
public partial class RequiredFunctionToolCall : RequiredToolCall
{
    // CUSTOM:
    //  - 'Type' is hidden, as the object discriminator does not carry additional value to the caller in the context
    //    of a strongly-typed object model
    //  - 'Function' is hidden and its constituent 'Name' and 'Arguments' members are promoted to direct visibility
    
    [CodeGenMember("Type")]
    private readonly object _type;
    [CodeGenMember("Function")]
    internal readonly InternalRunToolCallObjectFunction _internalFunction;

    /// <inheritdoc cref="InternalRunToolCallObjectFunction.Name"/>
    public string FunctionName => _internalFunction.Name;

    /// <inheritdoc cref="InternalRunToolCallObjectFunction.Arguments"/>
    public string FunctionArguments => _internalFunction.Arguments;

}