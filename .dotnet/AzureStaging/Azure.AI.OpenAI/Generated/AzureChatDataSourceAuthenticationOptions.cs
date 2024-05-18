// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;
using OpenAI.Chat;

namespace Azure.AI.OpenAI
{
    /// <summary>
    /// The AzureChatDataSourceAuthenticationOptions.
    /// Please note <see cref="AzureChatDataSourceAuthenticationOptions"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="AzureChatDataSourceAccessTokenAuthenticationOptions"/>, <see cref="AzureChatDataSourceApiKeyAuthenticationOptions"/>, <see cref="AzureChatDataSourceConnectionStringAuthenticationOptions"/>, <see cref="AzureChatDataSourceEncodedApiKeyAuthenticationOptions"/>, <see cref="AzureChatDataSourceKeyAndKeyIdAuthenticationOptions"/>, <see cref="AzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions"/> and <see cref="AzureChatDataSourceUserAssignedManagedIdentityAuthenticationOptions"/>.
    /// </summary>
    public abstract partial class AzureChatDataSourceAuthenticationOptions
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
        private protected IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="AzureChatDataSourceAuthenticationOptions"/>. </summary>
        protected AzureChatDataSourceAuthenticationOptions()
        {
        }

        /// <summary> Initializes a new instance of <see cref="AzureChatDataSourceAuthenticationOptions"/>. </summary>
        /// <param name="type"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AzureChatDataSourceAuthenticationOptions(string type, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Type = type;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets or sets the type. </summary>
        internal string Type { get; set; }
    }
}
