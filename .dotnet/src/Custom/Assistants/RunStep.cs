using System;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants;

[CodeGenModel("RunStepObject")]
public partial class RunStep
{
    private readonly object Object;

    /// <summary>
    /// The <c>step_details</c> associated with this run step.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Please note <see cref="RunStepDetails"/> is the base class.
    /// </para>
    /// <para>
    /// According to the scenario, a derived class of the base class might need to be assigned here, or this property
    /// needs to be casted to one of the possible derived classes.
    /// </para>
    /// <para>
    /// The available derived classes include <see cref="InternalRunStepMessageCreationDetails"/> and <see cref="InternalRunStepToolCallDetailsCollection"/>.
    /// </para>
    /// </remarks>
    [CodeGenMember("StepDetails")]
    public RunStepDetails Details { get; }
}
