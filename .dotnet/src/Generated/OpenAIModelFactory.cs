// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Images;
using OpenAI.Moderations;
using OpenAI.RealtimeConversation;
using OpenAI.VectorStores;

namespace OpenAI
{
    internal static partial class OpenAIModelFactory
    {
        public static VectorStoreFileCounts VectorStoreFileCounts(int inProgress = default, int completed = default, int failed = default, int cancelled = default, int total = default)
        {
            return new VectorStoreFileCounts(
                inProgress,
                completed,
                failed,
                cancelled,
                total,
                serializedAdditionalRawData: null);
        }

        public static VectorStoreFileAssociationError VectorStoreFileAssociationError(VectorStoreFileAssociationErrorCode code = default, string message = null)
        {
            return new VectorStoreFileAssociationError(code, message, serializedAdditionalRawData: null);
        }

        public static RunError RunError(RunErrorCode code = default, string message = null)
        {
            return new RunError(code, message, serializedAdditionalRawData: null);
        }

        public static RunIncompleteDetails RunIncompleteDetails(RunIncompleteReason? reason = null)
        {
            return new RunIncompleteDetails(reason, serializedAdditionalRawData: null);
        }

        public static RunTokenUsage RunTokenUsage(int outputTokenCount = default, int inputTokenCount = default, int totalTokenCount = default)
        {
            return new RunTokenUsage(outputTokenCount, inputTokenCount, totalTokenCount, serializedAdditionalRawData: null);
        }

        public static RunStepError RunStepError(RunStepErrorCode code = default, string message = null)
        {
            return new RunStepError(code, message, serializedAdditionalRawData: null);
        }

        public static RunStepTokenUsage RunStepTokenUsage(int outputTokenCount = default, int inputTokenCount = default, int totalTokenCount = default)
        {
            return new RunStepTokenUsage(outputTokenCount, inputTokenCount, totalTokenCount, serializedAdditionalRawData: null);
        }

        public static ModerationResultCollection ModerationResultCollection(string id = null, string model = null, IEnumerable<ModerationResult> results = null)
        {
            results ??= new List<ModerationResult>();

            return new ModerationResultCollection(id, model, results?.ToList());
        }

        public static MessageFailureDetails MessageFailureDetails(MessageFailureReason reason = default)
        {
            return new MessageFailureDetails(reason, serializedAdditionalRawData: null);
        }

        public static GeneratedImageCollection GeneratedImageCollection(DateTimeOffset created = default, IEnumerable<GeneratedImage> data = null)
        {
            data ??= new List<GeneratedImage>();

            return new GeneratedImageCollection(created, data?.ToList());
        }

        public static GeneratedImage GeneratedImage(BinaryData imageBytes = null, Uri imageUri = null, string revisedPrompt = null)
        {
            return new GeneratedImage(imageBytes, imageUri, revisedPrompt, serializedAdditionalRawData: null);
        }

        public static EmbeddingTokenUsage EmbeddingTokenUsage(int inputTokenCount = default, int totalTokenCount = default)
        {
            return new EmbeddingTokenUsage(inputTokenCount, totalTokenCount, serializedAdditionalRawData: null);
        }

        public static ChatTokenUsage ChatTokenUsage(int outputTokenCount = default, int inputTokenCount = default, int totalTokenCount = default, ChatOutputTokenUsageDetails outputTokenDetails = null)
        {
            return new ChatTokenUsage(outputTokenCount, inputTokenCount, totalTokenCount, outputTokenDetails, serializedAdditionalRawData: null);
        }

        public static ChatOutputTokenUsageDetails ChatOutputTokenUsageDetails(int reasoningTokenCount = default)
        {
            return new ChatOutputTokenUsageDetails(reasoningTokenCount, serializedAdditionalRawData: null);
        }

        public static ChatMessage ChatMessage(ChatMessageContent content = null)
        {
            return new InternalUnknownChatMessage(default, content, serializedAdditionalRawData: null);
        }

        public static SystemChatMessage SystemChatMessage(ChatMessageContent content = null, string participantName = null)
        {
            return new SystemChatMessage(ChatMessageRole.System, content, serializedAdditionalRawData: null, participantName);
        }

