namespace OpenAI.Assistants;

[CodeGenModel("AssistantObject")]
public partial class Assistant
{
    // CUSTOM: hide non-discriminated object/type labels, as they're not necessary in the context of strongly typed
    //          representations
    private readonly object Object;
}
