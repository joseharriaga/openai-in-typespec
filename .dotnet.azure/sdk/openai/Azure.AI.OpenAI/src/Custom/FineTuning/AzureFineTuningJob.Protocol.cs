// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

#if !AZURE_OPENAI_GA

#nullable enable

namespace Azure.AI.OpenAI.FineTuning;

/// <summary>
/// A long-running operation for creating a new model from a given dataset.
/// </summary>
[Experimental("OPENAI001")]
internal class AzureFineTuningJob : FineTuningJob
{
    private readonly PipelineMessageClassifier _deleteJobClassifier;
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;

    internal AzureFineTuningJob(
        ClientPipeline pipeline,
        Uri endpoint,
        PipelineResponse response)
        : base(pipeline, endpoint, response)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;

        
        _deleteJobClassifier = PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });
    }

    [Experimental("AOAI001")]
    public virtual ClientResult DeleteJob(string fineTuningJobId, RequestOptions? options)
    {
        using PipelineMessage message = CreateDeleteJobRequestMessage(fineTuningJobId, options);
        return ClientResult.FromResponse(_pipeline.ProcessMessage(message, options));
    }

    [Experimental("AOAI001")]
    public virtual async Task<ClientResult> DeleteJobAsync(string fineTuningJobId, RequestOptions? options)
    {
        using PipelineMessage message = CreateDeleteJobRequestMessage(fineTuningJobId, options);
        PipelineResponse response = await _pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false);
        return ClientResult.FromResponse(response);
    }

    private PipelineMessage CreateDeleteJobRequestMessage(string fineTuningJobId, RequestOptions? options)
    => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint)
        .WithMethod("DELETE")
        .WithPath("fine_tuning", "jobs", fineTuningJobId)
        .WithAccept("application/json")
        .WithClassifier(_deleteJobClassifier)
        .WithOptions(options)
        .Build();

    

    internal override PipelineMessage CancelPipelineMessage(string fineTuningJobId, RequestOptions? options)
    => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint)
        .WithMethod("POST")
        .WithPath("fine_tuning", "jobs", fineTuningJobId, "cancel")
        .WithAccept("application/json")
        .WithOptions(options)
        .Build();

    internal override PipelineMessage GetCheckpointsPipelineMessage(string fineTuningJobId, string? after, int? limit, RequestOptions? options)
    => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint)
        .WithMethod("GET")
        .WithPath("fine_tuning", "jobs", fineTuningJobId, "checkpoints")
        .WithOptionalQueryParameter("after", after)
        .WithOptionalQueryParameter("limit", limit)
        .WithAccept("application/json")
        .WithOptions(options)
        .Build();

    internal override PipelineMessage GetEventsPipelineMessage(string fineTuningJobId, string? after, int? limit, RequestOptions? options)
    => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint)
        .WithMethod("GET")
        .WithPath("fine_tuning", "jobs", fineTuningJobId, "events")
        .WithOptionalQueryParameter("after", after)
        .WithOptionalQueryParameter("limit", limit)
        .WithAccept("application/json")
        .WithOptions(options)
        .Build();
}

#endif
