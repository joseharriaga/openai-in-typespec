using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureCosmosDBChatDataSourceParameters")]
internal partial class InternalAzureCosmosDBChatDataSourceParameters
{
    [CodeGenMember("IncludeContexts")]
    private IList<string> _internalIncludeContexts = new ChangeTrackingList<string>();
    private DataSourceOutputContextFlags? _outputContextFlags;

    /// <summary>
    /// The output context properties to include on the response.
    /// By default, citations and intent will be requested.
    /// </summary>
    public DataSourceOutputContextFlags? OutputContextFlags
    {
        get => DataSourceOutputContextFlagsExtensions.FromStringList(_internalIncludeContexts);
        internal set
        {
            _outputContextFlags = value;
            _internalIncludeContexts = _outputContextFlags?.ToStringList();
        }
    }

    /// <summary> Gets the fields mapping. </summary>
    [CodeGenMember("FieldsMapping")]
    public DataSourceFieldMappings FieldMappings { get; set; }
    /// <summary>
    /// Gets the embedding dependency
    /// </summary>
    [CodeGenMember("EmbeddingDependency")]
    internal DataSourceVectorizer VectorizationSource { get; set; }
}
