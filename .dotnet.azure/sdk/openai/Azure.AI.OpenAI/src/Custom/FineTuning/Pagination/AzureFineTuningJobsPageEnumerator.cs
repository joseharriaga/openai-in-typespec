// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.FineTuning;

internal class AzureFineTuningJobsPageEnumerator : FineTuningJobsPageEnumerator
{
    private readonly string _apiVersion;

    public AzureFineTuningJobsPageEnumerator(
        ClientPipeline pipeline,
        Uri endpoint,
        string? after,
        int? limit,
        string apiVersion,
        RequestOptions options)
        : base(pipeline, endpoint, after, limit, options)
    {
        _apiVersion = apiVersion;
    }

    internal override PipelineMessage CreateGetFineTuningJobsRequest(string? after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(_pipeline, _endpoint, _apiVersion)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}
