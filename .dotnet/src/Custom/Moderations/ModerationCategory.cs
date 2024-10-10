using System.Collections.Generic;

namespace OpenAI.Moderations;

public partial class ModerationCategory
{
    internal ModerationCategory(bool flagged, float score, IEnumerable<string> internalAppliedInputTypes)
    {
        Flagged = flagged;
        Score = score;
        InputKinds = ModerationInputKindsExtensions.FromInternalInputKinds(internalAppliedInputTypes);
    }

    public bool Flagged { get; }
    public float Score { get; }
    public ModerationInputKinds InputKinds { get; }
}
