using System;

namespace OpenAI.Moderations;

[Flags]
public enum ModerationInputKinds : int
{
    Other = 1 << 0,
    Text = 1 << 1,
    Image = 1 << 2,
    // Audio = 1 << 3,
}