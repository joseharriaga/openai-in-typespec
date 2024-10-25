// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Assistants
{
    public partial class RunStepFileSearchResult
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal RunStepFileSearchResult(string fileId, string fileName, float score)
        {
            FileId = fileId;
            FileName = fileName;
            Score = score;
            Content = new ChangeTrackingList<InternalRunStepDetailsToolCallsFileSearchResultObjectContent>();
        }

        internal RunStepFileSearchResult(string fileId, string fileName, float score, IReadOnlyList<InternalRunStepDetailsToolCallsFileSearchResultObjectContent> content, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            FileId = fileId;
            FileName = fileName;
            Score = score;
            Content = content;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string FileId { get; }

        public string FileName { get; }

        public float Score { get; }

        internal IDictionary<string, BinaryData> SerializedAdditionalRawData
        {
            get => _additionalBinaryDataProperties;
            set => _additionalBinaryDataProperties = value;
        }
    }
}
