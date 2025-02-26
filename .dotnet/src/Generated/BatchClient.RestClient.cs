// <auto-generated/>

#nullable disable

using System.ClientModel.Primitives;
using OpenAI;

namespace OpenAI.Batch
{
    public partial class BatchClient
    {
        private static PipelineMessageClassifier _pipelineMessageClassifier200;

        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

        internal virtual PipelineMessage CreateListBatchesRequest(string after, int? limit, RequestOptions options)
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
    }
}
