using OpenAI.Assistants;
using System.ClientModel.Primitives;
using System.ClientModel;
using System.Threading.Tasks;

namespace OpenAI;

[CodeGenModel("ListOrder")]
public readonly partial struct ListOrder
{
    // CUSTOM: Rename members.

    [CodeGenMember("Asc")]
    public static ListOrder OldestFirst { get; } = new ListOrder(OldestFirstValue);
    [CodeGenMember("Desc")]
    public static ListOrder NewestFirst { get; } = new ListOrder(NewestFirstValue);
}