        public static UserChatMessage UserChatMessage(ChatMessageContent content = null, string participantName = null)
        {
            return new UserChatMessage(ChatMessageRole.User, content, serializedAdditionalRawData: null, participantName);
        }

        public static AssistantChatMessage AssistantChatMessage(ChatMessageContent content = null, string refusal = null, string participantName = null, IEnumerable<ChatToolCall> toolCalls = null, ChatFunctionCall functionCall = null)
        {
            toolCalls ??= new List<ChatToolCall>();

            return new AssistantChatMessage(
                ChatMessageRole.Assistant,
                content,
                serializedAdditionalRawData: null,
                refusal,
                participantName,
                toolCalls?.ToList(),
                functionCall);
        }

        public static ToolChatMessage ToolChatMessage(ChatMessageContent content = null, string toolCallId = null)
        {
            return new ToolChatMessage(ChatMessageRole.Tool, content, serializedAdditionalRawData: null, toolCallId);
        }

        public static FunctionChatMessage FunctionChatMessage(ChatMessageContent content = null, string functionName = null)
        {
            return new FunctionChatMessage(ChatMessageRole.Function, content, serializedAdditionalRawData: null, functionName);
        }

        public static ChatFunction ChatFunction(string functionDescription = null, string functionName = null, BinaryData functionParameters = null)
        {
            return new ChatFunction(functionDescription, functionName, functionParameters, serializedAdditionalRawData: null);
        }

        public static ChatTokenLogProbabilityDetails ChatTokenLogProbabilityDetails(string token = null, float logProbability = default, ReadOnlyMemory<byte>? utf8Bytes = null, IEnumerable<ChatTokenTopLogProbabilityDetails> topLogProbabilities = null)
        {
            topLogProbabilities ??= new List<ChatTokenTopLogProbabilityDetails>();

            return new ChatTokenLogProbabilityDetails(token, logProbability, utf8Bytes, topLogProbabilities?.ToList(), serializedAdditionalRawData: null);
        }

        public static ChatTokenTopLogProbabilityDetails ChatTokenTopLogProbabilityDetails(string token = null, float logProbability = default, ReadOnlyMemory<byte>? utf8Bytes = null)
        {
            return new ChatTokenTopLogProbabilityDetails(token, logProbability, utf8Bytes, serializedAdditionalRawData: null);
        }

        public static TranscribedWord TranscribedWord(string word = null, TimeSpan startTime = default, TimeSpan endTime = default)
        {
            return new TranscribedWord(word, startTime, endTime, serializedAdditionalRawData: null);
        }

        public static TranscribedSegment TranscribedSegment(int id = default, int seekOffset = default, TimeSpan startTime = default, TimeSpan endTime = default, string text = null, ReadOnlyMemory<int> tokenIds = default, float temperature = default, float averageLogProbability = default, float compressionRatio = default, float noSpeechProbability = default)
        {
            return new TranscribedSegment(
                id,
                seekOffset,
                startTime,
                endTime,
                text,
                tokenIds,
                temperature,
                averageLogProbability,
                compressionRatio,
                noSpeechProbability,
                serializedAdditionalRawData: null);
        }

        public static ConversationUpdate ConversationUpdate(string eventId = null)
        {
            return new UnknownRealtimeResponseCommand(default, eventId, serializedAdditionalRawData: null);
        }

        public static ConversationItemAcknowledgedUpdate ConversationItemAcknowledgedUpdate(string eventId = null, ConversationItem item = null)
        {
            return new ConversationItemAcknowledgedUpdate(ConversationUpdateKind.ItemAcknowledged, eventId, serializedAdditionalRawData: null, item);
        }

        public static ConversationItemDeletedUpdate ConversationItemDeletedUpdate(string eventId = null, string itemId = null)
        {
            return new ConversationItemDeletedUpdate(ConversationUpdateKind.ItemDeleted, eventId, serializedAdditionalRawData: null, itemId);
        }

