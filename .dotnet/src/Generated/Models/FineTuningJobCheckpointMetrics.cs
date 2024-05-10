// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.FineTuning
{
    /// <summary> The FineTuningJobCheckpointMetrics. </summary>
    internal partial class FineTuningJobCheckpointMetrics
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="FineTuningJobCheckpointMetrics"/>. </summary>
        internal FineTuningJobCheckpointMetrics()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FineTuningJobCheckpointMetrics"/>. </summary>
        /// <param name="step"></param>
        /// <param name="trainLoss"></param>
        /// <param name="trainMeanTokenAccuracy"></param>
        /// <param name="validLoss"></param>
        /// <param name="validMeanTokenAccuracy"></param>
        /// <param name="fullValidLoss"></param>
        /// <param name="fullValidMeanTokenAccuracy"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FineTuningJobCheckpointMetrics(float? step, float? trainLoss, float? trainMeanTokenAccuracy, float? validLoss, float? validMeanTokenAccuracy, float? fullValidLoss, float? fullValidMeanTokenAccuracy, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Step = step;
            TrainLoss = trainLoss;
            TrainMeanTokenAccuracy = trainMeanTokenAccuracy;
            ValidLoss = validLoss;
            ValidMeanTokenAccuracy = validMeanTokenAccuracy;
            FullValidLoss = fullValidLoss;
            FullValidMeanTokenAccuracy = fullValidMeanTokenAccuracy;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the step. </summary>
        public float? Step { get; }
        /// <summary> Gets the train loss. </summary>
        public float? TrainLoss { get; }
        /// <summary> Gets the train mean token accuracy. </summary>
        public float? TrainMeanTokenAccuracy { get; }
        /// <summary> Gets the valid loss. </summary>
        public float? ValidLoss { get; }
        /// <summary> Gets the valid mean token accuracy. </summary>
        public float? ValidMeanTokenAccuracy { get; }
        /// <summary> Gets the full valid loss. </summary>
        public float? FullValidLoss { get; }
        /// <summary> Gets the full valid mean token accuracy. </summary>
        public float? FullValidMeanTokenAccuracy { get; }
    }
}
