// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.FineTuning;

internal class AzureFineTuningJobCheckpointsPageEnumerator : FineTuningJobCheckpointsPageEnumerator
{
    private readonly string _apiVersion;

    public AzureFineTuningJobCheckpointsPageEnumerator(
        ClientPipeline pipeline,
        Uri endpoint,
        string jobId, string after, int? limit,
        string apiVersion,
        RequestOptions options)
        : base(pipeline, endpoint, jobId, after, limit, options)
    {
        _apiVersion = apiVersion;
    }

    internal override PipelineMessage CreateGetFineTuningJobCheckpointsRequest(string fineTuningJobId, string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs", fineTuningJobId, "checkpoints")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
