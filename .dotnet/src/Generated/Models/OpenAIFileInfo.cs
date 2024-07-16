// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Files
{
    public partial class OpenAIFileInfo
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        internal OpenAIFileInfo(string id, long? sizeInBytes, DateTimeOffset createdAt, string filename, OpenAIFilePurpose purpose, OpenAIFileStatus status)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(filename, nameof(filename));

            Id = id;
            SizeInBytes = sizeInBytes;
            CreatedAt = createdAt;
            Filename = filename;
            Purpose = purpose;
            Status = status;
            SerializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        internal OpenAIFileInfo(string id, long? sizeInBytes, DateTimeOffset createdAt, string filename, InternalOpenAIFileObject @object, OpenAIFilePurpose purpose, OpenAIFileStatus status, string statusDetails, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            SizeInBytes = sizeInBytes;
            CreatedAt = createdAt;
            Filename = filename;
            Object = @object;
            Purpose = purpose;
            Status = status;
            StatusDetails = statusDetails;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal OpenAIFileInfo()
        {
        }

        public string Id { get; }
        public DateTimeOffset CreatedAt { get; }
        public string Filename { get; }

        public OpenAIFilePurpose Purpose { get; }
        public OpenAIFileStatus Status { get; }
        public string StatusDetails { get; }
    }
}
