using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.Files;

/// <summary>
/// A representation of a multi-part upload operation that can add data parts in parallel, useful for uploading very
/// large files.
/// </summary>
/// <remarks>
/// <see cref="IncrementalUpload"/> instances are obtained via
/// <see cref="FileClient.CreateIncrementalUpload(BinaryContent, RequestOptions)"/> or rehydrated via
/// <see cref="FromContinuationToken(OpenAI.Files.FileClient, ContinuationToken)"/> using a <see cref="ContinuationToken"/> from
/// an existing instance.
/// </remarks>
public partial class IncrementalUpload : ClientResult
{
    private readonly InternalUpload _internalJobInfo;
    private readonly InternalUploadClient _internalClient;

    /// <summary>
    /// The identifier of the <c>Upload</c> job that will assemble an <see cref="OpenAIFileInfo"/> instance from the
    /// job's data parts upon completion.
    /// </summary>
    public string Id => _internalJobInfo.Id;

    /// <summary>
    /// The timestamp at which the job was created.
    /// </summary>
    public DateTimeOffset CreatedAt => _internalJobInfo.CreatedAt;

    /// <summary>
    /// The timestamp at which the job will expire. A job must have all its data parts uploaded and be completed before
    /// this timestamp in order to produce a valid file.
    /// </summary>
    public DateTimeOffset ExpiresAt => _internalJobInfo.ExpiresAt;

    /// <summary>
    /// A token that can be serialized/deserialized and used to reinstantiate an <see cref="IncrementalUpload"/>,
    /// including to facilitate parallel data part uploads across multiple environments.
    /// </summary>
    /// <remarks>
    /// The full binary representation of the original server <c>Upload</c> is also represented in this token via
    /// <see cref="ContinuationToken.ToBytes"/>.
    /// </remarks>
    public ContinuationToken ContinuationToken { get; }

    /// <summary>
    /// Creates a new instance of <see cref="IncrementalUpload"/> based on a live service response.
    /// </summary>
    /// <param name="internalJobInfo"></param>
    /// <param name="internalClient"></param>
    /// <param name="protocolJobResponse"></param>
    internal IncrementalUpload(InternalUpload internalJobInfo, InternalUploadClient internalClient, PipelineResponse protocolJobResponse)
        : base(protocolJobResponse)
    {
        _internalJobInfo = internalJobInfo;
        _internalClient = internalClient;
        ContinuationToken = new InternalIncrementalUploadJobToken(internalJobInfo);
    }

    /// <summary>
    /// Creates a new instance of <see cref="IncrementalUpload"/> from a rehydration <see cref="ContinuationToken"/>.
    /// </summary>
    /// <param name="continuationToken"></param>
    /// <param name="internalClient"></param>
    internal IncrementalUpload(ContinuationToken continuationToken, InternalUploadClient internalClient)
        : base()
    {
        InternalIncrementalUploadJobToken specificToken = InternalIncrementalUploadJobToken.FromToken(continuationToken);

        _internalJobInfo = specificToken.Upload;
        _internalClient = internalClient;
        ContinuationToken = specificToken;
    }

    /// <summary>
    /// Instantiates a new instance of <see cref="IncrementalUpload"/> that will interact with the same server
    /// <c>Upload</c> object created by a previous call to
    /// <see cref="FileClient.CreateIncrementalUpload(BinaryContent, RequestOptions)"/>. A rehydrated instance may
    /// be used to upload data parts and complete the job in a different environment relative to where the job was
    /// started.
    /// </summary>
    /// <param name="client"> The <see cref="FileClient"/> instance that the rehydrated job should use for operations. </param>
    /// <param name="continuationToken">
    /// The token, retrieved from the <see cref="IncrementalUpload.RehydrationToken"/> property, that will configure
    /// the rehydrated job instance.
    /// </param>
    /// <returns>
    /// A new instance of <see cref="IncrementalUpload"/> that will interact with the same <c>Upload</c> that the
    /// previous job, represented by <paramref name="continuationToken"/>, does.
    /// </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="client"/> or <paramref name="continuationToken"/> is null. </exception>
    public static IncrementalUpload FromContinuationToken(FileClient client, ContinuationToken continuationToken)
    {
        Argument.AssertNotNull(client, nameof(client));
        Argument.AssertNotNull(continuationToken, nameof(continuationToken));

        return new IncrementalUpload(continuationToken, client._internalUploadClient);
    }
}
