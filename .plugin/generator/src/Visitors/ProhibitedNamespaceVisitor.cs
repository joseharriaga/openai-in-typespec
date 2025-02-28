using System;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace OpenAILibraryPlugin.Visitors;

/// <summary>
/// A visitor that throws an exception if a generated namespace is prohibited. This happens when a newly introduced
/// type isn't emplaced into its appropriate namespace. Custom code definitions, including stubs that only emplace in
/// namespaces, are exempt and will cause the generated code to be accepted.
/// </summary>
public class ProhibitedNamespaceVisitor : ScmLibraryVisitor
{
    protected override TypeProvider VisitType(TypeProvider type)
    {
        if (type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public)
            && (type.Type.Namespace == "OpenAI" || type.Type.Namespace == "OpenAI.Models")
            && string.IsNullOrEmpty(type.CustomCodeView?.Type.Namespace))
        {
            throw new InvalidOperationException(Environment.NewLine
                + $"Public type '{type.Name}' is present via generation in prohibited namespace '{type.Type.Namespace}'."
                + Environment.NewLine
                + "Please forward-declare the type in an appropriate namespace."
                + Environment.NewLine);
        }
        return type;
    }
}