        public static ConversationItemTruncatedUpdate ConversationItemTruncatedUpdate(string eventId = null, string itemId = null, int audioEndMs = default, int index = default)
        {
            return new ConversationItemTruncatedUpdate(
                ConversationUpdateKind.ItemTruncated,
                eventId,
                serializedAdditionalRawData: null,
                itemId,
                audioEndMs,
                index);
        }

        public static ConversationTokenUsage ConversationTokenUsage(int totalTokens = default, int inputTokens = default, int outputTokens = default, ConversationInputTokenUsageDetails inputTokenDetails = null, ConversationOutputTokenUsageDetails outputTokenDetails = null)
        {
            return new ConversationTokenUsage(
                totalTokens,
                inputTokens,
                outputTokens,
                inputTokenDetails,
                outputTokenDetails,
                serializedAdditionalRawData: null);
        }

        public static ConversationInputTokenUsageDetails ConversationInputTokenUsageDetails(int cachedTokens = default, int textTokens = default, int audioTokens = default)
        {
            return new ConversationInputTokenUsageDetails(cachedTokens, textTokens, audioTokens, serializedAdditionalRawData: null);
        }

        public static ConversationOutputTokenUsageDetails ConversationOutputTokenUsageDetails(int textTokens = default, int audioTokens = default)
        {
            return new ConversationOutputTokenUsageDetails(textTokens, audioTokens, serializedAdditionalRawData: null);
        }

        public static ConversationRateLimitsUpdatedUpdate ConversationRateLimitsUpdatedUpdate(string eventId = null, IEnumerable<ConversationRateLimitDetailsItem> rateLimits = null)
        {
            rateLimits ??= new List<ConversationRateLimitDetailsItem>();

            return new ConversationRateLimitsUpdatedUpdate(ConversationUpdateKind.RateLimitsUpdated, eventId, serializedAdditionalRawData: null, rateLimits?.ToList());
        }

        public static ConversationRateLimitDetailsItem ConversationRateLimitDetailsItem(string name = null, int limit = default, int remaining = default, float resetSeconds = default)
        {
            return new ConversationRateLimitDetailsItem(name, limit, remaining, resetSeconds, serializedAdditionalRawData: null);
        }

        public static ConversationAudioDeltaUpdate ConversationAudioDeltaUpdate(string eventId = null, string responseId = null, string itemId = null, int outputIndex = default, int contentIndex = default, BinaryData delta = null)
        {
            return new ConversationAudioDeltaUpdate(
                ConversationUpdateKind.ResponseAudioDelta,
                eventId,
                serializedAdditionalRawData: null,
                responseId,
                itemId,
                outputIndex,
                contentIndex,
                delta);
        }

        public static ConversationAudioDoneUpdate ConversationAudioDoneUpdate(string eventId = null, string responseId = null, string itemId = null, int outputIndex = default, int contentIndex = default)
        {
            return new ConversationAudioDoneUpdate(
                ConversationUpdateKind.ResponseAudioDone,
                eventId,
                serializedAdditionalRawData: null,
                responseId,
                itemId,
                outputIndex,
                contentIndex);
        }

        public static ConversationOutputTranscriptionDeltaUpdate ConversationOutputTranscriptionDeltaUpdate(string eventId = null, string responseId = null, string itemId = null, int outputIndex = default, int contentIndex = default, string delta = null)
        {
            return new ConversationOutputTranscriptionDeltaUpdate(
                ConversationUpdateKind.ResponseAudioTranscriptDelta,
                eventId,
                serializedAdditionalRawData: null,
                responseId,
                itemId,
                outputIndex,
                contentIndex,
                delta);
        }

        public static ConversationOutputTranscriptionFinishedUpdate ConversationOutputTranscriptionFinishedUpdate(string eventId = null, string responseId = null, string itemId = null, int outputIndex = default, int contentIndex = default)
        {
            return new ConversationOutputTranscriptionFinishedUpdate(
                ConversationUpdateKind.ResponseAudioTranscriptDone,
                eventId,
                serializedAdditionalRawData: null,
                responseId,
                itemId,
                outputIndex,
                contentIndex);
        }

