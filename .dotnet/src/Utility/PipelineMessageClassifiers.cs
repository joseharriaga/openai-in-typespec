using System.ClientModel.Primitives;

namespace OpenAI;

internal static partial class PipelineMessageClassifiers
{
    private static PipelineMessageClassifier? _responseErrorClassifier200;
    internal static PipelineMessageClassifier ResponseErrorClassifier200
        => _responseErrorClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
}