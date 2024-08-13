using NUnit.Framework;
using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;

namespace OpenAI.Tests.Miscellaneous;

public partial class UserAgentTests
{
    [Test]
    public void UserAgentStringWorks()
    {
        ApiKeyCredential mockKeyCredential = new("no-real-key-needed");
        string userAgent = null;
        TestPipelinePolicy policy = new((m) =>
        {
            _ = m?.Request?.Headers?.TryGetValue("User-Agent", out userAgent);
        });

        OpenAIClientOptions options = new();
        options.AddPolicy(policy, PipelinePosition.BeforeTransport);

        ChatClient client = new("no-real-model-needed", options);
        RequestOptions noThrowOptions = new() { ErrorOptions = ClientErrorBehaviors.NoThrow, };
        using BinaryContent emptyContent = BinaryContent.Create(new MemoryStream());
        _ = client.CompleteChat(emptyContent, noThrowOptions);

        Assert.That(userAgent, Is.Not.Null.Or.Empty);

        Assert.That(userAgent, Does.Contain("OpenAI/"));
    }
}
