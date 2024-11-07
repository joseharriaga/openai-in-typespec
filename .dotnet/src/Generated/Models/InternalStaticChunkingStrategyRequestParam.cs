// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.VectorStores
{
    internal partial class InternalStaticChunkingStrategyRequestParam : InternalFileChunkingStrategyRequestParam
    {
        public InternalStaticChunkingStrategyRequestParam(InternalStaticChunkingStrategyDetails @static) : base("static")
        {
            Argument.AssertNotNull(@static, nameof(@static));

            Static = @static;
        }

        internal InternalStaticChunkingStrategyRequestParam(InternalStaticChunkingStrategyDetails @static, string @type, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(@type, additionalBinaryDataProperties)
        {
            Static = @static;
        }

        public InternalStaticChunkingStrategyDetails Static { get; }
    }
}
