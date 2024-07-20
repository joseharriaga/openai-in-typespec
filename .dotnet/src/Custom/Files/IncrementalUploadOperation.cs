using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Files;

public partial class IncrementalUploadOperation : ClientResult
{
    private readonly InternalUploadClient _internalClient;
    private readonly PipelineResponse _protocolJobResponse;

    public string UploadJobId { get; }

    public DateTimeOffset ExpiresAt { get; }

    internal IncrementalUploadOperation(InternalUploadClient internalClient, PipelineResponse protocolJobResponse)
        : base(protocolJobResponse)
    {
        _internalClient = internalClient;
        _protocolJobResponse = protocolJobResponse;

        using JsonDocument jobDocument = JsonDocument.Parse(_protocolJobResponse.Content);
        UploadJobId = jobDocument.RootElement.GetProperty("id"u8).GetString();
        ExpiresAt = DateTimeOffset.FromUnixTimeSeconds(jobDocument.RootElement.GetProperty("expires_at"u8).GetInt32());
    }
}
