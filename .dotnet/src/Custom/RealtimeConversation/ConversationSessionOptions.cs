using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeRequestSession")]
public partial class ConversationSessionOptions
{
    [CodeGenMember("Modalities")]
    private IList<InternalRealtimeRequestSessionModality> _internalModalities;

    public ConversationContentModalities ContentModalities
    {
        get => ConversationContentModalitiesExtensions.FromInternalModalities(_internalModalities);
        set => _internalModalities = value.ToInternalModalities();
    }

    [CodeGenMember("ToolChoice")]
    private BinaryData _internalToolChoice;

    public ConversationToolChoice ToolChoice
    {
        get => ConversationToolChoice.FromBinaryData(_internalToolChoice);
        set
        {
            _internalToolChoice = value is not null
                ? ModelReaderWriter.Write(value)
                : null;
        }
    }

    [CodeGenMember("MaxResponseOutputTokens")]
    private BinaryData _maxResponseOutputTokens;
    private bool _maxResponseOutputTokensHasValue;

    public ConversationMaxTokensChoice MaxOutputTokens
    {
        get => _maxResponseOutputTokensHasValue
            ? ConversationMaxTokensChoice.FromBinaryData(_maxResponseOutputTokens)
            : null;
        set
        {
            _maxResponseOutputTokensHasValue = value is not null;
            _maxResponseOutputTokens = value is not null ? ModelReaderWriter.Write(value) : null;
        }
    }

    [CodeGenMember("TurnDetection")]
    public ConversationTurnDetectionOptions TurnDetectionOptions { get; set; }

    [CodeGenMember("InputAudioTranscription")]
    public ConversationInputTranscriptionOptions InputTranscriptionOptions { get; set; }
}