// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI.Models;

namespace OpenAI.Assistants
{
    internal partial class InternalMessageImageFileContent : MessageContent
    {
        internal InternalMessageImageFileContent(IDictionary<string, BinaryData> serializedAdditionalRawData, string type, InternalMessageContentItemFileObjectImageFile imageFile) : base(serializedAdditionalRawData)
        {
            _type = type;
            _imageFile = imageFile;
        }

        internal InternalMessageImageFileContent()
        {
        }
    }
}
