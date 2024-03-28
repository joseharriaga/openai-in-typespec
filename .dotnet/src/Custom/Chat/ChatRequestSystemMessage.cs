using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Chat;

/// <summary>
/// Represents a chat message of the <c>system</c> role as supplied to a chat completion request. A system message is
/// generally supplied as the first message to a chat completion request and guides the model's behavior across future
/// <c>assistant</c> role response messages. These messages may help control behavior, style, tone, and
/// restrictions for a model-based assistant.
/// </summary>
public class ChatRequestSystemMessage : ChatRequestMessage
{
    /// <summary>
    /// An optional <c>name</c> for the participant.
    /// </summary>
    public string ParticipantName { get; set; } // JSON "name"

    /// <summary>
    /// Creates a new instance of <see cref="ChatRequestSystemMessage"/>.
    /// </summary>
    /// <param name="content"> The <c>system</c> message text that guides the model's behavior. </param>
    public ChatRequestSystemMessage(string content) : base(ChatRole.System, content) { }

    internal override void WriteDerivedAdditions(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (Optional.IsDefined(ParticipantName))
        {
            writer.WriteString("name"u8, ParticipantName);
        }
    }
}