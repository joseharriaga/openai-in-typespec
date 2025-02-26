using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using System.Collections.Generic;
using System.Linq;
using static OpenAILibraryPlugin.Visitors.VisitorHelpers;

namespace OpenAILibraryPlugin.Visitors;

/// <summary>
/// This visitor supplements instances of a conditional check of "Optional.IsDefined(Content)" to include a parallel
/// check to "Content.IsInnerCollectionDefined()".
/// </summary>
public class ContentInnerCollectionDefinedVisitor : ScmLibraryVisitor
{
    protected override MethodProvider Visit(MethodProvider method)
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