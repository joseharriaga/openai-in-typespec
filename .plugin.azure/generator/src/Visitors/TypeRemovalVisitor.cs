using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.ClientModel.Providers;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Snippets;
using Microsoft.Generator.CSharp.Statements;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace AzureOpenAILibraryPlugin
{
    public class TypeRemovalVisitor : ScmLibraryVisitor
    {
        private static readonly string[] PatternsToKeep =
            [
              ".*BingSearchTool.*",
              ".*DataSource.*",
              ".*ContentFilter.*",
              ".*OpenAI.*Error.*",
              ".*Context.*",
              ".*RetrievedDoc.*",
              ".*ChatDocument.*",
              ".*Citation.*",
              "Argument",
              "BinaryContentHelper",
              "ChangeTracking.*",
              "ClientPipelineExtensions",
              "ClientUriBuilder",
              "ErrorResult",
              "ModelSerializationExtensions",
              "Optional",
              "PipelineRequestHeadersExtensions",
              "TypeFormatters",
              "Utf8JsonBinaryContent",
            ];
        private static readonly string[] PatternsToStillDeleteAfterPatternsToKeep =
            [
              "AzureOpenAIFile.*",
              "BingSearchToolDefinition.cs",
              ".*Elasticsearch*QueryType.*",
              ".*FieldsMapping.*",
              ".*ContentTextAnnotationsFileCitation.*"
            ];

        protected override TypeProvider? Visit(TypeProvider type)
        {
            if (PatternsToKeep.Any(patternToKeep => Regex.IsMatch(type.Name, patternToKeep)
                && !PatternsToStillDeleteAfterPatternsToKeep.Any(patternToStillDelete => Regex.IsMatch(type.Name, patternToStillDelete))))
            {
                return type;
            }
            return null;
        }
    }
}
