using System;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("RunStepDetailsMessageCreationObject")]
internal partial class InternalRunStepMessageCreationDetails
{
    /// <inheritdoc cref="InternalRunStepDetailsMessageCreationObjectMessageCreation.MessageId"/>
    public string InternalMessageId => _messageCreation.MessageId;

    [CodeGenMember("MessageCreation")]
    internal readonly InternalRunStepDetailsMessageCreationObjectMessageCreation _messageCreation;
}