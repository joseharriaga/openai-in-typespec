using System;

namespace OpenAI.Chat;

[Flags]
public enum ChatContentModalities : int
{
    Text = 1 << 0,
    Audio = 1 << 1,
}