using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace AzureOpenAILibraryPlugin;

/// <summary>
/// This visitor adds extensions for model serialization that use an empty sentinel value to serve as a suppression
/// flag for a named property on the additional binary data properties dictionary.
/// </summary>
public class ModelSerializationEmptySentinelVisitor : ScmLibraryVisitor
{
    private const string ModelSerializationExtensionsTypeName = "ModelSerializationExtensions";
    private const string SentinelValueFieldName = "_sentinelValue";
    private const string IsSentinelValueMethodName = "IsSentinelValue";

    protected override TypeProvider VisitType(TypeProvider type)
    {
        if (type.Name == ModelSerializationExtensionsTypeName)
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
}
