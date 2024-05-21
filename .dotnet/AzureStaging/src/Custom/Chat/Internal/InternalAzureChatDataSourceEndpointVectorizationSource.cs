using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.OpenAI.Chat;

[CodeGenModel("AzureChatDataSourceEndpointVectorizationSource")]
internal partial class InternalAzureChatDataSourceEndpointVectorizationSource
{
    internal DataSourceAuthentication Authentication { get; set; }
}
