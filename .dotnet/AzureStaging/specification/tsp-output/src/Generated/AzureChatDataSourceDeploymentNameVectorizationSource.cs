// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.OpenAI
{
    /// <summary> The AzureChatDataSourceDeploymentNameVectorizationSource. </summary>
    public partial class AzureChatDataSourceDeploymentNameVectorizationSource : AzureChatDataSourceVectorizationSource
    {
        /// <summary> Initializes a new instance of <see cref="AzureChatDataSourceDeploymentNameVectorizationSource"/>. </summary>
        /// <param name="deploymentName"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="deploymentName"/> is null. </exception>
        internal AzureChatDataSourceDeploymentNameVectorizationSource(string deploymentName)
        {
            Argument.AssertNotNull(deploymentName, nameof(deploymentName));

            Type = "deployment_name";
            DeploymentName = deploymentName;
        }

        /// <summary> Initializes a new instance of <see cref="AzureChatDataSourceDeploymentNameVectorizationSource"/>. </summary>
        /// <param name="type"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="deploymentName"></param>
        /// <param name="dimensions"></param>
        internal AzureChatDataSourceDeploymentNameVectorizationSource(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, string deploymentName, int? dimensions) : base(type, serializedAdditionalRawData)
        {
            DeploymentName = deploymentName;
            Dimensions = dimensions;
        }

        /// <summary> Initializes a new instance of <see cref="AzureChatDataSourceDeploymentNameVectorizationSource"/> for deserialization. </summary>
        internal AzureChatDataSourceDeploymentNameVectorizationSource()
        {
        }

        /// <summary> Gets the deployment name. </summary>
        public string DeploymentName { get; }
        /// <summary> Gets the dimensions. </summary>
        public int? Dimensions { get; }
    }
}
