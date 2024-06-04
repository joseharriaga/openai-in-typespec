// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    internal partial class StaticChunkingStrategyResponseParam
    {
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal StaticChunkingStrategyResponseParam(StaticChunkingStrategy @static)
        {
            Argument.AssertNotNull(@static, nameof(@static));

            Static = @static;
        }

        internal StaticChunkingStrategyResponseParam(StaticChunkingStrategyResponseParamType type, StaticChunkingStrategy @static, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Type = type;
            Static = @static;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal StaticChunkingStrategyResponseParam()
        {
        }

        public StaticChunkingStrategyResponseParamType Type { get; } = StaticChunkingStrategyResponseParamType.Static;

        public StaticChunkingStrategy Static { get; }
    }
}