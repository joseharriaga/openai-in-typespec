namespace OpenAI;

[CodeGenModel("ListOrder")]
public readonly partial struct ListOrder
{
    [CodeGenMember("Asc")]
    public static ListOrder OldestFirst { get; } = new ListOrder(OldestFirstValue);
    [CodeGenMember("Desc")]
    public static ListOrder NewestFirst { get; } = new ListOrder(NewestFirstValue);
}