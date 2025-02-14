using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace AzureOpenAILibraryPlugin
{
    public class InternalSettablePropertiesVisitor : ScmLibraryVisitor
    {
        protected override TypeProvider? Visit(TypeProvider type)
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
}
