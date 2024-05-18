using System.ClientModel.Primitives;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Azure.AI.OpenAI.Internal;

internal static class RawDataExtensions
{
    private static FieldInfo GetSardField(this object o)
    {
        BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        FieldInfo sardInfo = o.GetType().GetField("_serializedAdditionalRawData", flags);
        return sardInfo
            ?? throw new InvalidOperationException(
                $"Object of type '{o.GetType()}' does not support retrieval of the _serializedAdditionalRawData field.");
    }

    private static bool TryGetSard(this object o, out IDictionary<string, BinaryData> serializedAdditionalRawData)
    {
        serializedAdditionalRawData = null;
        FieldInfo sardInfo = o.GetSardField();
        if (sardInfo is null) return false;
        serializedAdditionalRawData = (IDictionary<string, BinaryData>)sardInfo.GetValue(o);
        return serializedAdditionalRawData is not null;
    }

    private static void SetSard(this object o, object value)
    {
        FieldInfo sardField = o.GetSardField();
        sardField.SetValue(o, value);
    }

    internal static bool TryGetSardValue<T>(this object o, string key, out T value)
    {
        value = default(T);
        if (!o.TryGetSard(out IDictionary<string, BinaryData> sard)) return false;
        if (!sard.TryGetValue(key, out BinaryData binaryValue)) return false;
        value = (T)ModelReaderWriter.Read(binaryValue, typeof(T));
        return true;
    }

    internal static bool TryGetSardValue<T,U>(this object o, string key, out T value)
        where T : IList<U>
    {
        value = default(T);
        if (!o.TryGetSard(out IDictionary<string, BinaryData> sard)) return false;
        if (!sard.TryGetValue(key, out BinaryData binaryValue)) return false;
        List<U> items = [];
        using JsonDocument document = JsonDocument.Parse(binaryValue);
        foreach (JsonElement element in document.RootElement.EnumerateArray())
        {
            items.Add((U)ModelReaderWriter.Read(BinaryData.FromObjectAsJson(element.GetRawText()), typeof(U)));
        }
        value = (T)(IList<U>)items;
        return true;
    }

    internal static void SetSardValue<T>(this object o, string key, T value)
    {
        if (!o.TryGetSard(out IDictionary<string, BinaryData> sard))
        {
            sard = new Dictionary<string, BinaryData>();
        }
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            writer.WriteObjectValue(value);
        }
        stream.Position = 0;
        BinaryData binaryValue = BinaryData.FromStream(stream);
        sard[key] = binaryValue;
        o.SetSard(sard);
    }

    internal static void SetSardValue<T,U>(this object o, string key, T value)
        where T : IList<U>
    {
        if (!o.TryGetSard(out IDictionary<string, BinaryData> sard))
        {
            sard = new Dictionary<string, BinaryData>();
        }
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            writer.WriteObjectValue(value);
        }
        stream.Position = 0;
        BinaryData binaryValue = BinaryData.FromStream(stream);
        sard[key] = binaryValue;
    }
}