using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace OpenAI.Files;

public partial class IncrementalUploadJob
{
    /// <summary>
    /// <para>[Protocol Method]</para>
    /// Adds a data part to the in-progress upload job. Data parts may be added in parallel and out of order, with
    /// their sequencing determined by the final call to <see cref="Complete(string, BinaryContent, RequestOptions)"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="jobId">
    /// The ID of the upload job to add the data part to. This should typically be the value of <see cref="Id"/> in the
    /// instance.
    /// </param>
    /// <param name="content">
    /// <para>
    /// The binary request content describing the data part. This is a multipart/form-data body that should use the same
    /// boundary value described by <paramref name="contentType"/> and provide a required <c>data</c> form field.
    /// </para>
    /// An example value template:
    /// <code>
    /// BinaryContent.Create(BinaryData.FromString($$"""
    ///     --{{boundaryValueMatchingContentType}}
    ///     Content-Disposition: form-data; name="data"; filename="data_part"
    ///
    ///     {{contentForDataPart}}
    ///     --{{boundaryValueMatchingContentType}}--
    ///     """);
    /// </code>
    /// </param>
    /// <param name="contentType">
    /// <para>
    /// The content type for the request. This should be multipart/form-data and provide a boundary value matched in
    /// the payload of <paramref name="content"/>.
    /// </para>
    /// Example value:
    /// <code>
    /// $@"multipart/form-data; boundary=""{boundaryValueMatchingContent}"""
    /// </code>
    /// </param>
    /// <param name="options">
    /// Additional options for the protocol request, including cancellation and error behavior.
    /// </param>
    /// <returns>
    /// A <see cref="ClientResult"/> with response content, retrievable via <see cref="ClientResult.GetRawResponse"/>,
    /// that describes the newly added data part. The <c>id</c> from this part is necessary to sequence parts in the
    /// final call to <see cref="Complete(string, BinaryContent, RequestOptions)"/>.
    /// </returns>
    public virtual Task<ClientResult> AddDataPartAsync(string jobId, BinaryContent content, string contentType, RequestOptions options = null)
        => _internalClient.AddDataPartToUploadJobAsync(jobId, content, contentType, options);

    /// <summary>
    /// <para>[Protocol Method]</para>
    /// Adds a data part to the in-progress upload job. Data parts may be added in parallel and out of order, with
    /// their sequencing determined by the final call to <see cref="Complete(string, BinaryContent, RequestOptions)"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="jobId">
    /// The ID of the upload job to add the data part to. This should typically be the value of <see cref="Id"/> in the
    /// instance.
    /// </param>
    /// <param name="content">
    /// <para>
    /// The binary request content describing the data part. This is a multipart/form-data body that should use the same
    /// boundary value described by <paramref name="contentType"/> and provide a required <c>data</c> form field.
    /// </para>
    /// An example value template:
    /// <code>
    /// BinaryContent.Create(BinaryData.FromString($$"""
    ///     --{{boundaryValueMatchingContentType}}
    ///     Content-Disposition: form-data; name="data"; filename="data_part"
    ///
    ///     {{contentForDataPart}}
    ///     --{{boundaryValueMatchingContentType}}--
    ///     """);
    /// </code>
    /// </param>
    /// <param name="contentType">
    /// <para>
    /// The content type for the request. This should be multipart/form-data and provide a boundary value matched in
    /// the payload of <paramref name="content"/>.
    /// </para>
    /// Example value:
    /// <code>
    /// $@"multipart/form-data; boundary=""{boundaryValueMatchingContent}"""
    /// </code>
    /// </param>
    /// <param name="options">
    /// Additional options for the protocol request, including cancellation and error behavior.
    /// </param>
    /// <returns>
    /// A <see cref="ClientResult"/> with response content, retrievable via <see cref="ClientResult.GetRawResponse"/>,
    /// that describes the newly added data part. The <c>id</c> from this part is necessary to sequence parts in the
    /// final call to <see cref="Complete(string, BinaryContent, RequestOptions)"/>.
    /// </returns>
    public virtual ClientResult AddDataPart(string jobId, BinaryContent content, string contentType, RequestOptions options = null)
        => _internalClient.AddDataPartToUploadJob(jobId, content, contentType, options);

