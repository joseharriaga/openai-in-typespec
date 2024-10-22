using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeFunctionTool")]
public partial class ConversationFunctionTool : ConversationTool
{
    [CodeGenMember("Name")]
    private string _name;
    public required string Name
    {
        get => _name;
        set => _name = value;
    }

    [CodeGenMember("Description")]
    private string _description;

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    [CodeGenMember("Parameters")]
    private BinaryData _parameters;

    public BinaryData Parameters
    {
        get => _parameters;
        set => _parameters = value;
    }

    public ConversationFunctionTool() : base(ConversationToolKind.Function, null)
    {
    }

    [SetsRequiredMembers]
    public ConversationFunctionTool(string name)
        : this(name, null, null, ConversationToolKind.Function, null)
    {
        Argument.AssertNotNull(name, nameof(name));
    }

    [SetsRequiredMembers]
    internal ConversationFunctionTool(string name, string description, BinaryData parameters, ConversationToolKind kind, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(kind, serializedAdditionalRawData)
    {
        _name = name;
        _description = description;
        _parameters = parameters;
    }
}
