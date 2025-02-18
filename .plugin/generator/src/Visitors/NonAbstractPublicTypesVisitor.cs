using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using System.Reflection;

namespace OpenAILibraryPlugin.Visitors;

/// <summary>
/// A visitor that removes a generated 'abstract' modifier if a custom code definition exists for the type and it
/// doesn't provide 'abstract'.
/// </summary>
public class NonAbstractPublicTypesVisitor : ScmLibraryVisitor
{
    protected override TypeProvider Visit(TypeProvider type)
    {
        if (type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Public)
            && type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Abstract)
            && type.CustomCodeView?.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Abstract) == false)
        {
            // Keep types defined in custom code without 'abstract' non-abstract

            // Post-update:
            // type.Update(modifiers: type.DeclarationModifiers & ~TypeSignatureModifiers.Abstract);
            // Temporary:
            FieldInfo privateModifiersInfo = typeof(TypeProvider)
                .GetField("_declarationModifiers", BindingFlags.Instance | BindingFlags.NonPublic)!;
            TypeSignatureModifiers privateValue = (TypeSignatureModifiers)privateModifiersInfo.GetValue(type)!;
            privateValue &= ~TypeSignatureModifiers.Abstract;
            privateModifiersInfo.SetValue(type, privateValue);
        }
        return type;
    }
}