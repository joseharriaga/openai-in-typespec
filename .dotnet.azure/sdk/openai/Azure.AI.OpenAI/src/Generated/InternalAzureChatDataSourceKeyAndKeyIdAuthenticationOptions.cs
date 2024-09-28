// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary> The AzureChatDataSourceKeyAndKeyIdAuthenticationOptions. </summary>
    internal partial class InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions : DataSourceAuthentication
    {
        /// <summary> Initializes a new instance of <see cref="InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions"/>. </summary>
        /// <param name="key"></param>
        /// <param name="keyId"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="keyId"/> is null. </exception>
        public InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions(string key, string keyId)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(keyId, nameof(keyId));

            Type = "key_and_key_id";
            Key = key;
            KeyId = keyId;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions"/>. </summary>
        /// <param name="type"> Discriminator. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="key"></param>
        /// <param name="keyId"></param>
        internal InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, string key, string keyId) : base(type, serializedAdditionalRawData)
        {
            Key = key;
            KeyId = keyId;
        }

        /// <summary> Initializes a new instance of <see cref="InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions"/> for deserialization. </summary>
        internal InternalAzureChatDataSourceKeyAndKeyIdAuthenticationOptions()
        {
        }

        /// <summary> Gets the key. </summary>
        internal string Key { get; set; }
        /// <summary> Gets the key id. </summary>
        internal string KeyId { get; set; }
    }
}



