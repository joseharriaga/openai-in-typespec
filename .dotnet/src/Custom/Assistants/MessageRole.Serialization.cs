using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI.Assistants;

internal class MessageRoleSerialization
{
    public static MessageRole DeserializeMessageRole(JsonElement jsonElement, ModelReaderWriterOptions options = default)
    {
        if (jsonElement.ValueKind != JsonValueKind.String)
        {
            throw new ArgumentException(nameof(jsonElement));
        }
        string roleName = jsonElement.GetString();
        if (roleName == "assistant")
        {
            return MessageRole.Assistant;
        }
        else if (roleName == "user")
        {
            return MessageRole.User;
        }
        else
        {
            throw new NotImplementedException(roleName);
        }
    }
}
