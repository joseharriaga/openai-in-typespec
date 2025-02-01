using NUnit.Framework;

#region usings
using System;

using OpenAI;
#endregion


namespace OpenAI.Docs.ApiReference;
public partial class OrgsAndProjectsApiReference {

    [Test]
    public void OrgsAndProjects()
    {
        #region logic
        
        OpenAIClient client = new(
            credential: new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")),
            options: new()
            {
                OrganizationId = "YOUR_ORG_ID",
                ProjectId = "PROJECT_ID"
            }
        );

        #endregion
    }
}
