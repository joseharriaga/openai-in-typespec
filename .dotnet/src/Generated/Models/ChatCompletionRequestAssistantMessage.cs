// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> The ChatCompletionRequestAssistantMessage. </summary>
    internal partial class ChatCompletionRequestAssistantMessage
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ChatCompletionRequestAssistantMessage"/>. </summary>
        public ChatCompletionRequestAssistantMessage()
        {
            ToolCalls = new ChangeTrackingList<ChatCompletionMessageToolCall>();
        }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionRequestAssistantMessage"/>. </summary>
        /// <param name="content"> The contents of the assistant message. Required unless `tool_calls` or `function_call` is specified. </param>
        /// <param name="role"> The role of the messages author, in this case `assistant`. </param>
        /// <param name="name"> An optional name for the participant. Provides the model information to differentiate between participants of the same role. </param>
        /// <param name="toolCalls"></param>
        /// <param name="functionCall"> Deprecated and replaced by `tool_calls`. The name and arguments of a function that should be called, as generated by the model. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ChatCompletionRequestAssistantMessage(string content, ChatCompletionRequestAssistantMessageRole role, string name, IList<ChatCompletionMessageToolCall> toolCalls, ChatCompletionRequestAssistantMessageFunctionCall functionCall, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Content = content;
            Role = role;
            Name = name;
            ToolCalls = toolCalls;
            FunctionCall = functionCall;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The contents of the assistant message. Required unless `tool_calls` or `function_call` is specified. </summary>
        public string Content { get; set; }
        /// <summary> The role of the messages author, in this case `assistant`. </summary>
        public ChatCompletionRequestAssistantMessageRole Role { get; } = ChatCompletionRequestAssistantMessageRole.Assistant;

        /// <summary> An optional name for the participant. Provides the model information to differentiate between participants of the same role. </summary>
        public string Name { get; set; }
        /// <summary> Gets the tool calls. </summary>
        public IList<ChatCompletionMessageToolCall> ToolCalls { get; }
        /// <summary> Deprecated and replaced by `tool_calls`. The name and arguments of a function that should be called, as generated by the model. </summary>
        public ChatCompletionRequestAssistantMessageFunctionCall FunctionCall { get; set; }
    }
}
