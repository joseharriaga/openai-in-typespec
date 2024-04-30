namespace OpenAI.Chat;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

internal partial class StreamingChatUpdateCollection : ReadOnlyCollection<StreamingChatUpdate>
{
    internal StreamingChatUpdateCollection() : this([]) { }
    internal StreamingChatUpdateCollection(IList<StreamingChatUpdate> list) : base(list) { }
}
