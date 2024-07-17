// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.VectorStores
{
    public partial class VectorStore
    {
        internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }
        internal VectorStore(string id, DateTimeOffset createdAt, string name, int usageBytes, VectorStoreFileCounts fileCounts, VectorStoreStatus status, DateTimeOffset? lastActiveAt, IReadOnlyDictionary<string, string> metadata)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(name, nameof(name));

            Id = id;
            CreatedAt = createdAt;
            Name = name;
            UsageBytes = usageBytes;
            FileCounts = fileCounts;
            Status = status;
            LastActiveAt = lastActiveAt;
            Metadata = metadata;
        }

        internal VectorStore(string id, InternalVectorStoreObjectObject @object, DateTimeOffset createdAt, string name, int usageBytes, VectorStoreFileCounts fileCounts, VectorStoreStatus status, VectorStoreExpirationPolicy expirationPolicy, DateTimeOffset? expiresAt, DateTimeOffset? lastActiveAt, IReadOnlyDictionary<string, string> metadata, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Object = @object;
            CreatedAt = createdAt;
            Name = name;
            UsageBytes = usageBytes;
            FileCounts = fileCounts;
            Status = status;
            ExpirationPolicy = expirationPolicy;
            ExpiresAt = expiresAt;
            LastActiveAt = lastActiveAt;
            Metadata = metadata;
            SerializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal VectorStore()
        {
        }

        public string Id { get; }

        public DateTimeOffset CreatedAt { get; }
        public string Name { get; }
        public int UsageBytes { get; }
        public VectorStoreFileCounts FileCounts { get; }
        public VectorStoreStatus Status { get; }
        public DateTimeOffset? ExpiresAt { get; }
        public DateTimeOffset? LastActiveAt { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
    }
}
