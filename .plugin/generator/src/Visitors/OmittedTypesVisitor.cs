using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using System;
using System.Collections.Generic;
using System.Linq;

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

    protected override TypeProvider? Visit(TypeProvider type)
    {
        if (TypeNamesToOmit.Any(typeName => type.Name == typeName))
        {
            return null;
        }
        return type;
    }
}