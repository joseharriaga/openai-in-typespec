namespace OpenAI.Assistants;


public abstract partial class MessageContent
{
    public virtual string GetText() => (this as MessageTextContent).Text;
}
