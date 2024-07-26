using System.ComponentModel;

namespace OpenAI.VectorStores;

/// <summary>
/// Represents the available timestamps to which the duration in a <see cref="VectorStoreExpirationPolicy"/> will apply.
/// </summary>
[CodeGenModel("VectorStoreExpirationAfterAnchor")]
public enum VectorStoreExpirationAnchor
{
    /// <summary>
    /// An unknown anchor.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    Unknown,

    /// <summary>
    /// Specifies that the expiration policy should apply relative to the last timestamp at which the vector store was
    /// used.
    /// </summary>
    [CodeGenMember("LastActiveAt")]
    LastActiveAt
}
