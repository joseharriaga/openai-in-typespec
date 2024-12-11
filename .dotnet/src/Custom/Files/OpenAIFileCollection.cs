using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenAI.Files;

[CodeGenModel("ListFilesResponse")]
[CodeGenSuppress("Data")]
[CodeGenSuppress(nameof(OpenAIFileCollection))]
[CodeGenSuppress(nameof(OpenAIFileCollection), typeof(string), typeof(IReadOnlyList<OpenAIFile>), typeof(string), typeof(string), typeof(bool))]
[CodeGenSuppress(nameof(OpenAIFileCollection), typeof(string), typeof(IEnumerable<OpenAIFile>), typeof(string), typeof(string), typeof(bool))]
public partial class OpenAIFileCollection : ReadOnlyCollection<OpenAIFile>
{
    // CUSTOM: Made private. This property does not add value in the context of a strongly-typed class.
    /// <summary> Gets the object. </summary>
    private string Object { get; } = "list";

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
    private IDictionary<string, BinaryData> SerializedAdditionalRawData;

    /// <summary> Initializes a new instance of <see cref="OpenAIFileCollection"/>. </summary>
    /// <param name="data"></param>
    /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
    internal OpenAIFileCollection(IEnumerable<OpenAIFile> data, string firstId, string lastId, bool hasMore)
        : base([.. data])
    {
        Argument.AssertNotNull(data, nameof(data));
        FirstId = firstId;
        LastId = lastId;
        HasMore = hasMore;
    }

    /// <summary> Initializes a new instance of <see cref="OpenAIFileCollection"/>. </summary>
    /// <param name="data"></param>
    /// <param name="object"></param>
    /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
    internal OpenAIFileCollection(IReadOnlyList<OpenAIFile> data, string @object, string firstId, string lastId, bool hasMore, IDictionary<string, BinaryData> serializedAdditionalRawData)
        : base([.. data])
    {
        Object = @object;
        SerializedAdditionalRawData = serializedAdditionalRawData;
        FirstId = firstId;
        LastId = lastId;
        HasMore = hasMore;
    }

    /// <summary> Initializes a new instance of <see cref="OpenAIFileCollection"/> for deserialization. </summary>
    internal OpenAIFileCollection()
        : base([])
    {
    }
}