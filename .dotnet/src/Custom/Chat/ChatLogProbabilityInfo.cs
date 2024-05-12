using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OpenAI.Chat;

/// <summary>
/// Represents a collection of log probability result information as requested via
/// <see cref="ChatCompletionOptions.IncludeLogProbabilities"/>.
/// </summary>
[CodeGenModel("CreateChatCompletionResponseChoiceLogprobs")]
public partial class ChatLogProbabilityInfo
{
    // CUSTOM: Renamed.
    /// <summary> A list of message content tokens with log probability information. </summary>
    [CodeGenMember("Content")]
    public IReadOnlyList<ChatTokenLogProbabilityInfo> ContentTokenLogProbabilities { get; }
}