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
    public class ModelSerializationEmptySentinelVisitor : ScmLibraryVisitor
    {
        private const string ModelSerializationExtensionsTypeName = "ModelSerializationExtensions";
        private const string SentinelValueFieldName = "_sentinelValue";
        private const string IsSentinelValueMethodName = "IsSentinelValue";

        protected override TypeProvider Visit(TypeProvider type)
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
}
