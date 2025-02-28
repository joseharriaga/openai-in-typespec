// <auto-generated/>

#nullable disable

using System;

namespace OpenAI.Files
{
    internal static partial class FilePurposeExtensions
    {
        public static string ToSerialString(this FilePurpose value) => value switch
        {
            FilePurpose.Assistants => "assistants",
            FilePurpose.AssistantsOutput => "assistants_output",
            FilePurpose.Batch => "batch",
            FilePurpose.BatchOutput => "batch_output",
            FilePurpose.FineTune => "fine-tune",
            FilePurpose.FineTuneResults => "fine-tune-results",
            FilePurpose.Vision => "vision",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FilePurpose value.")
        };

        public static FilePurpose ToFilePurpose(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "assistants"))
            {
                return FilePurpose.Assistants;
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "assistants_output"))
            {
                return FilePurpose.AssistantsOutput;
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "batch"))
            {
                return FilePurpose.Batch;
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "batch_output"))
            {
                return FilePurpose.BatchOutput;
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "fine-tune"))
            {
                return FilePurpose.FineTune;
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "fine-tune-results"))
            {
                return FilePurpose.FineTuneResults;
            }
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "vision"))
            {
                return FilePurpose.Vision;
            }
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown FilePurpose value.");
        }
    }
}
