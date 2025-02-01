using NUnit.Framework;
using System.Text.Json;

#region usings
using System;
using System.ClientModel.Primitives;

using OpenAI.FineTuning;
#endregion

namespace OpenAI.Docs.ApiReference;
public partial class ListFineTunningEventsApiReference {

    //[Test]
    public void ListFineTunningEvents()
    {
        #region logic
        FineTuningClient client = new(
			apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY")
		);

        FineTuningJobOperation operation = FineTuningJobOperation.Rehydrate(client, "ftjob-abc123");
		CollectionResult result = operation.GetJobEvents(null, 2, new RequestOptions() { });
        
        #endregion
        
    }
}
