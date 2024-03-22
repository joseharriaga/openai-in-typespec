using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAI;

internal static partial class PipelineMessageClassifiers
{
    private static PipelineMessageClassifier? _responseErrorClassifier200;
    internal static PipelineMessageClassifier ResponseErrorClassifier200
        => _responseErrorClassifier200 ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });
}