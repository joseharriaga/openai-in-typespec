namespace OpenAI.Assistants;

/// <summary>
/// An abstract, base representation for a tool call that an Assistants API run requires outputs
/// from in order to continue.
/// </summary>
/// <remarks>
/// <see cref="RequiredToolCall"/> is the abstract base type for all required tool calls. Its
/// concrete type can be one of:
/// <list type="bullet">
/// <item> <see cref="RequiredFunctionToolCall"/> </item> 
/// </list>
/// </remarks>
public abstract partial class RequiredToolCall : RequiredAction
{

}