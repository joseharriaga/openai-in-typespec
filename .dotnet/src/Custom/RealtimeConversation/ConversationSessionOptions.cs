using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeRequestSession")]
public partial class ConversationSessionOptions
{
    [CodeGenMember("Model")]
    public string Model { get; set; }

    [CodeGenMember("Modalities")]
    private readonly IList<InternalRealtimeClientEventSessionUpdateSessionModality> _internalModalities
        = new ChangeTrackingList<InternalRealtimeClientEventSessionUpdateSessionModality>();

    public ConversationContentModalities ContentModalities
    {
        get => ConversationContentModalitiesExtensions.FromInternalModalities(_internalModalities);
        set => value.ToInternalModalities(_internalModalities);
    }

    [CodeGenMember("ToolChoice")]
    private BinaryData _internalToolChoice;

    public ConversationToolChoice ToolChoice
    {
        get => ConversationToolChoice.FromBinaryData(_internalToolChoice);
        set
        {
            _internalToolChoice = ModelReaderWriter.Write(value);
        }
    }

    [CodeGenMember("MaxResponseOutputTokens")]
    private BinaryData _maxResponseOutputTokens;

    public ConversationMaxTokensChoice MaxResponseOutputTokens
    {
        get => ConversationMaxTokensChoice.FromBinaryData(_maxResponseOutputTokens);
        set
        {
            _maxResponseOutputTokens = value == null ? null : ModelReaderWriter.Write(value);
        }
    }

    [CodeGenMember("TurnDetection")]
    public ConversationTurnDetectionOptions TurnDetectionOptions { get; set; }

    [CodeGenMember("InputAudioTranscription")]
    public ConversationInputTranscriptionOptions InputTranscriptionOptions { get; set; }
}