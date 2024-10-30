using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace OpenAI.RealtimeConversation;

[Experimental("OPENAI002")]
[CodeGenModel("RealtimeResponseOptions")]
internal partial class InternalRealtimeResponseOptions
{
    [CodeGenMember("ToolChoice")]
    public BinaryData ToolChoice { get; set; }

    public static InternalRealtimeResponseOptions FromSessionOptions(
        ConversationSessionOptions sessionOptions)
    {
        Argument.AssertNotNull(sessionOptions, nameof(sessionOptions));
        if (Optional.IsDefined(sessionOptions.InputAudioFormat))
        {
            throw new InvalidOperationException($"{nameof(sessionOptions.InputAudioFormat)} cannot be overriden"
                + " per response.");
        }
        BinaryData maxTokensChoice = Optional.IsDefined(sessionOptions.MaxOutputTokens)
            ? ModelReaderWriter.Write(sessionOptions.MaxOutputTokens)
            : null;
        IList<InternalRealtimeRequestSessionModality> internalModalities
            = sessionOptions.ContentModalities.ToInternalModalities();
        BinaryData toolChoice = Optional.IsDefined(sessionOptions.ToolChoice)
            ? ModelReaderWriter.Write(sessionOptions.ToolChoice)
            : null;
        InternalRealtimeResponseOptions internalOptions = new(
            modalities: internalModalities,
            instructions: sessionOptions.Instructions,
            voice: sessionOptions.Voice,
            outputAudioFormat: sessionOptions.OutputAudioFormat,
            tools: sessionOptions.Tools,
            toolChoice: toolChoice,
            temperature: sessionOptions.Temperature,
            maxOutputTokens: maxTokensChoice,
            serializedAdditionalRawData: null);
        return internalOptions;
    }
}
