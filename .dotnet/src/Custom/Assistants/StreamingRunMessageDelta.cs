using OpenAI.Internal.Models;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI.Assistants;

[CodeGenModel("MessageDeltaObject")]
public partial class StreamingRunMessageDelta
{
    /// <inheritdoc cref="InternalMessageDeltaObjectDelta.Content"/>
    public IReadOnlyList<MessageDeltaContent> DeltaContent => _internalDelta.Content;

    [CodeGenMember("Delta")]
    internal readonly InternalMessageDeltaObjectDelta _internalDelta;
}
