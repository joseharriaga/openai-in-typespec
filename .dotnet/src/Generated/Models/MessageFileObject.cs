// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> A list of files attached to a `message`. </summary>
    internal partial class MessageFileObject
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

        /// <summary> Initializes a new instance of <see cref="MessageFileObject"/>. </summary>
        /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
        /// <param name="createdAt"> The Unix timestamp (in seconds) for when the message file was created. </param>
        /// <param name="messageId"> The ID of the [message](/docs/api-reference/messages) that the [File](/docs/api-reference/files) is attached to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="messageId"/> is null. </exception>
        internal MessageFileObject(string id, DateTimeOffset createdAt, string messageId)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(messageId, nameof(messageId));

            Id = id;
            CreatedAt = createdAt;
            MessageId = messageId;
        }

        /// <summary> Initializes a new instance of <see cref="MessageFileObject"/>. </summary>
        /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
        /// <param name="object"> The object type, which is always `thread.message.file`. </param>
        /// <param name="createdAt"> The Unix timestamp (in seconds) for when the message file was created. </param>
        /// <param name="messageId"> The ID of the [message](/docs/api-reference/messages) that the [File](/docs/api-reference/files) is attached to. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MessageFileObject(string id, MessageFileObjectObject @object, DateTimeOffset createdAt, string messageId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Object = @object;
            CreatedAt = createdAt;
            MessageId = messageId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MessageFileObject"/> for deserialization. </summary>
        internal MessageFileObject()
        {
        }

        /// <summary> The identifier, which can be referenced in API endpoints. </summary>
        public string Id { get; }
        /// <summary> The object type, which is always `thread.message.file`. </summary>
        public MessageFileObjectObject Object { get; } = MessageFileObjectObject.ThreadMessageFile;

        /// <summary> The Unix timestamp (in seconds) for when the message file was created. </summary>
        public DateTimeOffset CreatedAt { get; }
        /// <summary> The ID of the [message](/docs/api-reference/messages) that the [File](/docs/api-reference/files) is attached to. </summary>
        public string MessageId { get; }
    }
}
