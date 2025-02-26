// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.FineTuning;
using OpenAI.TestFramework;
using System;
using System.Threading;




using System.Threading.Tasks;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using Azure.AI.OpenAI.Tests.Models;
using Azure.AI.OpenAI.Tests.Utils;
using Azure.AI.OpenAI.Tests.Utils.Config;
using OpenAI.Chat;
using OpenAI.Files;
using OpenAI.TestFramework.Utils;
using NUnit.Framework.Internal.Commands;
using Azure.AI.OpenAI.Files;


#if !AZURE_OPENAI_GA
using Azure.AI.OpenAI.FineTuning;
#endif

namespace Azure.AI.OpenAI.Tests;

#pragma warning disable CS0618

[Category("FineTuning")]
public class FineTuningTests : AoaiTestBase<FineTuningClient>
{
    public FineTuningTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<FineTuningClient>());

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task CanUploadFileForFineTuning(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        FineTuningClient ftClient = GetTestClient(GetTestClientOptions(version));
        OpenAIFileClient fileClient = GetTestClientFrom<OpenAIFileClient>(ftClient);

        OpenAIFile newFile = await fileClient.UploadFileAsync(
            BinaryData.FromString("this isn't valid input for fine tuning"),
            "intentionally-bad-ft-input.jsonl",
            FileUploadPurpose.FineTune);
        Validate(newFile);

        // In contrast to batch, files uploaded for fine tuning will initially appear in a 'pending' state,
        // transitioning into a terminal as input validation is handled. In this case, because malformed input is
        // uploaded, the terminal status should be 'error'.
        AzureOpenAIFileStatus azureStatus = newFile.GetAzureOpenAIFileStatus();
        Assert.That(azureStatus, Is.EqualTo(AzureOpenAIFileStatus.Pending));

        TimeSpan filePollingInterval = Recording!.Mode == RecordedTestMode.Playback ? TimeSpan.FromMilliseconds(1) : TimeSpan.FromSeconds(5);

        for (int i = 0; i < 10 && azureStatus == AzureOpenAIFileStatus.Pending; i++)
        {
            await Task.Delay(filePollingInterval);
            newFile = await fileClient.GetFileAsync(newFile.Id);
            azureStatus = newFile.GetAzureOpenAIFileStatus();
        }

        Assert.That(azureStatus, Is.EqualTo(AzureOpenAIFileStatus.Error));
        Assert.That(newFile.StatusDetails.ToLower(), Does.Contain("validation of jsonl"));
    }

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    //[TestCase(null)]
    public async Task JobsFineTuning(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        FineTuningClient client = GetTestClient(GetTestClientOptions(version));

        int count = 25;

        await foreach (FineTuningJob job in client.GetJobsAsync(options: new() { PageSize = 10 }))
        {
            if (count-- <= 0)
            {
                break;
            }

            Assert.That(job, Is.Not.Null);
            Assert.That(job.Value, Is.Null.Or.Not.Empty); // this either null or set to some non-empty value
            Assert.That(job.Status, Is.Not.Null.Or.Empty);
        }
    }

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task CheckpointsFineTuning(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        FineTuningClient client = GetTestClient(GetTestClientOptions(version));

        FineTuningJob job = await client.GetJobsAsync(options: new() { PageSize = 10 })
                                        .FirstOrDefaultAsync(j => j.Status == "succeeded");

        Assert.That(job, Is.Not.Null);
        Assert.That(job.Status, Is.EqualTo("succeeded"));

        Console.WriteLine("Job id: " + job.JobId);

        var checkpoints = job.GetCheckpointsAsync();

        await checkpoints.ToListAsync();

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
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    //[TestCase(null)]
    public async Task EventsFineTuning(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        FineTuningClient client = GetTestClient(GetTestClientOptions(version));
        string fineTunedModel = GetFineTunedModel();

        // Check if the model exists by searching all jobs
        var alljobs = client.GetJobsAsync();

        await alljobs.ToListAsync();

        FineTuningJob job = await alljobs.FirstOrDefaultAsync(j => j.Value == fineTunedModel)!;

        Assert.NotNull(job);
        Assert.AreEqual(job.Status, "succeeded");

        HashSet<string> ids = [];

        int count = 25;
        var asyncEnum = job.GetEventsAsync(new() { PageSize = count });

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
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    public async Task CreateCancelDelete(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        FineTuningClient client = GetTestClient(GetTestClientOptions(version));
        var fineTuningFile = Assets.FineTuning;

        OpenAIFileClient fileClient = GetTestClientFrom<OpenAIFileClient>(client);

        var uploadedFile = await UploadAndWaitForCompleteOrFail(fileClient, Assets.FineTuning.RelativePath);


        FineTuningJob job = await client.FineTuneAsync(
            "gpt-4o-mini",
            uploadedFile.Id,
            waitUntilCompleted: false, new() { TrainingMethod = FineTuningTrainingMethod.CreateSupervised() });

        Assert.That(job.JobId, Is.Not.Null.Or.Empty);
        Assert.That(job.Status, !(Is.Null.Or.EqualTo("failed").Or.EqualTo("cancelled")));

        await job.CancelAndUpdateAsync();

        // Wait for the fine tuning to complete
        await job.WaitForCompletionAsync();

        Assert.That(job.Status, Is.EqualTo("cancelled"), "Fine tuning did not cancel");

        // Delete the fine tuned model
        bool deleted = await DeleteJobAndVerifyAsync((AzureFineTuningJob)job, client);
        Assert.True(deleted, "Failed to delete fine tuning model: {0}", job.Value);
    }

    [RecordedTest]
#if !AZURE_OPENAI_GA
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_12_01_Preview)]
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2025_01_01_Preview)]
#else
    [TestCase(AzureOpenAIClientOptions.ServiceVersion.V2024_10_21)]
