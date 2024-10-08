// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Models
{
    public partial class OpenAIModel
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal OpenAIModel(string id, string ownedBy, InternalModelObject @object, DateTimeOffset createdAt)
        {
            Id = id;
            OwnedBy = ownedBy;
            Object = @object;
            CreatedAt = createdAt;
        }

        internal OpenAIModel(string id, string ownedBy, InternalModelObject @object, DateTimeOffset createdAt, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Id = id;
            OwnedBy = ownedBy;
            Object = @object;
            CreatedAt = createdAt;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Id { get; set; }

        public string OwnedBy { get; set; }
    }
}
