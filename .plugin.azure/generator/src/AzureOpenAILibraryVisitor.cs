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
    public class AzureOpenAILibraryVisitor : ScmLibraryVisitor
    {
        private const string RawDataPropertyName = "SerializedAdditionalRawData";
        private const string AdditionalPropertiesFieldName = "_additionalBinaryDataProperties";
        private const string SentinelValueFieldName = "_sentinelValue";
        private const string WritePropertyNameMethodCall = "WritePropertyName(\"";
        private const string ModelSerializationExtensionsTypeName = "ModelSerializationExtensions";
        private const string IsSentinelValueMethodName = "IsSentinelValue";
        private const string JsonModelWriteCoreMethodName = "JsonModelWriteCore";
        
        protected override TypeProvider Visit(TypeProvider type)
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
            else if (type.Name == ModelSerializationExtensionsTypeName)
            {
                // Add a static BinaryData field representing the sentinel value
                var sentinelValueField = new FieldProvider(
                    FieldModifiers.Private | FieldModifiers.Static | FieldModifiers.ReadOnly,
                    typeof(BinaryData),
                    SentinelValueFieldName,
                    type,
                    $"",
                    BinaryDataSnippets.FromBytes(LiteralU8("\"__EMPTY__\"").Invoke("ToArray")));
                var fields = new List<FieldProvider>(type.Fields)
                {
                    sentinelValueField
                };

                // Add the IsSentinelValue method
                var valueParameter = new ParameterProvider("value", $"", typeof(BinaryData));
                var methods = new List<MethodProvider>(type.Methods)
                {
                    new MethodProvider(
                        new MethodSignature(
                            IsSentinelValueMethodName,
                            $"",
                            MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
                            typeof(bool),
                            $"",
                            [valueParameter]),
                        new[]
                        {
                            Declare("sentinelSpan", typeof(ReadOnlySpan<byte>), sentinelValueField.As<BinaryData>().ToMemory().Property("Span"), out var sentinelVariable),
                            Declare("valueSpan", typeof(ReadOnlySpan<byte>), valueParameter.As<BinaryData>().ToMemory().Property("Span"), out var valueVariable),
                            Return(sentinelVariable.Invoke("SequenceEqual", valueVariable))
                        },
                        type)
                };
                
                type.Update(fields: fields, methods: methods);
            }
            return type;
        }

        protected override FieldProvider Visit(FieldProvider field)
        {
            // Make the backing additional properties field not be read only as long as the type is not readonly.
            if (field.Name == AdditionalPropertiesFieldName && !field.EnclosingType.DeclarationModifiers.HasFlag(TypeSignatureModifiers.ReadOnly))
            {
                field.Modifiers &= ~FieldModifiers.ReadOnly;
            }
            return field;
        }

        protected override MethodProvider Visit(MethodProvider method)
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
}
