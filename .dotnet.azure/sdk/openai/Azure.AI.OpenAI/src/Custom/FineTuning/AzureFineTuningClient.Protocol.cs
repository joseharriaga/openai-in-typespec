// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.OpenAI.FineTuning;

internal partial class AzureFineTuningClient : FineTuningClient
{
    internal override PipelineMessage PostJobPipelineMessage(BinaryContent content, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint)
            .WithMethod("POST")
            .WithPath("fine_tuning", "jobs")
            .WithContent(content, "application/json")
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();

    internal override PipelineMessage GetJobsPipelineMessage(string after, int? limit, RequestOptions options)
        => new AzureOpenAIPipelineMessageBuilder(Pipeline, _endpoint)
            .WithMethod("GET")
            .WithPath("fine_tuning", "jobs")
            .WithOptionalQueryParameter("after", after)
            .WithOptionalQueryParameter("limit", limit)
            .WithAccept("application/json")
            .WithOptions(options)
            .Build();
}

#endif