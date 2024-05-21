using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantToolsFunction")]
[CodeGenSuppress(nameof(FunctionToolDefinition), typeof(FunctionDefinition))]
public partial class FunctionToolDefinition : ToolDefinition
{
    // CUSTOM: the visibility of the underlying function object is hidden to simplify the structure of the tool.

    [CodeGenMember("Function")]
    private readonly FunctionDefinition _internalFunction;

    /// <inheritdoc cref="FunctionDefinition.Name"/>
    public required string FunctionName
    {
        get => _internalFunction.Name;
        init => _internalFunction.Name = value;
    }

    /// <inheritdoc cref="FunctionDefinition.Description"/>
    public string Description
    {
        get => _internalFunction.Description;
        init => _internalFunction.Description = value;
    }

    /// <inheritdoc cref="FunctionDefinition.Parameters"/>
    public BinaryData Parameters
    {
        get => _internalFunction.Parameters;
        init => _internalFunction.Parameters = value;
    }

    /// <summary>
    /// Creates a new instance of <see cref="FunctionToolDefinition"/>. 
    /// </summary>
    [SetsRequiredMembers]
    public FunctionToolDefinition(string name, string description = null, BinaryData parameters = null)
        : this("function", null, new FunctionDefinition(description, name, parameters, null))
    {}

    /// <summary>
    /// Creates a new instance of <see cref="FunctionToolDefinition"/>. 
    /// </summary>
    public FunctionToolDefinition()
        : base("function", null)
    {
        _internalFunction = new FunctionDefinition();
    }

    [SetsRequiredMembers]
    internal FunctionToolDefinition(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, FunctionDefinition function)
        : base(type, serializedAdditionalRawData)
    {
        _internalFunction = function;
    }
}
