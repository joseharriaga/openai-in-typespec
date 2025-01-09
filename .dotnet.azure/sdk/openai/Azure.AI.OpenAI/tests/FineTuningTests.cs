// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Tests.Models;
using Azure.AI.OpenAI.Tests.Utils;
using Azure.AI.OpenAI.Tests.Utils.Config;
using OpenAI.Chat;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.TestFramework;
using OpenAI.TestFramework.Utils;
using NUnit.Framework.Internal.Commands;


#if !AZURE_OPENAI_GA
using Azure.AI.OpenAI.FineTuning;
#endif

namespace Azure.AI.OpenAI.Tests;

[Category("FineTuning")]
public class FineTuningTests : AoaiTestBase<FineTuningClient>
{
    public FineTuningTests(bool isAsync) : base(isAsync)
    {
        if (Mode == RecordedTestMode.Playback)
        {
            Assert.Inconclusive("Playback for fine-tuning temporarily disabled");
        }
    }

#if !AZURE_OPENAI_GA
    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<FineTuningClient>());

    [RecordedTest]
    public async Task JobsFineTuning()
    {
        FineTuningClient client = GetTestClient();

        int count = 25;

        await foreach (FineTuningJob job in client.ListJobsAsync())
        {
            if (count-- <= 0)
            {
                break;
            }

            Assert.That(job, Is.Not.Null);
            Assert.That(job.Value, Is.Null.Or.Not.Empty); // this either null or set to some non-empty value
            Assert.That(job.Status, !(Is.Null.Or.Empty));
        }
    }

    [RecordedTest]
    public async Task CheckpointsFineTuning()
    {
        string fineTunedModel = GetFineTunedModel();
        FineTuningClient client = GetTestClient();

        // Check if the model exists by searching all jobs
        FineTuningJob job = await client.ListJobsAsync()
            .FirstOrDefaultAsync(j => j.Value == fineTunedModel)!;
        Assert.That(job, Is.Not.Null);
        Assert.That(job!.Status, Is.EqualTo("succeeded"));

        FineTuningJob job2 = await FineTuningJob.RehydrateAsync(UnWrap(client), job.JobId);

        int count = 25;
        await foreach (FineTuningCheckpoint checkpoint in job2.GetCheckpointsAsync())
        {
            if (count-- <= 0)
            {
                break;
            }

            Assert.That(checkpoint, Is.Not.Null);
            Assert.That(checkpoint.JobId, !(Is.Null.Or.Empty));
            Assert.That(checkpoint.CreatedAt, Is.GreaterThan(START_2024));
            Assert.That(checkpoint.CheckpointId, !(Is.Null.Or.Empty));
            Assert.That(checkpoint.Metrics, Is.Not.Null);
            Assert.That(checkpoint.Metrics.StepNumber, Is.GreaterThan(0));
            Assert.That(checkpoint.Metrics.TrainLoss, Is.GreaterThan(0));
            Assert.That(checkpoint.Metrics.TrainMeanTokenAccuracy, Is.GreaterThan(0));
            //Assert.That(checkpoint.Metrics.ValidLoss, Is.GreaterThan(0));
            //Assert.That(checkpoint.Metrics.ValidMeanTokenAccuracy, Is.GreaterThan(0));
            //Assert.That(checkpoint.Metrics.FullValidLoss, Is.GreaterThan(0));
            //Assert.That(checkpoint.Metrics.FullValidMeanTokenAccuracy, Is.GreaterThan(0));
        }
    }

    [RecordedTest]
    public async Task EventsFineTuning()
    {
        string fineTunedModel = GetFineTunedModel();
        FineTuningClient client = GetTestClient();

        // Check if the model exists by searching all jobs
        FineTuningJob job = await client.ListJobsAsync()
            .FirstOrDefaultAsync(j => j.Value == fineTunedModel)!;
        Assert.That(job, Is.Not.Null);
        Assert.That(job!.Status, Is.EqualTo("succeeded"));

        HashSet<string> ids = new();

        //TODO fix unwrapping so you don't have to unwrap here.
        FineTuningJob job2 = await FineTuningJob.RehydrateAsync(UnWrap(client), job.JobId);

        int count = 25;
        var asyncEnum = job2.GetEventsAsync(new(){ PageSize = count });

        await foreach (FineTuningEvent evt in asyncEnum)
        {
            if (count-- <= 0)
            {
                break;
            }

            Assert.That(evt, Is.Not.Null);
            Assert.That(evt.Id, !(Is.Null.Or.Empty));
            Assert.That(evt.CreatedAt, Is.GreaterThan(START_2024));
            Assert.That(evt.Level, !(Is.Null.Or.Empty));
            Assert.That(evt.Message, !(Is.Null.Or.Empty));

            bool added = ids.Add(evt.Id);
            Assert.That(added, Is.True, "Duplicate event ID detected {0}", evt.Id);
        }
    }

    [RecordedTest]
    public async Task CreateAndCancelFineTuning()
    {
        var fineTuningFile = Assets.FineTuning;

        FineTuningClient client = GetTestClient();
        OpenAIFileClient fileClient = GetTestClientFrom<OpenAIFileClient>(client);

        OpenAIFile uploadedFile;
        try
        {
            ClientResult fileResult = await fileClient.GetFileAsync("file-db5f5bfe5ea04ffcaeba89947a872828", new RequestOptions() { });
            uploadedFile = ValidateAndParse<OpenAIFile>(fileResult);
        }
        catch (ClientResultException e)
        {
            if (e.Message.Contains("ResourceNotFound"))
            {
                // upload training data
                uploadedFile = await UploadAndWaitForCompleteOrFail(fileClient, fineTuningFile.RelativePath);
            }
            else
            {
                throw;
            }
        }

        // Create the fine tuning job
        FineTuningJob operation = await client.FineTuneAsync("gpt-3.5-turbo", uploadedFile.Id);
        FineTuningJob job = ValidateAndParse<FineTuningJob>(ClientResult.FromResponse(operation.GetRawResponse()));
        Assert.That(job.JobId, !(Is.Null.Or.Empty));

        await using RunOnScopeExit _ = new(async () =>
        {
            bool deleted = await DeleteJobAndVerifyAsync((AzureFineTuningJob)operation, job.JobId, client);
            Assert.True(deleted, "Failed to delete fine tuning job: {0}", job.JobId);
        });

        // Wait for some events to become available
        ClientResult result;
        ListResponse<FineTuningEvent> events;
        int maxLoops = 10;
        do
        {
            result = await operation.GetEventsAsync(null, 10, new()).GetRawPagesAsync().FirstOrDefaultAsync();
            events = ValidateAndParse<ListResponse<FineTuningEvent>>(result);

            if (events.Data?.Count > 0)
            {
                Assert.That(events.Data[0], Is.Not.Null);
                Assert.That(events.Data[0].Id, !(Is.Null.Or.Empty));
                Assert.That(events.Data[0].Level, !(Is.Null.Or.Empty));
                Assert.That(events.Data[0].Message, !(Is.Null.Or.Empty));
                Assert.That(events.Data[0].CreatedAt, Is.GreaterThan(START_2024));

                break;
            }

            await Task.Delay(TimeSpan.FromSeconds(2));

        } while (maxLoops-- > 0);

        // Cancel the fine tuning job
        await operation.CancelAndUpdateAsync();

        // Make sure the job status shows as cancelled
        await operation.WaitForCompletionAsync();
        Assert.True(operation.HasCompleted);
    }

    [RecordedTest]
    public async Task CreateAndDeleteFineTuning()
    {
        var fineTuningFile = Assets.FineTuning;

        FineTuningClient client = GetTestClient();
        OpenAIFileClient fileClient = GetTestClientFrom<OpenAIFileClient>(client);
        OpenAIFile uploadedFile;
        try
        {
            ClientResult fileResult = await fileClient.GetFileAsync("file-db5f5bfe5ea04ffcaeba89947a872828", new RequestOptions() { });
            uploadedFile = ValidateAndParse<OpenAIFile>(fileResult);
        }
        catch (ClientResultException e)
        {
            if (e.Message.Contains("ResourceNotFound"))
            {
                // upload training data
                uploadedFile = await UploadAndWaitForCompleteOrFail(fileClient, fineTuningFile.RelativePath);
            }
            else
            {
                throw;
            }
        }

        // Create the fine tuning job
        var requestContent = new FineTuningOptions()
        {
            Hyperparameters = new()
            {
                CycleCount = 1,
                BatchSize = 11,
            }
        };

        FineTuningJob job = await client.FineTuneAsync("gpt-3.5-turbo", uploadedFile.Id, requestContent);
        Assert.That(job.JobId, Is.Not.Null.Or.Empty);
        Assert.That(job.Status, !(Is.Null.Or.EqualTo("failed").Or.EqualTo("cancelled")));
        await job.CancelAndUpdateAsync();

        // Wait for the fine tuning to complete
        await job.WaitForCompletionAsync();

        
        Assert.That(job.Status, Is.EqualTo("cancelled"), "Fine tuning did not cancel");

        // Delete the fine tuned model
        bool deleted = await DeleteJobAndVerifyAsync((AzureFineTuningJob)job, job.JobId, client);
        Assert.True(deleted, "Failed to delete fine tuning model: {0}", job.Value);
    }

    [RecordedTest]//AutomaticRecord = false)]
    [Category("LongRunning")] // CAUTION: This test can take around 10 to 15 *minutes* in live mode to run
    public async Task DeployAndChatWithModel()
    {
        string fineTunedModel = GetFineTunedModel();
        FineTuningClient client = GetTestClient();

        AzureDeploymentClient deploymentClient = GetTestClientFrom<AzureDeploymentClient>(client);
        string? deploymentName = null;
        await using RunOnScopeExit _ = new(async () =>
        {
            if (deploymentName != null)
            {
                await deploymentClient.DeleteDeploymentAsync(deploymentName);
            }
        });

        // Check if the model exists by searching all jobs
        FineTuningJob? job = await client.ListJobsAsync()
            .FirstOrDefaultAsync(j => j.Value == fineTunedModel);
        Assert.That(job, Is.Not.Null);
        Assert.That(job!.Status, Is.EqualTo("succeeded"));

        // Deploy the model and wait for the deployment to finish
        deploymentName = "azure-ai-openai-test-" + Recording?.Random.NewGuid().ToString();
        AzureDeployedModel deployment = await deploymentClient.CreateDeploymentAsync(deploymentName, fineTunedModel);
        Assert.That(deployment, Is.Not.Null);
        Assert.That(deployment.ID, !(Is.Null.Or.Empty));
        Assert.That(deployment.Properties, Is.Not.Null);

        deployment = await WaitUntilReturnLast(
            deployment,
            () => deploymentClient.GetDeploymentAsync(deploymentName),
            (d) =>
            {
                Assert.That(deployment?.Properties?.ProvisioningState, !(Is.Null.Or.Empty));

                return d.Properties.ProvisioningState == "Succeeded"
                    || d.Properties.ProvisioningState == "Failed"
                    || d.Properties.ProvisioningState == "Canceled";
            },
            TimeSpan.FromMinutes(1),
            TimeSpan.FromMinutes(30));

        Assert.That(deployment.Properties.ProvisioningState, Is.EqualTo("Succeeded"));

        // Run a chat completion test
        ChatClient chatClient = GetTestClientFrom<ChatClient>(client, deploymentName);

        ChatCompletion completion = await chatClient.CompleteChatAsync(
        [
            new SystemChatMessage("Convert sports headline to JSON: \"player\" (full name), \"team\", \"sport\", and \"gender\". If more than one return an array. No markdown"),
            new UserChatMessage("Pavleski will not play in 2024-2025 season")
        ]);
        Assert.That(completion, Is.Not.Null);
        Assert.That(completion.FinishReason, Is.EqualTo(ChatFinishReason.Stop));
        Assert.That(completion.Content, Has.Count.GreaterThan(0));
        Assert.That(completion.Content[0].Kind, Is.EqualTo(ChatMessageContentPartKind.Text));
        Assert.That(completion.Content[0].Text, !Is.Null.Or.Empty);

        // we expect a JSON payload as the response so let's try to deserialize it
        using var jsonDoc = JsonDocument.Parse(completion.Content[0].Text, new()
        {
            AllowTrailingCommas = true,
            CommentHandling = JsonCommentHandling.Skip,
            MaxDepth = 2
        });
        JsonElement json = jsonDoc.RootElement;
        if (json.ValueKind == JsonValueKind.Array)
        {
            json = json.EnumerateArray().FirstOrDefault();
        }

        Assert.That(json.ValueKind, Is.EqualTo(JsonValueKind.Object));
        Assert.That(json.EnumerateObject().Select(p => p.Name), Has.Some.Match("(player)|(team)|(sport)|(gender)"));
    }

    #region helper methods

    private string GetFineTunedModel()
    {
        string? model = TestConfig.GetConfig<FineTuningClient>()
            ?.GetValue<string>("fine_tuned_model");
        Assert.That(model, !(Is.Null.Or.Empty), "Failed to find the already fine tuned model to use");
        return model!;
    }

    private async Task<OpenAIFile> UploadAndWaitForCompleteOrFail(OpenAIFileClient fileClient, string path)
    {
        OpenAIFile uploadedFile = await fileClient.UploadFileAsync(path, FileUploadPurpose.FineTune);
        Validate(uploadedFile);

#pragma warning disable CS0618
        uploadedFile = await WaitUntilReturnLast(
            uploadedFile,
            () => fileClient.GetFileAsync(uploadedFile.Id),
            f => f.Status == FileStatus.Processed || f.Status == FileStatus.Error,
            TimeSpan.FromSeconds(5),
            TimeSpan.FromMinutes(5))
            .ConfigureAwait(false);
#pragma warning restore CS0618

        return uploadedFile;
    }

    private async Task<bool> DeleteJobAndVerifyAsync(AzureFineTuningJob operation, string jobId, FineTuningClient client, TimeSpan? timeBetween = null, TimeSpan? maxWaitTime = null)
    {
        var stopTime = DateTimeOffset.Now + (maxWaitTime ?? TimeSpan.FromMinutes(1));
        var sleepTime = timeBetween ?? TimeSpan.FromSeconds(2);

        RequestOptions noThrow = new()
        {
            ErrorOptions = ClientErrorBehaviors.NoThrow
        };


        bool success = false;
        while (DateTimeOffset.Now < stopTime)
        {
            ClientResult result = IsAsync
                ? await operation.DeleteJobAsync(jobId, noThrow).ConfigureAwait(false)
                : operation.DeleteJob(jobId, noThrow);
            Assert.That(result, Is.Not.Null);

            // verify the deletion actually succeeded
            var result2 = await client.GetJobAsync(jobId, noThrow.CancellationToken).ConfigureAwait(false);
            
            var rawResponse = result2.GetRawResponse();
            success = rawResponse.Status == 404;
            if (success)
            {
                break;
            }

            await Task.Delay(sleepTime).ConfigureAwait(false);
        }

        return success;
    }

    #endregion

#else

    [Test]
    [SyncOnly]
    public void UnsupportedVersionFineTuningClientThrows()
    {
        Assert.Throws<InvalidOperationException>(() => GetTestClient());
    }

#endif
}
