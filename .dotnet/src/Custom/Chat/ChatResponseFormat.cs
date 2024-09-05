using OpenAI.Internal;
using System;

namespace OpenAI.Chat;

/// <summary>
///     The format that the model should output.
///     <list>
///         <item>
///             Call <see cref="CreateTextFormat()"/> to create a <see cref="ChatResponseFormat"/> requesting plain
///             text.
///         </item>
///         <item>
///             Call <see cref="CreateJsonObjectFormat()"/> to create a <see cref="ChatResponseFormat"/> requesting
///             valid JSON, a.k.a. JSON mode.
///         </item>
///         <item>
///             Call <see cref="CreateJsonSchemaFormat(string, BinaryData, string, bool?)"/> to create a
///             <see cref="ChatResponseFormat"/> requesting adherence to the specified JSON schema,
///             a.k.a. structured outputs.
///         </item>
///     </list>
/// </summary>
[CodeGenModel("ChatResponseFormat")]
public abstract partial class ChatResponseFormat
{
    /// <summary> Creates a new <see cref="ChatResponseFormat"/> requesting plain text. </summary>
    public static ChatResponseFormat CreateTextFormat() => new InternalChatResponseFormatText();

    /// <summary> Creates a new <see cref="ChatResponseFormat"/> requesting valid JSON, a.k.a. JSON mode. </summary>
    public static ChatResponseFormat CreateJsonObjectFormat() => new InternalChatResponseFormatJsonObject();

    /// <summary>
    ///     Creates a new <see cref="ChatResponseFormat"/> requesting adherence to the specified JSON schema,
    ///     a.k.a. structured outputs.
    /// </summary>
    /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="jsonSchema"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
    public static ChatResponseFormat CreateJsonSchemaFormat(string name, BinaryData jsonSchema, string description = null, bool? strictSchemaEnabled = null)
    {
        Argument.AssertNotNullOrEmpty(name, nameof(name));
        Argument.AssertNotNull(jsonSchema, nameof(jsonSchema));

        InternalResponseFormatJsonSchemaJsonSchema internalSchema = new(
            description,
            name,
            jsonSchema,
            strictSchemaEnabled,
            serializedAdditionalRawData: null);

        return new InternalChatResponseFormatJsonSchema(internalSchema);
    }
}