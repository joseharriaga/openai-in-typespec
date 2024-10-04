using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
internal static partial class ConversationContentModalitiesExtensions
{
    internal static IList<InternalRealtimeClientEventSessionUpdateSessionModality> ToInternalModalities(this ConversationContentModalities modalities)
    {
        List<InternalRealtimeClientEventSessionUpdateSessionModality> internalModalities = [];
        if (modalities.HasFlag(ConversationContentModalities.Text))
        {
            internalModalities.Add(InternalRealtimeClientEventSessionUpdateSessionModality.Text);
        }
        if (modalities.HasFlag(ConversationContentModalities.Audio))
        {
            internalModalities.Add(InternalRealtimeClientEventSessionUpdateSessionModality.Audio);
        }
        return internalModalities;
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