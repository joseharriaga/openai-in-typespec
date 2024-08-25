// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.AI.OpenAI;

/// <summary>
/// A representation of Azure OpenAI Service API versions, including known values.
/// </summary>
/// <remarks>
/// <para>
/// Using non-default service API versions may not function as intended, as capabilities and payload structures
/// may differ. Exercise caution when changing the service API version and consider using protocol method
/// variants (e.g. <see cref="ChatClient.CompleteChat(BinaryContent,RequestOptions)"/>) to maximize cross-version
/// compatibility.
/// </para>
/// <para>
/// This corresponds to the value of the <c>api-version</c> query string parameter in the REST API.
/// </para>
/// </remarks>
[CodeGenModel("AzureOpenAIServiceApiVersion")]
public readonly partial struct ServiceVersion : IEquatable<string>, IComparable<ServiceVersion>, IComparable<string>
{
    /// <summary>
    /// The default Azure OpenAI Service API version, which is the latest version that has been targeted and validated
    /// by this version of the library.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Using non-default service API versions may not function as intended, as capabilities and payload structures
    /// may differ. Exercise caution when changing the service API version and consider using protocol method
    /// variants (e.g. <see cref="ChatClient.CompleteChat(BinaryContent,RequestOptions)"/>) to maximize cross-version
    /// compatibility.
    /// </para>
    /// </remarks>
    public static ServiceVersion Default => V20240801Preview;

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj)
        => (obj is ServiceVersion other && Equals(other))
        || (obj is string rawOther && Equals(rawOther));

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Equals(string other) => string.Equals(_value, other, StringComparison.InvariantCultureIgnoreCase);

    /// <summary>
    /// Compares one <see cref="ServiceVersion"/> to another version label based on a string-initial date in the
    /// format of YYYY-MM-DD. If a date cannot be determined, it is treated as greater than all known values.
    /// </summary>
    /// <param name="other"> The version to compare. </param>
    /// <returns>
    /// <list type="bullet">
    /// <item>
    /// A value <c>&lt; 0</c> if this <see cref="ServiceVersion"/> evaluates to an earlier date than
    /// <paramref name="other"/>;
    /// </item>
    /// <item>
    /// A value <c>&gt; 0</c> if this <see cref="ServiceVersion"/> evaluates to a later date than
    /// <paramref name="other"/>;
    /// </item>
    /// <item>
    /// The value <c>0</c> if this <see cref="ServiceVersion"/> evaluates to the same date as <paramref name="other"/>
    /// or if both values cannot be evaluated for a date.
    /// </item>
    /// </list>
    /// </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int CompareTo(ServiceVersion other) => CompareTo(other._value);

    /// <inheritdoc cref="CompareTo(ServiceVersion)"/>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public int CompareTo(string other)
    {
        DateTimeOffset thisTime = TryGetDateFromVersionString(_value, out DateTimeOffset parsedValue)
            ? parsedValue : DateTimeOffset.MaxValue;
        DateTimeOffset otherTime = TryGetDateFromVersionString(other, out DateTimeOffset otherParsedValue)
            ? otherParsedValue : DateTimeOffset.MaxValue;
        return thisTime.CompareTo(otherTime);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static implicit operator string(ServiceVersion value) => value.ToString();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator >(ServiceVersion first, ServiceVersion second) => first.CompareTo(second) > 0;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator <(ServiceVersion first, ServiceVersion second) => first.CompareTo(second) < 0;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator >=(ServiceVersion first, ServiceVersion second) => first.CompareTo(second) >= 0;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator <=(ServiceVersion first, ServiceVersion second) => first.CompareTo(second) >= 0;

    private static bool TryGetDateFromVersionString(string input, out DateTimeOffset value)
    {
        value = default;
        if (input?.Length >= 10 != true)
        {
            return false;
        }

        return DateTimeOffset.TryParse(input.Substring(0, 10), out value);
    }
}