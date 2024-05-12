using System;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("RunStepDetailsMessageCreationObject")]
public partial class RunStepMessageCreationDetails
{
    /// <inheritdoc cref="InternalRunStepDetailsMessageCreationObjectMessageCreation.MessageId"/>
    public string MessageId => _messageCreation.MessageId;

    [CodeGenMember("MessageCreation")]
    internal readonly InternalRunStepDetailsMessageCreationObjectMessageCreation _messageCreation;
}