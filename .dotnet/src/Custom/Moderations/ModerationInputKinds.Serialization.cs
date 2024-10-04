using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Moderations;

internal static partial class ModerationInputKindsExtensions
{
    internal static IList<string> ToInternalInputKinds(this ModerationInputKinds inputKinds)
    {
        List<string> internalInputKinds = [];
        if (inputKinds.HasFlag(ModerationInputKinds.Text))
        {
            internalInputKinds.Add("text");
        }
        if (inputKinds.HasFlag(ModerationInputKinds.Image))
        {
            internalInputKinds.Add("image");
        }
        // if (inputKinds.HasFlag(ModerationInputKinds.Audio))
        // {
        //     internalInputKinds.Add("audio");
        // }
        return internalInputKinds;
    }

    internal static ModerationInputKinds FromInternalInputKinds(IEnumerable<string> internalInputKinds)
    {
        ModerationInputKinds result = 0;
        foreach (string internalInputKind in internalInputKinds ?? [])
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(internalInputKind, "text"))
            {
                result |= ModerationInputKinds.Text;
            }
            else if (StringComparer.OrdinalIgnoreCase.Equals(internalInputKind, "image"))
            {
                result |= ModerationInputKinds.Image;
            }
            // else if (StringComparer.OrdinalIgnoreCase.Equals(internalInputKind, "audio"))
            // {
            //     result |= ModerationInputKinds.Audio;
            // }
            else
            {
                result |= ModerationInputKinds.Other;
            }
        }
        return result;
    }
}