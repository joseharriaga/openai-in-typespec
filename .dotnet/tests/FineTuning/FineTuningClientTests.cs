using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenAI.Files;
using OpenAI.FineTuning;
using System;
using System.ClientModel;
using System.IO;
using System.Threading.Tasks;

namespace OpenAI.Tests.FineTuning
{
    [TestFixture]
    public class FineTuningClientTests
    {
        FineTuningClient client;
        FileClient fileClient;
        OpenAIFileInfo sampleFile;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new FineTuningClient();
            fileClient = new FileClient();
            string path = Path.Combine("Assets", "fine_tuning_sample.jsonl");

            sampleFile = fileClient.UploadFile(path, "fine-tune");

        }
        [OneTimeTearDown]
        public void TearDown()
        {
            fileClient.DeleteFile(sampleFile.Id);
        }

        [Test]
        [Parallelizable]
        public void ExceptionThrownOnInvalidFileName()
        {
            Assert.Throws<ClientResultException>(() =>
                client.CreateJob(model: "gpt-3.5-turbo", trainingFile: "Invalid File Name")
            );
        }

        [Test]
        [Parallelizable]
        public void ExceptionThrownOnInvalidModelName()
        {
            Assert.Throws<ClientResultException>(() =>
                client.CreateJob(model: "gpt-nonexistent", trainingFile: sampleFile.Id)
            );
        }

        [Test]
        [Parallelizable]
        public void CreateAndCancelJob()
        {

            FineTuningJob job = client.CreateJob("gpt-3.5-turbo", sampleFile.Id);

            Assert.True(job.Status.InProgress());
            Assert.AreEqual(0, job.Hyperparameters.GetCycleCount());

            job = client.CancelJob(job.Id);

            Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
            Assert.AreEqual("fine_tuning.job", job.Object);
            Assert.False(job.Status.InProgress());
        }

        [Test]
        [Parallelizable]
        public void CreateAndCancelJobWithHyperparams()
        {

            var hp = new HyperparameterOptions(cycleCount: 1, batchSize: 2, learningRate: 3);

            FineTuningJob job = client.CreateJob("gpt-3.5-turbo", sampleFile.Id, hyperparameters: hp);

            Assert.AreEqual(1, job.Hyperparameters.GetCycleCount());
            Assert.AreEqual(2, job.Hyperparameters.GetBatchSize());
            Assert.AreEqual(3, job.Hyperparameters.GetLearningRateMultiplier());

            client.CancelJob(job.Id);
        }

        [Test]
        [Parallelizable]
        public async Task CreateAndCancelJobAsync()
        {
            var hp = new FineTuningJobHyperparameters(nEpochs: 1, batchSize: 2, learningRateMultiplier: 3);

            FineTuningJob job = await client.CreateJobAsync("gpt-3.5-turbo", sampleFile.Id);
            Assert.True(job.Status.InProgress());
            job = await client.CancelJobAsync(job.Id);
            Assert.AreEqual(FineTuningJobStatus.Cancelled, job.Status);
            Assert.False(job.Status.InProgress());
        }
    }
}