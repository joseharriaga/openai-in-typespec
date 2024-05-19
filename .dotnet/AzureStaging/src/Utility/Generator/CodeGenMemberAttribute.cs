#nullable enable

using System;

namespace Azure.AI.OpenAI;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
internal class CodeGenMemberAttribute : CodeGenTypeAttribute
{
    public CodeGenMemberAttribute() : base(null)
    {
    }

    public CodeGenMemberAttribute(string originalName) : base(originalName)
    {
    }
}