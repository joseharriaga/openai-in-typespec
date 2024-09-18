using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Moderations;

/// <summary> Model factory for models. </summary>
public static partial class OpenAIModerationsModelFactory
{
    /// <summary> Initializes a new instance of <see cref="OpenAI.Moderations.ModerationCategory"/>. </summary>
    /// <returns> A new <see cref="OpenAI.Moderations.ModerationCategory"/> instance for mocking. </returns>
    public static ModerationCategory ModerationCategory(bool isFlagged = default, float score = default)
    {
        return new ModerationCategory(isFlagged, score);
    }

    /// <summary> Initializes a new instance of <see cref="OpenAI.Moderations.ModerationCollection"/>. </summary>
    /// <returns> A new <see cref="OpenAI.Moderations.ModerationCollection"/> instance for mocking. </returns>
    public static ModerationCollection ModerationCollection(string id = null, string model = null, IEnumerable<ModerationResult> items = null)
    {
        items ??= new List<ModerationResult>();

        return new ModerationCollection(
            id,
            model,
            items.ToList(),
            serializedAdditionalRawData: null);
    }

    /// <summary> Initializes a new instance of <see cref="OpenAI.Moderations.ModerationResult"/>. </summary>
    /// <returns> A new <see cref="OpenAI.Moderations.ModerationResult"/> instance for mocking. </returns>
    public static ModerationResult ModerationResult(bool flagged = default, ModerationCategory hate = default, ModerationCategory hateThreatening = default, ModerationCategory harassment = default, ModerationCategory harassmentThreatening = default, ModerationCategory selfHarm = default, ModerationCategory selfHarmIntent = default, ModerationCategory selfHarmInstructions = default, ModerationCategory sexual = default, ModerationCategory sexualMinors = default, ModerationCategory violence = default, ModerationCategory violenceGraphic = default)
    {
        return new ModerationResult(
            flagged,
            hate,
            hateThreatening,
            harassment,
            harassmentThreatening,
            selfHarm,
            selfHarmIntent,
            selfHarmInstructions,
            sexual,
            sexualMinors,
            violence,
            violenceGraphic,
            serializedAdditionalRawData: null);
    }
}
