using System;
using System.ClientModel.Primitives;

namespace OpenAI;

internal static class PipelineClassifiers
{
    internal static PipelineMessageClassifier _pipelineMessageClassifier200;
    internal static PipelineMessageClassifier PipelineMessageClassifier200
        => _pipelineMessageClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
}