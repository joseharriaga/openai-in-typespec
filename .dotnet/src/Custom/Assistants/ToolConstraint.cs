using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantsNamedToolChoice")]
public partial class ToolConstraint
{
    private IDictionary<string, BinaryData> _serializedAdditionalRawData;

    /// <summary>
    /// Gets the dictionary containing additional raw data to serialize.
    /// </summary>
    /// <remarks>
    /// NOTE: This mechanism added for subclients pending availability of a C# language feature.
    ///       It is subject to change and not intended for stable use.
    /// </remarks>
    [Experimental("OPENAI002")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IDictionary<string, BinaryData> SerializedAdditionalRawData
        => _serializedAdditionalRawData ??= new ChangeTrackingDictionary<string, BinaryData>();

    private readonly string _plainTextValue;
    [CodeGenMember("Type")]
    private readonly string _objectType;
    private readonly string _objectFunctionName;

    public static ToolConstraint None { get; } = new("none");
    public static ToolConstraint Auto { get; } = new("auto");
    public static ToolConstraint Required { get; } = new("required");

    public ToolConstraint(ToolDefinition toolDefinition)
    {
        switch (toolDefinition)
        {
            case CodeInterpreterToolDefinition:
                _objectType = "code_interpreter";
                break;
            case FileSearchToolDefinition:
                _objectType = "file_search";
                break;
            case FunctionToolDefinition functionTool:
                _objectType = "function";
                _objectFunctionName = functionTool.FunctionName;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(toolDefinition));
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
