using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.RealtimeConversation;

/// <summary>
/// The update (response command) of type <c>response.audio.done</c>, which is received after correlated
/// <see cref="ConversationItemStartedUpdate"/> (<c>response.output_item.added</c>),
/// <see cref="ConversationItemAcknowledgedUpdate"/> (<c>conversation.item.created</c>),
/// <see cref="ConversationContentPartStartedUpdate"/> (<c>response.content_part.added)</c>, and
/// <see cref="ConversationAudioContentDeltaUpdate"/> commands. This update indicates that all streamed <c>delta</c> content
/// has completed and the associated content part will soon be completed.
/// </summary>
[Experimental("OPENAI002")]
[CodeGenModel("RealtimeServerEventResponseAudioDone")]
public partial class ConversationAudioContentFinishedUpdate
{ }
