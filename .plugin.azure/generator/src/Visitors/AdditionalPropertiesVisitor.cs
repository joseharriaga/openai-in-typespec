using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace AzureOpenAILibraryPlugin;

/// <summary>
/// This visitor ensures that each emitted model has an internal "additional raw data" dictionary property included
/// and used during the serialization and deserialization process.
/// </summary>
public class AdditionalPropertiesVisitor : ScmLibraryVisitor
{
    private const string RawDataPropertyName = "SerializedAdditionalRawData";
    private const string AdditionalPropertiesFieldName = "_additionalBinaryDataProperties";
    private const string WritePropertyNameMethodCall = "WritePropertyName(\"";
    private const string IsSentinelValueMethodName = "IsSentinelValue";
    private const string JsonModelWriteCoreMethodName = "JsonModelWriteCore";

    protected override TypeProvider VisitType(TypeProvider type)
    {
        if (type is ModelProvider { BaseModelProvider: null })
        {
            // Add an internal AdditionalProperties property to all base models
            var additionalPropertiesField = type.Fields.Single(f => f.Name == AdditionalPropertiesFieldName);
            var properties = new List<PropertyProvider>(type.Properties)
            {
                new PropertyProvider($"", MethodSignatureModifiers.Internal,
                    typeof(IDictionary<string, BinaryData>), RawDataPropertyName,
                    new ExpressionPropertyBody(
                        additionalPropertiesField,
                        type.DeclarationModifiers.HasFlag(TypeSignatureModifiers.ReadOnly) ? null : additionalPropertiesField.Assign(Value)),
                    type)
            };

            type.Update(properties: properties);
        }
        return type;
    }

    protected override MethodProvider VisitMethod(MethodProvider method)
    {
        if (method.Signature.Name != JsonModelWriteCoreMethodName)
        {
            return method;
        }

        // If there are no body statements, return the method as is
        if (method.BodyStatements == null)
        {
            return method;
        }

        // If the body statements are not MethodBodyStatements, return the method as is
        if (method.BodyStatements is not MethodBodyStatements statements)
        {
            return method;
        }

        var updatedStatements = new List<MethodBodyStatement>();
        var flattenedStatements = statements.Flatten().ToArray();

        for (int line = 0; line < flattenedStatements.Length; line++)
        {
            var statement = flattenedStatements[line];

            if (statement is IfStatement ifStatement)
            {
                var body = ifStatement.Body.ToDisplayString();

                // If we already have an if statement that contains property writing, we need to add the condition to the existing if statement
                if (body.Contains(WritePropertyNameMethodCall))
                {
                    ifStatement.Condition = ifStatement.Condition.As<bool>().And(GetContainsKeyCondition(body));
                }

                // Handle writing AdditionalProperties
                else if (ifStatement.Body.Flatten().First() is ForeachStatement foreachStatement)
                {
                    foreachStatement.Body.Insert(
                        0,
                        new IfStatement(
                            Static(new ModelSerializationExtensionsDefinition().Type).Invoke(
                                IsSentinelValueMethodName,
                                foreachStatement.ItemVariable.Property("Value")))
                        {
                            Continue
                        });
                }

                updatedStatements.Add(ifStatement);
                continue;
            }

            var displayString = statement.ToDisplayString();
            if (displayString.Contains(WritePropertyNameMethodCall))
            {
                var ifSt = new IfStatement(GetContainsKeyCondition(displayString)) { statement };

                // If this is a plain expression statement, we need to add the next statement as well which
                // will either write the property value or start writing an array
                if (statement is ExpressionStatement)
                {
                    ifSt.Add(flattenedStatements[++line]);
                    // Include array writing in the if statement
                    if (flattenedStatements[line + 1] is ForeachStatement)
                    {
                        // Foreach
                        ifSt.Add(flattenedStatements[++line]);
                        // End array
                        ifSt.Add(flattenedStatements[++line]);
                    }
                }
                updatedStatements.Add(ifSt);
            }
            else
            {
                updatedStatements.Add(statement);
            }
        }

        method.Update(bodyStatements: updatedStatements);
        return method;
    }

    private static ScopedApi<bool> GetContainsKeyCondition(string displayString)
    {
        var propertyName = displayString.Split('"')[1];
        return This.Property(AdditionalPropertiesFieldName)
            .NullConditional()
            .Invoke("ContainsKey", Literal(propertyName)).NotEqual(True);
    }
}
