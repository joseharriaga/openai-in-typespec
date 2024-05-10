// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Internal.Models;

namespace OpenAI.Internal.VectorStores
{
    /// <summary> The UpdateVectorStoreRequest. </summary>
    internal partial class InternalUpdateVectorStoreRequest
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

        /// <summary> Initializes a new instance of <see cref="InternalUpdateVectorStoreRequest"/>. </summary>
        public InternalUpdateVectorStoreRequest()
        {
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="InternalUpdateVectorStoreRequest"/>. </summary>
        /// <param name="name"> The name of the vector store. </param>
        /// <param name="expiresAfter"></param>
        /// <param name="metadata"> Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal InternalUpdateVectorStoreRequest(string name, VectorStoreExpirationAfter expiresAfter, IDictionary<string, string> metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            ExpiresAfter = expiresAfter;
            Metadata = metadata;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The name of the vector store. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the expires after. </summary>
        public VectorStoreExpirationAfter ExpiresAfter { get; set; }
        /// <summary> Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format. Keys can be a maximum of 64 characters long and values can be a maxium of 512 characters long. </summary>
        public IDictionary<string, string> Metadata { get; set; }
    }
}
