// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> The ChatCompletionFunctions. </summary>
    internal partial class ChatCompletionFunctions
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

        /// <summary> Initializes a new instance of <see cref="ChatCompletionFunctions"/>. </summary>
        /// <param name="name">
        /// The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and
        /// dashes, with a maximum length of 64.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public ChatCompletionFunctions(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Parameters = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionFunctions"/>. </summary>
        /// <param name="description">
        /// A description of what the function does, used by the model to choose when and how to call the
        /// function.
        /// </param>
        /// <param name="name">
        /// The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and
        /// dashes, with a maximum length of 64.
        /// </param>
        /// <param name="parameters"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ChatCompletionFunctions(string description, string name, IDictionary<string, BinaryData> parameters, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Description = description;
            Name = name;
            Parameters = parameters;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ChatCompletionFunctions"/> for deserialization. </summary>
        internal ChatCompletionFunctions()
        {
        }

        /// <summary>
        /// A description of what the function does, used by the model to choose when and how to call the
        /// function.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The name of the function to be called. Must be a-z, A-Z, 0-9, or contain underscores and
        /// dashes, with a maximum length of 64.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gets the parameters
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
        public IDictionary<string, BinaryData> Parameters { get; }
    }
}
