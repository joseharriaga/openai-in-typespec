using System;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace OpenAI;

internal static class CustomSerialization
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DeserializeTimeSpan(JsonProperty property, ref TimeSpan timespan)
    {
        timespan = property.Value.ValueKind switch
        {
            JsonValueKind.Number => TimeSpan.FromSeconds(property.Value.GetDouble()),
            _ => throw new ArgumentException(
                $"Unsupported 'TimeSpan' deserialization for JSON value kind: {property.Value.ValueKind}"),
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void DeserializeNullableTimeSpan(JsonProperty property, ref TimeSpan? nullableTimespan)
    {
        nullableTimespan = property.Value.ValueKind switch
        {
            JsonValueKind.Null => null,
            JsonValueKind.Number => TimeSpan.FromSeconds(property.Value.GetDouble()),
            _ => throw new ArgumentException(
                $"Unsupported 'TimeSpan?' deserialization for JSON value kind: {property.Value.ValueKind}"),
        };
    }
}