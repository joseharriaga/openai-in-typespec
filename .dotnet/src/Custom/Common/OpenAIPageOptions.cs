using System.Diagnostics.CodeAnalysis;

namespace OpenAI;

/// <summary> The options to configure how paginated objects are retrieved and processed. </summary>
[Experimental("OPENAI001")]
[CodeGenModel("CommonPageQueryParameters")]
public class OpenAIPageOptions
{
    /// <summary> Initializes a new instance of <see cref="OpenAIPageOptions"/>. </summary>
    public OpenAIPageOptions() { }

    /// <summary> 
    ///     A limit on the number of objects to be returned per page.
    /// </summary>
    public int? PageSizeLimit { get; set; }

    /// <summary>
    ///     The order in which to retrieve objects when sorted by their
    ///     created timestamps.
    /// </summary>
    public OpenAIPageOrder? Order { get; set; }

    /// <summary>
    ///     The object ID used to retrieve the page of objects that come
    ///     after this one.
    /// </summary>
    public string AfterId { get; set; }

    /// <summary>
    ///     The object ID used to retrieve the page of objects that come
    ///     before this one.
    /// </summary>
    public string BeforeId { get; set; }
}