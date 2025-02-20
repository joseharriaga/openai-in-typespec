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
/// A visitor that removes all "options.Format != "W"" condition checks from JsonModelWriteCore and emitted type
/// deserialization methods, which causes unknown properties to always be written to the additional properties
/// collection.
/// </summary>
public class InvariantFormatAdditionalPropertiesVisitor : ScmLibraryVisitor
{
    protected override MethodProvider Visit(MethodProvider method)
    {
        if (method.Signature.Name == "JsonModelWriteCore"
            || method.Signature.Name.StartsWith("Deserialize"))
        {
            List<MethodBodyStatement> statements = method.BodyStatements?.Flatten().ToList() ?? [];
            VisitExplodedMethodBodyStatements(
                statements!,
                statement => GetUpdatedIfStatement(
                    statement, expression =>
                    {
                        if (GetIsOptionsFormatNotEqualToExpression(expression))
                        {
                            return null;
                        }
                        return expression;
                    }));
            method.Update(bodyStatements: statements);
        }
        return method;
    }

    private static bool GetIsOptionsFormatNotEqualToExpression(
        ValueExpression expression)
    {
        BinaryOperatorExpression? binaryOperatorExpression
            = expression as BinaryOperatorExpression
                ?? (expression as ScopedApi<bool>)?.Original as BinaryOperatorExpression;

        if (binaryOperatorExpression?.Left is MemberExpression leftMemberExpression
            && leftMemberExpression.Inner?.ToDisplayString() == "options"
            && leftMemberExpression.MemberName == "Format"
            && binaryOperatorExpression.Operator == "!=")
        {
            return true;
        }
        return false;
    }
}