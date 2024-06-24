using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAI.Tests.Utility;

public class SimpleMockPipelineTransport : PipelineTransport
{
    public SimpleMockPipelineRequest MockRequest { get; set; }
    public SimpleMockPipelineResponse MockResponse { get; set; }

    public SimpleMockPipelineTransport(BinaryData requestData, BinaryData responseData)
    {
        MockRequest = new SimpleMockPipelineRequest(requestData);
        MockResponse = new SimpleMockPipelineResponse(responseData);
    }

    protected override PipelineMessage CreateMessageCore()
    {
        return new SimpleMockPipelineMessage(MockRequest);
    }

    protected override void ProcessCore(PipelineMessage message)
    {
        (message as SimpleMockPipelineMessage).SetResponse(MockResponse);
    }

    protected override ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        (message as SimpleMockPipelineMessage).SetResponse(MockResponse);
        return ValueTask.CompletedTask;
    }

    public class SimpleMockPipelineRequest : PipelineRequest
    {
        protected override string MethodCore { get; set; } = "POST";

        protected override Uri UriCore { get; set; }

        protected override PipelineRequestHeaders HeadersCore { get; } = new SimpleMockPipelineRequestHeaders();

        protected override BinaryContent ContentCore { get; set; }

        public SimpleMockPipelineRequest(BinaryData requestData)
        {
            ContentCore = BinaryContent.Create(requestData);
        }

        public override void Dispose()
        {
            ContentCore?.Dispose();
        }

        public class SimpleMockPipelineRequestHeaders : PipelineRequestHeaders
        {
            private readonly Dictionary<string, string> _headers = [];
            public override void Add(string name, string value) => _headers[name] = value;
            public override IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _headers.GetEnumerator();
            public override bool Remove(string name) => _headers.Remove(name);
            public override void Set(string name, string value) => _headers[name] = value;
            public override bool TryGetValue(string name, out string value) => _headers.TryGetValue(name, out value);
            public override bool TryGetValues(string name, out IEnumerable<string> values)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class SimpleMockPipelineResponse : PipelineResponse
    {
        public override int Status { get; } = 200;

        public override string ReasonPhrase => throw new NotImplementedException();

        public override Stream ContentStream { get; set; }

        public override BinaryData Content
        {
            get
            {
                BufferContent();
                return _bufferedContent;
            }
        }

        protected override PipelineResponseHeaders HeadersCore => throw new NotImplementedException();

        private BinaryData _bufferedContent;

        public SimpleMockPipelineResponse(BinaryData responseData)
        {
            ContentStream = responseData.ToStream();
        }

        public override BinaryData BufferContent(CancellationToken cancellationToken = default)
        {
            if (ContentStream is null) return null;
            if (_bufferedContent is null)
            {
                ContentStream.Position = 0;
                _bufferedContent = BinaryData.FromStream(ContentStream);
            }
            return _bufferedContent;
        }

        public override ValueTask<BinaryData> BufferContentAsync(CancellationToken cancellationToken = default)
        {
            return ValueTask.FromResult(BufferContent(cancellationToken));
        }

        public override void Dispose()
        {
            ContentStream?.Dispose();
        }
    }

    public class SimpleMockPipelineMessage : PipelineMessage
    {
        protected internal SimpleMockPipelineMessage(PipelineRequest request) : base(request)
        {
        }

        public void SetResponse(SimpleMockPipelineResponse response)
        {
            Response = response;
        }
    }
}
