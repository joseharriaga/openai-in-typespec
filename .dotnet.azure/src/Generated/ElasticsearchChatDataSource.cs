// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat
{
    /// <summary> The ElasticsearchChatDataSource. </summary>
    public partial class ElasticsearchChatDataSource : AzureChatDataSource
    {
        /// <summary> Initializes a new instance of <see cref="ElasticsearchChatDataSource"/>. </summary>
        /// <param name="internalParameters"> The parameter information to control the use of the Elasticsearch data source. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="internalParameters"/> is null. </exception>
        internal ElasticsearchChatDataSource(InternalElasticsearchChatDataSourceParameters internalParameters)
        {
            Argument.AssertNotNull(internalParameters, nameof(internalParameters));

            Type = "elasticsearch";
            InternalParameters = internalParameters;
        }
    }
}
