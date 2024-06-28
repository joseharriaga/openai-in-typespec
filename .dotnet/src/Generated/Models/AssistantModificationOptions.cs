// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class AssistantModificationOptions
    {
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        public AssistantModificationOptions()
        {
            DefaultTools = new ChangeTrackingList<ToolDefinition>();
            Metadata = new ChangeTrackingDictionary<string, string>();
        }

        internal AssistantModificationOptions(string model, string name, string description, string instructions, IList<ToolDefinition> defaultTools, ToolResources toolResources, IDictionary<string, string> metadata, float? temperature, float? nucleusSamplingFactor, AssistantResponseFormat responseFormat, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Model = model;
            Name = name;
            Description = description;
            Instructions = instructions;
            DefaultTools = defaultTools;
            ToolResources = toolResources;
            Metadata = metadata;
            Temperature = temperature;
            NucleusSamplingFactor = nucleusSamplingFactor;
            ResponseFormat = responseFormat;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public IDictionary<string, string> Metadata { get; }
        public float? Temperature { get; set; }
    }
}
