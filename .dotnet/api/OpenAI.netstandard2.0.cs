```csharp
namespace OpenAI {
    public sealed class ListOrder {
        public ListOrder(string value);
        public static ListOrder NewestFirst { get; }
        public static ListOrder OldestFirst { get; }
        public bool Equals(ListOrder other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(ListOrder left, ListOrder right);
        public static implicit operator ListOrder(string value);
        public static bool operator !=(ListOrder left, ListOrder right);
        public override string ToString();
    }
    public class OpenAIClient {
        protected OpenAIClient();
        public OpenAIClient(OpenAIClientOptions options = null);
        public OpenAIClient(ApiKeyCredential credential, OpenAIClientOptions options = null);
        protected OpenAIClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options);
        protected Uri Endpoint { get; }
        public virtual ClientPipeline Pipeline { get; }
        public virtual AssistantClient GetAssistantClient();
        public virtual AudioClient GetAudioClient(string model);
        public virtual BatchClient GetBatchClient();
        public virtual ChatClient GetChatClient(string model);
        public virtual EmbeddingClient GetEmbeddingClient(string model);
        public virtual FileClient GetFileClient();
        public virtual FineTuningClient GetFineTuningClient();
        public virtual ImageClient GetImageClient(string model);
        public virtual ModelClient GetModelClient();
        public virtual ModerationClient GetModerationClient(string model);
        public virtual VectorStoreClient GetVectorStoreClient();
    }
    public class OpenAIClientOptions {
        public OpenAIClientOptions();
        public string ApplicationId { get; set; }
        public Uri Endpoint { get; set; }
        public string OrganizationId { get; set; }
        public string ProjectId { get; set; }
    }
}
namespace OpenAI.Assistants {
    public class Assistant {
        public DateTimeOffset CreatedAt { get; }
        public string Description { get; }
        public string Id { get; }
        public string Instructions { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public string Model { get; }
        public string Name { get; }
        public float? NucleusSamplingFactor { get; }
        public AssistantResponseFormat ResponseFormat { get; }
        public float? Temperature { get; }
        public ToolResources ToolResources { get; }
        public IReadOnlyList<ToolDefinition> Tools { get; }
    }
    public class AssistantClient {
        protected AssistantClient();
        public AssistantClient(OpenAIClientOptions options = null);
        public AssistantClient(ApiKeyCredential credential, OpenAIClientOptions options = null);
        protected internal AssistantClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<ThreadRun> CancelRun(ThreadRun run);
        public virtual ClientResult CancelRun(string threadId, string runId, RequestOptions options);
        public virtual ClientResult<ThreadRun> CancelRun(string threadId, string runId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<ThreadRun>> CancelRunAsync(ThreadRun run);
        public virtual Task<ClientResult> CancelRunAsync(string threadId, string runId, RequestOptions options);
        public virtual Task<ClientResult<ThreadRun>> CancelRunAsync(string threadId, string runId, CancellationToken cancellationToken = null);
        public virtual ClientResult CreateAssistant(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<Assistant> CreateAssistant(string model, AssistantCreationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> CreateAssistantAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<Assistant>> CreateAssistantAsync(string model, AssistantCreationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<ThreadMessage> CreateMessage(AssistantThread thread, MessageRole role, IEnumerable<MessageContent> content, MessageCreationOptions options = null);
        public virtual ClientResult<ThreadMessage> CreateMessage(string threadId, MessageRole role, IEnumerable<MessageContent> content, MessageCreationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult CreateMessage(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ThreadMessage>> CreateMessageAsync(AssistantThread thread, MessageRole role, IEnumerable<MessageContent> content, MessageCreationOptions options = null);
        public virtual Task<ClientResult<ThreadMessage>> CreateMessageAsync(string threadId, MessageRole role, IEnumerable<MessageContent> content, MessageCreationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> CreateMessageAsync(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> CreateRun(AssistantThread thread, Assistant assistant, RunCreationOptions options = null);
        public virtual ClientResult CreateRun(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> CreateRun(string threadId, string assistantId, RunCreationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<ThreadRun>> CreateRunAsync(AssistantThread thread, Assistant assistant, RunCreationOptions options = null);
        public virtual Task<ClientResult> CreateRunAsync(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ThreadRun>> CreateRunAsync(string threadId, string assistantId, RunCreationOptions options = null, CancellationToken cancellationToken = null);
        public virtual CollectionResult<StreamingUpdate> CreateRunStreaming(AssistantThread thread, Assistant assistant, RunCreationOptions options = null);
        public virtual CollectionResult<StreamingUpdate> CreateRunStreaming(string threadId, string assistantId, RunCreationOptions options = null, CancellationToken cancellationToken = null);
        public virtual AsyncCollectionResult<StreamingUpdate> CreateRunStreamingAsync(AssistantThread thread, Assistant assistant, RunCreationOptions options = null);
        public virtual AsyncCollectionResult<StreamingUpdate> CreateRunStreamingAsync(string threadId, string assistantId, RunCreationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<AssistantThread> CreateThread(ThreadCreationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult CreateThread(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> CreateThreadAndRun(Assistant assistant, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null);
        public virtual ClientResult CreateThreadAndRun(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> CreateThreadAndRun(string assistantId, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<ThreadRun>> CreateThreadAndRunAsync(Assistant assistant, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null);
        public virtual Task<ClientResult> CreateThreadAndRunAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ThreadRun>> CreateThreadAndRunAsync(string assistantId, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null, CancellationToken cancellationToken = null);
        public virtual CollectionResult<StreamingUpdate> CreateThreadAndRunStreaming(Assistant assistant, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null);
        public virtual CollectionResult<StreamingUpdate> CreateThreadAndRunStreaming(string assistantId, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null, CancellationToken cancellationToken = null);
        public virtual AsyncCollectionResult<StreamingUpdate> CreateThreadAndRunStreamingAsync(Assistant assistant, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null);
        public virtual AsyncCollectionResult<StreamingUpdate> CreateThreadAndRunStreamingAsync(string assistantId, ThreadCreationOptions threadOptions = null, RunCreationOptions runOptions = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<AssistantThread>> CreateThreadAsync(ThreadCreationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> CreateThreadAsync(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<bool> DeleteAssistant(Assistant assistant);
        public virtual ClientResult DeleteAssistant(string assistantId, RequestOptions options);
        public virtual ClientResult<bool> DeleteAssistant(string assistantId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<bool>> DeleteAssistantAsync(Assistant assistant);
        public virtual Task<ClientResult> DeleteAssistantAsync(string assistantId, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteAssistantAsync(string assistantId, CancellationToken cancellationToken = null);
        public virtual ClientResult<bool> DeleteMessage(ThreadMessage message);
        public virtual ClientResult DeleteMessage(string threadId, string messageId, RequestOptions options);
        public virtual ClientResult<bool> DeleteMessage(string threadId, string messageId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<bool>> DeleteMessageAsync(ThreadMessage message);
        public virtual Task<ClientResult> DeleteMessageAsync(string threadId, string messageId, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteMessageAsync(string threadId, string messageId, CancellationToken cancellationToken = null);
        public virtual ClientResult<bool> DeleteThread(AssistantThread thread);
        public virtual ClientResult DeleteThread(string threadId, RequestOptions options);
        public virtual ClientResult<bool> DeleteThread(string threadId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<bool>> DeleteThreadAsync(AssistantThread thread);
        public virtual Task<ClientResult> DeleteThreadAsync(string threadId, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteThreadAsync(string threadId, CancellationToken cancellationToken = null);
        public virtual ClientResult GetAssistant(string assistantId, RequestOptions options);
        public virtual ClientResult<Assistant> GetAssistant(string assistantId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> GetAssistantAsync(string assistantId, RequestOptions options);
        public virtual Task<ClientResult<Assistant>> GetAssistantAsync(string assistantId, CancellationToken cancellationToken = null);
        public virtual PageCollection<Assistant> GetAssistants(AssistantCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual PageCollection<Assistant> GetAssistants(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual IEnumerable<ClientResult> GetAssistants(int? limit, string order, string after, string before, RequestOptions options);
        public virtual AsyncPageCollection<Assistant> GetAssistantsAsync(AssistantCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual AsyncPageCollection<Assistant> GetAssistantsAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual IAsyncEnumerable<ClientResult> GetAssistantsAsync(int? limit, string order, string after, string before, RequestOptions options);
        public virtual ClientResult<ThreadMessage> GetMessage(ThreadMessage message);
        public virtual ClientResult GetMessage(string threadId, string messageId, RequestOptions options);
        public virtual ClientResult<ThreadMessage> GetMessage(string threadId, string messageId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<ThreadMessage>> GetMessageAsync(ThreadMessage message);
        public virtual Task<ClientResult> GetMessageAsync(string threadId, string messageId, RequestOptions options);
        public virtual Task<ClientResult<ThreadMessage>> GetMessageAsync(string threadId, string messageId, CancellationToken cancellationToken = null);
        public virtual PageCollection<ThreadMessage> GetMessages(AssistantThread thread, MessageCollectionOptions options = null);
        public virtual PageCollection<ThreadMessage> GetMessages(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual PageCollection<ThreadMessage> GetMessages(string threadId, MessageCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual IEnumerable<ClientResult> GetMessages(string threadId, int? limit, string order, string after, string before, RequestOptions options);
        public virtual AsyncPageCollection<ThreadMessage> GetMessagesAsync(AssistantThread thread, MessageCollectionOptions options = null);
        public virtual AsyncPageCollection<ThreadMessage> GetMessagesAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual AsyncPageCollection<ThreadMessage> GetMessagesAsync(string threadId, MessageCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual IAsyncEnumerable<ClientResult> GetMessagesAsync(string threadId, int? limit, string order, string after, string before, RequestOptions options);
        public virtual ClientResult<ThreadRun> GetRun(ThreadRun run);
        public virtual ClientResult GetRun(string threadId, string runId, RequestOptions options);
        public virtual ClientResult<ThreadRun> GetRun(string threadId, string runId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<ThreadRun>> GetRunAsync(ThreadRun run);
        public virtual Task<ClientResult> GetRunAsync(string threadId, string runId, RequestOptions options);
        public virtual Task<ClientResult<ThreadRun>> GetRunAsync(string threadId, string runId, CancellationToken cancellationToken = null);
        public virtual PageCollection<ThreadRun> GetRuns(AssistantThread thread, RunCollectionOptions options = null);
        public virtual PageCollection<ThreadRun> GetRuns(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual PageCollection<ThreadRun> GetRuns(string threadId, RunCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual IEnumerable<ClientResult> GetRuns(string threadId, int? limit, string order, string after, string before, RequestOptions options);
        public virtual AsyncPageCollection<ThreadRun> GetRunsAsync(AssistantThread thread, RunCollectionOptions options = null);
        public virtual AsyncPageCollection<ThreadRun> GetRunsAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual AsyncPageCollection<ThreadRun> GetRunsAsync(string threadId, RunCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual IAsyncEnumerable<ClientResult> GetRunsAsync(string threadId, int? limit, string order, string after, string before, RequestOptions options);
        public virtual ClientResult GetRunStep(string threadId, string runId, string stepId, RequestOptions options);
        public virtual ClientResult<RunStep> GetRunStep(string threadId, string runId, string stepId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> GetRunStepAsync(string threadId, string runId, string stepId, RequestOptions options);
        public virtual Task<ClientResult<RunStep>> GetRunStepAsync(string threadId, string runId, string stepId, CancellationToken cancellationToken = null);
        public virtual PageCollection<RunStep> GetRunSteps(ThreadRun run, RunStepCollectionOptions options = null);
        public virtual PageCollection<RunStep> GetRunSteps(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual PageCollection<RunStep> GetRunSteps(string threadId, string runId, RunStepCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual IEnumerable<ClientResult> GetRunSteps(string threadId, string runId, int? limit, string order, string after, string before, RequestOptions options);
        public virtual AsyncPageCollection<RunStep> GetRunStepsAsync(ThreadRun run, RunStepCollectionOptions options = null);
        public virtual AsyncPageCollection<RunStep> GetRunStepsAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual AsyncPageCollection<RunStep> GetRunStepsAsync(string threadId, string runId, RunStepCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual IAsyncEnumerable<ClientResult> GetRunStepsAsync(string threadId, string runId, int? limit, string order, string after, string before, RequestOptions options);
        public virtual ClientResult<AssistantThread> GetThread(AssistantThread thread);
        public virtual ClientResult GetThread(string threadId, RequestOptions options);
        public virtual ClientResult<AssistantThread> GetThread(string threadId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<AssistantThread>> GetThreadAsync(AssistantThread thread);
        public virtual Task<ClientResult> GetThreadAsync(string threadId, RequestOptions options);
        public virtual Task<ClientResult<AssistantThread>> GetThreadAsync(string threadId, CancellationToken cancellationToken = null);
        public virtual ClientResult<Assistant> ModifyAssistant(Assistant assistant, AssistantModificationOptions options);
        public virtual ClientResult<Assistant> ModifyAssistant(string assistantId, AssistantModificationOptions options, CancellationToken cancellationToken = null);
        public virtual ClientResult ModifyAssistant(string assistantId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<Assistant>> ModifyAssistantAsync(Assistant assistant, AssistantModificationOptions options);
        public virtual Task<ClientResult<Assistant>> ModifyAssistantAsync(string assistantId, AssistantModificationOptions options, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> ModifyAssistantAsync(string assistantId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadMessage> ModifyMessage(ThreadMessage message, MessageModificationOptions options);
        public virtual ClientResult<ThreadMessage> ModifyMessage(string threadId, string messageId, MessageModificationOptions options, CancellationToken cancellationToken = null);
        public virtual ClientResult ModifyMessage(string threadId, string messageId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ThreadMessage>> ModifyMessageAsync(ThreadMessage message, MessageModificationOptions options);
        public virtual Task<ClientResult<ThreadMessage>> ModifyMessageAsync(string threadId, string messageId, MessageModificationOptions options, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> ModifyMessageAsync(string threadId, string messageId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult ModifyRun(string threadId, string runId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult> ModifyRunAsync(string threadId, string runId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<AssistantThread> ModifyThread(AssistantThread thread, ThreadModificationOptions options);
        public virtual ClientResult<AssistantThread> ModifyThread(string threadId, ThreadModificationOptions options, CancellationToken cancellationToken = null);
        public virtual ClientResult ModifyThread(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<AssistantThread>> ModifyThreadAsync(AssistantThread thread, ThreadModificationOptions options);
        public virtual Task<ClientResult<AssistantThread>> ModifyThreadAsync(string threadId, ThreadModificationOptions options, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> ModifyThreadAsync(string threadId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> SubmitToolOutputsToRun(ThreadRun run, IEnumerable<ToolOutput> toolOutputs);
        public virtual ClientResult SubmitToolOutputsToRun(string threadId, string runId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ThreadRun> SubmitToolOutputsToRun(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<ThreadRun>> SubmitToolOutputsToRunAsync(ThreadRun run, IEnumerable<ToolOutput> toolOutputs);
        public virtual Task<ClientResult> SubmitToolOutputsToRunAsync(string threadId, string runId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ThreadRun>> SubmitToolOutputsToRunAsync(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = null);
        public virtual CollectionResult<StreamingUpdate> SubmitToolOutputsToRunStreaming(ThreadRun run, IEnumerable<ToolOutput> toolOutputs);
        public virtual CollectionResult<StreamingUpdate> SubmitToolOutputsToRunStreaming(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = null);
        public virtual AsyncCollectionResult<StreamingUpdate> SubmitToolOutputsToRunStreamingAsync(ThreadRun run, IEnumerable<ToolOutput> toolOutputs);
        public virtual AsyncCollectionResult<StreamingUpdate> SubmitToolOutputsToRunStreamingAsync(string threadId, string runId, IEnumerable<ToolOutput> toolOutputs, CancellationToken cancellationToken = null);
    }
    public class AssistantCollectionOptions {
        public AssistantCollectionOptions();
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public class AssistantCreationOptions {
        public AssistantCreationOptions();
        public string Description { get; set; }
        public string Instructions { get; set; }
        public IDictionary<string, string> Metadata { get; }
        public string Name { get; set; }
        public float? NucleusSamplingFactor { get; set; }
        public AssistantResponseFormat ResponseFormat { get; set; }
        public float? Temperature { get; set; }
        public ToolResources ToolResources { get; }
        public IList<ToolDefinition> Tools { get; }
    }
    public class AssistantModificationOptions {
        public AssistantModificationOptions();
        public IList<ToolDefinition> DefaultTools { get; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public IDictionary<string, string> Metadata { get; }
        public string Model { get; set; }
        public string Name { get; set; }
        public float? NucleusSamplingFactor { get; set; }
        public AssistantResponseFormat ResponseFormat { get; set; }
        public float? Temperature { get; set; }
        public ToolResources ToolResources { get; }
    }
    public class AssistantResponseFormat {
        protected AssistantResponseFormat();
        public static AssistantResponseFormat Auto { get; }
        public static AssistantResponseFormat JsonObject { get; }
        public static AssistantResponseFormat Text { get; }
        public bool Equals(AssistantResponseFormat other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(AssistantResponseFormat left, AssistantResponseFormat right);
        public static implicit operator AssistantResponseFormat(string value);
        public static bool operator !=(AssistantResponseFormat left, AssistantResponseFormat right);
        public override string ToString();
    }
    public class AssistantThread {
        public DateTimeOffset CreatedAt { get; }
        public string Id { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public ToolResources ToolResources { get; }
    }
    public class CodeInterpreterToolDefinition : ToolDefinition {
        protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    }
    public class CodeInterpreterToolResources {
        public CodeInterpreterToolResources();
        public IList<string> FileIds { get; set; }
    }
    public class FileSearchToolDefinition : ToolDefinition {
        public int? MaxResults { get; set; }
        protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    }
    public class FileSearchToolResources {
        public FileSearchToolResources();
        public IList<VectorStoreCreationHelper> NewVectorStores { get; }
        public IList<string> VectorStoreIds { get; set; }
    }
    public class FunctionToolDefinition : ToolDefinition {
        public FunctionToolDefinition();
        public FunctionToolDefinition(string name, string description = null, BinaryData parameters = null);
        public string Description { get; set; }
        public required string FunctionName { get; set; }
        public BinaryData Parameters { get; set; }
        protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    }
    public class MessageCollectionOptions {
        public MessageCollectionOptions();
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public abstract class MessageContent {
        protected MessageContent();
        public MessageImageDetail? ImageDetail { get; }
        public string ImageFileId { get; }
        public Uri ImageUrl { get; }
        public string Text { get; }
        public IReadOnlyList<TextAnnotation> TextAnnotations { get; }
        public static MessageContent FromImageFileId(string imageFileId, MessageImageDetail? detail = null);
        public static MessageContent FromImageUrl(Uri imageUri, MessageImageDetail? detail = null);
        public static MessageContent FromText(string text);
        public static implicit operator MessageContent(string value);
        protected abstract void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    }
    public class MessageContentUpdate : StreamingUpdate {
        public MessageImageDetail? ImageDetail { get; }
        public string ImageFileId { get; }
        public string MessageId { get; }
        public int MessageIndex { get; }
        public MessageRole? Role { get; }
        public string Text { get; }
        public TextAnnotationUpdate TextAnnotation { get; }
    }
    public class MessageCreationAttachment {
        public MessageCreationAttachment(string fileId, IEnumerable<ToolDefinition> tools);
        public string FileId { get; }
        public IReadOnlyList<ToolDefinition> Tools { get; }
    }
    public class MessageCreationOptions {
        public MessageCreationOptions();
        public IList<MessageCreationAttachment> Attachments { get; }
        public IDictionary<string, string> Metadata { get; }
    }
    public class MessageFailureDetails {
        public MessageFailureReason Reason { get; }
    }
    public sealed class MessageFailureReason {
        public MessageFailureReason(string value);
        public static MessageFailureReason ContentFilter { get; }
        public static MessageFailureReason MaxTokens { get; }
        public static MessageFailureReason RunCancelled { get; }
        public static MessageFailureReason RunExpired { get; }
        public static MessageFailureReason RunFailed { get; }
        public bool Equals(MessageFailureReason other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(MessageFailureReason left, MessageFailureReason right);
        public static implicit operator MessageFailureReason(string value);
        public static bool operator !=(MessageFailureReason left, MessageFailureReason right);
        public override string ToString();
    }
    public sealed class MessageImageDetail {
        public const MessageImageDetail Auto = 0;
        public const MessageImageDetail High = 2;
        public const MessageImageDetail Low = 1;
    }
    public class MessageModificationOptions {
        public MessageModificationOptions();
        public IDictionary<string, string> Metadata { get; }
    }
    public sealed class MessageRole {
        public const MessageRole Assistant = 1;
        public const MessageRole User = 0;
    }
    public sealed class MessageStatus {
        public MessageStatus(string value);
        public static MessageStatus Completed { get; }
        public static MessageStatus Incomplete { get; }
        public static MessageStatus InProgress { get; }
        public bool Equals(MessageStatus other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(MessageStatus left, MessageStatus right);
        public static implicit operator MessageStatus(string value);
        public static bool operator !=(MessageStatus left, MessageStatus right);
        public override string ToString();
    }
    public class MessageStatusUpdate : StreamingUpdate<ThreadMessage> {
    }
    public abstract class RequiredAction {
        protected RequiredAction();
        public string FunctionArguments { get; }
        public string FunctionName { get; }
        public string ToolCallId { get; }
    }
    public class RequiredActionUpdate : RunUpdate {
        public string FunctionArguments { get; }
        public string FunctionName { get; }
        public string ToolCallId { get; }
        public ThreadRun GetThreadRun();
    }
    public class RunCollectionOptions {
        public RunCollectionOptions();
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public class RunCreationOptions {
        public RunCreationOptions();
        public string AdditionalInstructions { get; set; }
        public IList<ThreadInitializationMessage> AdditionalMessages { get; }
        public string InstructionsOverride { get; set; }
        public int? MaxCompletionTokens { get; set; }
        public int? MaxPromptTokens { get; set; }
        public IDictionary<string, string> Metadata { get; }
        public string ModelOverride { get; set; }
        public float? NucleusSamplingFactor { get; set; }
        public bool? ParallelToolCallsEnabled { get; set; }
        public AssistantResponseFormat ResponseFormat { get; set; }
        public float? Temperature { get; }
        public ToolConstraint ToolConstraint { get; set; }
        public IList<ToolDefinition> ToolsOverride { get; }
        public RunTruncationStrategy TruncationStrategy { get; set; }
    }
    public class RunError {
        public RunErrorCode Code { get; }
        public string Message { get; }
    }
    public sealed class RunErrorCode {
        public RunErrorCode(string value);
        public static RunErrorCode InvalidPrompt { get; }
        public static RunErrorCode RateLimitExceeded { get; }
        public static RunErrorCode ServerError { get; }
        public bool Equals(RunErrorCode other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(RunErrorCode left, RunErrorCode right);
        public static implicit operator RunErrorCode(string value);
        public static bool operator !=(RunErrorCode left, RunErrorCode right);
        public override string ToString();
    }
    public class RunIncompleteDetails {
        public RunIncompleteReason? Reason { get; }
    }
    public sealed class RunIncompleteReason {
        public RunIncompleteReason(string value);
        public static RunIncompleteReason MaxCompletionTokens { get; }
        public static RunIncompleteReason MaxPromptTokens { get; }
        public bool Equals(RunIncompleteReason other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(RunIncompleteReason left, RunIncompleteReason right);
        public static implicit operator RunIncompleteReason(string value);
        public static bool operator !=(RunIncompleteReason left, RunIncompleteReason right);
        public override string ToString();
    }
    public class RunModificationOptions {
        public RunModificationOptions();
        public IDictionary<string, string> Metadata { get; }
    }
    public sealed class RunStatus {
        public RunStatus(string value);
        public static RunStatus Cancelled { get; }
        public static RunStatus Cancelling { get; }
        public static RunStatus Completed { get; }
        public static RunStatus Expired { get; }
        public static RunStatus Failed { get; }
        public static RunStatus Incomplete { get; }
        public static RunStatus InProgress { get; }
        public bool IsTerminal { get; }
        public static RunStatus Queued { get; }
        public static RunStatus RequiresAction { get; }
        public bool Equals(RunStatus other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(RunStatus left, RunStatus right);
        public static implicit operator RunStatus(string value);
        public static bool operator !=(RunStatus left, RunStatus right);
        public override string ToString();
    }
    public class RunStep {
        public string AssistantId { get; }
        public DateTimeOffset? CancelledAt { get; }
        public DateTimeOffset? CompletedAt { get; }
        public DateTimeOffset CreatedAt { get; }
        public RunStepDetails Details { get; }
        public DateTimeOffset? ExpiredAt { get; }
        public DateTimeOffset? FailedAt { get; }
        public string Id { get; }
        public RunStepError LastError { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public string RunId { get; }
        public RunStepStatus Status { get; }
        public string ThreadId { get; }
        public RunStepType Type { get; }
        public RunStepTokenUsage Usage { get; }
    }
    public abstract class RunStepCodeInterpreterOutput {
        protected RunStepCodeInterpreterOutput();
        public string ImageFileId { get; }
        public string Logs { get; }
    }
    public class RunStepCollectionOptions {
        public RunStepCollectionOptions();
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public abstract class RunStepDetails {
        protected RunStepDetails();
        public string CreatedMessageId { get; }
        public IReadOnlyList<RunStepToolCall> ToolCalls { get; }
    }
    public class RunStepDetailsUpdate : StreamingUpdate {
        public string CodeInterpreterInput { get; }
        public IReadOnlyList<RunStepUpdateCodeInterpreterOutput> CodeInterpreterOutputs { get; }
        public string CreatedMessageId { get; }
        public string FunctionArguments { get; }
        public string FunctionName { get; }
        public string FunctionOutput { get; }
        public string StepId { get; }
        public string ToolCallId { get; }
        public int? ToolCallIndex { get; }
    }
    public class RunStepError {
        public RunStepErrorCode Code { get; }
        public string Message { get; }
    }
    public sealed class RunStepErrorCode {
        public RunStepErrorCode(string value);
        public static RunStepErrorCode RateLimitExceeded { get; }
        public static RunStepErrorCode ServerError { get; }
        public bool Equals(RunStepErrorCode other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(RunStepErrorCode left, RunStepErrorCode right);
        public static implicit operator RunStepErrorCode(string value);
        public static bool operator !=(RunStepErrorCode left, RunStepErrorCode right);
        public override string ToString();
    }
    public sealed class RunStepStatus {
        public RunStepStatus(string value);
        public static RunStepStatus Cancelled { get; }
        public static RunStepStatus Completed { get; }
        public static RunStepStatus Expired { get; }
        public static RunStepStatus Failed { get; }
        public static RunStepStatus InProgress { get; }
        public bool Equals(RunStepStatus other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(RunStepStatus left, RunStepStatus right);
        public static implicit operator RunStepStatus(string value);
        public static bool operator !=(RunStepStatus left, RunStepStatus right);
        public override string ToString();
    }
    public class RunStepTokenUsage {
        public int CompletionTokens { get; }
        public int PromptTokens { get; }
        public int TotalTokens { get; }
    }
    public abstract class RunStepToolCall {
        protected RunStepToolCall();
        public string CodeInterpreterInput { get; }
        public IReadOnlyList<RunStepCodeInterpreterOutput> CodeInterpreterOutputs { get; }
        public string FunctionArguments { get; }
        public string FunctionName { get; }
        public string FunctionOutput { get; }
        public string ToolCallId { get; }
        public RunStepToolCallKind ToolKind { get; }
    }
    public sealed class RunStepToolCallKind {
        public const RunStepToolCallKind CodeInterpreter = 1;
        public const RunStepToolCallKind FileSearch = 2;
        public const RunStepToolCallKind Function = 3;
        public const RunStepToolCallKind Unknown = 0;
    }
    public sealed class RunStepType {
        public RunStepType(string value);
        public static RunStepType MessageCreation { get; }
        public static RunStepType ToolCalls { get; }
        public bool Equals(RunStepType other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(RunStepType left, RunStepType right);
        public static implicit operator RunStepType(string value);
        public static bool operator !=(RunStepType left, RunStepType right);
        public override string ToString();
    }
    public class RunStepUpdate : StreamingUpdate<RunStep> {
    }
    public abstract class RunStepUpdateCodeInterpreterOutput {
        protected RunStepUpdateCodeInterpreterOutput();
        public string ImageFileId { get; }
        public string Logs { get; }
        public int OutputIndex { get; }
    }
    public class RunTokenUsage {
        public int CompletionTokens { get; }
        public int PromptTokens { get; }
        public int TotalTokens { get; }
    }
    public class RunTruncationStrategy {
        public static RunTruncationStrategy Auto { get; }
        public int? LastMessages { get; }
        public static RunTruncationStrategy CreateLastMessagesStrategy(int lastMessageCount);
    }
    public class RunUpdate : StreamingUpdate<ThreadRun> {
    }
    public abstract class StreamingUpdate {
        public StreamingUpdateReason UpdateKind { get; }
    }
    public sealed class StreamingUpdateReason {
        public const StreamingUpdateReason Done = 25;
        public const StreamingUpdateReason Error = 24;
        public const StreamingUpdateReason MessageCompleted = 22;
        public const StreamingUpdateReason MessageCreated = 19;
        public const StreamingUpdateReason MessageFailed = 23;
        public const StreamingUpdateReason MessageInProgress = 20;
        public const StreamingUpdateReason MessageUpdated = 21;
        public const StreamingUpdateReason RunCancelled = 10;
        public const StreamingUpdateReason RunCancelling = 9;
        public const StreamingUpdateReason RunCompleted = 6;
        public const StreamingUpdateReason RunCreated = 2;
        public const StreamingUpdateReason RunExpired = 11;
        public const StreamingUpdateReason RunFailed = 8;
        public const StreamingUpdateReason RunIncomplete = 7;
        public const StreamingUpdateReason RunInProgress = 4;
        public const StreamingUpdateReason RunQueued = 3;
        public const StreamingUpdateReason RunRequiresAction = 5;
        public const StreamingUpdateReason RunStepCancelled = 17;
        public const StreamingUpdateReason RunStepCompleted = 15;
        public const StreamingUpdateReason RunStepCreated = 12;
        public const StreamingUpdateReason RunStepExpired = 18;
        public const StreamingUpdateReason RunStepFailed = 16;
        public const StreamingUpdateReason RunStepInProgress = 13;
        public const StreamingUpdateReason RunStepUpdated = 14;
        public const StreamingUpdateReason ThreadCreated = 1;
        public const StreamingUpdateReason Unknown = 0;
    }
    public class StreamingUpdate<T> : StreamingUpdate where T : class {
        public T Value { get; }
        public static implicit operator T(StreamingUpdate<T> update);
    }
    public class TextAnnotation {
        public int EndIndex { get; }
        public string InputFileId { get; }
        public string OutputFileId { get; }
        public int StartIndex { get; }
        public string TextToReplace { get; }
    }
    public class TextAnnotationUpdate {
        public int ContentIndex { get; }
        public int? EndIndex { get; }
        public string InputFileId { get; }
        public string OutputFileId { get; }
        public int? StartIndex { get; }
        public string TextToReplace { get; }
    }
    public class ThreadCreationOptions {
        public ThreadCreationOptions();
        public IList<ThreadInitializationMessage> InitialMessages { get; }
        public IDictionary<string, string> Metadata { get; }
        public ToolResources ToolResources { get; set; }
    }
    public class ThreadInitializationMessage : MessageCreationOptions {
        public ThreadInitializationMessage(MessageRole role, IEnumerable<MessageContent> content);
        public static implicit operator ThreadInitializationMessage(string initializationMessage);
    }
    public class ThreadMessage {
        public string AssistantId { get; }
        public IReadOnlyList<MessageCreationAttachment> Attachments { get; }
        public DateTimeOffset? CompletedAt { get; }
        public IReadOnlyList<MessageContent> Content { get; }
        public DateTimeOffset CreatedAt { get; }
        public string Id { get; }
        public DateTimeOffset? IncompleteAt { get; }
        public MessageFailureDetails IncompleteDetails { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public MessageRole Role { get; }
        public string RunId { get; }
        public MessageStatus Status { get; }
        public string ThreadId { get; }
    }
    public class ThreadModificationOptions {
        public ThreadModificationOptions();
        public IDictionary<string, string> Metadata { get; }
        public ToolResources ToolResources { get; set; }
    }
    public class ThreadRun {
        public string AssistantId { get; }
        public DateTimeOffset? CancelledAt { get; }
        public DateTimeOffset? CompletedAt { get; }
        public DateTimeOffset CreatedAt { get; }
        public DateTimeOffset? ExpiresAt { get; }
        public DateTimeOffset? FailedAt { get; }
        public string Id { get; }
        public RunIncompleteDetails IncompleteDetails { get; }
        public string Instructions { get; }
        public RunError LastError { get; }
        public int? MaxCompletionTokens { get; }
        public int? MaxPromptTokens { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public string Model { get; }
        public float? NucleusSamplingFactor { get; }
        public bool? ParallelToolCallsEnabled { get; set; }
        public IReadOnlyList<RequiredAction> RequiredActions { get; }
        public AssistantResponseFormat ResponseFormat { get; }
        public DateTimeOffset? StartedAt { get; }
        public RunStatus Status { get; }
        public float? Temperature { get; }
        public string ThreadId { get; }
        public ToolConstraint ToolConstraint { get; }
        public IReadOnlyList<ToolDefinition> Tools { get; }
        public RunTruncationStrategy TruncationStrategy { get; }
        public RunTokenUsage Usage { get; }
    }
    public class ThreadUpdate : StreamingUpdate<AssistantThread> {
        public DateTimeOffset CreatedAt { get; }
        public string Id { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public ToolResources ToolResources { get; }
    }
    public class ToolConstraint {
        public ToolConstraint(ToolDefinition toolDefinition);
        public static ToolConstraint Auto { get; }
        public static ToolConstraint None { get; }
        public static ToolConstraint Required { get; }
    }
    public abstract class ToolDefinition {
        protected ToolDefinition();
        protected ToolDefinition(string type);
        public static CodeInterpreterToolDefinition CreateCodeInterpreter();
        public static FileSearchToolDefinition CreateFileSearch(int? maxResults = null);
        public static FunctionToolDefinition CreateFunction(string name, string description = null, BinaryData parameters = null);
        protected abstract void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    }
    public class ToolOutput {
        public ToolOutput();
        public ToolOutput(string toolCallId, string output);
        public string Output { get; set; }
        public string ToolCallId { get; set; }
    }
    public class ToolResources {
        public ToolResources();
        public CodeInterpreterToolResources CodeInterpreter { get; set; }
        public FileSearchToolResources FileSearch { get; set; }
    }
    public class VectorStoreCreationHelper {
        public VectorStoreCreationHelper();
        public VectorStoreCreationHelper(IEnumerable<Files.OpenAIFileInfo> files, IDictionary<string, string> metadata = null);
        public VectorStoreCreationHelper(IEnumerable<string> fileIds, IDictionary<string, string> metadata = null);
        public IList<string> FileIds { get; }
        public IDictionary<string, string> Metadata { get; }
    }
}
namespace OpenAI.Audio {
    public class AudioClient {
        protected AudioClient();
        protected internal AudioClient(ClientPipeline pipeline, string model, Uri endpoint, OpenAIClientOptions options);
        public AudioClient(string model, OpenAIClientOptions options = null);
        public AudioClient(string model, ApiKeyCredential credential, OpenAIClientOptions options = null);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult GenerateSpeechFromText(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<BinaryData> GenerateSpeechFromText(string text, GeneratedSpeechVoice voice, SpeechGenerationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> GenerateSpeechFromTextAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<BinaryData>> GenerateSpeechFromTextAsync(string text, GeneratedSpeechVoice voice, SpeechGenerationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult TranscribeAudio(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual ClientResult<AudioTranscription> TranscribeAudio(Stream audio, string audioFilename, AudioTranscriptionOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<AudioTranscription> TranscribeAudio(string audioFilePath, AudioTranscriptionOptions options = null);
        public virtual Task<ClientResult> TranscribeAudioAsync(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual Task<ClientResult<AudioTranscription>> TranscribeAudioAsync(Stream audio, string audioFilename, AudioTranscriptionOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<AudioTranscription>> TranscribeAudioAsync(string audioFilePath, AudioTranscriptionOptions options = null);
        public virtual ClientResult TranslateAudio(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual ClientResult<AudioTranslation> TranslateAudio(Stream audio, string audioFilename, AudioTranslationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<AudioTranslation> TranslateAudio(string audioFilePath, AudioTranslationOptions options = null);
        public virtual Task<ClientResult> TranslateAudioAsync(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual Task<ClientResult<AudioTranslation>> TranslateAudioAsync(Stream audio, string audioFilename, AudioTranslationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<AudioTranslation>> TranslateAudioAsync(string audioFilePath, AudioTranslationOptions options = null);
    }
    public sealed class AudioTimestampGranularities {
        public const AudioTimestampGranularities Default = 0;
        public const AudioTimestampGranularities Segment = 2;
        public const AudioTimestampGranularities Word = 1;
    }
    public class AudioTranscription {
        public TimeSpan? Duration { get; }
        public string Language { get; }
        public IReadOnlyList<TranscribedSegment> Segments { get; }
        public string Text { get; }
        public IReadOnlyList<TranscribedWord> Words { get; }
    }
    public sealed class AudioTranscriptionFormat {
        public const AudioTranscriptionFormat Simple = 1;
        public const AudioTranscriptionFormat Srt = 3;
        public const AudioTranscriptionFormat Text = 0;
        public const AudioTranscriptionFormat Verbose = 2;
        public const AudioTranscriptionFormat Vtt = 4;
    }
    public class AudioTranscriptionOptions {
        public AudioTranscriptionOptions();
        public AudioTimestampGranularities Granularities { get; set; }
        public string Language { get; set; }
        public string Prompt { get; set; }
        public AudioTranscriptionFormat? ResponseFormat { get; set; }
        public float? Temperature { get; set; }
    }
    public class AudioTranslation {
        public TimeSpan? Duration { get; }
        public string Language { get; }
        public IReadOnlyList<TranscribedSegment> Segments { get; }
        public string Text { get; }
    }
    public sealed class AudioTranslationFormat {
        public const AudioTranslationFormat Simple = 1;
        public const AudioTranslationFormat Srt = 3;
        public const AudioTranslationFormat Text = 0;
        public const AudioTranslationFormat Verbose = 2;
        public const AudioTranslationFormat Vtt = 4;
    }
    public class AudioTranslationOptions {
        public AudioTranslationOptions();
        public string Prompt { get; set; }
        public AudioTranslationFormat? ResponseFormat { get; set; }
        public float? Temperature { get; set; }
    }
    public sealed class GeneratedSpeechFormat {
        public const GeneratedSpeechFormat Aac = 2;
        public const GeneratedSpeechFormat Flac = 3;
        public const GeneratedSpeechFormat Mp3 = 0;
        public const GeneratedSpeechFormat Opus = 1;
        public const GeneratedSpeechFormat Pcm = 5;
        public const GeneratedSpeechFormat Wav = 4;
    }
    public sealed class GeneratedSpeechVoice {
        public const GeneratedSpeechVoice Alloy = 0;
        public const GeneratedSpeechVoice Echo = 1;
        public const GeneratedSpeechVoice Fable = 2;
        public const GeneratedSpeechVoice Nova = 4;
        public const GeneratedSpeechVoice Onyx = 3;
        public const GeneratedSpeechVoice Shimmer = 5;
    }
    public class SpeechGenerationOptions {
        public SpeechGenerationOptions();
        public GeneratedSpeechFormat? ResponseFormat { get; set; }
        public float? Speed { get; set; }
    }
    public sealed class TranscribedSegment {
        public TranscribedSegment();
        public Double AverageLogProbability { get; }
        public float CompressionRatio { get; }
        public TimeSpan End { get; }
        public int Id { get; }
        public Double NoSpeechProbability { get; }
        public long SeekOffset { get; }
        public TimeSpan Start { get; }
        public float Temperature { get; }
        public string Text { get; }
        public IReadOnlyList<long> TokenIds { get; }
    }
    public sealed class TranscribedWord {
        public TranscribedWord();
        public TimeSpan End { get; }
        public TimeSpan Start { get; }
        public string Word { get; }
    }
}
namespace OpenAI.Batch {
    public class BatchClient {
        protected BatchClient();
        public BatchClient(OpenAIClientOptions options = null);
        public BatchClient(ApiKeyCredential credential, OpenAIClientOptions options = null);
        protected internal BatchClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult CancelBatch(string batchId, RequestOptions options);
        public virtual Task<ClientResult> CancelBatchAsync(string batchId, RequestOptions options);
        public virtual ClientResult CreateBatch(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult> CreateBatchAsync(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult GetBatch(string batchId, RequestOptions options);
        public virtual Task<ClientResult> GetBatchAsync(string batchId, RequestOptions options);
        public virtual ClientResult GetBatches(string after, int? limit, RequestOptions options);
        public virtual Task<ClientResult> GetBatchesAsync(string after, int? limit, RequestOptions options);
    }
}
namespace OpenAI.Chat {
    public class AssistantChatMessage : ChatMessage {
        public AssistantChatMessage(ChatCompletion chatCompletion);
        public AssistantChatMessage(ChatFunctionCall functionCall, string content = null);
        public AssistantChatMessage(IEnumerable<ChatToolCall> toolCalls, string content = null);
        public AssistantChatMessage(string content);
        public ChatFunctionCall FunctionCall { get; set; }
        public string ParticipantName { get; }
        public IList<ChatToolCall> ToolCalls { get; }
        protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    }
    public class ChatClient {
        protected ChatClient();
        protected internal ChatClient(ClientPipeline pipeline, string model, Uri endpoint, OpenAIClientOptions options);
        public ChatClient(string model, OpenAIClientOptions options = null);
        public ChatClient(string model, ApiKeyCredential credential, OpenAIClientOptions options = null);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<ChatCompletion> CompleteChat(params ChatMessage[] messages);
        public virtual ClientResult CompleteChat(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ChatCompletion> CompleteChat(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<ChatCompletion>> CompleteChatAsync(params ChatMessage[] messages);
        public virtual Task<ClientResult> CompleteChatAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ChatCompletion>> CompleteChatAsync(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = null);
        public virtual CollectionResult<StreamingChatCompletionUpdate> CompleteChatStreaming(params ChatMessage[] messages);
        public virtual CollectionResult<StreamingChatCompletionUpdate> CompleteChatStreaming(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = null);
        public virtual AsyncCollectionResult<StreamingChatCompletionUpdate> CompleteChatStreamingAsync(params ChatMessage[] messages);
        public virtual AsyncCollectionResult<StreamingChatCompletionUpdate> CompleteChatStreamingAsync(IEnumerable<ChatMessage> messages, ChatCompletionOptions options = null, CancellationToken cancellationToken = null);
    }
    public class ChatCompletion {
        public IReadOnlyList<ChatMessageContentPart> Content { get; }
        public IReadOnlyList<ChatTokenLogProbabilityInfo> ContentTokenLogProbabilities { get; }
        public DateTimeOffset CreatedAt { get; }
        public ChatFinishReason FinishReason { get; }
        public ChatFunctionCall FunctionCall { get; }
        public string Id { get; }
        public string Model { get; }
        public ChatMessageRole Role { get; }
        public string SystemFingerprint { get; }
        public IReadOnlyList<ChatToolCall> ToolCalls { get; }
        public ChatTokenUsage Usage { get; }
        public override string ToString();
    }
    public class ChatCompletionOptions {
        public ChatCompletionOptions();
        public float? FrequencyPenalty { get; set; }
        public ChatFunctionChoice FunctionChoice { get; set; }
        public IList<ChatFunction> Functions { get; }
        public bool? IncludeLogProbabilities { get; }
        public IDictionary<int, int> LogitBiases { get; }
        public int? MaxTokens { get; set; }
        public bool? ParallelToolCallsEnabled { get; set; }
        public float? PresencePenalty { get; set; }
        public ChatResponseFormat ResponseFormat { get; set; }
        public long? Seed { get; set; }
        public IList<string> StopSequences { get; }
        public float? Temperature { get; set; }
        public ChatToolChoice ToolChoice { get; set; }
        public IList<ChatTool> Tools { get; }
        public int? TopLogProbabilityCount { get; set; }
        public float? TopP { get; set; }
        public string User { get; set; }
    }
    public sealed class ChatFinishReason {
        public const ChatFinishReason ContentFilter = 2;
        public const ChatFinishReason FunctionCall = 4;
        public const ChatFinishReason Length = 1;
        public const ChatFinishReason Stop = 0;
        public const ChatFinishReason ToolCalls = 3;
    }
    public class ChatFunction {
        public ChatFunction(string functionName, string functionDescription = null, BinaryData functionParameters = null);
        public string FunctionDescription { get; set; }
        public string FunctionName { get; }
        public BinaryData FunctionParameters { get; set; }
    }
    public class ChatFunctionCall {
        public ChatFunctionCall(string functionName, string functionArguments);
        public string FunctionArguments { get; }
        public string FunctionName { get; }
    }
    public class ChatFunctionChoice {
        public ChatFunctionChoice(ChatFunction chatFunction);
        public static ChatFunctionChoice Auto { get; }
        public static ChatFunctionChoice None { get; }
    }
    public abstract class ChatMessage {
        protected ChatMessage();
        public IList<ChatMessageContentPart> Content { get; protected set; }
        public static AssistantChatMessage CreateAssistantMessage(ChatCompletion chatCompletion);
        public static AssistantChatMessage CreateAssistantMessage(ChatFunctionCall functionCall, string content = null);
        public static AssistantChatMessage CreateAssistantMessage(IEnumerable<ChatToolCall> toolCalls, string content = null);
        public static AssistantChatMessage CreateAssistantMessage(string content);
        public static FunctionChatMessage CreateFunctionMessage(string functionName, string content);
        public static SystemChatMessage CreateSystemMessage(string content);
        public static ToolChatMessage CreateToolChatMessage(string toolCallId, string content);
        public static UserChatMessage CreateUserMessage(params ChatMessageContentPart[] contentParts);
        public static UserChatMessage CreateUserMessage(IEnumerable<ChatMessageContentPart> contentParts);
        public static UserChatMessage CreateUserMessage(string content);
        public static implicit operator ChatMessage(string userMessage);
        protected abstract void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    }
    public class ChatMessageContentPart {
        public BinaryData ImageBytes { get; }
        public string ImageBytesMediaType { get; }
        public ImageChatMessageContentPartDetail? ImageDetail { get; }
        public Uri ImageUri { get; }
        public ChatMessageContentPartKind Kind { get; }
        public string Text { get; }
        public static ChatMessageContentPart CreateImageMessageContentPart(BinaryData imageBytes, string imageBytesMediaType, ImageChatMessageContentPartDetail? imageDetail = null);
        public static ChatMessageContentPart CreateImageMessageContentPart(Uri imageUri, ImageChatMessageContentPartDetail? imageDetail = null);
        public static ChatMessageContentPart CreateTextMessageContentPart(string text);
        public static implicit operator ChatMessageContentPart(string content);
        public override string ToString();
    }
    public sealed class ChatMessageContentPartKind {
        public ChatMessageContentPartKind(string value);
        public static ChatMessageContentPartKind Image { get; }
        public static ChatMessageContentPartKind Text { get; }
        public bool Equals(ChatMessageContentPartKind other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(ChatMessageContentPartKind left, ChatMessageContentPartKind right);
        public static implicit operator ChatMessageContentPartKind(string value);
        public static bool operator !=(ChatMessageContentPartKind left, ChatMessageContentPartKind right);
        public override string ToString();
    }
    public sealed class ChatMessageRole {
        public const ChatMessageRole Assistant = 2;
        public const ChatMessageRole Function = 4;
        public const ChatMessageRole System = 0;
        public const ChatMessageRole Tool = 3;
        public const ChatMessageRole User = 1;
    }
    public class ChatResponseFormat {
        public static ChatResponseFormat JsonObject { get; }
        public static ChatResponseFormat Text { get; }
    }
    public class ChatTokenLogProbabilityInfo {
        public float LogProbability { get; }
        public string Token { get; }
        public IReadOnlyList<ChatTokenTopLogProbabilityInfo> TopLogProbabilities { get; }
        public IReadOnlyList<int> Utf8ByteValues { get; }
    }
    public class ChatTokenTopLogProbabilityInfo {
        public float LogProbability { get; }
        public string Token { get; }
        public IReadOnlyList<int> Utf8ByteValues { get; }
    }
    public class ChatTokenUsage {
        public int InputTokens { get; }
        public int OutputTokens { get; }
        public int TotalTokens { get; }
    }
    public class ChatTool {
        public string FunctionDescription { get; }
        public string FunctionName { get; }
        public BinaryData FunctionParameters { get; }
        public ChatToolKind Kind { get; }
        public static ChatTool CreateFunctionTool(string functionName, string functionDescription = null, BinaryData functionParameters = null);
    }
    public class ChatToolCall {
        public string FunctionArguments { get; }
        public string FunctionName { get; }
        public string Id { get; set; }
        public ChatToolCallKind Kind { get; }
        public static ChatToolCall CreateFunctionToolCall(string toolCallId, string functionName, string functionArguments);
    }
    public sealed class ChatToolCallKind {
        public ChatToolCallKind(string value);
        public static ChatToolCallKind Function { get; }
        public bool Equals(ChatToolCallKind other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(ChatToolCallKind left, ChatToolCallKind right);
        public static implicit operator ChatToolCallKind(string value);
        public static bool operator !=(ChatToolCallKind left, ChatToolCallKind right);
        public override string ToString();
    }
    public class ChatToolChoice {
        public ChatToolChoice(ChatTool tool);
        public static ChatToolChoice Auto { get; }
        public static ChatToolChoice None { get; }
        public static ChatToolChoice Required { get; }
    }
    public sealed class ChatToolKind {
        public ChatToolKind(string value);
        public static ChatToolKind Function { get; }
        public bool Equals(ChatToolKind other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(ChatToolKind left, ChatToolKind right);
        public static implicit operator ChatToolKind(string value);
        public static bool operator !=(ChatToolKind left, ChatToolKind right);
        public override string ToString();
    }
    public class FunctionChatMessage : ChatMessage {
        public FunctionChatMessage(string functionName, string content = null);
        public string FunctionName { get; }
        protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    }
    public sealed class ImageChatMessageContentPartDetail {
        public ImageChatMessageContentPartDetail(string value);
        public static ImageChatMessageContentPartDetail Auto { get; }
        public static ImageChatMessageContentPartDetail High { get; }
        public static ImageChatMessageContentPartDetail Low { get; }
        public bool Equals(ImageChatMessageContentPartDetail other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(ImageChatMessageContentPartDetail left, ImageChatMessageContentPartDetail right);
        public static implicit operator ImageChatMessageContentPartDetail(string value);
        public static bool operator !=(ImageChatMessageContentPartDetail left, ImageChatMessageContentPartDetail right);
        public override string ToString();
    }
    public class StreamingChatCompletionUpdate {
        public IReadOnlyList<ChatTokenLogProbabilityInfo> ContentTokenLogProbabilities { get; }
        public IReadOnlyList<ChatMessageContentPart> ContentUpdate { get; }
        public DateTimeOffset CreatedAt { get; }
        public ChatFinishReason? FinishReason { get; }
        public StreamingChatFunctionCallUpdate FunctionCallUpdate { get; }
        public string Id { get; }
        public string Model { get; }
        public ChatMessageRole? Role { get; }
        public string SystemFingerprint { get; }
        public IReadOnlyList<StreamingChatToolCallUpdate> ToolCallUpdates { get; }
        public ChatTokenUsage Usage { get; }
    }
    public class StreamingChatFunctionCallUpdate {
        public string FunctionArgumentsUpdate { get; }
        public string FunctionName { get; }
    }
    public class StreamingChatToolCallUpdate {
        public string FunctionArgumentsUpdate { get; }
        public string FunctionName { get; }
        public string Id { get; }
        public int Index { get; }
        public ChatToolCallKind Kind { get; }
    }
    public class SystemChatMessage : ChatMessage {
        public SystemChatMessage(string content);
        public string ParticipantName { get; }
        protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    }
    public class ToolChatMessage : ChatMessage {
        public ToolChatMessage(string toolCallId, string content);
        public string ToolCallId { get; }
        protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    }
    public class UserChatMessage : ChatMessage {
        public UserChatMessage(params ChatMessageContentPart[] content);
        public UserChatMessage(IEnumerable<ChatMessageContentPart> content);
        public UserChatMessage(string content);
        public string ParticipantName { get; set; }
        protected override void WriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options);
    }
}
namespace OpenAI.Embeddings {
    public class Embedding {
        public int Index { get; }
        public ReadOnlyMemory<float> Vector { get; }
    }
    public class EmbeddingClient {
        protected EmbeddingClient();
        protected internal EmbeddingClient(ClientPipeline pipeline, string model, Uri endpoint, OpenAIClientOptions options);
        public EmbeddingClient(string model, OpenAIClientOptions options = null);
        public EmbeddingClient(string model, ApiKeyCredential credential, OpenAIClientOptions options = null);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<Embedding> GenerateEmbedding(string input, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<Embedding>> GenerateEmbeddingAsync(string input, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult GenerateEmbeddings(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<EmbeddingCollection> GenerateEmbeddings(IEnumerable<IEnumerable<int>> inputs, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<EmbeddingCollection> GenerateEmbeddings(IEnumerable<string> inputs, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> GenerateEmbeddingsAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<EmbeddingCollection>> GenerateEmbeddingsAsync(IEnumerable<IEnumerable<int>> inputs, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<EmbeddingCollection>> GenerateEmbeddingsAsync(IEnumerable<string> inputs, EmbeddingGenerationOptions options = null, CancellationToken cancellationToken = null);
    }
    public class EmbeddingCollection {
        public string Model { get; }
        public EmbeddingTokenUsage Usage { get; }
    }
    public class EmbeddingGenerationOptions {
        public EmbeddingGenerationOptions();
        public int? Dimensions { get; set; }
        public string User { get; set; }
    }
    public class EmbeddingTokenUsage {
        public int InputTokens { get; }
        public int TotalTokens { get; }
    }
}
namespace OpenAI.Files {
    public class FileClient {
        protected FileClient();
        public FileClient(OpenAIClientOptions options = null);
        public FileClient(ApiKeyCredential credential, OpenAIClientOptions options = null);
        protected internal FileClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<bool> DeleteFile(OpenAIFileInfo file);
        public virtual ClientResult DeleteFile(string fileId, RequestOptions options);
        public virtual ClientResult<bool> DeleteFile(string fileId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<bool>> DeleteFileAsync(OpenAIFileInfo file);
        public virtual Task<ClientResult> DeleteFileAsync(string fileId, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteFileAsync(string fileId, CancellationToken cancellationToken = null);
        public virtual ClientResult<BinaryData> DownloadFile(OpenAIFileInfo file);
        public virtual ClientResult DownloadFile(string fileId, RequestOptions options);
        public virtual ClientResult<BinaryData> DownloadFile(string fileId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<BinaryData>> DownloadFileAsync(OpenAIFileInfo file);
        public virtual Task<ClientResult> DownloadFileAsync(string fileId, RequestOptions options);
        public virtual Task<ClientResult<BinaryData>> DownloadFileAsync(string fileId, CancellationToken cancellationToken = null);
        public virtual ClientResult GetFile(string fileId, RequestOptions options);
        public virtual ClientResult<OpenAIFileInfo> GetFile(string fileId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> GetFileAsync(string fileId, RequestOptions options);
        public virtual Task<ClientResult<OpenAIFileInfo>> GetFileAsync(string fileId, CancellationToken cancellationToken = null);
        public virtual ClientResult<OpenAIFileInfoCollection> GetFiles(OpenAIFilePurpose? purpose = null, CancellationToken cancellationToken = null);
        public virtual ClientResult GetFiles(string purpose, RequestOptions options);
        public virtual Task<ClientResult<OpenAIFileInfoCollection>> GetFilesAsync(OpenAIFilePurpose? purpose = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> GetFilesAsync(string purpose, RequestOptions options);
        public virtual ClientResult<OpenAIFileInfo> UploadFile(BinaryData file, string filename, FileUploadPurpose purpose);
        public virtual ClientResult UploadFile(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual ClientResult<OpenAIFileInfo> UploadFile(Stream file, string filename, FileUploadPurpose purpose, CancellationToken cancellationToken = null);
        public virtual ClientResult<OpenAIFileInfo> UploadFile(string filePath, FileUploadPurpose purpose);
        public virtual Task<ClientResult<OpenAIFileInfo>> UploadFileAsync(BinaryData file, string filename, FileUploadPurpose purpose);
        public virtual Task<ClientResult> UploadFileAsync(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual Task<ClientResult<OpenAIFileInfo>> UploadFileAsync(Stream file, string filename, FileUploadPurpose purpose, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<OpenAIFileInfo>> UploadFileAsync(string filePath, FileUploadPurpose purpose);
    }
    public sealed class FileUploadPurpose {
        public FileUploadPurpose(string value);
        public static FileUploadPurpose Assistants { get; }
        public static FileUploadPurpose Batch { get; }
        public static FileUploadPurpose FineTune { get; }
        public static FileUploadPurpose Vision { get; }
        public bool Equals(FileUploadPurpose other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(FileUploadPurpose left, FileUploadPurpose right);
        public static implicit operator FileUploadPurpose(string value);
        public static bool operator !=(FileUploadPurpose left, FileUploadPurpose right);
        public override string ToString();
    }
    public class OpenAIFileInfo {
        public DateTimeOffset CreatedAt { get; }
        public string Filename { get; }
        public string Id { get; }
        public OpenAIFilePurpose Purpose { get; }
        public long? SizeInBytes { get; }
        public OpenAIFileStatus Status { get; }
        public string StatusDetails { get; }
    }
    public class OpenAIFileInfoCollection {
    }
    public sealed class OpenAIFilePurpose {
        public OpenAIFilePurpose(string value);
        public static OpenAIFilePurpose Assistants { get; }
        public static OpenAIFilePurpose AssistantsOutput { get; }
        public static OpenAIFilePurpose Batch { get; }
        public static OpenAIFilePurpose BatchOutput { get; }
        public static OpenAIFilePurpose FineTune { get; }
        public static OpenAIFilePurpose FineTuneResults { get; }
        public static OpenAIFilePurpose Vision { get; }
        public bool Equals(OpenAIFilePurpose other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(OpenAIFilePurpose left, OpenAIFilePurpose right);
        public static implicit operator OpenAIFilePurpose(string value);
        public static bool operator !=(OpenAIFilePurpose left, OpenAIFilePurpose right);
        public override string ToString();
    }
    public sealed class OpenAIFileStatus {
        public OpenAIFileStatus(string value);
        public static OpenAIFileStatus Error { get; }
        public static OpenAIFileStatus Processed { get; }
        public static OpenAIFileStatus Uploaded { get; }
        public bool Equals(OpenAIFileStatus other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(OpenAIFileStatus left, OpenAIFileStatus right);
        public static implicit operator OpenAIFileStatus(string value);
        public static bool operator !=(OpenAIFileStatus left, OpenAIFileStatus right);
        public override string ToString();
    }
}
namespace OpenAI.FineTuning {
    public class FineTuningClient {
        protected FineTuningClient();
        public FineTuningClient(OpenAIClientOptions options = null);
        public FineTuningClient(ApiKeyCredential credential, OpenAIClientOptions options = null);
        protected internal FineTuningClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult CancelJob(string jobId, RequestOptions options);
        public virtual Task<ClientResult> CancelJobAsync(string jobId, RequestOptions options);
        public virtual ClientResult CreateJob(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult> CreateJobAsync(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult GetJob(string jobId, RequestOptions options);
        public virtual Task<ClientResult> GetJobAsync(string jobId, RequestOptions options);
        public virtual ClientResult GetJobCheckpoints(string fineTuningJobId, string after, int? limit, RequestOptions options);
        public virtual Task<ClientResult> GetJobCheckpointsAsync(string fineTuningJobId, string after, int? limit, RequestOptions options);
        public virtual ClientResult GetJobEvents(string jobId, string after, int? limit, RequestOptions options);
        public virtual Task<ClientResult> GetJobEventsAsync(string jobId, string after, int? limit, RequestOptions options);
        public virtual ClientResult GetJobs(string after, int? limit, RequestOptions options);
        public virtual Task<ClientResult> GetJobsAsync(string after, int? limit, RequestOptions options);
    }
}
namespace OpenAI.Images {
    public class GeneratedImage {
        public BinaryData ImageBytes { get; }
        public Uri ImageUri { get; }
        public string RevisedPrompt { get; }
    }
    public class GeneratedImageCollection {
        public DateTimeOffset Created { get; }
        public DateTimeOffset CreatedAt { get; }
    }
    public sealed class GeneratedImageFormat {
        public const GeneratedImageFormat Bytes = 0;
        public const GeneratedImageFormat Uri = 1;
    }
    public sealed class GeneratedImageQuality {
        public const GeneratedImageQuality High = 0;
        public const GeneratedImageQuality Standard = 1;
    }
    public sealed class GeneratedImageSize {
        public static readonly GeneratedImageSize W1024xH1024;
        public static readonly GeneratedImageSize W1024xH1792;
        public static readonly GeneratedImageSize W1792xH1024;
        public static readonly GeneratedImageSize W256xH256;
        public static readonly GeneratedImageSize W512xH512;
        public GeneratedImageSize(int width, int height);
        public bool Equals(GeneratedImageSize other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(GeneratedImageSize left, GeneratedImageSize right);
        public static bool operator !=(GeneratedImageSize left, GeneratedImageSize right);
        public override string ToString();
    }
    public sealed class GeneratedImageStyle {
        public const GeneratedImageStyle Natural = 1;
        public const GeneratedImageStyle Vivid = 0;
    }
    public class ImageClient {
        protected ImageClient();
        protected internal ImageClient(ClientPipeline pipeline, string model, Uri endpoint, OpenAIClientOptions options);
        public ImageClient(string model, OpenAIClientOptions options = null);
        public ImageClient(string model, ApiKeyCredential credential, OpenAIClientOptions options = null);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<GeneratedImage> GenerateImage(string prompt, ImageGenerationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageAsync(string prompt, ImageGenerationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<GeneratedImage> GenerateImageEdit(Stream image, string imageFilename, string prompt, ImageEditOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<GeneratedImage> GenerateImageEdit(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, ImageEditOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<GeneratedImage> GenerateImageEdit(string imageFilePath, string prompt, ImageEditOptions options = null);
        public virtual ClientResult<GeneratedImage> GenerateImageEdit(string imageFilePath, string prompt, string maskFilePath, ImageEditOptions options = null);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageEditAsync(Stream image, string imageFilename, string prompt, ImageEditOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageEditAsync(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, ImageEditOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageEditAsync(string imageFilePath, string prompt, ImageEditOptions options = null);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageEditAsync(string imageFilePath, string prompt, string maskFilePath, ImageEditOptions options = null);
        public virtual ClientResult GenerateImageEdits(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(Stream image, string imageFilename, string prompt, int imageCount, ImageEditOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, int imageCount, ImageEditOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(string imageFilePath, string prompt, int imageCount, ImageEditOptions options = null);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageEdits(string imageFilePath, string prompt, string maskFilePath, int imageCount, ImageEditOptions options = null);
        public virtual Task<ClientResult> GenerateImageEditsAsync(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(Stream image, string imageFilename, string prompt, int imageCount, ImageEditOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(Stream image, string imageFilename, string prompt, Stream mask, string maskFilename, int imageCount, ImageEditOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(string imageFilePath, string prompt, int imageCount, ImageEditOptions options = null);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageEditsAsync(string imageFilePath, string prompt, string maskFilePath, int imageCount, ImageEditOptions options = null);
        public virtual ClientResult GenerateImages(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<GeneratedImageCollection> GenerateImages(string prompt, int imageCount, ImageGenerationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> GenerateImagesAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImagesAsync(string prompt, int imageCount, ImageGenerationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<GeneratedImage> GenerateImageVariation(Stream image, string imageFilename, ImageVariationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<GeneratedImage> GenerateImageVariation(string imageFilePath, ImageVariationOptions options = null);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageVariationAsync(Stream image, string imageFilename, ImageVariationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<GeneratedImage>> GenerateImageVariationAsync(string imageFilePath, ImageVariationOptions options = null);
        public virtual ClientResult GenerateImageVariations(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageVariations(Stream image, string imageFilename, int imageCount, ImageVariationOptions options = null, CancellationToken cancellationToken = null);
        public virtual ClientResult<GeneratedImageCollection> GenerateImageVariations(string imageFilePath, int imageCount, ImageVariationOptions options = null);
        public virtual Task<ClientResult> GenerateImageVariationsAsync(BinaryContent content, string contentType, RequestOptions options = null);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageVariationsAsync(Stream image, string imageFilename, int imageCount, ImageVariationOptions options = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<GeneratedImageCollection>> GenerateImageVariationsAsync(string imageFilePath, int imageCount, ImageVariationOptions options = null);
    }
    public class ImageEditOptions {
        public ImageEditOptions();
        public GeneratedImageFormat? ResponseFormat { get; set; }
        public GeneratedImageSize? Size { get; set; }
        public string User { get; set; }
    }
    public class ImageGenerationOptions {
        public ImageGenerationOptions();
        public GeneratedImageQuality? Quality { get; set; }
        public GeneratedImageFormat? ResponseFormat { get; set; }
        public GeneratedImageSize? Size { get; set; }
        public GeneratedImageStyle? Style { get; set; }
        public string User { get; set; }
    }
    public class ImageVariationOptions {
        public ImageVariationOptions();
        public GeneratedImageFormat? ResponseFormat { get; set; }
        public GeneratedImageSize? Size { get; set; }
        public string User { get; set; }
    }
}
namespace OpenAI.Models {
    public class ModelClient {
        protected ModelClient();
        public ModelClient(OpenAIClientOptions options = null);
        public ModelClient(ApiKeyCredential credential, OpenAIClientOptions options = null);
        protected internal ModelClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult DeleteModel(string model, RequestOptions options);
        public virtual ClientResult<bool> DeleteModel(string model);
        public virtual Task<ClientResult> DeleteModelAsync(string model, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteModelAsync(string model);
        public virtual ClientResult GetModel(string model, RequestOptions options);
        public virtual ClientResult<OpenAIModelInfo> GetModel(string model);
        public virtual Task<ClientResult> GetModelAsync(string model, RequestOptions options);
        public virtual Task<ClientResult<OpenAIModelInfo>> GetModelAsync(string model);
        public virtual ClientResult<OpenAIModelInfoCollection> GetModels();
        public virtual ClientResult GetModels(RequestOptions options);
        public virtual Task<ClientResult<OpenAIModelInfoCollection>> GetModelsAsync();
        public virtual Task<ClientResult> GetModelsAsync(RequestOptions options);
    }
    public class OpenAIModelInfo {
        public DateTimeOffset CreatedAt { get; }
        public string Id { get; }
        public string OwnedBy { get; }
    }
    public class OpenAIModelInfoCollection {
    }
}
namespace OpenAI.Moderations {
    public class ModerationCategories {
        public bool Harassment { get; }
        public bool HarassmentThreatening { get; }
        public bool Hate { get; }
        public bool HateThreatening { get; }
        public bool SelfHarm { get; }
        public bool SelfHarmInstructions { get; }
        public bool SelfHarmIntent { get; }
        public bool Sexual { get; }
        public bool SexualMinors { get; }
        public bool Violence { get; }
        public bool ViolenceGraphic { get; }
    }
    public class ModerationCategoryScores {
        public float Harassment { get; }
        public float HarassmentThreatening { get; }
        public float Hate { get; }
        public float HateThreatening { get; }
        public float SelfHarm { get; }
        public float SelfHarmInstructions { get; }
        public float SelfHarmIntent { get; }
        public float Sexual { get; }
        public float SexualMinors { get; }
        public float Violence { get; }
        public float ViolenceGraphic { get; }
    }
    public class ModerationClient {
        protected ModerationClient();
        protected internal ModerationClient(ClientPipeline pipeline, string model, Uri endpoint, OpenAIClientOptions options);
        public ModerationClient(string model, OpenAIClientOptions options = null);
        public ModerationClient(string model, ApiKeyCredential credential, OpenAIClientOptions options = null);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<ModerationResult> ClassifyTextInput(string input, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<ModerationResult>> ClassifyTextInputAsync(string input, CancellationToken cancellationToken = null);
        public virtual ClientResult ClassifyTextInputs(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<ModerationCollection> ClassifyTextInputs(IEnumerable<string> inputs, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> ClassifyTextInputsAsync(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<ModerationCollection>> ClassifyTextInputsAsync(IEnumerable<string> inputs, CancellationToken cancellationToken = null);
    }
    public class ModerationCollection {
        public string Id { get; }
        public string Model { get; }
    }
    public class ModerationResult {
        public ModerationCategories Categories { get; }
        public ModerationCategoryScores CategoryScores { get; }
        public bool Flagged { get; }
    }
}
namespace OpenAI.VectorStores {
    public abstract class FileChunkingStrategy {
        protected FileChunkingStrategy();
        public static FileChunkingStrategy Auto { get; }
        public static FileChunkingStrategy Unknown { get; }
        public static FileChunkingStrategy CreateStaticStrategy(int maxTokensPerChunk, int overlappingTokenCount);
    }
    public class StaticFileChunkingStrategy : FileChunkingStrategy {
        public StaticFileChunkingStrategy(int maxTokensPerChunk, int overlappingTokenCount);
        public int MaxTokensPerChunk { get; }
        public int OverlappingTokenCount { get; }
    }
    public class VectorStore {
        public DateTimeOffset CreatedAt { get; }
        public VectorStoreExpirationPolicy ExpirationPolicy { get; }
        public DateTimeOffset? ExpiresAt { get; }
        public VectorStoreFileCounts FileCounts { get; }
        public string Id { get; }
        public DateTimeOffset? LastActiveAt { get; }
        public IReadOnlyDictionary<string, string> Metadata { get; }
        public string Name { get; }
        public VectorStoreStatus Status { get; }
        public int UsageBytes { get; }
    }
    public class VectorStoreBatchFileJob {
        public string BatchId { get; }
        public DateTimeOffset CreatedAt { get; }
        public VectorStoreFileCounts FileCounts { get; }
        public VectorStoreBatchFileJobStatus Status { get; }
        public string VectorStoreId { get; }
    }
    public sealed class VectorStoreBatchFileJobStatus {
        public VectorStoreBatchFileJobStatus(string value);
        public static VectorStoreBatchFileJobStatus Cancelled { get; }
        public static VectorStoreBatchFileJobStatus Completed { get; }
        public static VectorStoreBatchFileJobStatus Failed { get; }
        public static VectorStoreBatchFileJobStatus InProgress { get; }
        public bool Equals(VectorStoreBatchFileJobStatus other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(VectorStoreBatchFileJobStatus left, VectorStoreBatchFileJobStatus right);
        public static implicit operator VectorStoreBatchFileJobStatus(string value);
        public static bool operator !=(VectorStoreBatchFileJobStatus left, VectorStoreBatchFileJobStatus right);
        public override string ToString();
    }
    public class VectorStoreClient {
        protected VectorStoreClient();
        public VectorStoreClient(OpenAIClientOptions options = null);
        public VectorStoreClient(ApiKeyCredential credential, OpenAIClientOptions options = null);
        protected internal VectorStoreClient(ClientPipeline pipeline, Uri endpoint, OpenAIClientOptions options);
        public virtual ClientPipeline Pipeline { get; }
        public virtual ClientResult<VectorStoreFileAssociation> AddFileToVectorStore(VectorStore vectorStore, Files.OpenAIFileInfo file);
        public virtual ClientResult AddFileToVectorStore(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<VectorStoreFileAssociation> AddFileToVectorStore(string vectorStoreId, string fileId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<VectorStoreFileAssociation>> AddFileToVectorStoreAsync(VectorStore vectorStore, Files.OpenAIFileInfo file);
        public virtual Task<ClientResult> AddFileToVectorStoreAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<VectorStoreFileAssociation>> AddFileToVectorStoreAsync(string vectorStoreId, string fileId, CancellationToken cancellationToken = null);
        public virtual ClientResult<VectorStoreBatchFileJob> CancelBatchFileJob(VectorStoreBatchFileJob batchJob);
        public virtual ClientResult CancelBatchFileJob(string vectorStoreId, string batchId, RequestOptions options);
        public virtual ClientResult<VectorStoreBatchFileJob> CancelBatchFileJob(string vectorStoreId, string batchJobId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> CancelBatchFileJobAsync(VectorStoreBatchFileJob batchJob);
        public virtual Task<ClientResult> CancelBatchFileJobAsync(string vectorStoreId, string batchId, RequestOptions options);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> CancelBatchFileJobAsync(string vectorStoreId, string batchJobId, CancellationToken cancellationToken = null);
        public virtual ClientResult<VectorStoreBatchFileJob> CreateBatchFileJob(VectorStore vectorStore, IEnumerable<Files.OpenAIFileInfo> files);
        public virtual ClientResult CreateBatchFileJob(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<VectorStoreBatchFileJob> CreateBatchFileJob(string vectorStoreId, IEnumerable<string> fileIds, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> CreateBatchFileJobAsync(VectorStore vectorStore, IEnumerable<Files.OpenAIFileInfo> files);
        public virtual Task<ClientResult> CreateBatchFileJobAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> CreateBatchFileJobAsync(string vectorStoreId, IEnumerable<string> fileIds, CancellationToken cancellationToken = null);
        public virtual ClientResult<VectorStore> CreateVectorStore(VectorStoreCreationOptions vectorStore = null, CancellationToken cancellationToken = null);
        public virtual ClientResult CreateVectorStore(BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<VectorStore>> CreateVectorStoreAsync(VectorStoreCreationOptions vectorStore = null, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> CreateVectorStoreAsync(BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<bool> DeleteVectorStore(VectorStore vectorStore);
        public virtual ClientResult DeleteVectorStore(string vectorStoreId, RequestOptions options);
        public virtual ClientResult<bool> DeleteVectorStore(string vectorStoreId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<bool>> DeleteVectorStoreAsync(VectorStore vectorStore);
        public virtual Task<ClientResult> DeleteVectorStoreAsync(string vectorStoreId, RequestOptions options);
        public virtual Task<ClientResult<bool>> DeleteVectorStoreAsync(string vectorStoreId, CancellationToken cancellationToken = null);
        public virtual ClientResult<VectorStoreBatchFileJob> GetBatchFileJob(VectorStoreBatchFileJob batchJob);
        public virtual ClientResult GetBatchFileJob(string vectorStoreId, string batchId, RequestOptions options);
        public virtual ClientResult<VectorStoreBatchFileJob> GetBatchFileJob(string vectorStoreId, string batchJobId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> GetBatchFileJobAsync(VectorStoreBatchFileJob batchJob);
        public virtual Task<ClientResult> GetBatchFileJobAsync(string vectorStoreId, string batchId, RequestOptions options);
        public virtual Task<ClientResult<VectorStoreBatchFileJob>> GetBatchFileJobAsync(string vectorStoreId, string batchJobId, CancellationToken cancellationToken = null);
        public virtual ClientResult<VectorStoreFileAssociation> GetFileAssociation(VectorStore vectorStore, Files.OpenAIFileInfo file);
        public virtual ClientResult GetFileAssociation(string vectorStoreId, string fileId, RequestOptions options);
        public virtual ClientResult<VectorStoreFileAssociation> GetFileAssociation(string vectorStoreId, string fileId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<VectorStoreFileAssociation>> GetFileAssociationAsync(VectorStore vectorStore, Files.OpenAIFileInfo file);
        public virtual Task<ClientResult> GetFileAssociationAsync(string vectorStoreId, string fileId, RequestOptions options);
        public virtual Task<ClientResult<VectorStoreFileAssociation>> GetFileAssociationAsync(string vectorStoreId, string fileId, CancellationToken cancellationToken = null);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(VectorStore vectorStore, VectorStoreFileAssociationCollectionOptions options = null);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(VectorStoreBatchFileJob batchJob, VectorStoreFileAssociationCollectionOptions options = null);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(string vectorStoreId, VectorStoreFileAssociationCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual IEnumerable<ClientResult> GetFileAssociations(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(string vectorStoreId, string batchJobId, VectorStoreFileAssociationCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual PageCollection<VectorStoreFileAssociation> GetFileAssociations(string vectorStoreId, string batchJobId, ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual IEnumerable<ClientResult> GetFileAssociations(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(VectorStore vectorStore, VectorStoreFileAssociationCollectionOptions options = null);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(VectorStoreBatchFileJob batchJob, VectorStoreFileAssociationCollectionOptions options = null);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(string vectorStoreId, VectorStoreFileAssociationCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual IAsyncEnumerable<ClientResult> GetFileAssociationsAsync(string vectorStoreId, int? limit, string order, string after, string before, string filter, RequestOptions options);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(string vectorStoreId, string batchJobId, VectorStoreFileAssociationCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual AsyncPageCollection<VectorStoreFileAssociation> GetFileAssociationsAsync(string vectorStoreId, string batchJobId, ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual IAsyncEnumerable<ClientResult> GetFileAssociationsAsync(string vectorStoreId, string batchId, int? limit, string order, string after, string before, string filter, RequestOptions options);
        public virtual ClientResult<VectorStore> GetVectorStore(VectorStore vectorStore);
        public virtual ClientResult GetVectorStore(string vectorStoreId, RequestOptions options);
        public virtual ClientResult<VectorStore> GetVectorStore(string vectorStoreId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<VectorStore>> GetVectorStoreAsync(VectorStore vectorStore);
        public virtual Task<ClientResult> GetVectorStoreAsync(string vectorStoreId, RequestOptions options);
        public virtual Task<ClientResult<VectorStore>> GetVectorStoreAsync(string vectorStoreId, CancellationToken cancellationToken = null);
        public virtual PageCollection<VectorStore> GetVectorStores(VectorStoreCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual PageCollection<VectorStore> GetVectorStores(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual IEnumerable<ClientResult> GetVectorStores(int? limit, string order, string after, string before, RequestOptions options);
        public virtual AsyncPageCollection<VectorStore> GetVectorStoresAsync(VectorStoreCollectionOptions options = null, CancellationToken cancellationToken = null);
        public virtual AsyncPageCollection<VectorStore> GetVectorStoresAsync(ContinuationToken firstPageToken, CancellationToken cancellationToken = null);
        public virtual IAsyncEnumerable<ClientResult> GetVectorStoresAsync(int? limit, string order, string after, string before, RequestOptions options);
        public virtual ClientResult<VectorStore> ModifyVectorStore(VectorStore vectorStore, VectorStoreModificationOptions options);
        public virtual ClientResult<VectorStore> ModifyVectorStore(string vectorStoreId, VectorStoreModificationOptions vectorStore, CancellationToken cancellationToken = null);
        public virtual ClientResult ModifyVectorStore(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual Task<ClientResult<VectorStore>> ModifyVectorStoreAsync(VectorStore vectorStore, VectorStoreModificationOptions options);
        public virtual Task<ClientResult<VectorStore>> ModifyVectorStoreAsync(string vectorStoreId, VectorStoreModificationOptions vectorStore, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult> ModifyVectorStoreAsync(string vectorStoreId, BinaryContent content, RequestOptions options = null);
        public virtual ClientResult<bool> RemoveFileFromStore(VectorStore vectorStore, Files.OpenAIFileInfo file);
        public virtual ClientResult RemoveFileFromStore(string vectorStoreId, string fileId, RequestOptions options);
        public virtual ClientResult<bool> RemoveFileFromStore(string vectorStoreId, string fileId, CancellationToken cancellationToken = null);
        public virtual Task<ClientResult<bool>> RemoveFileFromStoreAsync(VectorStore vectorStore, Files.OpenAIFileInfo file);
        public virtual Task<ClientResult> RemoveFileFromStoreAsync(string vectorStoreId, string fileId, RequestOptions options);
        public virtual Task<ClientResult<bool>> RemoveFileFromStoreAsync(string vectorStoreId, string fileId, CancellationToken cancellationToken = null);
    }
    public class VectorStoreCollectionOptions {
        public VectorStoreCollectionOptions();
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public class VectorStoreCreationOptions {
        public VectorStoreCreationOptions();
        public FileChunkingStrategy ChunkingStrategy { get; set; }
        public VectorStoreExpirationPolicy ExpirationPolicy { get; set; }
        public IList<string> FileIds { get; }
        public IDictionary<string, string> Metadata { get; }
        public string Name { get; set; }
    }
    public sealed class VectorStoreExpirationAnchor {
        public const VectorStoreExpirationAnchor LastActiveAt = 1;
        public const VectorStoreExpirationAnchor Unknown = 0;
    }
    public class VectorStoreExpirationPolicy {
        public VectorStoreExpirationPolicy();
        public VectorStoreExpirationPolicy(VectorStoreExpirationAnchor anchor, int days);
        public required VectorStoreExpirationAnchor Anchor { get; set; }
        public required int Days { get; set; }
    }
    public class VectorStoreFileAssociation {
        public FileChunkingStrategy ChunkingStrategy { get; }
        public DateTimeOffset CreatedAt { get; }
        public string FileId { get; }
        public VectorStoreFileAssociationError? LastError { get; }
        public int Size { get; }
        public VectorStoreFileAssociationStatus Status { get; }
        public string VectorStoreId { get; }
    }
    public class VectorStoreFileAssociationCollectionOptions {
        public VectorStoreFileAssociationCollectionOptions();
        public string AfterId { get; set; }
        public string BeforeId { get; set; }
        public VectorStoreFileStatusFilter? Filter { get; set; }
        public ListOrder? Order { get; set; }
        public int? PageSize { get; set; }
    }
    public sealed class VectorStoreFileAssociationError {
        public VectorStoreFileAssociationError();
        public VectorStoreFileAssociationErrorCode Code { get; }
        public string Message { get; }
    }
    public sealed class VectorStoreFileAssociationErrorCode {
        public VectorStoreFileAssociationErrorCode(string value);
        public static VectorStoreFileAssociationErrorCode FileNotFound { get; }
        public static VectorStoreFileAssociationErrorCode InternalError { get; }
        public static VectorStoreFileAssociationErrorCode ParsingError { get; }
        public static VectorStoreFileAssociationErrorCode UnhandledMimeType { get; }
        public bool Equals(VectorStoreFileAssociationErrorCode other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(VectorStoreFileAssociationErrorCode left, VectorStoreFileAssociationErrorCode right);
        public static implicit operator VectorStoreFileAssociationErrorCode(string value);
        public static bool operator !=(VectorStoreFileAssociationErrorCode left, VectorStoreFileAssociationErrorCode right);
        public override string ToString();
    }
    public sealed class VectorStoreFileAssociationStatus {
        public const VectorStoreFileAssociationStatus Cancelled = 3;
        public const VectorStoreFileAssociationStatus Completed = 2;
        public const VectorStoreFileAssociationStatus Failed = 4;
        public const VectorStoreFileAssociationStatus InProgress = 1;
        public const VectorStoreFileAssociationStatus Unknown = 0;
    }
    public sealed class VectorStoreFileCounts {
        public VectorStoreFileCounts();
        public int Cancelled { get; }
        public int Completed { get; }
        public int Failed { get; }
        public int InProgress { get; }
        public int Total { get; }
    }
    public sealed class VectorStoreFileStatusFilter {
        public VectorStoreFileStatusFilter(string value);
        public static VectorStoreFileStatusFilter Cancelled { get; }
        public static VectorStoreFileStatusFilter Completed { get; }
        public static VectorStoreFileStatusFilter Failed { get; }
        public static VectorStoreFileStatusFilter InProgress { get; }
        public bool Equals(VectorStoreFileStatusFilter other);
        public override bool Equals(object obj);
        public override int GetHashCode();
        public static bool operator ==(VectorStoreFileStatusFilter left, VectorStoreFileStatusFilter right);
        public static implicit operator VectorStoreFileStatusFilter(string value);
        public static bool operator !=(VectorStoreFileStatusFilter left, VectorStoreFileStatusFilter right);
        public override string ToString();
    }
    public class VectorStoreModificationOptions {
        public VectorStoreModificationOptions();
        public VectorStoreExpirationPolicy ExpirationPolicy { get; set; }
        public IDictionary<string, string> Metadata { get; }
        public string Name { get; set; }
    }
    public sealed class VectorStoreStatus {
        public const VectorStoreStatus Completed = 2;
        public const VectorStoreStatus Expired = 3;
        public const VectorStoreStatus InProgress = 1;
        public const VectorStoreStatus Unknown = 0;
    }
}
```