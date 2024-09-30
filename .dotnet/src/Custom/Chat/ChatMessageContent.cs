using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenAI.Chat;

[CodeGenModel("ChatMessageContent")]
public partial class ChatMessageContent : Collection<ChatMessageContentPart>
{
    public ChatMessageContent() 
        : base(new ChangeTrackingList<ChatMessageContentPart>())
    {
    }

    public ChatMessageContent(string text) 
        : base([ChatMessageContentPart.CreateTextPart(text)])
    {
    }

    public ChatMessageContent(IList<ChatMessageContentPart> parts)
        : base(new ChangeTrackingList<ChatMessageContentPart>(parts))
    {
    }

    public ChatMessageContent(params ChatMessageContentPart[] parts) 
        : base(parts)
    {
    }

    internal bool IsInnerCollectionDefined()
    {
        return !(Items is ChangeTrackingList<ChatMessageContentPart> changeTrackingList && changeTrackingList.IsUndefined);
    }
}
