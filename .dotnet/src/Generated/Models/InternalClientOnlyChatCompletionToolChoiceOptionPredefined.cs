// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Chat
{
    internal partial class InternalClientOnlyChatCompletionToolChoiceOptionPredefined : ChatToolChoice
    {
        public InternalClientOnlyChatCompletionToolChoiceOptionPredefined(InternalClientOnlyChatCompletionToolChoiceOptionPredefinedValue value)
        {
            PlaceholderDiscriminator = InternalClientOnlyChatCompletionToolChoiceOptionPlaceholderDiscriminator.Predefined;
            Value = value;
        }

        internal InternalClientOnlyChatCompletionToolChoiceOptionPredefined(InternalClientOnlyChatCompletionToolChoiceOptionPlaceholderDiscriminator placeholderDiscriminator, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalClientOnlyChatCompletionToolChoiceOptionPredefinedValue value) : base(placeholderDiscriminator, serializedAdditionalRawData)
        {
            Value = value;
        }

        internal InternalClientOnlyChatCompletionToolChoiceOptionPredefined()
        {
        }

        public InternalClientOnlyChatCompletionToolChoiceOptionPredefinedValue Value { get; }
    }
}
