// <auto-generated/>

#nullable disable

using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI
{
    internal partial class ErrorResult<T> : ClientResult<T>
    {
        private readonly PipelineResponse _response;
        private readonly ClientResultException _exception;

        public ErrorResult(PipelineResponse response, ClientResultException exception) : base(default, response)
        {
            _response = response;
            _exception = exception;
        }

        public override T Value => throw _exception;
    }
}
