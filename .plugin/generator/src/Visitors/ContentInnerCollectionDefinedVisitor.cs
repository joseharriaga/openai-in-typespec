using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static OpenAILibraryPlugin.Visitors.VisitorHelpers;

namespace OpenAILibraryPlugin.Visitors;

/// <summary>
/// This visitor supplements instances of a conditional check of "Optional.IsDefined(Content)" to include a parallel
/// check to "Content.IsInnerCollectionDefined()".
/// </summary>
public class ContentInnerCollectionDefinedVisitor : ScmLibraryVisitor
{
    protected override MethodProvider VisitMethod(MethodProvider method)
    {
        if (method.Signature.Name != "JsonModelWriteCore"
            || method.BodyStatements is not MethodBodyStatements methodBodyStatements)
        {
            return method;
        }

        List<MethodBodyStatement> statements = methodBodyStatements.Flatten().ToList();
        VisitExplodedMethodBodyStatements(
            statements!,
            statement
                => GetUpdatedIfStatement(
                    statement,
                    expression =>
                    {
                        InvokeMethodExpression? invokeMethodExpression
                            = expression as InvokeMethodExpression
                                ?? (expression as ScopedApi<bool>)?.Original as InvokeMethodExpression;
                        if (invokeMethodExpression?.InstanceReference is TypeReferenceExpression instanceTypeReferenceExpression
                            && instanceTypeReferenceExpression.Type?.Name == "Optional"
                            && invokeMethodExpression.MethodName == "IsDefined"
                            && invokeMethodExpression.Arguments.Count == 1
                            && invokeMethodExpression.Arguments[0] is MemberExpression argumentMemberExpression
                            && argumentMemberExpression.MemberName == "Content")
                            if (statement is IfStatement ifStatement)
                            {
                                return invokeMethodExpression
                                    .As<bool>()
                                    .And(new MemberExpression(null, "Content").Invoke("IsInnerCollectionDefined"));
                            }
                        return expression;
                    }));

        method.Update(bodyStatements: statements);
        return method;
    }
}