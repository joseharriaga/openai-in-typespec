using System;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Text.Json;

#nullable enable

namespace OpenAI;

internal class PageToken : IJsonModel<PageToken>
{
    public PageToken() { }

    public PageToken(string? after, string? before, bool? hasMore)
    {
        After = after;
        Before = before;
        HasMore = hasMore;
    }

    public string? After { get; }
    public string? Before { get; }
    public bool? HasMore { get; }

    public PageToken Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => DeserializePageToken(ref reader);

    public PageToken Create(BinaryData data, ModelReaderWriterOptions options)
    {
        Utf8JsonReader reader = new(data);
        return DeserializePageToken(ref reader);
    }

    internal static PageToken DeserializePageToken(ref Utf8JsonReader reader)
    {
        string? after = null;
        string? before = null;
        bool? hasMore = null;

        // Read start object
        reader.Read();

        Debug.Assert(reader.TokenType == JsonTokenType.StartObject);

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            Debug.Assert(reader.TokenType == JsonTokenType.PropertyName);

            string name = reader.GetString()!;

            switch (name)
            {
                case "after":
                    reader.Read();

                    Debug.Assert(reader.TokenType == JsonTokenType.String);

                    after = reader.GetString()!;
                    break;
                case "before":
                    reader.Read();

                    Debug.Assert(reader.TokenType == JsonTokenType.String);

                    before = reader.GetString()!;
                    break;

                case "has_more":
                    reader.Read();

                    Debug.Assert(
                        reader.TokenType == JsonTokenType.True ||
                        reader.TokenType == JsonTokenType.False);

                    hasMore = reader.GetBoolean();
                    break;

                default:
                    break;
            }
        }

        return new PageToken(after, before, hasMore);
    }

    public string GetFormatFromOptions(ModelReaderWriterOptions options)
        => "J";

    public void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();

        if (After is not null)
        {
            writer.WritePropertyName("after");
            writer.WriteStringValue(After);
        }

        if (Before is not null)
        {
            writer.WritePropertyName("before");
            writer.WriteStringValue(Before);
        }

        if (HasMore is not null)
        {
            writer.WritePropertyName("has_more");
            writer.WriteBooleanValue(HasMore.Value);
        }

        writer.WriteEndObject();
    }

    public BinaryData Write(ModelReaderWriterOptions options)
        => ModelReaderWriter.Write(this, ModelReaderWriterOptions.Json);
}
