// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using OpenAI;

namespace OpenAI.Batch
{
    public partial class BatchClient
    {
        private static PipelineMessageClassifier _pipelineMessageClassifier200;
        private static PipelineMessageClassifier _pipelineMessageClassifier204;
        private static OpenAI.BatchClient.Classifier2xxAnd4xx _pipelineMessageClassifier2xxAnd4xx;

        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

        private static PipelineMessageClassifier PipelineMessageClassifier204 => _pipelineMessageClassifier204 = PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });

        private static OpenAI.BatchClient.Classifier2xxAnd4xx PipelineMessageClassifier2xxAnd4xx => _pipelineMessageClassifier2xxAnd4xx ??= new OpenAI.BatchClient.Classifier2xxAnd4xx();

        internal PipelineMessage CreateListBatchesRequest(string after, int? limit, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "GET";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/batches", false);
            if (after != null)
            {
                uri.AppendQuery("after", after, true);
            }
            if (limit != null)
            {
                uri.AppendQuery("limit", TypeFormatters.ConvertToString(limit, null), true);
            }
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        private class Classifier2xxAnd4xx : PipelineMessageClassifier
        {
            public override bool TryClassify(PipelineMessage message, out bool isError)
            {
                isError = false;
                if (message.Response == null)
                {
                    return false;
                }
                isError = message.Response.Status switch
                {
                    >= 200 and < 300 => false,
                    >= 400 and < 500 => false,
                    _ => true
                };
                return true;
            }

            public override bool TryClassify(PipelineMessage message, Exception exception, out bool isRetryable)
            {
                isRetryable = false;
                return false;
            }
        }
    }
}
