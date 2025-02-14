// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.AI.OpenAI;

namespace Azure.AI.OpenAI.Chat
{
    internal partial class InternalAzureChatDataSourceUsernameAndPasswordAuthenticationOptions : DataSourceAuthentication
    {
        public InternalAzureChatDataSourceUsernameAndPasswordAuthenticationOptions(string username, string password) : base("username_and_password")
        {
            Argument.AssertNotNull(username, nameof(username));
            Argument.AssertNotNull(password, nameof(password));

            Username = username;
            Password = password;
        }

        internal InternalAzureChatDataSourceUsernameAndPasswordAuthenticationOptions(string @type, IDictionary<string, BinaryData> additionalBinaryDataProperties, string username, string password) : base(@type, additionalBinaryDataProperties)
        {
            Username = username;
            Password = password;
        }

        internal string Username { get; set; }

        internal string Password { get; set; }
    }
}
