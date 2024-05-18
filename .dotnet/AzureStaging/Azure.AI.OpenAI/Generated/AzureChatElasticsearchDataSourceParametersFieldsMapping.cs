// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using OpenAI;
using OpenAI.Chat;

namespace Azure.AI.OpenAI
{
    /// <summary> The AzureChatElasticsearchDataSourceParametersFieldsMapping. </summary>
    public partial class AzureChatElasticsearchDataSourceParametersFieldsMapping
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

        /// <summary> Initializes a new instance of <see cref="AzureChatElasticsearchDataSourceParametersFieldsMapping"/>. </summary>
        internal AzureChatElasticsearchDataSourceParametersFieldsMapping()
        {
            ContentFields = new ChangeTrackingList<string>();
            VectorFields = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="AzureChatElasticsearchDataSourceParametersFieldsMapping"/>. </summary>
        /// <param name="titleField"></param>
        /// <param name="urlField"></param>
        /// <param name="filepathField"></param>
        /// <param name="contentFields"></param>
        /// <param name="contentFieldsSeparator"></param>
        /// <param name="vectorFields"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal AzureChatElasticsearchDataSourceParametersFieldsMapping(string titleField, string urlField, string filepathField, IReadOnlyList<string> contentFields, string contentFieldsSeparator, IReadOnlyList<string> vectorFields, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TitleField = titleField;
            UrlField = urlField;
            FilepathField = filepathField;
            ContentFields = contentFields;
            ContentFieldsSeparator = contentFieldsSeparator;
            VectorFields = vectorFields;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Gets the title field. </summary>
        public string TitleField { get; }
        /// <summary> Gets the url field. </summary>
        public string UrlField { get; }
        /// <summary> Gets the filepath field. </summary>
        public string FilepathField { get; }
        /// <summary> Gets the content fields. </summary>
        public IReadOnlyList<string> ContentFields { get; }
        /// <summary> Gets the content fields separator. </summary>
        public string ContentFieldsSeparator { get; }
        /// <summary> Gets the vector fields. </summary>
        public IReadOnlyList<string> VectorFields { get; }
    }
}
