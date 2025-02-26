using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Microsoft.Generator.CSharp.Snippets.Snippet;
using static OpenAILibraryPlugin.Visitors.VisitorHelpers;

namespace OpenAILibraryPlugin.Visitors;

/// <summary>
/// This visitor updates the in-constructor initialization of selected collection member types to ensure that they're
/// initialized, invariant of whether deserialization produced one.
/// </summary>
public class CollectionInitializationVisitor : ScmLibraryVisitor
{
    protected override ConstructorProvider? Visit(ConstructorProvider constructor)
    {
        IEnumerable<ParameterProvider> applicableParameters
            = constructor.Signature.Parameters
                .Where(parameter => parameter.Type.Name == "ChatMessageContent"
                    || (parameter.Type.IsList && parameter.Type.Arguments.FirstOrDefault()?.Name == "ChatMessage"));

        if (applicableParameters?.Any() != true)
        {
            return constructor;
        }

        List<MethodBodyStatement> statements = constructor.BodyStatements?.Flatten().ToList() ?? [];

        foreach (ParameterProvider parameter in applicableParameters)
        {
            UpdateStatementsForParameter(statements!, parameter);
        }

        constructor.Update(bodyStatements: statements);
        return constructor;
    }

    private static void UpdateStatementsForParameter(
        IList<MethodBodyStatement?> statements,
        ParameterProvider parameter)
    {
        VisitExplodedMethodBodyStatements(
            statements,
            statement =>
            {
                return TryGetCoalescedInitializeStatement(
                    statement,
                    parameter,
                    out MethodBodyStatement? updatedStatement)
                        ? updatedStatement
                        : statement;
            });
    }

    private static bool TryGetCoalescedInitializeStatement(
        MethodBodyStatement? originalStatement,
        ParameterProvider parameter,
        out MethodBodyStatement? updatedStatement)
    {
        if (originalStatement is not ExpressionStatement expressionStatement
            || expressionStatement.Expression is not AssignmentExpression assignmentExpression
            || assignmentExpression.Value.ToDisplayString() != parameter.Name)
        {
            updatedStatement = originalStatement;
            return false;
        }
        ValueExpression nullFallbackExpression = parameter.Type.IsList
            ? New.Instance(parameter.Type.PropertyInitializationType)
            : New.Instance(parameter.Type);
        ValueExpression coalescedValueExpression = assignmentExpression.Value
            .NullCoalesce(nullFallbackExpression);
        MethodBodyStatement coalescedStatement = assignmentExpression.Variable
            .Assign(coalescedValueExpression)
            .Terminate();
        updatedStatement = new MethodBodyStatements(
        [
            new SingleLineCommentStatement("Plugin customization: ensure initialization of collection"),
            coalescedStatement,
        ]);
        return true;
    }
}