using NUnit.Framework;
using System;

namespace OpenAI.Tests;

public partial class GitHubTests
{
    [Test(Description = "Test that we can use a GitHub secret")]
    [Category("GitHub")]
    public void CanUseGitHubSecret()
    {
        string gitHubSecretString = Environment.GetEnvironmentVariable("SECRET_VALUE");
        Assert.That(gitHubSecretString, Is.Not.Null.Or.Empty);
    }
}
