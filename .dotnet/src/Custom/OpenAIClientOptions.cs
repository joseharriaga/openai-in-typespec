using System;
using System.ClientModel.Primitives;

namespace OpenAI;

/// <summary>
/// Client-level options for the OpenAI service.
/// </summary>
[CodeGenModel("OpenAIClientOptions")]
public partial class OpenAIClientOptions : ClientPipelineOptions
{
    private Uri _endpoint;
    private string _organizationId;
    private string _projectId;

    /// <summary>
    /// A non-default base endpoint that clients should use when connecting.
    /// </summary>
    public Uri Endpoint
    {
        get => _endpoint;
        set
        {
            AssertNotFrozen();
            _endpoint = value;
        }
    }

    /// <summary>
    /// An optional ID added to OpenAI-Organization header
    /// </summary>
    public string OrganizationId
    {
        get => _organizationId;
        set
        {
            AssertNotFrozen();
            _organizationId = value;
        }
    }

    /// <summary>
    /// An optional ID added to OpenAI-Project header
    /// </summary>
    public string ProjectId
    {
        get => _projectId;
        set
        {
            AssertNotFrozen();
            _projectId = value;
        }
    }
}
