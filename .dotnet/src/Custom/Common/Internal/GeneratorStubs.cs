using System;

namespace OpenAI.Internal;

[CodeGenModel("OmniTypedResponseFormat")]
internal partial class InternalOmniTypedResponseFormat { }
[CodeGenModel("UnknownOmniTypedResponseFormat")]
internal partial class InternalUnknownOmniTypedResponseFormat { }
[CodeGenModel("ResponseFormatJsonObject")]
internal partial class InternalResponseFormatJsonObject { }
[CodeGenModel("ResponseFormatJsonObjectType")]
internal readonly partial struct InternalResponseFormatJsonObjectType { }
[CodeGenModel("ResponseFormatJsonSchema")]
internal partial class InternalResponseFormatJsonSchema { }
[CodeGenModel("ResponseFormatJsonSchemaJsonSchema")]
internal partial class InternalResponseFormatJsonSchemaJsonSchema
{
    [CodeGenMember("Schema")]
    internal BinaryData Schema { get; set; }
}
[CodeGenModel("ResponseFormatJsonSchemaSchema")]
internal readonly partial struct InternalResponseFormatJsonSchemaSchema { }
[CodeGenModel("ResponseFormatJsonSchemaType")]
internal readonly partial struct InternalResponseFormatJsonSchemaType { }
[CodeGenModel("ResponseFormatText")]
internal partial class InternalResponseFormatText { }
[CodeGenModel("ResponseFormatTextType")]
internal readonly partial struct InternalResponseFormatTextType { }
