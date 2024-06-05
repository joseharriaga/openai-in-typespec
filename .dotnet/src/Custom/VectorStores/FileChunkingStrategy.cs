using System;
using System.Collections.Generic;

namespace OpenAI.VectorStores;

[CodeGenModel("FileChunkingStrategyResponseParam")]
public abstract partial class FileChunkingStrategy
{
    public int? MaxTokensPerChunk => (this as InternalStaticChunkingStrategy)?.Static?.MaxChunkSizeTokens;
    public int? MaxOverlappingTokensBetweenChunks => (this as InternalStaticChunkingStrategy)?.Static?.ChunkOverlapTokens;
    
    public static FileChunkingStrategy Auto => _autoValue ??= new();

    public static FileChunkingStrategy Unknown => _unknownValue ??= new();

    public static FileChunkingStrategy CreateStaticStrategy(
        int maxTokensPerChunk,
        int maxOverlappingTokensBetweenChunks)
    {
        return new InternalStaticChunkingStrategy(
            new InternalStaticChunkingStrategyDetails(
                maxTokensPerChunk,
                maxOverlappingTokensBetweenChunks));
    }

    private static InternalAutoChunkingStrategy _autoValue;
    private static InternalUnknownChunkingStrategy _unknownValue; 
}
