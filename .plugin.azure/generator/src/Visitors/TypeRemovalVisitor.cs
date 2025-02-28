using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Providers;

namespace AzureOpenAILibraryPlugin;

/// <summary>
/// This visitor suppresses the emission of types according to pattern matches in their names.
/// We do this to trim the set of generated files such that the library serves as an extension to
/// the underlying OpenAI library (rather than a standalone library in its own right).
/// </summary>
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

    protected override TypeProvider? VisitType(TypeProvider type)
    {
        if (PatternsToKeep.Any(patternToKeep => Regex.IsMatch(type.Name, patternToKeep)
            && !PatternsToStillDeleteAfterPatternsToKeep.Any(patternToStillDelete => Regex.IsMatch(type.Name, patternToStillDelete))))
        {
            return type;
        }
        return null;
    }
}
