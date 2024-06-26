// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary> Represents a data source configuration that will use an Azure CosmosDB resource. </summary>
    public partial class AzureCosmosDBChatDataSource : AzureChatDataSource
    {
        /// <summary> Initializes a new instance of <see cref="AzureCosmosDBChatDataSource"/>. </summary>
        /// <param name="internalParameters"> The parameter information to control the use of the Azure CosmosDB data source. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="internalParameters"/> is null. </exception>
        internal AzureCosmosDBChatDataSource(InternalAzureCosmosDBChatDataSourceParameters internalParameters)
        {
            Argument.AssertNotNull(internalParameters, nameof(internalParameters));

            Type = "azure_cosmos_db";
            InternalParameters = internalParameters;
        }
    }
}
