
using Azure.AI.OpenAI.Chat;
using NUnit.Framework;

public partial class AzureChatTests
{
    [Test]
    public void AzureChat()
    {
        AzureChatClient client = new("gpt-35-turbo");
        ClientResult<ChatCompletion> = client.CompleteChat("Hello world");
    }
}