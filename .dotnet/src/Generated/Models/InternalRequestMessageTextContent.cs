// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    internal partial class InternalRequestMessageTextContent : MessageContent
    {
        public InternalRequestMessageTextContent(string internalText)
        {
            Argument.AssertNotNull(internalText, nameof(internalText));

            InternalText = internalText;
        }

        /// <summary> Initializes a new instance of <see cref="InternalRequestMessageTextContent"/>. </summary>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="type"> Always `text`. </param>
        /// <param name="internalText"> Text content to be sent to the model. </param>
        internal InternalRequestMessageTextContent(IDictionary<string, BinaryData> serializedAdditionalRawData, InternalMessageRequestContentTextObjectType type, string internalText) : base(serializedAdditionalRawData)
        {
            Type = type;
            InternalText = internalText;
        }

        internal InternalRequestMessageTextContent()
        {
        }

        /// <summary> Always `text`. </summary>
        public InternalMessageRequestContentTextObjectType Type { get; } = InternalMessageRequestContentTextObjectType.Text;
    }
}
