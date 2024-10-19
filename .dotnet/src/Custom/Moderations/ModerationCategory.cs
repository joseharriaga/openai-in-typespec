using System.Collections.Generic;

namespace OpenAI.Moderations;

public partial class ModerationCategory
{
    internal ModerationCategory(bool flagged, float score, ModerationFlaggedContentModalities flaggedContentModalities)
    {
        Flagged = flagged;
        Score = score;
        FlaggedContentModalities = flaggedContentModalities;
    }

    public bool Flagged { get; }
    public float Score { get; }
    public ModerationFlaggedContentModalities FlaggedContentModalities { get; }
}
