using System;

namespace OpenAI;

[CodeGenModel("FunctionObject")]
public partial class FunctionDefinition
{
    /// <summary>
    /// The parameters to the function, formatting as a JSON Schema object.
    /// </summary>
    [CodeGenMember("Parameters")]
    internal BinaryData Parameters;
}
