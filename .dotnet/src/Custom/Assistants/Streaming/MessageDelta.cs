using OpenAI.Internal.Models;
using System.Collections.Generic;

namespace OpenAI.Assistants;

[CodeGenModel("MessageDeltaObject")]
public partial class MessageDelta
{
    /// <inheritdoc cref="ThreadMessage.Role"/>
    public MessageRole Role => _delta.Role;

    /// <inheritdoc cref="InternalMessageDeltaObjectDelta.Content"/>
    public IReadOnlyList<MessageDeltaContent> Content => _delta.Content;

    [CodeGenMember("Delta")]
    internal readonly InternalMessageDeltaObjectDelta _delta;
}
