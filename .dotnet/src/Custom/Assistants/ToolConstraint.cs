using OpenAI.Internal.Models;
using System;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantsNamedToolChoice")]
public partial class ToolConstraint
{
    [CodeGenMember("Type")]
    private readonly object _type;
    private readonly BinaryData _innerTypeObject;
    private readonly string _predefinedValue;

    public static ToolConstraint None { get; } = new("none");
    public static ToolConstraint Auto { get; } = new("auto");
    public static ToolConstraint Required { get; }

    public ToolConstraint(ToolDefinition toolDefinition)
        : this(toolDefinition switch
        {
            CodeInterpreterToolDefinition _ => "code_interpreter",
            FileSearchToolDefinition _ => "file_search",
            FunctionToolDefinition functionDefinition => functionDefinition.FunctionName,
            _ => string.Empty,
        }, isInnerType: true)
    {}

    internal ToolConstraint(string value, bool isInnerType)
    {
        if (isInnerType)
        {
            _predefinedValue = value;
        }
        else
        {
            _innerTypeObject = BinaryData.FromObjectAsJson<dynamic>(new
            {
                type = value,
            });
        }
    }

    internal ToolConstraint(string prefinedValue)
    {
        _predefinedValue = prefinedValue;
    }
}
