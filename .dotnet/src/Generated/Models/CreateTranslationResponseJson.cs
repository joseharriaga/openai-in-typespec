// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Internal.Models
{
    internal partial class CreateTranslationResponseJson
    {
        internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        internal CreateTranslationResponseJson(string text)
        {
            Argument.AssertNotNull(text, nameof(text));

            Text = text;
        }

        internal CreateTranslationResponseJson(string text, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Text = text;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        internal CreateTranslationResponseJson()
        {
        }

        public string Text { get; }
    }
}
