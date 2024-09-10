// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    internal partial class InternalFineTuningJobsPageToken
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }
        public InternalFineTuningJobsPageToken()
        {
        }

        internal InternalFineTuningJobsPageToken(int? limit, string after, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Limit = limit;
            After = after;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        public int? Limit { get; set; }
        public string After { get; set; }
    }
}
