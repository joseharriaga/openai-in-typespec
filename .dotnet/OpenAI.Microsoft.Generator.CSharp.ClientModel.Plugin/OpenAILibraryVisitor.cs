// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Microsoft.Generator.CSharp.ClientModel.OpenAILibraryPlugin
{
    public class OpenAILibraryVisitor : ScmLibraryVisitor
    {
        private const string RawDataPropertyName = "SerializedAdditionalRawData";
        private const string AdditionalPropertiesFieldName = "_additionalBinaryDataProperties";
        private const string SentinelValueFieldName = "_sentinelValue";
        private const string WritePropertyNameMethodCall = "WritePropertyName(\"";

        private static readonly VariableExpression AdditionalBinaryDataExpression =
            new VariableExpression(typeof(IDictionary<string, BinaryData>), AdditionalPropertiesFieldName);
        protected override TypeProvider Visit(TypeProvider type)
        {
            if (type is ModelProvider { BaseModelProvider: null })
            {
                var additionalPropertiesField = type.Fields.Single(f => f.Name == AdditionalPropertiesFieldName);
                var properties = new List<PropertyProvider>(type.Properties)
                {
                    new PropertyProvider($"", MethodSignatureModifiers.Internal,
                        typeof(IDictionary<string, BinaryData>), RawDataPropertyName,
                        new ExpressionPropertyBody(
                            additionalPropertiesField,
                            additionalPropertiesField.Assign(Value)), type)
                };
                type.Update(properties: properties);
            }
            else if (type.Name == "ModelSerializationExtensions")
            {
                var sentinelValueField = new FieldProvider(
                    FieldModifiers.Private | FieldModifiers.Static | FieldModifiers.ReadOnly,
                    typeof(BinaryData),
                    SentinelValueFieldName,
                    type,
                    null,
                    BinaryDataSnippets.FromBytes(LiteralU8("\"__EMPTY__\"").Invoke("ToArray")));
                var fields = new List<FieldProvider>(type.Fields)
                {
                    sentinelValueField
                };

                var valueParameter = new ParameterProvider("value", $"", typeof(BinaryData));
                var methods = new List<MethodProvider>(type.Methods)
                {
                    new MethodProvider(
                        new MethodSignature(
                            "IsSentinelValue",
                            $"",
                            MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
                            typeof(bool),
                            $"",
                            [valueParameter]),
                        new[]
                        {
                            Declare("sentinelSpan", typeof(ReadOnlySpan<byte>), sentinelValueField.Invoke("ToMemory", []).Property("Span"), out var sentinelVariable),
                            Declare("valueSpan", typeof(ReadOnlySpan<byte>), valueParameter.Invoke("ToMemory", []).Property("Span"), out var valueVariable),
                            Return(sentinelVariable.Invoke("SequenceEqual", valueVariable))
                        },
                        type)
                };
                type.Update(fields: fields, methods: methods);
            }
            return type;
        }

        protected override FieldProvider? Visit(FieldProvider field)
        {
            if (field.Name == AdditionalPropertiesFieldName)
            {
                field.Modifiers &= ~FieldModifiers.ReadOnly;
            }
            return field;
        }

        protected override MethodProvider Visit(MethodProvider method)
        {
            if (method.Signature.Name != "JsonModelWriteCore")
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

            foreach (var statement in Flatten(statements!))
            {
                if (statement is IfStatement ifStatement)
                {
                    var body = ifStatement.Body.ToDisplayString();
                    if (body.Contains(WritePropertyNameMethodCall))
                    {
                        ifStatement.Condition = ifStatement.Condition.As<bool>().And(GetContainsKeyCondition(body));
                        updatedStatements.Add(ifStatement);
                        continue;
                    }

                    if (Flatten(ifStatement.Body).First() is ForeachStatement foreachStatement)
                    {
                        foreachStatement.Body.Insert(
                            0,
                            new IfStatement(
                                Static(new ModelSerializationExtensionsDefinition().Type).Invoke("IsSentinelValue", foreachStatement.ItemVariable.Property("Value")))
                            {
                                Continue
                            });
                    }
                }

                var displayString = statement.ToDisplayString();
                if (displayString.Contains(WritePropertyNameMethodCall))
                {
                    var ifSt = new IfStatement(GetContainsKeyCondition(displayString)) { statement };
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
            return AdditionalBinaryDataExpression
                .NullConditional()
                .Invoke("ContainsKey", Literal(propertyName)).NotEqual(True);
        }

        private IEnumerable<MethodBodyStatement> Flatten(MethodBodyStatement bodyStatement)
        {
            if (bodyStatement is MethodBodyStatements statements)
            {
                foreach (var statement in statements.Statements)
                {
                    foreach (var subStatement in Flatten(statement))
                    {
                        yield return subStatement;
                    }
                }
            }
            else
            {
                yield return bodyStatement;
            }
        }
    }
}
