namespace OpenAI.Moderations;

public partial class ModerationCategory
{
    internal ModerationCategory(bool flagged, float score)
    {
        IsFlagged = flagged;
        Score = score;
    }

    public bool IsFlagged { get; }
    public float Score { get; }
}
