// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    /// <summary> The RunStepDetailsToolCallsCodeOutputImageObject. </summary>
    internal partial class InternalRunStepDetailsToolCallsCodeOutputImageObject : RunStepCodeInterpreterOutput
    {
        /// <summary> Initializes a new instance of <see cref="InternalRunStepDetailsToolCallsCodeOutputImageObject"/>. </summary>
        /// <param name="image"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="image"/> is null. </exception>
        internal InternalRunStepDetailsToolCallsCodeOutputImageObject(InternalRunStepDetailsToolCallsCodeOutputImageObjectImage image)
        {
            Argument.AssertNotNull(image, nameof(image));

            Type = "image";
            _image = image;
        }

        /// <summary> Initializes a new instance of <see cref="InternalRunStepDetailsToolCallsCodeOutputImageObject"/>. </summary>
        /// <param name="type"> The discriminated type identifier for the details object. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="image"></param>
        internal InternalRunStepDetailsToolCallsCodeOutputImageObject(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalRunStepDetailsToolCallsCodeOutputImageObjectImage image) : base(type, serializedAdditionalRawData)
        {
            _image = image;
        }

        /// <summary> Initializes a new instance of <see cref="InternalRunStepDetailsToolCallsCodeOutputImageObject"/> for deserialization. </summary>
        internal InternalRunStepDetailsToolCallsCodeOutputImageObject()
        {
        }
    }
}
