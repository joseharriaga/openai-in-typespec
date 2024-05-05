// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Internal.Models
{
    /// <summary> Represents an `assistant` that can call the model and use tools. </summary>
    internal partial class AssistantObject
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

        /// <summary> Initializes a new instance of <see cref="AssistantObject"/>. </summary>
        /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
        /// <param name="createdAt"> The Unix timestamp (in seconds) for when the assistant was created. </param>
        /// <param name="name"> The name of the assistant. The maximum length is 256 characters. </param>
        /// <param name="description"> The description of the assistant. The maximum length is 512 characters. </param>
        /// <param name="model">
        /// ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to
        /// see all of your available models, or see our [Model overview](/docs/models/overview) for
        /// descriptions of them.
        /// </param>
        /// <param name="instructions"> The system instructions that the assistant uses. The maximum length is 32768 characters. </param>
        /// <param name="tools">
        /// A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant.
        /// Tools can be of types `code_interpreter`, `retrieval`, or `function`.
        /// </param>
        /// <param name="fileIds">
        /// A list of [file](/docs/api-reference/files) IDs attached to this assistant. There can be a
        /// maximum of 20 files attached to the assistant. Files are ordered by their creation date in
        /// ascending order.
        /// </param>
        /// <param name="metadata">
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
        /// additional information about the object in a structured format. Keys can be a maximum of 64
        /// characters long and values can be a maxium of 512 characters long.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="model"/>, <paramref name="tools"/> or <paramref name="fileIds"/> is null. </exception>
        internal AssistantObject(string id, DateTimeOffset createdAt, string name, string description, string model, string instructions, IEnumerable<BinaryData> tools, IEnumerable<string> fileIds, IReadOnlyDictionary<string, string> metadata)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(model, nameof(model));
            Argument.AssertNotNull(tools, nameof(tools));
            Argument.AssertNotNull(fileIds, nameof(fileIds));

            Id = id;
            CreatedAt = createdAt;
            Name = name;
            Description = description;
            Model = model;
            Instructions = instructions;
            Tools = tools.ToList();
            FileIds = fileIds.ToList();
            Metadata = metadata;
        }

        /// <summary> Initializes a new instance of <see cref="AssistantObject"/>. </summary>
        /// <param name="id"> The identifier, which can be referenced in API endpoints. </param>
        /// <param name="object"> The object type, which is always `assistant`. </param>
        /// <param name="createdAt"> The Unix timestamp (in seconds) for when the assistant was created. </param>
        /// <param name="name"> The name of the assistant. The maximum length is 256 characters. </param>
        /// <param name="description"> The description of the assistant. The maximum length is 512 characters. </param>
        /// <param name="model">
        /// ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to
        /// see all of your available models, or see our [Model overview](/docs/models/overview) for
        /// descriptions of them.
        /// </param>
        /// <param name="instructions"> The system instructions that the assistant uses. The maximum length is 32768 characters. </param>
        /// <param name="tools">
        /// A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant.
        /// Tools can be of types `code_interpreter`, `retrieval`, or `function`.
        /// </param>
        /// <param name="fileIds">
        /// A list of [file](/docs/api-reference/files) IDs attached to this assistant. There can be a
        /// maximum of 20 files attached to the assistant. Files are ordered by their creation date in
        /// ascending order.
        /// </param>
        /// <param name="metadata">
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
        /// additional information about the object in a structured format. Keys can be a maximum of 64
        /// characters long and values can be a maxium of 512 characters long.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AssistantObject(string id, AssistantObjectObject @object, DateTimeOffset createdAt, string name, string description, string model, string instructions, IReadOnlyList<BinaryData> tools, IReadOnlyList<string> fileIds, IReadOnlyDictionary<string, string> metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Object = @object;
            CreatedAt = createdAt;
            Name = name;
            Description = description;
            Model = model;
            Instructions = instructions;
            Tools = tools;
            FileIds = fileIds;
            Metadata = metadata;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="AssistantObject"/> for deserialization. </summary>
        internal AssistantObject()
        {
        }

        /// <summary> The identifier, which can be referenced in API endpoints. </summary>
        public string Id { get; }
        /// <summary> The object type, which is always `assistant`. </summary>
        public AssistantObjectObject Object { get; } = AssistantObjectObject.Assistant;

        /// <summary> The Unix timestamp (in seconds) for when the assistant was created. </summary>
        public DateTimeOffset CreatedAt { get; }
        /// <summary> The name of the assistant. The maximum length is 256 characters. </summary>
        public string Name { get; }
        /// <summary> The description of the assistant. The maximum length is 512 characters. </summary>
        public string Description { get; }
        /// <summary>
        /// ID of the model to use. You can use the [List models](/docs/api-reference/models/list) API to
        /// see all of your available models, or see our [Model overview](/docs/models/overview) for
        /// descriptions of them.
        /// </summary>
        public string Model { get; }
        /// <summary> The system instructions that the assistant uses. The maximum length is 32768 characters. </summary>
        public string Instructions { get; }
        /// <summary>
        /// A list of tool enabled on the assistant. There can be a maximum of 128 tools per assistant.
        /// Tools can be of types `code_interpreter`, `retrieval`, or `function`.
        /// <para>
        /// To assign an object to the element of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// <remarks>
        /// Supported types:
        /// <list type="bullet">
        /// <item>
        /// <description><see cref="AssistantToolsCode"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="AssistantToolsRetrieval"/></description>
        /// </item>
        /// <item>
        /// <description><see cref="AssistantToolsFunction"/></description>
        /// </item>
        /// </list>
        /// </remarks>
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
        public IReadOnlyList<BinaryData> Tools { get; }
        /// <summary>
        /// A list of [file](/docs/api-reference/files) IDs attached to this assistant. There can be a
        /// maximum of 20 files attached to the assistant. Files are ordered by their creation date in
        /// ascending order.
        /// </summary>
        public IReadOnlyList<string> FileIds { get; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing
        /// additional information about the object in a structured format. Keys can be a maximum of 64
        /// characters long and values can be a maxium of 512 characters long.
        /// </summary>
        public IReadOnlyDictionary<string, string> Metadata { get; }
    }
}
