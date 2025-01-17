using System.Collections.Generic;

namespace OpenAI.Chat;

internal static partial class ChatContentModalitiesExtensions
{
    internal static IList<InternalCreateChatCompletionRequestModality> ToInternalModalities(this ChatContentModalities modalities)
    {
        List<InternalCreateChatCompletionRequestModality> internalModalities = [];
        if (modalities.HasFlag(ChatContentModalities.Text))
        {
            internalModalities.Add(InternalCreateChatCompletionRequestModality.Text);
        }
        if (modalities.HasFlag(ChatContentModalities.Audio))
        {
            internalModalities.Add(InternalCreateChatCompletionRequestModality.Audio);
        }
        return internalModalities;
    }

    internal static ChatContentModalities FromInternalModalities(IEnumerable<InternalCreateChatCompletionRequestModality> internalModalities)
    {
        ChatContentModalities result = 0;
        foreach (InternalCreateChatCompletionRequestModality internalModality in internalModalities ?? [])
        {
            if (internalModality == InternalCreateChatCompletionRequestModality.Text)
            {
                result |= ChatContentModalities.Text;
            }
            else if (internalModality == InternalCreateChatCompletionRequestModality.Audio)
            {
                result |= ChatContentModalities.Audio;
            }
        }
        return result;
    }
}