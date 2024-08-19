using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.Files;

[CodeGenClient("Uploads")]
internal partial class InternalUploadsClient
{
    protected internal InternalUploadsClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }
}
