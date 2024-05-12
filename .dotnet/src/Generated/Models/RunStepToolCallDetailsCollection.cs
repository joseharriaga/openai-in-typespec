// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Assistants
{
    /// <summary> Details of the tool call. </summary>
    public partial class RunStepToolCallDetailsCollection : RunStepDetails
    {
        /// <summary> Initializes a new instance of <see cref="RunStepToolCallDetailsCollection"/>. </summary>
        /// <param name="toolCalls">
        /// An array of tool calls the run step was involved in. These can be associated with one of three types of tools: `code_interpreter`, `file_search`, or `function`.
        /// Please note <see cref="RunStepToolCallDetails"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="RunStepCodeInterpreterToolCallDetails"/>, <see cref="RunStepFileSearchToolCallDetails"/> and <see cref="RunStepFunctionToolCallDetails"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="toolCalls"/> is null. </exception>
        internal RunStepToolCallDetailsCollection(IEnumerable<RunStepToolCallDetails> toolCalls)
        {
            Argument.AssertNotNull(toolCalls, nameof(toolCalls));

            Type = "tool_calls";
            ToolCalls = toolCalls.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="RunStepToolCallDetailsCollection"/>. </summary>
        /// <param name="type"> The discriminated type identifier for the details object. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="toolCalls">
        /// An array of tool calls the run step was involved in. These can be associated with one of three types of tools: `code_interpreter`, `file_search`, or `function`.
        /// Please note <see cref="RunStepToolCallDetails"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="RunStepCodeInterpreterToolCallDetails"/>, <see cref="RunStepFileSearchToolCallDetails"/> and <see cref="RunStepFunctionToolCallDetails"/>.
        /// </param>
        internal RunStepToolCallDetailsCollection(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, IReadOnlyList<RunStepToolCallDetails> toolCalls) : base(type, serializedAdditionalRawData)
        {
            ToolCalls = toolCalls;
        }

        /// <summary> Initializes a new instance of <see cref="RunStepToolCallDetailsCollection"/> for deserialization. </summary>
        internal RunStepToolCallDetailsCollection()
        {
        }

        /// <summary>
        /// An array of tool calls the run step was involved in. These can be associated with one of three types of tools: `code_interpreter`, `file_search`, or `function`.
        /// Please note <see cref="RunStepToolCallDetails"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="RunStepCodeInterpreterToolCallDetails"/>, <see cref="RunStepFileSearchToolCallDetails"/> and <see cref="RunStepFunctionToolCallDetails"/>.
        /// </summary>
        public IReadOnlyList<RunStepToolCallDetails> ToolCalls { get; }
    }
}
