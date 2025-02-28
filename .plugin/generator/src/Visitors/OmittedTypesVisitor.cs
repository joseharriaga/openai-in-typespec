using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;

namespace OpenAILibraryPlugin.Visitors;

/// <summary>
/// This very simple visitor omits types with specific names.
/// </summary>
public class OmittedTypesVisitor : ScmLibraryVisitor
{
    private static IReadOnlyList<string> TypeNamesToOmit =
        [
            "ChatMessageContent"
        ];

    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (TypeNamesToOmit.Any(typeName => type.Name == typeName))
        {
            return null;
        }
        return type;
    }
}