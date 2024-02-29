using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAI.Chat;

public class AzureOpenAIClientOptions : OpenAIClientOptions
{
    public AzureOpenAIClientOptions(Uri endpoint, ApiKeyCredential apiKey, string deployment, ServiceVersion version = ServiceVersion.V20231201_preview)
    {
        base.AddPolicy(new ToAzureRequestPolicy(endpoint, apiKey, deployment, version), PipelinePosition.BeforeTransport);
    }

    public enum ServiceVersion
    {
        V20231201_preview
    }

    class ToAzureRequestPolicy : PipelinePolicy
    {
        Uri endpoint;
        string deployment;
        string version;
        ApiKeyCredential apiKey;

        public ToAzureRequestPolicy(Uri endpoint, ApiKeyCredential apiKey, string deployment, ServiceVersion version)
        {
            this.endpoint = endpoint;
            this.deployment = deployment;
            this.version = version == ServiceVersion.V20231201_preview ? "2023-12-01-preview" : throw new NotSupportedException();
            this.apiKey = apiKey;
        }

        private void RewriteRequest(PipelineMessage message)
        {
            apiKey.Deconstruct(out string key);
            message.Request.Headers.Add("api-key", key);
            message.Request.Headers.Remove("Authorization");

            var uri = message.Request.Uri.PathAndQuery.ToString();
            string operation = "";
            if (uri.EndsWith("chat/completions")) operation = "chat/completions";
            else throw new NotImplementedException();
            message.Request.Uri = new Uri($"{endpoint}openai/deployments/{deployment}/{operation}?api-version={version}");
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

