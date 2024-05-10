// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    /// <summary> The CreateFineTuningJobRequestIntegrationWandb. </summary>
    internal partial class CreateFineTuningJobRequestIntegrationWandb
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

        /// <summary> Initializes a new instance of <see cref="CreateFineTuningJobRequestIntegrationWandb"/>. </summary>
        /// <param name="project"> The name of the project that the new run will be created under. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="project"/> is null. </exception>
        public CreateFineTuningJobRequestIntegrationWandb(string project)
        {
            Argument.AssertNotNull(project, nameof(project));

            Project = project;
            Tags = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="CreateFineTuningJobRequestIntegrationWandb"/>. </summary>
        /// <param name="project"> The name of the project that the new run will be created under. </param>
        /// <param name="name"> A display name to set for the run. If not set, we will use the Job ID as the name. </param>
        /// <param name="entity">
        /// The entity to use for the run. This allows you to set the team or username of the WandB user that you would
        /// like associated with the run. If not set, the default entity for the registered WandB API key is used.
        /// </param>
        /// <param name="tags">
        /// A list of tags to be attached to the newly created run. These tags are passed through directly to WandB. Some
        /// default tags are generated by OpenAI: "openai/finetune", "openai/{base-model}", "openai/{ftjob-abcdef}".
        /// </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal CreateFineTuningJobRequestIntegrationWandb(string project, string name, string entity, IList<string> tags, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Project = project;
            Name = name;
            Entity = entity;
            Tags = tags;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="CreateFineTuningJobRequestIntegrationWandb"/> for deserialization. </summary>
        internal CreateFineTuningJobRequestIntegrationWandb()
        {
        }

        /// <summary> The name of the project that the new run will be created under. </summary>
        public string Project { get; }
        /// <summary> A display name to set for the run. If not set, we will use the Job ID as the name. </summary>
        public string Name { get; set; }
        /// <summary>
        /// The entity to use for the run. This allows you to set the team or username of the WandB user that you would
        /// like associated with the run. If not set, the default entity for the registered WandB API key is used.
        /// </summary>
        public string Entity { get; set; }
        /// <summary>
        /// A list of tags to be attached to the newly created run. These tags are passed through directly to WandB. Some
        /// default tags are generated by OpenAI: "openai/finetune", "openai/{base-model}", "openai/{ftjob-abcdef}".
        /// </summary>
        public IList<string> Tags { get; }
    }
}
