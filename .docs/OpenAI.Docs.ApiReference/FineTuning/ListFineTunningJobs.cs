using NUnit.Framework;
using System.Text.Json;

#region usings
using System;
using System.ClientModel.Primitives;

using OpenAI.FineTuning;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListFineTunningJobsApiReference {

    [Test]
    public void ListFineTunningJobs()
    {
        #region logic

        FineTuningClient client = new(
			apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);
		
		CollectionResult result = client.GetJobs(null, null, null);
        
        #endregion
    }
}
