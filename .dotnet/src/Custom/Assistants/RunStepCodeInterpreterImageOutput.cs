using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using OpenAI.Internal.Models;

namespace OpenAI.Assistants;

[CodeGenModel("RunStepDetailsToolCallsCodeOutputImageObject")]
public partial class RunStepCodeInterpreterImageOutput
{
    /// <inheritdoc cref="InternalRunStepDetailsToolCallsCodeOutputImageObjectImage.FileId"/>

    public string FileId => _internalDetails.FileId;

    [CodeGenMember("Image")]
    internal InternalRunStepDetailsToolCallsCodeOutputImageObjectImage _internalDetails;
}