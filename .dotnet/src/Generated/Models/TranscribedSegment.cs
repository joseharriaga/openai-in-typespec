// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Audio
{
    public readonly partial struct TranscribedSegment
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal TranscribedSegment(int id, string text, float temperature, float compressionRatio, TimeSpan startTime, TimeSpan endTime, int seekOffset, ReadOnlyMemory<int> tokenIds, float averageLogProbability, float noSpeechProbability)
        {
            Id = id;
            Text = text;
            Temperature = temperature;
            CompressionRatio = compressionRatio;
            StartTime = startTime;
            EndTime = endTime;
            SeekOffset = seekOffset;
            TokenIds = tokenIds;
            AverageLogProbability = averageLogProbability;
            NoSpeechProbability = noSpeechProbability;
        }

        internal TranscribedSegment(int id, string text, float temperature, float compressionRatio, TimeSpan startTime, TimeSpan endTime, int seekOffset, ReadOnlyMemory<int> tokenIds, float averageLogProbability, float noSpeechProbability, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Id = id;
            Text = text;
            Temperature = temperature;
            CompressionRatio = compressionRatio;
            StartTime = startTime;
            EndTime = endTime;
            SeekOffset = seekOffset;
            TokenIds = tokenIds;
            AverageLogProbability = averageLogProbability;
            NoSpeechProbability = noSpeechProbability;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public float Temperature { get; set; }

        public float CompressionRatio { get; set; }
    }
}
