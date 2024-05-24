using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantToolsFunction")]
[CodeGenSuppress(nameof(FunctionTool), typeof(InternalFunctionDefinition))]
public partial class FunctionTool : AssistantTool
{
    // CUSTOM: the visibility of the underlying function object is hidden to simplify the structure of the tool.

    [CodeGenMember("Function")]
    private readonly InternalFunctionDefinition _internalFunction;

    /// <inheritdoc cref="InternalFunctionDefinition.Name"/>
    public required string FunctionName
    {
        get => _internalFunction.Name;
        init => _internalFunction.Name = value;
    }

    /// <inheritdoc cref="InternalFunctionDefinition.Description"/>
    public string Description
    {
        get => _internalFunction.Description;
        init => _internalFunction.Description = value;
    }

    /// <inheritdoc cref="InternalFunctionDefinition.Parameters"/>
    public BinaryData Parameters
    {
        get => _internalFunction.Parameters;
        init => _internalFunction.Parameters = value;
    }

    /// <summary>
    /// Creates a new instance of <see cref="FunctionTool"/>. 
    /// </summary>
    [SetsRequiredMembers]
    public FunctionTool(string name, string description = null, BinaryData parameters = null)
        : this("function", null, new InternalFunctionDefinition(description, name, parameters, null))
    {}

    /// <summary>
    /// Creates a new instance of <see cref="FunctionTool"/>. 
    /// </summary>
    public FunctionTool()
        : base("function", null)
    {
        _internalFunction = new InternalFunctionDefinition();
    }

    [SetsRequiredMembers]
    internal FunctionTool(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalFunctionDefinition function)
        : base(type, serializedAdditionalRawData)
    {
        _internalFunction = function;
    }
}
