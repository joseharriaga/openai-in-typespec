using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Assistants;

[Experimental("OPENAI001")]
internal partial class InternalAssistantResponseFormatPlainTextNoObject : AssistantResponseFormat
{
    public string Value { get; set; }

    public InternalAssistantResponseFormatPlainTextNoObject(string value)
    {
        Value = value;
    }
}