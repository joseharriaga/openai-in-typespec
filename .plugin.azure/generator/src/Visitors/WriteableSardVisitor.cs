using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace AzureOpenAILibraryPlugin
{
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
}
