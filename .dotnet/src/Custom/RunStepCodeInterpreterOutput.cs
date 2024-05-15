namespace OpenAI.Assistants;

public abstract partial class RunStepCodeInterpreterOutput
{
    /// <inheritdoc cref="InternalRunStepCodeInterpreterImageOutput.FileId"/>
    public string ImageFileId => AsInternalImage?.FileId;
    /// <inheritdoc cref="InternalRunStepCodeInterpreterLogOutput.Logs"/>
    public string Logs => AsInternalLogs?.Logs;

    private InternalRunStepCodeInterpreterImageOutput AsInternalImage => this as InternalRunStepCodeInterpreterImageOutput;
    private InternalRunStepCodeInterpreterLogOutput AsInternalLogs => this as InternalRunStepCodeInterpreterLogOutput;
}
