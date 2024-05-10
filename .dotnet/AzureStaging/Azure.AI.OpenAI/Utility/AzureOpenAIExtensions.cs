using OpenAI.Chat;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

#nullable enable

namespace Azure.AI.OpenAI;

// TODO: add [Experimental]
public static class AzureOpenAIExtensions
{
    public static ChatCompletionOptions WithStreaming(this ChatCompletionOptions chatOptions)
    {
        StreamingChatCompletionOptions? scco = chatOptions as StreamingChatCompletionOptions;
        scco ??= new StreamingChatCompletionOptions(chatOptions);
        scco.Streaming = true;
        return scco;
    }

    public static BinaryContent ToContent(this ChatCompletionOptions chatOptions)
    {
        BinaryData bytes = ModelReaderWriter.Write(chatOptions, ModelReaderWriterOptions.Json);
        return BinaryContent.Create(bytes);
    }

    public static AsyncResultCollection<BinaryData> FromCompletionEvents(this PipelineResponse response)
    {
        throw new NotImplementedException();
    }

    internal class StreamingChatCompletionOptions : ChatCompletionOptions, IJsonModel<StreamingChatCompletionOptions>
    {
        // Important that we use this field to serialize and not inherited type.
        private readonly ChatCompletionOptions _chatOptions;
        public bool Streaming { get; set; }

        public StreamingChatCompletionOptions(ChatCompletionOptions chatOptions)
        {
            _chatOptions = chatOptions;
        }

        StreamingChatCompletionOptions IJsonModel<StreamingChatCompletionOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        StreamingChatCompletionOptions IPersistableModel<StreamingChatCompletionOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        string IPersistableModel<StreamingChatCompletionOptions>.GetFormatFromOptions(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        void IJsonModel<StreamingChatCompletionOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            ModelReaderWriter.Write(_chatOptions, new ModelReaderWriterOptions("W*"));
            writer.WritePropertyName("stream");
            writer.WriteBooleanValue(Streaming);
            writer.WriteEndObject();
        }

        BinaryData IPersistableModel<StreamingChatCompletionOptions>.Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
