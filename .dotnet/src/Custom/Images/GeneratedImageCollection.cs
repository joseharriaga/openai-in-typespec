using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Images;

/// <summary>
/// Represents an image generation response payload that contains information for multiple generated images.
/// </summary>
[CodeGenModel("ImagesResponse")]
[CodeGenSuppress("Data")]
[CodeGenSuppress(nameof(GeneratedImageCollection))]
[CodeGenSuppress(nameof(GeneratedImageCollection), typeof(DateTimeOffset), typeof(IReadOnlyList<GeneratedImage>))]
public partial class GeneratedImageCollection : ReadOnlyCollection<GeneratedImage>
{
    // CUSTOM: Recovered this field. See https://github.com/Azure/autorest.csharp/issues/4636.
    /// <summary>
    /// Keeps track of any properties unknown to the library.
    /// <para>
    /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
    /// </para>
    /// <para>
    /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
    /// </para>
    /// <para>
    /// Examples:
    /// <list type="bullet">
    /// <item>
    /// <term>BinaryData.FromObjectAsJson("foo")</term>
    /// <description>Creates a payload of "foo".</description>
    /// </item>
    /// <item>
    /// <term>BinaryData.FromString("\"foo\"")</term>
    /// <description>Creates a payload of "foo".</description>
    /// </item>
    /// <item>
    /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
    /// <description>Creates a payload of { "key": "value" }.</description>
    /// </item>
    /// <item>
    /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
    /// <description>Creates a payload of { "key": "value" }.</description>
    /// </item>
    /// </list>
    /// </para>
    /// </summary>
    private IDictionary<string, BinaryData> _serializedAdditionalRawData;

    /// <summary>
    /// Gets the dictionary containing additional raw data to serialize.
    /// </summary>
    /// <remarks>
    /// NOTE: This mechanism added for subclients pending availability of a C# language feature.
    ///       It is subject to change and not intended for stable use.
    /// </remarks>
    [Experimental("OPENAI002")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IDictionary<string, BinaryData> SerializedAdditionalRawData
        => _serializedAdditionalRawData ??= new ChangeTrackingDictionary<string, BinaryData>();

    // CUSTOM: Set the inherited Items property via the base constructor in favor of the suppressed Data property.
    /// <summary> Initializes a new instance of <see cref="GeneratedImageCollection"/>. </summary>
    /// <param name="created"></param>
    /// <param name="data"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
    internal GeneratedImageCollection(DateTimeOffset created, IEnumerable<GeneratedImage> data)
        : base([.. data])
    {
        Argument.AssertNotNull(data, nameof(data));

        CreatedAt = created;
    }

    // CUSTOM: Set the inherited Items property via the base constructor in favor of the suppressed Data property.
    /// <summary> Initializes a new instance of <see cref="GeneratedImageCollection"/>. </summary>
    /// <param name="created"></param>
    /// <param name="data"></param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    internal GeneratedImageCollection(DateTimeOffset created, IReadOnlyList<GeneratedImage> data, IDictionary<string, BinaryData> serializedAdditionalRawData)
        : base([.. data])
    {
        CreatedAt = created;
        _serializedAdditionalRawData = serializedAdditionalRawData;
    }

    // CUSTOM: Set the inherited Items property via the base constructor in favor of the suppressed Data property.
    /// <summary> Initializes a new instance of <see cref="GeneratedImageCollection"/> for deserialization. </summary>
    internal GeneratedImageCollection()
        : base([])
    {
    }

    // CUSTOM: Renamed.
    /// <summary>
    /// The timestamp at which the result image was generated.
    /// </summary>
    [CodeGenMember("Created")]
    public DateTimeOffset CreatedAt { get; }
}