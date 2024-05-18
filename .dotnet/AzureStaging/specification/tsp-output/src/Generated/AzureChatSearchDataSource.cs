// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    /// <summary> Represents a data source configuration that will use an Azure Search resource. </summary>
    public partial class AzureChatSearchDataSource : AzureChatDataSource
    {
        /// <summary> Initializes a new instance of <see cref="AzureChatSearchDataSource"/>. </summary>
        /// <param name="parameters"> The parameter information to control the use of the Azure Search data source. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        internal AzureChatSearchDataSource(AzureChatSearchDataSourceParameters parameters)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            Type = "azure_search";
            Parameters = parameters;
        }

        /// <summary> Initializes a new instance of <see cref="AzureChatSearchDataSource"/>. </summary>
        /// <param name="type"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="parameters"> The parameter information to control the use of the Azure Search data source. </param>
        internal AzureChatSearchDataSource(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, AzureChatSearchDataSourceParameters parameters) : base(type, serializedAdditionalRawData)
        {
            Parameters = parameters;
        }

        /// <summary> Initializes a new instance of <see cref="AzureChatSearchDataSource"/> for deserialization. </summary>
        internal AzureChatSearchDataSource()
        {
        }

        /// <summary> The parameter information to control the use of the Azure Search data source. </summary>
        public AzureChatSearchDataSourceParameters Parameters { get; }
    }
}
