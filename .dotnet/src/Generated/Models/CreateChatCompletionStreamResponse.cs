// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace OpenAI.Internal.Models
{
    /// <summary> Represents a streamed chunk of a chat completion response returned by model, based on the provided input. </summary>
    internal partial class CreateChatCompletionStreamResponse
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

        /// <summary> Initializes a new instance of <see cref="CreateChatCompletionStreamResponse"/>. </summary>
        /// <param name="id"> A unique identifier for the chat completion. Each chunk has the same ID. </param>
        /// <param name="choices">
        /// A list of chat completion choices. Can contain more than one elements if `n` is greater than 1. Can also be empty for the
        /// last chunk if you set `stream_options: {"include_usage": true}`.
        /// </param>
        /// <param name="created"> The Unix timestamp (in seconds) of when the chat completion was created. Each chunk has the same timestamp. </param>
        /// <param name="model"> The model to generate the completion. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="choices"/> or <paramref name="model"/> is null. </exception>
        internal CreateChatCompletionStreamResponse(string id, IEnumerable<CreateChatCompletionStreamResponseChoice> choices, DateTimeOffset created, string model)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(choices, nameof(choices));
            Argument.AssertNotNull(model, nameof(model));

            Id = id;
            Choices = choices.ToList();
            Created = created;
            Model = model;
        }

        /// <summary> Initializes a new instance of <see cref="CreateChatCompletionStreamResponse"/>. </summary>
        /// <param name="id"> A unique identifier for the chat completion. Each chunk has the same ID. </param>
        /// <param name="choices">
        /// A list of chat completion choices. Can contain more than one elements if `n` is greater than 1. Can also be empty for the
        /// last chunk if you set `stream_options: {"include_usage": true}`.
        /// </param>
        /// <param name="created"> The Unix timestamp (in seconds) of when the chat completion was created. Each chunk has the same timestamp. </param>
        /// <param name="model"> The model to generate the completion. </param>
        /// <param name="systemFingerprint">
        /// This fingerprint represents the backend configuration that the model runs with.
        /// Can be used in conjunction with the `seed` request parameter to understand when backend changes have been made that might impact determinism.
        /// </param>
        /// <param name="object"> The object type, which is always `chat.completion.chunk`. </param>
        /// <param name="usage">
        /// An optional field that will only be present when you set `stream_options: {"include_usage": true}` in your request.
        /// When present, it contains a null value except for the last chunk which contains the token usage statistics for the entire request.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateChatCompletionStreamResponse(string id, IReadOnlyList<CreateChatCompletionStreamResponseChoice> choices, DateTimeOffset created, string model, string systemFingerprint, string @object, CreateChatCompletionStreamResponseUsage usage, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Choices = choices;
            Created = created;
            Model = model;
            SystemFingerprint = systemFingerprint;
            Object = @object;
            Usage = usage;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateChatCompletionStreamResponse"/> for deserialization. </summary>
        internal CreateChatCompletionStreamResponse()
        {
        }

        /// <summary> A unique identifier for the chat completion. Each chunk has the same ID. </summary>
        public string Id { get; }
        /// <summary>
        /// A list of chat completion choices. Can contain more than one elements if `n` is greater than 1. Can also be empty for the
        /// last chunk if you set `stream_options: {"include_usage": true}`.
        /// </summary>
        public IReadOnlyList<CreateChatCompletionStreamResponseChoice> Choices { get; }
        /// <summary> The Unix timestamp (in seconds) of when the chat completion was created. Each chunk has the same timestamp. </summary>
        public DateTimeOffset Created { get; }
        /// <summary> The model to generate the completion. </summary>
        public string Model { get; }
        /// <summary>
        /// This fingerprint represents the backend configuration that the model runs with.
        /// Can be used in conjunction with the `seed` request parameter to understand when backend changes have been made that might impact determinism.
        /// </summary>
        public string SystemFingerprint { get; }
        /// <summary> The object type, which is always `chat.completion.chunk`. </summary>
        public string Object { get; } = "chat.completion.chunk";

        /// <summary>
        /// An optional field that will only be present when you set `stream_options: {"include_usage": true}` in your request.
        /// When present, it contains a null value except for the last chunk which contains the token usage statistics for the entire request.
        /// </summary>
        public CreateChatCompletionStreamResponseUsage Usage { get; }
    }
}

