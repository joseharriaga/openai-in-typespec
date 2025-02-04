using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Chat;

// CUSTOM: Added base type.

[CodeGenModel("PredictionContent")]
internal partial class InternalPredictionContent : ChatOutputPrediction
{

}