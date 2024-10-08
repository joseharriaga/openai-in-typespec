// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    internal partial class FineTuningIntegrationWandbWandb
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        internal FineTuningIntegrationWandbWandb(string project)
        {
            Argument.AssertNotNull(project, nameof(project));

            Project = project;
            Tags = new ChangeTrackingList<string>();
        }

        internal FineTuningIntegrationWandbWandb(string project, string name, string entity, IReadOnlyList<string> tags, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Project = project;
            Name = name;
            Entity = entity;
            Tags = tags;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal FineTuningIntegrationWandbWandb()
        {
        }

        public string Project { get; }
        public string Name { get; }
        public string Entity { get; }
        public IReadOnlyList<string> Tags { get; }
    }
}
