using System;
using System.ClientModel.Primitives;

namespace OpenAI;

/// <summary>
/// Client-level options for the OpenAI service.
/// </summary>
[CodeGenModel("OpenAIClientOptions")]
public partial class OpenAIClientOptions : ClientPipelineOptions
{
    // Note: this type currently proxies RequestOptions properties manually via the matching internal type. This is a
    //       temporary extra step pending richer integration with code generation.

    internal OpenAIClientOptions InternalOptions { get; }

    public new void AddPolicy(PipelinePolicy policy, PipelinePosition position)
    {
        AddPolicy(policy, position);
        InternalOptions.AddPolicy(policy, position);
    }

    /// <summary>
    /// Gets or sets a non-default base endpoint that clients should use when connecting.
    /// </summary>
    public Uri Endpoint { get; set; }
}
