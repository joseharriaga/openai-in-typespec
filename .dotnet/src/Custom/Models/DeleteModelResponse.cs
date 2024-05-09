namespace OpenAI.Models;

[CodeGenModel("DeleteModelResponse")]
public partial class DeleteModelResponse
{
    // CUSTOM: Made private. This property does not add value in the context of a strongly-typed class.
    /// <summary> Gets the object. </summary>
    private DeleteModelResponseObject Object { get; } = DeleteModelResponseObject.Model;
}