// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.OpenAI
{
    internal static class BinaryContentHelper
    {
        public static BinaryContent FromEnumerable<T>(IEnumerable<T> enumerable)
        where T : notnull
        {
            Utf8JsonBinaryContent content = new Utf8JsonBinaryContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in enumerable)
            {
                content.JsonWriter.WriteObjectValue(item, ModelSerializationExtensions.WireOptions);
            }
            content.JsonWriter.WriteEndArray();

            return content;
        }

        public static BinaryContent FromEnumerable(IEnumerable<BinaryData> enumerable)
        {
            Utf8JsonBinaryContent content = new Utf8JsonBinaryContent();
            content.JsonWriter.WriteStartArray();
            foreach (var item in enumerable)
            {
                if (item == null)
                {
                    content.JsonWriter.WriteNullValue();
                }
                else
                {
#if NET6_0_OR_GREATER
				content.JsonWriter.WriteRawValue(item);
#else
                    using (JsonDocument document = JsonDocument.Parse(item))
                    {
                        JsonSerializer.Serialize(content.JsonWriter, document.RootElement);
                    }
#endif
                }
            }
            content.JsonWriter.WriteEndArray();

            return content;
        }

        public static BinaryContent FromEnumerable<T>(ReadOnlySpan<T> span)
            where T : notnull
        {
            Utf8JsonBinaryContent content = new Utf8JsonBinaryContent();
            content.JsonWriter.WriteStartArray();
            for (int i = 0; i < span.Length; i++)
            {
                content.JsonWriter.WriteObjectValue(span[i], ModelSerializationExtensions.WireOptions);
            }
            content.JsonWriter.WriteEndArray();

            return content;
        }

        public static BinaryContent FromDictionary<TValue>(IDictionary<string, TValue> dictionary)
        where TValue : notnull
        {
            Utf8JsonBinaryContent content = new Utf8JsonBinaryContent();
            content.JsonWriter.WriteStartObject();
            foreach (var item in dictionary)
            {
                content.JsonWriter.WritePropertyName(item.Key);
                content.JsonWriter.WriteObjectValue(item.Value, ModelSerializationExtensions.WireOptions);
            }
            content.JsonWriter.WriteEndObject();

            return content;
        }

        public static BinaryContent FromDictionary(IDictionary<string, BinaryData> dictionary)
        {
            Utf8JsonBinaryContent content = new Utf8JsonBinaryContent();
            content.JsonWriter.WriteStartObject();
            foreach (var item in dictionary)
            {
                content.JsonWriter.WritePropertyName(item.Key);
                if (item.Value == null)
                {
                    content.JsonWriter.WriteNullValue();
                }
                else
                {
#if NET6_0_OR_GREATER
				content.JsonWriter.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(content.JsonWriter, document.RootElement);
                    }
#endif
                }
            }
            content.JsonWriter.WriteEndObject();

            return content;
        }

        public static BinaryContent FromObject(object value)
        {
            Utf8JsonBinaryContent content = new Utf8JsonBinaryContent();
            content.JsonWriter.WriteObjectValue<object>(value, ModelSerializationExtensions.WireOptions);
            return content;
        }

        public static BinaryContent FromObject(BinaryData value)
        {
            Utf8JsonBinaryContent content = new Utf8JsonBinaryContent();
#if NET6_0_OR_GREATER
				content.JsonWriter.WriteRawValue(value);
#else
            using (JsonDocument document = JsonDocument.Parse(value))
            {
                JsonSerializer.Serialize(content.JsonWriter, document.RootElement);
            }
#endif
            return content;
        }
    }
}
