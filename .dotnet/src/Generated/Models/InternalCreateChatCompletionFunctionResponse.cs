// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenAI.Chat
{
    internal partial class InternalCreateChatCompletionFunctionResponse
    {
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal InternalCreateChatCompletionFunctionResponse(string id, IEnumerable<InternalCreateChatCompletionFunctionResponseChoice> choices, DateTimeOffset created, string model)
        {
            Argument.AssertNotNull(id, nameof(id));
            Argument.AssertNotNull(choices, nameof(choices));
            Argument.AssertNotNull(model, nameof(model));

            Id = id;
            Choices = choices.ToList();
            Created = created;
            Model = model;
        }

        internal InternalCreateChatCompletionFunctionResponse(string id, IReadOnlyList<InternalCreateChatCompletionFunctionResponseChoice> choices, DateTimeOffset created, string model, string systemFingerprint, InternalCreateChatCompletionFunctionResponseObject @object, ChatTokenUsage usage, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Id = id;
            Choices = choices;
            Created = created;
            Model = model;
            SystemFingerprint = systemFingerprint;
            Object = @object;
            Usage = usage;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal InternalCreateChatCompletionFunctionResponse()
        {
        }

        public string Id { get; }
        public IReadOnlyList<InternalCreateChatCompletionFunctionResponseChoice> Choices { get; }
        public DateTimeOffset Created { get; }
        public string Model { get; }
        public string SystemFingerprint { get; }
        public InternalCreateChatCompletionFunctionResponseObject Object { get; } = InternalCreateChatCompletionFunctionResponseObject.ChatCompletion;

        public ChatTokenUsage Usage { get; }
    }
}
