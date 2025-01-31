using NUnit.Framework;

#region usings
using System;
using System.ClientModel;

using OpenAI;
#endregion


namespace OpenAI.Docs.ApiReference;
public partial class OrgsAndProjectsApiReference {

    [Test]
    public void OrgsAndProjects()
    {
		OpenAIClient client = new(new ApiKeyCredential(Environment.GetEnvironmentVariable("OPENAI_API_KEY")), new OpenAIClientOptions()
		{
		    OrganizationId = "YOUR_ORG_ID",
		    ProjectId = "PROJECT_ID"
		});
	}
}
