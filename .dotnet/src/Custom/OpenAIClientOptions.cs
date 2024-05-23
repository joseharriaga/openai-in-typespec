using System;
using System.ClientModel.Primitives;

namespace OpenAI;

/// <summary>
/// Client-level options for the OpenAI service.
/// </summary>
[CodeGenModel("OpenAIClientOptions")]
public partial class OpenAIClientOptions : ClientPipelineOptions
{
    /// <summary>
    /// Gets a non-default base endpoint that clients should use when connecting.
    /// </summary>
    public Uri Endpoint { get; init; }
}
