using System.Collections.Generic;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

// CUSTOM:
//  - Required actions are abstracted into a forward-compatible, strongly-typed conceptual
//    hierarchy and formatted into a more intuitive collection for the consumer.

[CodeGenModel("RunObject")]
public partial class ThreadRun
{
    [CodeGenMember("Object")]
    private readonly object _object;
    [CodeGenMember("RequiredAction")]
    internal readonly InternalRunRequiredAction _internalRequiredAction;

    /// <summary>
    /// The list of required actions that must have their results submitted for the run to continue.
    /// </summary>
    /// <remarks>
    /// <see cref="Assistants.RequiredAction"/> is the abstract base type for all required actions. Its
    /// concrete type can be one of:
    /// <list type="bullet">
    /// <item> <see cref="RequiredFunctionToolCall"/> </item> 
    /// </list>
    /// </remarks>
    public IReadOnlyList<RequiredAction> RequiredActions => _internalRequiredAction?.SubmitToolOutputs?.ToolCalls ?? [];
}
