// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace OpenAI.Assistants
{
    /// <summary> Details of the message creation by the run step. </summary>
    public partial class RunStepMessageCreationDetails : RunStepDetails
    {
        /// <summary> Initializes a new instance of <see cref="RunStepMessageCreationDetails"/>. </summary>
        /// <param name="messageCreation"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="messageCreation"/> is null. </exception>
        internal RunStepMessageCreationDetails(InternalRunStepDetailsMessageCreationObjectMessageCreation messageCreation)
        {
            Argument.AssertNotNull(messageCreation, nameof(messageCreation));

            Type = "message_creation";
            _messageCreation = messageCreation;
        }

        /// <summary> Initializes a new instance of <see cref="RunStepMessageCreationDetails"/>. </summary>
        /// <param name="type"> The discriminated type identifier for the details object. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="messageCreation"></param>
        internal RunStepMessageCreationDetails(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, InternalRunStepDetailsMessageCreationObjectMessageCreation messageCreation) : base(type, serializedAdditionalRawData)
        {
            _messageCreation = messageCreation;
        }

        /// <summary> Initializes a new instance of <see cref="RunStepMessageCreationDetails"/> for deserialization. </summary>
        internal RunStepMessageCreationDetails()
        {
        }
    }
}
