using System;

namespace OpenAI.Assistants;

[CodeGenModel("AssistantToolDefinition")]
public abstract partial class ToolDefinition
{   
    public static CodeInterpreterToolDefinition CreateCodeInterpreter()
        => new CodeInterpreterToolDefinition();
    public static FileSearchToolDefinition CreateFileSearch(int? maxResults = null)
    {
        return new FileSearchToolDefinition()
        {
            MaxResults = maxResults
        };
    }
    public static FunctionToolDefinition CreateFunction(string name, string description = null, BinaryData parameters = null, bool? useStrictSchema = null)
        => new FunctionToolDefinition(name)
        {
            Description = description,
            Parameters = parameters,
            UseStrictSchema = useStrictSchema,
        };

    protected ToolDefinition(string type)
    {
        Type = type;
    }
}
