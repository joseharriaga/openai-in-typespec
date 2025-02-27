using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;

namespace AzureOpenAILibraryPlugin;

/// <summary>
/// This visitor modifies the additional binary data properties field to be writeable (i.e. to exclude the
/// readonly modifier on the field).
/// </summary>
public class WriteableSardVisitor : ScmLibraryVisitor
{
    private const string AdditionalPropertiesFieldName = "_additionalBinaryDataProperties";

    protected override FieldProvider Visit(FieldProvider field)
    {
        // Make the backing additional properties field not be read only as long as the type is not readonly.
        if (field.Name == AdditionalPropertiesFieldName && !field.EnclosingType.DeclarationModifiers.HasFlag(TypeSignatureModifiers.ReadOnly))
        {
            field.Modifiers &= ~FieldModifiers.ReadOnly;
        }
        return field;
    }
}
