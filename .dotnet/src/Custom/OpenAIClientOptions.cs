using System;
using System.ClientModel.Primitives;

namespace OpenAI;

/// <summary>
/// Client-level options for the OpenAI service.
/// </summary>
public partial class OpenAIClientOptions : ClientPipelineOptions
{
    /// <summary>
    /// Gets or sets a non-default base endpoint that clients should use when connecting.
    /// </summary>
    public Uri Endpoint { get; set; }
}
