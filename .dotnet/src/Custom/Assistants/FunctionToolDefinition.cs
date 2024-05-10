using System;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantToolsFunction")]
public partial class FunctionToolDefinition : ToolDefinition
{
    [CodeGenMember("function")]
    private readonly FunctionDefinition _internalFunction;


    /// <inheritdoc cref="FunctionDefinition.Name"/>
    public string Name
    {
        get => _internalFunction.Name;
        set => _internalFunction.Name = value;
    }

    /// <inheritdoc cref="FunctionDefinition.Description"/>
    public string Description
    {
        get => _internalFunction.Description;
        set => _internalFunction.Description = value;
    }

    /// <inheritdoc cref="FunctionDefinition.Parameters"/>
    public BinaryData Parameters
    {
        get => _internalFunction.Parameters;
        set => _internalFunction.Parameters = value;
    }

    /// <summary>
    /// Creates a new instance of <see cref="FunctionToolDefinition"/>. 
    /// </summary>
    public FunctionToolDefinition(string name, string description = null, BinaryData parameters = null)
        : this(new FunctionDefinition(description, name, parameters, serializedAdditionalRawData: null))
    {}
}
