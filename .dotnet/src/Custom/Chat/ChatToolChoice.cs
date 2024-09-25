using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

/// <summary>
///     The manner in which the model chooses which tool (if any) to call.
///     <list>
///         <item>
///             Call <see cref="CreateAutoChoice()"/> to create a <see cref="ChatToolChoice"/> indicating that the
///             model can freely pick between generating a message or calling one or more tools.
///         </item>
///         <item>
///             Call <see cref="CreateNoneChoice()"/> to create a <see cref="ChatToolChoice"/> indicating that the
///             model must not call any tools and that instead it must generate a message.
///         </item>
///         <item>
///             Call <see cref="CreateRequiredChoice()"/> to create a <see cref="ChatToolChoice"/> indicating that the
///             model must call one or more tools.
///         </item>
///         <item>
///             Call <see cref="CreateFunctionChoice(string)"/> to create a <see cref="ChatToolChoice"/> indicating
///             that the model must call the specified function.
///         </item>
///     </list>
/// </summary>
[CodeGenModel("ClientOnlyChatCompletionToolChoiceOption")]
public abstract partial class ChatToolChoice
{
    /// <summary>
    ///     Creates a new <see cref="ChatToolChoice"/> indicating that the model can freely pick between generating a
    ///     message or calling one or more tools.
    /// </summary>
    public static ChatToolChoice CreateAutoChoice()
        => new InternalClientOnlyChatCompletionToolChoiceOptionPredefined(
            InternalClientOnlyChatCompletionToolChoiceOptionPredefinedValue.Auto);

    /// <summary>
    ///     Creates a new <see cref="ChatToolChoice"/> indicating that the model must not call any tools and that
    ///     instead it must generate a message.
    /// </summary>
    public static ChatToolChoice CreateNoneChoice()
        => new InternalClientOnlyChatCompletionToolChoiceOptionPredefined(
            InternalClientOnlyChatCompletionToolChoiceOptionPredefinedValue.None);

    /// <summary>
    ///     Creates a new <see cref="ChatToolChoice"/> indicating that the model must call one or more tools.
    /// </summary>
    public static ChatToolChoice CreateRequiredChoice()
        => new InternalClientOnlyChatCompletionToolChoiceOptionPredefined(
            InternalClientOnlyChatCompletionToolChoiceOptionPredefinedValue.Required);

    /// <summary>
    ///     Creates a new <see cref="ChatToolChoice"/> indicating that the model must call the specified function.
    /// </summary>
    /// <exception cref="ArgumentNullException"> <paramref name="functionName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="functionName"/> is an empty string, and was expected to be non-empty. </exception>
    public static ChatToolChoice CreateFunctionChoice(string functionName)
    {
        Argument.AssertNotNullOrEmpty(functionName, nameof(functionName));
        return new InternalClientOnlyChatCompletionToolChoiceOptionNamed(
            new InternalChatCompletionNamedToolChoiceFunction(functionName));
    }

    internal ChatToolChoice(IDictionary<string, BinaryData> serializedAdditionalRawData)
    {
        SerializedAdditionalRawData = serializedAdditionalRawData;
    }

    internal ChatToolChoice()
    { }
}
