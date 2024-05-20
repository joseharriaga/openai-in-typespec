using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace OpenAI.Models;

/// <summary>
/// Represents a collection of entries for available models.
/// </summary>
[CodeGenModel("ListModelsResponse")]
[CodeGenSuppress("Data")]
[CodeGenSuppress(nameof(OpenAIModelInfoCollection))]
[CodeGenSuppress(nameof(OpenAIModelInfoCollection), typeof(ListModelsResponseObject), typeof(IReadOnlyList<OpenAIModelInfo>))]
public partial class OpenAIModelInfoCollection : ReadOnlyCollection<OpenAIModelInfo>
{
    // CUSTOM: Made private. This property does not add value in the context of a strongly-typed class.
    /// <summary> Gets the object. </summary>
    private ListModelsResponseObject Object { get; } = ListModelsResponseObject.List;

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

    /// <summary> Initializes a new instance of <see cref="OpenAIModelInfoCollection"/>. </summary>
    /// <param name="data"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
    internal OpenAIModelInfoCollection(IEnumerable<OpenAIModelInfo> data)
        : base([.. data])
    {
        Argument.AssertNotNull(data, nameof(data));
    }

    /// <summary> Initializes a new instance of <see cref="OpenAIModelInfoCollection"/>. </summary>
    /// <param name="object"></param>
    /// <param name="data"></param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    internal OpenAIModelInfoCollection(ListModelsResponseObject @object, IReadOnlyList<OpenAIModelInfo> data, IDictionary<string, BinaryData> serializedAdditionalRawData)
        : base([.. data])
    {
        Object = @object;
        _serializedAdditionalRawData = serializedAdditionalRawData;
    }

    /// <summary> Initializes a new instance of <see cref="OpenAIModelInfoCollection"/> for deserialization. </summary>
    internal OpenAIModelInfoCollection()
        : base([])
    {
    }
}
