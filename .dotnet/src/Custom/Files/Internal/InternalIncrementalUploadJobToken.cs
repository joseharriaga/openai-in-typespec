using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Files;

internal partial class InternalIncrementalUploadJobToken : ContinuationToken
{
    public InternalUploadJobInfo JobInfo { get; }

    public InternalIncrementalUploadJobToken(InternalUploadJobInfo jobInfo)
    {
        JobInfo = jobInfo;
    }

    public override BinaryData ToBytes() => ModelReaderWriter.Write(JobInfo);

    public static InternalIncrementalUploadJobToken FromToken(ContinuationToken genericToken)
    {
        if (genericToken is InternalIncrementalUploadJobToken specificToken)
        {
            return specificToken;
        }

        BinaryData data = genericToken.ToBytes();
        InternalUploadJobInfo jobInfo = ModelReaderWriter.Read<InternalUploadJobInfo>(data);
        return new InternalIncrementalUploadJobToken(jobInfo);
    }
}
