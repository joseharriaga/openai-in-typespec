using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAI;

public class AzureOpenAIClientOptions : OpenAIClientOptions
{
    ToAzureRequestPolicy _policy;
    DeploymentsOptions _deployments = new DeploymentsOptions();

    public AzureOpenAIClientOptions(Uri endpoint, ApiKeyCredential apiKey, ServiceVersion version = ServiceVersion.V20231201_preview)
    {
        _policy = new ToAzureRequestPolicy(endpoint, apiKey, version, _deployments);
        base.AddPolicy(_policy, PipelinePosition.BeforeTransport);
    }

    public DeploymentsOptions Deployments => _deployments;

    public enum ServiceVersion
    {
        V20231201_preview
    }

    class ToAzureRequestPolicy : PipelinePolicy
    {
        Uri _endpoint;
        string _version;
        ApiKeyCredential _apiKey;
        DeploymentsOptions _deployments;

        public ToAzureRequestPolicy(Uri endpoint, ApiKeyCredential apiKey, ServiceVersion version, DeploymentsOptions deployments)
        {
            _endpoint=endpoint;
            _version=version == ServiceVersion.V20231201_preview ? "2023-12-01-preview" : throw new NotSupportedException();
            _apiKey=apiKey;
            _deployments=deployments;
        }

        private void RewriteRequest(PipelineMessage message)
        {
            _apiKey.Deconstruct(out string key);
            message.Request.Headers.Add("api-key", key);
            message.Request.Headers.Remove("Authorization");

            var uri = message.Request.Uri.PathAndQuery.ToString();
            if (uri.EndsWith("chat/completions"))
            {
                message.Request.Uri = new Uri($"{_endpoint}openai/deployments/{_deployments.Chat}/chat/completions?api-version={_version}");
            }
            else if (uri.EndsWith("embeddings"))
            {
                message.Request.Uri = new Uri($"{_endpoint}openai/deployments/{_deployments.Embeddigs}/embeddings?api-version={_version}");
            }
            else throw new NotImplementedException();
        }

        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            RewriteRequest(message);
            ProcessNext(message, pipeline, currentIndex);
        }

        public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
        {
            RewriteRequest(message);
            await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
        }
    }
}

public class DeploymentsOptions
{
    public string Chat { get; set; }
    public string Embeddigs { get; set; }
}


