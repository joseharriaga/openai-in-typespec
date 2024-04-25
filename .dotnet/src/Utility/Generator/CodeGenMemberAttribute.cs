﻿#nullable enable

using System;

namespace OpenAI;

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