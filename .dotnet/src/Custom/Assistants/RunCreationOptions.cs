using System;
using System.Collections.Generic;

// namespace OpenAI.Assistants;
namespace OpenAI.Internal.Models;

/// <summary>
/// Represents additional options available when creating a new <see cref="ThreadRun"/>.
/// </summary>
[CodeGenModel("CreateRunRequest")]
internal partial class RunCreationOptions
{
    /// <summary>
    /// A run-specific model name that will override the assistant's defined model. If not provided, the assistant's
    /// selection will be used.
    /// </summary>
    [CodeGenMember("model")]
    public string ModelOverride { get; init; }

    /// <summary>
    /// A run specific replacement for the assistant's default instructions that will override the assistant-level
    /// instructions. If not specified, the assistant's instructions will be used.
    /// </summary>
    [CodeGenMember("instructions")]
    public string InstructionsOverride { get; init; }

    /// <summary>
    /// Run-specific additional instructions that will be appended to the assistant-level instructions solely for this
    /// run. Unlike <see cref="InstructionsOverride"/>, the assistant's instructions are preserved and these additional
    /// instructions are concatenated.
    /// </summary>
    [CodeGenMember("additional_instructions")]
    public string AdditionalInstructions { get; init; }

    /// <summary>
    /// A run-specific collection of tool definitions that will override the assistant-level defaults. If not provided,
    /// the assistant's defined tools will be used. Available tools include:
    /// <para>
    /// <list type="bullet">
    /// <item>
    ///     <c>code_interpreter</c> - <see cref="CodeInterpreterToolDefinition"/> 
    ///     - works with data, math, and computer code
    /// </item>
    /// <item>
    ///     <c>retrieval</c> - <see cref="RetrievalToolDefinition"/> 
    ///     - dynamically enriches an Run's context with content from uploaded, indexed files
    /// </item>
    /// <item>
    ///     <c>function</c> - <see cref="FunctionToolDefinition"/>
    ///     - enables caller-provided custom functions for actions and enrichment
    /// </item>
    /// </list>
    /// </para>
    /// </summary>
    // public IList<ToolDefinition> ToolsOverride { get; } = new ChangeTrackingList<ToolDefinition>();
}