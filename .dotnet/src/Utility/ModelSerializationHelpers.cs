using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace OpenAI;

internal static partial class ModelSerializationHelpers
{
    internal static TOutput DeserializeNewInstance<TOutput,UInstanceInput>(
        UInstanceInput existingInstance,
        Func<JsonElement, ModelReaderWriterOptions?, TOutput> deserializationFunc,
        ref Utf8JsonReader reader,
        ModelReaderWriterOptions options)
            where UInstanceInput : IJsonModel<TOutput>
    {
        var format = options.Format == "W" ? ((IJsonModel<TOutput>)existingInstance).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(UInstanceInput)} does not support '{format}' format.");
        }

        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return deserializationFunc.Invoke(document.RootElement, options);
    }

    internal static TOutput DeserializeNewInstance<TOutput,UInstanceInput>(
        UInstanceInput existingInstance,
        Func<JsonElement, ModelReaderWriterOptions?, TOutput> deserializationFunc,
        BinaryData data,
        ModelReaderWriterOptions options)
            where UInstanceInput : IPersistableModel<TOutput>
    {
        var format = options.Format == "W" ? ((IPersistableModel<TOutput>)existingInstance).GetFormatFromOptions(options) : options.Format;

        switch (format)
        {
            case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return deserializationFunc.Invoke(document.RootElement, options)!;
                }
            default:
                throw new FormatException($"The model {nameof(UInstanceInput)} does not support '{format}' format.");
        }
    }

    internal static void AssertSupportedJsonWriteFormat<T>(T instance, ModelReaderWriterOptions options)
        where T : IJsonModel<T>
            => AssertSupportedJsonWriteFormat<T, T>(instance, options);

    internal static void AssertSupportedJsonWriteFormat<TOutput,UInstanceInput>(UInstanceInput instance, ModelReaderWriterOptions options)
        where UInstanceInput : IJsonModel<TOutput>
    {
        var format = options.Format == "W" ? ((IJsonModel<TOutput>)instance).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(UInstanceInput)} does not support '{format}' format.");
        }
    }

    internal static void AssertSupportedPersistableWriteFormat<T>(T instance, ModelReaderWriterOptions options)
        where T : IPersistableModel<T>
            => AssertSupportedPersistableWriteFormat<T, T>(instance, options);

    internal static void AssertSupportedPersistableWriteFormat<TOutput,UInstanceInput>(UInstanceInput instance, ModelReaderWriterOptions options)
        where UInstanceInput : IPersistableModel<TOutput>
    {
        var format = options.Format == "W" ? ((IPersistableModel<TOutput>)instance).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(UInstanceInput)} does not support '{format}' format.");
        }
    }
}