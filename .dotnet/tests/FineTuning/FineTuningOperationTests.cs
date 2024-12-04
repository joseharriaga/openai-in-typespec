using NUnit.Framework;
using OpenAI.FineTuning;
using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Tests.FineTuning;


[Parallelizable(ParallelScope.Fixtures)]
[Category("FineTuning")]
[Category("Unit")]

internal class FineTuningOperationTests
{
    //[Test]
    //[Parallelizable]
    //public void TestInProgress()
    //{
    //    FineTuningOperation job;
    //    job = JobStub(status: FineTuningStatus.Queued);
    //    Assert.IsTrue(job.Status.InProgress);

    //    job = JobStub(status: FineTuningStatus.Succeeded);
    //    Assert.IsFalse(job.Status.InProgress);
    //}

    //private static FineTuningOperation JobStub(FineTuningStatus? status = null)
    //{
    //    //FineTuningOperation op = new FineTuningOperation(null, null, "ftjob-unitTest", new ResponseStub());
    //    ////PipelineResponse response = new PipelineResponse(200, null, null, null);
    //    //return ModelReaderWriter.Read<FineTuningOperation>(BinaryData.FromString($$"""
    //    //{
    //    //  "object": "fine_tuning.job",
    //    //  "id": "ftjob-unitTest",
    //    //  "created_at": {{DateTimeOffset.MinValue.ToUnixTimeSeconds()}},
    //    //  "error": null,
    //    //  "fine_tuned_model": "ft:gpt-3.5-turbo-0125:personal::unitTest",
    //    //  "finished_at": {{DateTimeOffset.Now.ToUnixTimeSeconds()}},
    //    //  "hyperparameters": {},
    //    //  "model": "gpt-3.5-turbo-0125",
    //    //  "organization_id": "org-unitTest",
    //    //  "result_files": ["file-unitTest"],
    //    //  "status": "{{status ?? FineTuningStatus.Succeeded}}",
    //    //  "trained_tokens": 0,
    //    //  "training_file": "file-unitTest",
    //    //  "validation_file": "file-unitTest",
    //    //  "seed": 0
    //    //}
    //    //"""));

    //    return new FineTuningOperation(null, null, "ftjob-unitTest", new ResponseStub());
    //}
}

class ResponseStub : PipelineResponse
{
    public ResponseStub()
    {
    }

    public override int Status => throw new NotImplementedException();

    public override string ReasonPhrase => throw new NotImplementedException();

    public override Stream ContentStream { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override BinaryData Content => throw new NotImplementedException();

    protected override PipelineResponseHeaders HeadersCore => throw new NotImplementedException();

    public override BinaryData BufferContent(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override void Dispose()
    {
        throw new NotImplementedException();
    }
}