    /// <summary>
    /// <para>[Protocol Method]</para>
    /// Completes an in-progress upload job, sequencing the parts added via
    /// <see cref="AddDataPart(string, BinaryContent, string, RequestOptions)"/> and assembling them into a file object
    /// with an ID usable in other operations.
    /// </summary>
    /// <param name="jobId">
    /// The ID of the upload job to complete. This should typically be the value of <see cref="Id"/> in the instance.
    /// </param>
    /// <param name="content">
    /// <para>
    /// The request body that defines how to complete the upload job. This should be a JSON object with a required
    /// <c>part_ids</c> property.
    /// </para>
    /// Example request content:
    /// <code>
    /// BinaryContent.Create(BinaryData.FromObjectAsJson(new
    ///     {
    ///         part_ids = orderedListOfDataPartIds,
    ///         checksum = optionalChecksum
    ///     }));
    /// </code>
    /// </param>
    /// <param name="options">
    /// Additional options for the protocol request, including cancellation and error behavior.
    /// </param>
    /// <returns>
    /// A <see cref="ClientResult"/> with response content, retrievable via <see cref="ClientResult.GetRawResponse"/>,
    /// that describes the completed job. If the job was completed successfully, this will include a <c>file</c>
    /// property for the completed file that, in turn, has an <c>id</c> property usable in other operations.
    /// </returns>
    public virtual Task<ClientResult> CompleteAsync(string jobId, BinaryContent content, RequestOptions options = null)
        => _internalClient.CompleteUploadJobAsync(jobId, content, options);

    /// <summary>
    /// <para>[Protocol Method]</para>
    /// Completes an in-progress upload job, sequencing the parts added via
    /// <see cref="AddDataPart(string, BinaryContent, string, RequestOptions)"/> and assembling them into a file object
    /// with an ID usable in other operations.
    /// </summary>
    /// <param name="jobId">
    /// The ID of the upload job to complete. This should typically be the value of <see cref="Id"/> in the instance.
    /// </param>
    /// <param name="content">
    /// <para>
    /// The request body that defines how to complete the upload job. This should be a JSON object with a required
    /// <c>part_ids</c> property.
    /// </para>
    /// Example request content:
    /// <code>
    /// BinaryContent.Create(BinaryData.FromObjectAsJson(new
    ///     {
    ///         part_ids = orderedListOfDataPartIds,
    ///         checksum = optionalChecksum
    ///     }));
    /// </code>
    /// </param>
    /// <param name="options">
    /// Additional options for the protocol request, including cancellation and error behavior.
    /// </param>
    /// <returns>
    /// A <see cref="ClientResult"/> with response content, retrievable via <see cref="ClientResult.GetRawResponse"/>,
    /// that describes the completed job. If the job was completed successfully, this will include a <c>file</c>
    /// property for the completed file that, in turn, has an <c>id</c> property usable in other operations.
    /// </returns>
    public virtual ClientResult Complete(string jobId, BinaryContent content, RequestOptions options = null)
        => _internalClient.CompleteUploadJob(jobId, content, options);

    /// <summary>
    /// <para>[Protocol Method]</para>
    /// Cancels an in-progress upload job. Cancelled jobs will no longer accept new data parts and cannot be completed.
    /// Previously uploaded data parts for a cancelled job will be discarded.
    /// </summary>
    /// <param name="jobId"> The ID of the job to cancel. This should typically match the <see cref="Id"/> property of
    /// the <see cref="IncrementalUploadJob"/> instance.
    /// </param>
    /// <param name="options">
    /// Additional options for the protocol request, including cancellation and error behavior.
    /// </param>
    /// <returns>
    /// A <see cref="ClientResult"/> with response content, retrievable via <see cref="ClientResult.GetRawResponse"/>,
    /// that describes the cancelled job.
    /// </returns>
    public virtual Task<ClientResult> CancelAsync(string jobId, RequestOptions options)
        => _internalClient.CancelUploadJobAsync(jobId, options);

    /// <summary>
    /// <para>[Protocol Method]</para>
    /// Cancels an in-progress upload job. Cancelled jobs will no longer accept new data parts and cannot be completed.
    /// Previously uploaded data parts for a cancelled job will be discarded.
    /// </summary>
    /// <param name="jobId"> The ID of the job to cancel. This should typically match the <see cref="Id"/> property of
    /// the <see cref="IncrementalUploadJob"/> instance.
    /// </param>
    /// <param name="options">
    /// Additional options for the protocol request, including cancellation and error behavior.
    /// </param>
    /// <returns>
    /// A <see cref="ClientResult"/> with response content, retrievable via <see cref="ClientResult.GetRawResponse"/>,
    /// that describes the cancelled job.
    /// </returns>
    public virtual ClientResult Cancel(string jobId, RequestOptions options)
        => _internalClient.CancelUploadJob(jobId, options);
}