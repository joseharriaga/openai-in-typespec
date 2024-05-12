using System;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

/// <summary>
/// An abstract, base representation for an action that an Assistants API run requires outputs
/// from in order to continue.
/// </summary>
/// <remarks>
/// <see cref="RequiredAction"/> is the abstract base type for all required actions. Its
/// concrete type can be one of:
/// <list type="bullet">
/// <item> <see cref="RequiredFunctionToolCall"/> </item> 
/// </list>
/// </remarks>
public abstract partial class RequiredAction
{

}