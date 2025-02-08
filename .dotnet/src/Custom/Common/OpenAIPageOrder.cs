using System;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI;

[CodeGenModel("PageOrder")]
[Experimental("OPENAI001")]
public readonly partial struct OpenAIPageOrder
{
    [CodeGenMember("Desc")]
    public static OpenAIPageOrder Descending { get; } = new(DescValue);

    [CodeGenMember("Asc")]
    public static OpenAIPageOrder Ascending { get; } = new(AscValue);
}