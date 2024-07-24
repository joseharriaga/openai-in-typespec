using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.Files;

public partial class IncrementalUploadJob : ClientResult
{
    private readonly InternalUploadJobInfo _internalJobInfo;
    private readonly InternalUploadClient _internalClient;

    public string Id => _internalJobInfo.Id;
    public DateTimeOffset CreatedAt => _internalJobInfo.CreatedAt;
    public DateTimeOffset ExpiresAt => _internalJobInfo.ExpiresAt;

    public ContinuationToken RehydrationToken { get; }

    /// <summary>
    /// Creates a new instance of <see cref="IncrementalUploadJob"/> based on a live service response.
    /// </summary>
    /// <param name="internalJobInfo"></param>
    /// <param name="internalClient"></param>
    /// <param name="protocolJobResponse"></param>
    internal IncrementalUploadJob(InternalUploadJobInfo internalJobInfo, InternalUploadClient internalClient, PipelineResponse protocolJobResponse)
        : base(protocolJobResponse)
    {
        _internalJobInfo = internalJobInfo;
        _internalClient = internalClient;
        RehydrationToken = new InternalIncrementalUploadJobToken(internalJobInfo);
    }

    /// <summary>
    /// Creates a new instance of <see cref="IncrementalUploadJob"/> from a rehydration <see cref="ContinuationToken"/>.
    /// </summary>
    /// <param name="rehydrationToken"></param>
    /// <param name="internalClient"></param>
    internal IncrementalUploadJob(ContinuationToken rehydrationToken, InternalUploadClient internalClient)
        : base()
    {
        InternalIncrementalUploadJobToken specificToken = InternalIncrementalUploadJobToken.FromToken(rehydrationToken);

        _internalJobInfo = specificToken.JobInfo;
        _internalClient = internalClient;
        RehydrationToken = specificToken;
    }

    public static IncrementalUploadJob Rehydrate(FileClient client, ContinuationToken rehydrationToken)
    {
        Argument.AssertNotNull(client, nameof(client));
        Argument.AssertNotNull(rehydrationToken, nameof(rehydrationToken));

        return new IncrementalUploadJob(rehydrationToken, client._internalUploadClient);
    }
}
