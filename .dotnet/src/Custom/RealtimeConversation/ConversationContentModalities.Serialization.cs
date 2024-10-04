using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
internal static partial class ConversationContentModalitiesExtensions
{
    internal static void ToInternalModalities(this ConversationContentModalities modalities, IList<InternalRealtimeClientEventSessionUpdateSessionModality> internalModalities)
    {
        internalModalities.Clear();
        if (modalities.HasFlag(ConversationContentModalities.Text))
        {
            internalModalities.Add(InternalRealtimeClientEventSessionUpdateSessionModality.Text);
        }
        if (modalities.HasFlag(ConversationContentModalities.Audio))
        {
            internalModalities.Add(InternalRealtimeClientEventSessionUpdateSessionModality.Audio);
        }
    }

    internal static ConversationContentModalities FromInternalModalities(IEnumerable<InternalRealtimeClientEventSessionUpdateSessionModality> internalModalities)
    {
        ConversationContentModalities result = 0;
        foreach (InternalRealtimeClientEventSessionUpdateSessionModality internalModality in internalModalities ?? [])
        {
            if (internalModality == InternalRealtimeClientEventSessionUpdateSessionModality.Text)
            {
                result |= ConversationContentModalities.Text;
            }
            else if (internalModality == InternalRealtimeClientEventSessionUpdateSessionModality.Audio)
            {
                result |= ConversationContentModalities.Audio;
            }
        }
        return result;
    }
}