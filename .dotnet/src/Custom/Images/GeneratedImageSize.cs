namespace OpenAI.Images;

/// <summary>
/// Represents the available output dimensions for generated images.
/// </summary>
public partial class GeneratedImageSize
{
    /// <summary>
    /// Gets the desired width, in pixels, for an image.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Gets the desired height, in pixels, for an image.
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Creates a new instance of <see cref="GeneratedImageSize"/>.
    /// </summary>
    /// <remarks>
    /// <b>Note:</b> arbitrary dimensions are not supported and a given model will only support a set of predefined
    /// sizes. If supported dimensions are not known, try using one of the static properties like <see cref="W1024xH1024"/>.
    /// </remarks>
    /// <param name="width"> The desired width, in pixels, for an image. </param>
    /// <param name="height"> The desired height, in pixels, for an image. </param>
    public GeneratedImageSize(int width, int height)
    {
        Width = width;
        Height = height;
    }

    /// <summary>
    /// A small, square image with 256 pixels of both width and height.
    /// <para>
    /// Supported <b>only</b> for the older <c>dall-e-2</c> model.
    /// </para>
    /// </summary>
    public static readonly GeneratedImageSize W256xH256 = new(256, 256);

    /// <summary>
    /// A medium-small, square image with 512 pixels of both width and height.
    /// <para>
    /// Supported <b>only</b> for the older <c>dall-e-2</c> model.
    /// </para>
    /// </summary>
    public static readonly GeneratedImageSize W512xH512 = new(512, 512);

    /// <summary>
    /// A square image with 1024 pixels of both width and height.
    /// <para>
    /// <b>Supported</b> and <b>default</b> for both <c>dall-e-2</c> and <c>dall-e-3</c> models.
    /// </para>
    /// </summary>
    public static readonly GeneratedImageSize W1024xH1024 = new(1024, 1024);

    /// <summary>
    /// An extra tall image, 1024 pixels wide by 1792 pixels high.
    /// <para>
    /// Supported <b>only</b> for the <c>dall-e-3</c> model.
    /// </para>
    /// </summary>
    public static readonly GeneratedImageSize W1024xH1792 = new(1024, 1792);

    /// <summary>
    /// An extra wide image, 1792 pixels wide by 1024 pixels high.
    /// <para>
    /// Supported <b>only</b> for the <c>dall-e-3</c> model.
    /// </para>
    /// </summary>
    public static readonly GeneratedImageSize W1792xH1024 = new(1792, 1024);

    /// <inheritdoc/>
    public static bool operator ==(GeneratedImageSize left, GeneratedImageSize right)
        => ((left is null) == (right is null)) && (left is null || left.Equals(right));

    /// <inheritdoc/>
    public static bool operator !=(GeneratedImageSize left, GeneratedImageSize right)
        => ((left is null) != (right is null)) || (left is not null && !left.Equals(right));

    /// <inheritdoc/>
    public bool Equals(GeneratedImageSize other) => other?.Width == Width && other?.Height == Height;

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is GeneratedImageSize other && Equals(other);
}