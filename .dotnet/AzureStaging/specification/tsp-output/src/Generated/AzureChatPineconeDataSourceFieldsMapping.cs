// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.OpenAI
{
    /// <summary> The AzureChatPineconeDataSourceFieldsMapping. </summary>
    public partial class AzureChatPineconeDataSourceFieldsMapping
    {
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

        /// <summary> Initializes a new instance of <see cref="AzureChatPineconeDataSourceFieldsMapping"/>. </summary>
        /// <param name="contentFields"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="contentFields"/> is null. </exception>
        internal AzureChatPineconeDataSourceFieldsMapping(IEnumerable<string> contentFields)
        {
            Argument.AssertNotNull(contentFields, nameof(contentFields));

            ContentFields = contentFields.ToList();
        }

        /// <summary> Initializes a new instance of <see cref="AzureChatPineconeDataSourceFieldsMapping"/>. </summary>
        /// <param name="contentFields"></param>
        /// <param name="titleField"></param>
        /// <param name="urlField"></param>
        /// <param name="filepathField"></param>
        /// <param name="contentFieldsSeparator"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AzureChatPineconeDataSourceFieldsMapping(IReadOnlyList<string> contentFields, string titleField, string urlField, string filepathField, string contentFieldsSeparator, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ContentFields = contentFields;
            TitleField = titleField;
            UrlField = urlField;
            FilepathField = filepathField;
            ContentFieldsSeparator = contentFieldsSeparator;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="AzureChatPineconeDataSourceFieldsMapping"/> for deserialization. </summary>
        internal AzureChatPineconeDataSourceFieldsMapping()
        {
        }

        /// <summary> Gets the content fields. </summary>
        public IReadOnlyList<string> ContentFields { get; }
        /// <summary> Gets the title field. </summary>
        public string TitleField { get; }
        /// <summary> Gets the url field. </summary>
        public string UrlField { get; }
        /// <summary> Gets the filepath field. </summary>
        public string FilepathField { get; }
        /// <summary> Gets the content fields separator. </summary>
        public string ContentFieldsSeparator { get; }
    }
}