#endif
    [TestCase(null)]
    [Category("LongRunning")] // CAUTION: This test can take around 10 to 15 *minutes* in live mode to run
    [NonParallelizable]
    public async Task DeployAndChatWithModel(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        FineTuningClient client = GetTestClient(GetTestClientOptions(version));
        string fineTunedModel = GetFineTunedModel();

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
        FineTuningJob? job = await client.GetJobsAsync()
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

    private TestClientOptions GetTestClientOptions(AzureOpenAIClientOptions.ServiceVersion? version)
    {
        return version is null ? new TestClientOptions() : new TestClientOptions(version.Value);
    }

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

    private async Task<bool> DeleteJobAndVerifyAsync(AzureFineTuningJob job, FineTuningClient client, TimeSpan? timeBetween = null, TimeSpan? maxWaitTime = null)
    {
        var stopTime = DateTimeOffset.Now + (maxWaitTime ?? TimeSpan.FromMinutes(1));
        TimeSpan sleepTime = timeBetween ?? (Recording!.Mode == RecordedTestMode.Playback ? TimeSpan.FromMilliseconds(1): TimeSpan.FromSeconds(2));

        RequestOptions noThrow = new()
        {
            ErrorOptions = ClientErrorBehaviors.NoThrow
        };


        bool success = false;
        while (DateTimeOffset.Now < stopTime)
        {
            ClientResult result = IsAsync
                ? await job.DeleteJobAsync(job.JobId, noThrow).ConfigureAwait(false)
                : job.DeleteJob(job.JobId, noThrow);
            Assert.That(result, Is.Not.Null);

            // verify the deletion actually succeeded
            try
            {
                await client.GetJobAsync(job.JobId, noThrow.CancellationToken).ConfigureAwait(false);
            }
            catch (ClientResultException ex) when (ex.Status == 404)
            {
                success = true;
                break;
            }
            await Task.Delay(sleepTime).ConfigureAwait(false);
        }

        return success;
    }

    #endregion


    [Test]
    [SyncOnly]
    public void UnsupportedVersionFineTuningClientThrows()
    {
        Assert.Throws<InvalidOperationException>(() => GetTestClient());
    }

    [Test]
    [SyncOnly]
    public void TestSomething()
    {
        FineTuningClient client = GetTestClient();

    }

}
