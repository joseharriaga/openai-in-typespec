using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Files;

internal partial class InternalIncrementalUploadJobToken : ContinuationToken
{
    public InternalUpload Upload { get; }

    public InternalIncrementalUploadJobToken(InternalUpload jobInfo)
    {
        Upload = jobInfo;
    }

    public override BinaryData ToBytes() => ModelReaderWriter.Write(Upload);

    public static InternalIncrementalUploadJobToken FromToken(ContinuationToken genericToken)
    {
        if (genericToken is InternalIncrementalUploadJobToken specificToken)
        {
            return specificToken;
        }

        BinaryData data = genericToken.ToBytes();
        InternalUpload jobInfo = ModelReaderWriter.Read<InternalUpload>(data);
        return new InternalIncrementalUploadJobToken(jobInfo);
    }
}
