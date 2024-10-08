// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;

namespace OpenAI.Audio
{
    public partial class AudioTranslation
    {
        private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        internal AudioTranslation(string language, string text, InternalCreateTranslationResponseVerboseJsonTask task, TimeSpan? duration)
        {
            Language = language;
            Text = text;
            Segments = new ChangeTrackingList<TranscribedSegment>();
            Task = task;
            Duration = duration;
        }

        internal AudioTranslation(string language, string text, IList<TranscribedSegment> segments, InternalCreateTranslationResponseVerboseJsonTask task, TimeSpan? duration, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Language = language;
            Text = text;
            Segments = segments;
            Task = task;
            Duration = duration;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        public string Language { get; set; }

        public string Text { get; set; }

        public IList<TranscribedSegment> Segments { get; }
    }
}
