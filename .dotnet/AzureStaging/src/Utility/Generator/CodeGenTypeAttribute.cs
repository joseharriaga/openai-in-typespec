#nullable enable

using System;

namespace Azure.AI.OpenAI;

[AttributeUsage(AttributeTargets.Class)]
internal class CodeGenTypeAttribute : Attribute
{
    public string? OriginalName { get; }

    public CodeGenTypeAttribute(string? originalName)
    {
        OriginalName = originalName;
    }
}