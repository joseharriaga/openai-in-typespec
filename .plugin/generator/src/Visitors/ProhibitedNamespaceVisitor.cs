using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using System;

namespace OpenAILibraryPlugin.Visitors;

/// <summary>
/// A visitor that throws an exception if a generated namespace is prohibited. This happens when a newly introduced
/// type isn't emplaced into its appropriate namespace. Custom code definitions, including stubs that only emplace in
/// namespaces, are exempt and will cause the generated code to be accepted.
/// </summary>
public class ProhibitedNamespaceVisitor : ScmLibraryVisitor
{
    protected override TypeProvider Visit(TypeProvider type)
    {
        if (type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public)
            && (type.Namespace == "OpenAI" || type.Namespace == "OpenAI.Models")
            && string.IsNullOrEmpty(type.CustomCodeView?.Namespace))
        {
            throw new InvalidOperationException(Environment.NewLine
                + $"Public type '{type.Name}' is present via generation in prohibited namespace '{type.Namespace}'."
                + Environment.NewLine
                + "Please forward-declare the type in an appropriate namespace."
                + Environment.NewLine);
        }
        return type;
    }
}