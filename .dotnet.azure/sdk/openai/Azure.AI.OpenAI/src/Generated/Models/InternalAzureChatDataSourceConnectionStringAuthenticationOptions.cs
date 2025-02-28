// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.AI.OpenAI;

namespace Azure.AI.OpenAI.Chat
{
    internal partial class InternalAzureChatDataSourceConnectionStringAuthenticationOptions : DataSourceAuthentication
    {
        public InternalAzureChatDataSourceConnectionStringAuthenticationOptions(string connectionString) : base("connection_string")
        {
            Argument.AssertNotNull(connectionString, nameof(connectionString));

            ConnectionString = connectionString;
        }

        internal InternalAzureChatDataSourceConnectionStringAuthenticationOptions(string @type, IDictionary<string, BinaryData> additionalBinaryDataProperties, string connectionString) : base(@type, additionalBinaryDataProperties)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }
    }
}
