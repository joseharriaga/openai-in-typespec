

using OpenAI.Chat;
using OpenAI.ClientShared.Internal;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat;

public partial class AzureChatCompletionOptions : ChatCompletionOptions
{
    public IList<AzureChatDataSource> DataSources { get; } = new OptionalList<AzureChatDataSource>();
}