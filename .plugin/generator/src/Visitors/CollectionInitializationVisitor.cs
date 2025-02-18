using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.Generator.CSharp.Snippets.Snippet;
using static OpenAILibraryPlugin.Visitors.VisitorHelpers;

namespace OpenAILibraryPlugin.Visitors;

/// <summary>
/// This visitor supplements instances of a conditional check of "Optional.IsDefined(Content)" to include a parallel
/// check to "Content.IsInnerCollectionDefined()".
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
            VisitExplodedMethodBodyStatements(
                statements!,
                statement =>
                {
                    if (statement is ExpressionStatement expressionStatement
                        && expressionStatement.Expression is AssignmentExpression assignmentExpression
                        && assignmentExpression.Value.ToDisplayString() == parameter.Name)
                    {
                        ValueExpression nullFallbackExpression = parameter.Type.IsList
                            ? New.Instance(parameter.Type.PropertyInitializationType)
                            : New.Instance(parameter.Type);
                        return assignmentExpression.Variable.Assign(
                            assignmentExpression.Value.NullCoalesce(nullFallbackExpression)).Terminate();
                    }
                    return statement;
                });
        }

        constructor.Update(bodyStatements: statements);
        return constructor;
    }
}