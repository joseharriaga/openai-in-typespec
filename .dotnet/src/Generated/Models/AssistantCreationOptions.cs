// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    public partial class AssistantCreationOptions
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }

        internal AssistantCreationOptions(string model, string name, string description, string instructions, IList<ToolDefinition> tools, ToolResources toolResources, IDictionary<string, string> metadata, float? temperature, float? nucleusSamplingFactor, AssistantResponseFormat responseFormat, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Model = model;
            Name = name;
            Description = description;
            Instructions = instructions;
            Tools = tools;
            ToolResources = toolResources;
            Metadata = metadata;
            Temperature = temperature;
            NucleusSamplingFactor = nucleusSamplingFactor;
            ResponseFormat = responseFormat;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public IDictionary<string, string> Metadata { get; }
        public float? Temperature { get; set; }
    }
}
