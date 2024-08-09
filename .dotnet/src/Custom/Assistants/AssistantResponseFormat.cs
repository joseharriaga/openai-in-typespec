// using System;
// using System.Collections.Generic;
// using System.ComponentModel;

namespace OpenAI.Assistants;

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using OpenAI;
using OpenAI.Internal;

[CodeGenModel("AssistantResponseFormat")]
public readonly partial struct AssistantResponseFormat
{
    public static AssistantResponseFormat Text { get; }
        = new($@"""type"": ""text""");
    public static AssistantResponseFormat JsonObject { get; } = new($@"{{""type"":""json_object""}}");
    public static AssistantResponseFormat FromJsonSchema(BinaryData jsonSchema)
        => new($@"{{""type"":""json_schema"",""json_schema"":""{jsonSchema.ToString()}""}}");
}