// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using OpenAI;

namespace OpenAI.Assistants
{
    internal partial class InternalAssistantRunClient
    {
        private static PipelineMessageClassifier _pipelineMessageClassifier200;
        private static PipelineMessageClassifier _pipelineMessageClassifier201;
        private static PipelineMessageClassifier _pipelineMessageClassifier204;
        private static Classifier2xxAnd4xx _pipelineMessageClassifier2xxAnd4xx;

        private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

        private static PipelineMessageClassifier PipelineMessageClassifier201 => _pipelineMessageClassifier201 = PipelineMessageClassifier.Create(stackalloc ushort[] { 201 });

        private static PipelineMessageClassifier PipelineMessageClassifier204 => _pipelineMessageClassifier204 = PipelineMessageClassifier.Create(stackalloc ushort[] { 204 });

        private static Classifier2xxAnd4xx PipelineMessageClassifier2xxAnd4xx => _pipelineMessageClassifier2xxAnd4xx ??= new Classifier2xxAnd4xx();

        internal PipelineMessage CreateCreateThreadAndRunRequest(BinaryContent content, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "POST";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/threads/runs", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateCreateRunRequest(string threadId, BinaryContent content, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "POST";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateListRunsRequest(string threadId, int? limit, string order, string after, string before, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "GET";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs", false);
            if (limit != null)
            {
                uri.AppendQuery("limit", TypeFormatters.ConvertToString(limit, null), true);
            }
            if (order != null)
            {
                uri.AppendQuery("order", order, true);
            }
            if (after != null)
            {
                uri.AppendQuery("after", after, true);
            }
            if (before != null)
            {
                uri.AppendQuery("before", before, true);
            }
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateGetRunRequest(string threadId, string runId, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "GET";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateModifyRunRequest(string threadId, string runId, BinaryContent content, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "POST";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateCancelRunRequest(string threadId, string runId, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "POST";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            uri.AppendPath("/cancel", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateSubmitToolOutputsToRunRequest(string threadId, string runId, BinaryContent content, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "POST";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            uri.AppendPath("/submit_tool_outputs", false);
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            request.Headers.Set("Content-Type", "application/json");
            request.Content = content;
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateListRunStepsRequest(string threadId, string runId, int? limit, string order, string after, string before, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "GET";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            uri.AppendPath("/steps", false);
            if (limit != null)
            {
                uri.AppendQuery("limit", TypeFormatters.ConvertToString(limit, null), true);
            }
            if (order != null)
            {
                uri.AppendQuery("order", order, true);
            }
            if (after != null)
            {
                uri.AppendQuery("after", after, true);
            }
            if (before != null)
            {
                uri.AppendQuery("before", before, true);
            }
            request.Uri = uri.ToUri();
            request.Headers.Set("Accept", "application/json");
            message.Apply(options);
            return message;
        }

        internal PipelineMessage CreateGetRunStepRequest(string threadId, string runId, string stepId, RequestOptions options)
        {
            PipelineMessage message = Pipeline.CreateMessage();
            message.ResponseClassifier = PipelineMessageClassifier200;
            PipelineRequest request = message.Request;
            request.Method = "GET";
            ClientUriBuilder uri = new ClientUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/threads/", false);
            uri.AppendPath(threadId, true);
            uri.AppendPath("/runs/", false);
            uri.AppendPath(runId, true);
            uri.AppendPath("/steps/", false);
            uri.AppendPath(stepId, true);
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