        public static ConversationTextDeltaUpdate ConversationTextDeltaUpdate(string eventId = null, string responseId = null, string itemId = null, int outputIndex = default, int contentIndex = default, string delta = null)
        {
            return new ConversationTextDeltaUpdate(
                ConversationUpdateKind.ResponseTextDelta,
                eventId,
                serializedAdditionalRawData: null,
                responseId,
                itemId,
                outputIndex,
                contentIndex,
                delta);
        }

        public static ConversationTextDoneUpdate ConversationTextDoneUpdate(string eventId = null, string responseId = null, string itemId = null, int outputIndex = default, int contentIndex = default, string value = null)
        {
            return new ConversationTextDoneUpdate(
                ConversationUpdateKind.ResponseTextDone,
                eventId,
                serializedAdditionalRawData: null,
                responseId,
                itemId,
                outputIndex,
                contentIndex,
                value);
        }

        public static ConversationFunctionCallArgumentsDeltaUpdate ConversationFunctionCallArgumentsDeltaUpdate(string eventId = null, string responseId = null, string itemId = null, int outputIndex = default, string callId = null, string delta = null)
        {
            return new ConversationFunctionCallArgumentsDeltaUpdate(
                ConversationUpdateKind.ResponseFunctionCallArgumentsDelta,
                eventId,
                serializedAdditionalRawData: null,
                responseId,
                itemId,
                outputIndex,
                callId,
                delta);
        }

        public static ConversationFunctionCallArgumentsDoneUpdate ConversationFunctionCallArgumentsDoneUpdate(string eventId = null, string responseId = null, string itemId = null, int outputIndex = default, string callId = null, string name = null, string arguments = null)
        {
            return new ConversationFunctionCallArgumentsDoneUpdate(
                ConversationUpdateKind.ResponseFunctionCallArgumentsDone,
                eventId,
                serializedAdditionalRawData: null,
                responseId,
                itemId,
                outputIndex,
                callId,
                name,
                arguments);
        }

        public static ConversationInputSpeechStartedUpdate ConversationInputSpeechStartedUpdate(string eventId = null, int audioStartMs = default, string itemId = null)
        {
            return new ConversationInputSpeechStartedUpdate(ConversationUpdateKind.InputAudioBufferSpeechStarted, eventId, serializedAdditionalRawData: null, audioStartMs, itemId);
        }

        public static ConversationInputSpeechFinishedUpdate ConversationInputSpeechFinishedUpdate(string eventId = null, int audioEndMs = default, string itemId = null)
        {
            return new ConversationInputSpeechFinishedUpdate(ConversationUpdateKind.InputAudioBufferSpeechStopped, eventId, serializedAdditionalRawData: null, audioEndMs, itemId);
        }

        public static ConversationInputTranscriptionFinishedUpdate ConversationInputTranscriptionFinishedUpdate(string eventId = null, string itemId = null, int contentIndex = default, string transcript = null)
        {
            return new ConversationInputTranscriptionFinishedUpdate(
                ConversationUpdateKind.ItemInputAudioTranscriptionCompleted,
                eventId,
                serializedAdditionalRawData: null,
                itemId,
                contentIndex,
                transcript);
        }

        public static ConversationInputAudioBufferCommittedUpdate ConversationInputAudioBufferCommittedUpdate(string eventId = null, string itemId = null, string previousItemId = null)
        {
            return new ConversationInputAudioBufferCommittedUpdate(ConversationUpdateKind.InputAudioBufferCommitted, eventId, serializedAdditionalRawData: null, itemId, previousItemId);
        }

        public static ConversationInputAudioBufferClearedUpdate ConversationInputAudioBufferClearedUpdate(string eventId = null)
        {
            return new ConversationInputAudioBufferClearedUpdate(ConversationUpdateKind.InputAudioBufferCleared, eventId, serializedAdditionalRawData: null);
        }

        public static StreamingChatFunctionCallUpdate StreamingChatFunctionCallUpdate(string functionName = null, BinaryData functionArgumentsUpdate = null)
        {
            return new StreamingChatFunctionCallUpdate(functionName, functionArgumentsUpdate, serializedAdditionalRawData: null);
        }
    }
}
