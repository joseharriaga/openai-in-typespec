using OpenAI.Internal.Models;

namespace OpenAI.Files;

[CodeGenModel("DeleteFileResponse")]
public partial class DeleteFileResponse
{
    // CUSTOM: Made private. This property does not add value in the context of a strongly-typed class.
    /// <summary> Gets the object. </summary>
    private DeleteFileResponseObject Object { get; } = DeleteFileResponseObject.File;
}