// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    /// <summary> The CreateFineTuningJobRequestIntegration. </summary>
    internal partial class CreateFineTuningJobRequestIntegration
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

        /// <summary> Initializes a new instance of <see cref="CreateFineTuningJobRequestIntegration"/>. </summary>
        /// <param name="wandb">
        /// The settings for your integration with Weights and Biases. This payload specifies the
        /// project that
        /// metrics will be sent to. Optionally, you can set an explicit display name for your run, add
        /// tags
        /// to your run, and set a default entity (team, username, etc) to be associated with your run.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="wandb"/> is null. </exception>
        public CreateFineTuningJobRequestIntegration(CreateFineTuningJobRequestIntegrationWandb wandb)
        {
            Argument.AssertNotNull(wandb, nameof(wandb));

            Wandb = wandb;
        }

        /// <summary> Initializes a new instance of <see cref="CreateFineTuningJobRequestIntegration"/>. </summary>
        /// <param name="type"> The type of integration to enable. Currently, only "wandb" (Weights and Biases) is supported. </param>
        /// <param name="wandb">
        /// The settings for your integration with Weights and Biases. This payload specifies the
        /// project that
        /// metrics will be sent to. Optionally, you can set an explicit display name for your run, add
        /// tags
        /// to your run, and set a default entity (team, username, etc) to be associated with your run.
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateFineTuningJobRequestIntegration(CreateFineTuningJobRequestIntegrationType type, CreateFineTuningJobRequestIntegrationWandb wandb, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Type = type;
            Wandb = wandb;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateFineTuningJobRequestIntegration"/> for deserialization. </summary>
        internal CreateFineTuningJobRequestIntegration()
        {
        }

        /// <summary> The type of integration to enable. Currently, only "wandb" (Weights and Biases) is supported. </summary>
        public CreateFineTuningJobRequestIntegrationType Type { get; } = CreateFineTuningJobRequestIntegrationType.Wandb;

        /// <summary>
        /// The settings for your integration with Weights and Biases. This payload specifies the
        /// project that
        /// metrics will be sent to. Optionally, you can set an explicit display name for your run, add
        /// tags
        /// to your run, and set a default entity (team, username, etc) to be associated with your run.
        /// </summary>
        public CreateFineTuningJobRequestIntegrationWandb Wandb { get; }
    }
}
