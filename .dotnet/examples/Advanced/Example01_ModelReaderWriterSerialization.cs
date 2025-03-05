using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel.Primitives;
using System.Text.Json.Nodes;

namespace OpenAI.Examples;

public partial class AdvancedScenarioExamples
{
    [Test]
    public void Example01_ModelReaderWriterSerialization()
    {
        // Most library types can be instantiated directly from JSON using ModelReaderWriter.Read<T>() with BinaryData.
        // Conversely, BinaryData instances can be serialized from most types via ModelReaderWriter.Write(instance).
        BinaryData responseFormatBytes = BinaryData.FromBytes("""
        {
          "type": "json_object"
        }
        """u8.ToArray());
        ChatResponseFormat responseFormatFromJson = ModelReaderWriter.Read<ChatResponseFormat>(responseFormatBytes);

        // BinaryData creation can also be done from dynamic objects, allowing a degree of composition between library and dynamic types.
        //
        // NOTE: When serializing library types into a dynamic object for BinaryData, the library types must first be serialized
        //       to BinaryData before being converted to a generalized object via ToObjectFromJson<dynamic>().
        BinaryData chatOptionsBytes = BinaryData.FromObjectAsJson(
            new
            {
                model = "", // Not applicable: the model value provided to ChatClient will still be used here
                messages = Array.Empty<dynamic>(), // Not applicable: the messages provided to CompleteChat() will still be used here
                max_completion_tokens = 1024,
                response_format = ModelReaderWriter.Write(responseFormatFromJson).ToObjectFromJson<dynamic>(),
            });
        ChatCompletionOptions chatOptions = ModelReaderWriter.Read<ChatCompletionOptions>(chatOptionsBytes);

        // Via this same mechanism, an existing instance of a library type can be serialized to BinaryData, manipulated
        // via low-level JSON changes, and then deserialized back into a library type.
        BinaryData serializedChatOptions = ModelReaderWriter.Write(chatOptions);
        JsonNode jsonNode = JsonNode.Parse(serializedChatOptions);
        jsonNode["temperature"] = 0.5f;
        chatOptions = ModelReaderWriter.Read<ChatCompletionOptions>(BinaryData.FromObjectAsJson(jsonNode));

        // Instances created using low-level ModelReaderWriter.Read<T>() can then be used in methods just like ones
        // created via standard constructors or factory methods.
        //
        // NOTE: in contrast to when using protocol methods like ChatClient.CompleteChat(binaryContent, requestOptions),
        //       invoking client convenience methods with explicitly deserialized strong input types, like
        //       ChatClient.CompleteChat(messages, options), will still use input information provided at the client
        //       or method level. In this case, any value provided via JSON or a dynamic object for "model" or
        //       "messages" will be overwritten by the values provided to the model and CompleteChat() method,
        //       respectively.
        ChatClient client = new("gpt-4o-mini", Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
        ChatCompletion completion = client.CompleteChat(["Say hello. In JSON format, please!"], chatOptions);

        // Response types can also be serialized to BinaryData via ModelReaderWriter.Write(). This BinaryData can, in turn,
        // be used with typical System.Text.Json APIs.
        BinaryData completionBytes = ModelReaderWriter.Write(completion);
        JsonNode completionJsonNode = JsonNode.Parse(completionBytes);

        string lowLevelRetrievedRole = completionJsonNode["choices"][0]["message"]["role"].GetValue<string>();
        string lowLevelRetrievedContent = completionJsonNode["choices"][0]["message"]["content"].GetValue<string>();
        Console.WriteLine($"[{lowLevelRetrievedRole}]: {lowLevelRetrievedContent}");
    }
}
