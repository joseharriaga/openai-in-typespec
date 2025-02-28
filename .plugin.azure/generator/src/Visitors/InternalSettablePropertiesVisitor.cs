using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace AzureOpenAILibraryPlugin;

/// <summary>
/// This visitor ensures that all properties on internal types with "Internal" type prefix are settable. 
/// </summary>
public class InternalSettablePropertiesVisitor : ScmLibraryVisitor
{
    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (type.Name.Contains("Internal") && type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.Internal))
        {
            foreach (PropertyProvider property in type.Properties)
            {
                if (property.Body is AutoPropertyBody autoPropertyBody && !property.Body.HasSetter)
                {
                    PropertyBody updatedBody = new AutoPropertyBody(
                        HasSetter: true,
                        autoPropertyBody.SetterModifiers,
                        autoPropertyBody.InitializationExpression);
                    property.Update(body: updatedBody);
                }
            }
        }
        return type;
    }
}
