using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OpenAI.Internal;
using OpenAI.Models;

namespace OpenAI.Chat;

[CodeGenModel("ChatResponseFormatJsonSchema")]
[CodeGenSuppress(nameof(ChatResponseFormatDefinition), typeof(InternalResponseFormatJsonSchemaJsonSchema))]
[CodeGenSuppress(nameof(ChatResponseFormatDefinition), typeof(InternalChatResponseFormatJsonSchemaType), typeof(InternalResponseFormatJsonSchemaJsonSchema), typeof(IDictionary<string, BinaryData>))]
public partial class ChatResponseFormatDefinition
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
    internal InternalChatResponseFormatJsonSchemaType _type
        = InternalChatResponseFormatJsonSchemaType.JsonSchema;

    [CodeGenMember("JsonSchema")]
    internal InternalResponseFormatJsonSchemaJsonSchema _internalSchema;

    [SetsRequiredMembers]
    public ChatResponseFormatDefinition(string name)
    {
        Argument.AssertNotNull(name, nameof(name));

        _internalSchema = new(name);
    }

    public ChatResponseFormatDefinition()
    {
        _internalSchema = new();
    }

    [SetsRequiredMembers]
    internal ChatResponseFormatDefinition(InternalChatResponseFormatJsonSchemaType type, InternalResponseFormatJsonSchemaJsonSchema internalSchema, IDictionary<string, BinaryData> serializedAdditionalRawData)
    {
        _type = type;
        _internalSchema = internalSchema;
        SerializedAdditionalRawData = serializedAdditionalRawData;
    }
}