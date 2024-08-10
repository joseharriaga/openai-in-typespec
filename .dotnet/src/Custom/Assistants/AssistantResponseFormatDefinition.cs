using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OpenAI.Internal;
using OpenAI.Models;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantResponseFormatJsonSchema")]
[CodeGenSuppress(nameof(AssistantResponseFormatDefinition), typeof(InternalResponseFormatJsonSchemaJsonSchema))]
[CodeGenSuppress(nameof(AssistantResponseFormatDefinition), typeof(InternalAssistantResponseFormatJsonSchemaType), typeof(InternalResponseFormatJsonSchemaJsonSchema), typeof(IDictionary<string, BinaryData>))]
public partial class AssistantResponseFormatDefinition
{
    public required string Name
    {
        get => _internalSchema.Name;
        set => _internalSchema.Name = value;
    }

    public string Description
    {
        get => _internalSchema.Description;
        set => _internalSchema.Description = value;
    }

    public BinaryData JsonSchema
    {
        get => _internalSchema.Schema;
        set => _internalSchema.Schema = value;
    }

    public bool? UseStrictSchema
    {
        get => _internalSchema.Strict;
        set => _internalSchema.Strict = value;
    }

    [CodeGenMember("Type")]
    internal InternalAssistantResponseFormatJsonSchemaType _type
        = InternalAssistantResponseFormatJsonSchemaType.JsonSchema;

    [CodeGenMember("JsonSchema")]
    internal InternalResponseFormatJsonSchemaJsonSchema _internalSchema;

    [SetsRequiredMembers]
    public AssistantResponseFormatDefinition(string name)
    {
        Argument.AssertNotNull(name, nameof(name));

        _internalSchema = new(name);
    }

    public AssistantResponseFormatDefinition()
    {
        _internalSchema = new();
    }

    [SetsRequiredMembers]
    internal AssistantResponseFormatDefinition(InternalAssistantResponseFormatJsonSchemaType type, InternalResponseFormatJsonSchemaJsonSchema internalSchema, IDictionary<string, BinaryData> serializedAdditionalRawData)
    {
        _type = type;
        _internalSchema = internalSchema;
        SerializedAdditionalRawData = serializedAdditionalRawData;
    }
}