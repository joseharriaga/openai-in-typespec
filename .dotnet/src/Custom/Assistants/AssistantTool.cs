using System;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantToolDefinition")]
public abstract partial class AssistantTool
{
    /// <summary>
    /// Creates a new instance of <see cref="CodeInterpreterTool"/>.
    /// </summary>
    /// <returns></returns>
    public static CodeInterpreterTool CreateCodeInterpreter()
        => new CodeInterpreterTool();

    /// <summary>
    /// Creates a new instance of <see cref="FileSearchTool"/>.
    /// </summary>
    /// <returns></returns>
    public static FileSearchTool CreateFileSearch()
        => new FileSearchTool();

    /// <summary>
    /// Creates a new instance of <see cref="FunctionTool"/>.
    /// </summary>
    /// <returns></returns>
    public static FunctionTool CreateFunction(string name, string description = null, BinaryData parameters = null)
        => new FunctionTool(name, description, parameters);
}
