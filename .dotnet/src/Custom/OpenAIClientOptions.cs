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
    /// Gets or sets a non-default base endpoint that clients should use when connecting.
    /// </summary>
    public Uri Endpoint
    {
        get
        {
            AssertNotFrozen();
            return _endpoint;
        }
        set
        {
            AssertNotFrozen();
            _endpoint = value;
        }
    }
    private Uri _endpoint;
}
