using System;
using NUnit.Framework;


using OpenAI;
using System.ClientModel;

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
