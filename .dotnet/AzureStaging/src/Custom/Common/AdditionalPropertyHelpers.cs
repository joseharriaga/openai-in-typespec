// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.OpenAI.Internal;

internal static class AdditionalPropertyHelpers
{
    internal static bool TryGetAdditionalProperty<T>(IDictionary<string, BinaryData> additionalProperties, string key, out T value)
    {
        value = default;
        if (!additionalProperties.TryGetValue(key, out BinaryData binaryValue)) return false;
        value = (T)ModelReaderWriter.Read(binaryValue, typeof(T));
        return true;
    }

    internal static bool TryGetAdditionalProperty<T,U>(IDictionary<string, BinaryData> additionalProperties, string key, out T value)
        where T : IList<U>
    {
        value = default;
        if (!additionalProperties.TryGetValue(key, out BinaryData binaryValue)) return false;
        List<U> items = [];
        using JsonDocument document = JsonDocument.Parse(binaryValue);
        foreach (JsonElement element in document.RootElement.EnumerateArray())
        {
            items.Add((U)ModelReaderWriter.Read(BinaryData.FromObjectAsJson(element), typeof(U)));
        }
        value = (T)(IList<U>)items;
        return true;
    }

    internal static void SetAdditionalProperty<T>(IDictionary<string, BinaryData> additionalProperties, string key, T value)
    {
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            writer.WriteObjectValue(value);
        }
        stream.Position = 0;
        BinaryData binaryValue = BinaryData.FromStream(stream);
        additionalProperties[key] = binaryValue;
    }
}