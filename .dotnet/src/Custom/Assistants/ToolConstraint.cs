using System;
using System.Collections.Generic;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantsNamedToolChoice")]
public partial class ToolConstraint
{
    private readonly string _plainTextValue;
    [CodeGenMember("Type")]
    private readonly string _objectType;
    private readonly string _objectFunctionName;
    private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

    public static ToolConstraint None { get; } = new("none");
    public static ToolConstraint Auto { get; } = new("auto");
    public static ToolConstraint Required { get; } = new("required");

    public ToolConstraint(AssistantTool tool)
    {
        switch (tool)
        {
            case CodeInterpreterTool:
                _objectType = "code_interpreter";
                break;
            case FileSearchTool:
                _objectType = "file_search";
                break;
            case FunctionTool functionTool:
                _objectType = "function";
                _objectFunctionName = functionTool.FunctionName;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(tool));
        }
        _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
    }

    internal ToolConstraint(string plainTextValue)
        : this(plainTextValue, null, null, null)
    { }

    internal ToolConstraint(string plainTextValue, string objectType, string objectFunctionName, IDictionary<string, BinaryData> serializedAdditionalRawData)
    {
        _plainTextValue = plainTextValue;
        _objectType = objectType;
        _objectFunctionName = objectFunctionName;
        _serializedAdditionalRawData = serializedAdditionalRawData ?? new ChangeTrackingDictionary<string, BinaryData>();
    }
}
