using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Moderations;

internal static partial class ModerationFlaggedContentModalitiesExtensions
{
    internal static IReadOnlyList<string> ToInternalFlaggedContentModalities(this ModerationFlaggedContentModalities inputKinds)
    {
        List<string> internalInputKinds = [];
        if (inputKinds.HasFlag(ModerationFlaggedContentModalities.Text))
        {
            internalInputKinds.Add("text");
        }
        if (inputKinds.HasFlag(ModerationFlaggedContentModalities.Image))
        {
            internalInputKinds.Add("image");
        }
        // if (inputKinds.HasFlag(ModerationInputKinds.Audio))
        // {
        //     internalInputKinds.Add("audio");
        // }
        return internalInputKinds;
    }

    internal static ModerationFlaggedContentModalities FromInternalFlaggedContentModalities(IEnumerable<string> internalInputKinds)
    {
        ModerationFlaggedContentModalities result = 0;
        foreach (string internalInputKind in internalInputKinds ?? [])
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(internalInputKind, "text"))
            {
                result |= ModerationFlaggedContentModalities.Text;
            }
            else if (StringComparer.OrdinalIgnoreCase.Equals(internalInputKind, "image"))
            {
                result |= ModerationFlaggedContentModalities.Image;
            }
            // else if (StringComparer.OrdinalIgnoreCase.Equals(internalInputKind, "audio"))
            // {
            //     result |= ModerationInputKinds.Audio;
            // }
            else
            {
                result |= ModerationFlaggedContentModalities.Other;
            }
        }
        return result;
    }

    internal static string ToSerialString(this ModerationFlaggedContentModalities value)
        => throw new NotImplementedException();

    internal static ModerationFlaggedContentModalities ToModerationFlaggedContentModalities(this string value)
        => throw new NotImplementedException();
}