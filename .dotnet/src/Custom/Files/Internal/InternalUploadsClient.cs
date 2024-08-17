using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI.Files;

[CodeGenClient("Uploads")]
internal partial class InternalUploadsClient
{
    public InternalUploadsClient(ApiKeyCredential credential, OpenAIClientOptions options = default)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(credential, requireExplicitCredential: true), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    public InternalUploadsClient(OpenAIClientOptions options = default)
        : this(
              OpenAIClient.CreatePipeline(OpenAIClient.GetApiKey(), options),
              OpenAIClient.GetEndpoint(options),
              options)
    { }

    protected internal InternalUploadsClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
    }
}
