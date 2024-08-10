// using System;
// using System.Collections.Generic;
// using System.ComponentModel;

namespace OpenAI.Assistants;

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using OpenAI;
using OpenAI.Internal;

[CodeGenModel("AssistantResponseFormat")]
public partial class AssistantResponseFormat : IEquatable<AssistantResponseFormat>
{
    private readonly string _plainTextValue;
    private readonly BinaryData _binaryValue;

    public static AssistantResponseFormat Auto { get; }
        = new("auto");
    public static AssistantResponseFormat Text { get; }
        = new(ModelReaderWriter.Write(new InternalResponseFormatText()));
    public static AssistantResponseFormat JsonObject { get; }
        = new(ModelReaderWriter.Write(new InternalResponseFormatJsonObject()));
    public static AssistantResponseFormat FromDefinition(AssistantResponseFormatDefinition formatDefinition)
        => new(ModelReaderWriter.Write(formatDefinition));

    [EditorBrowsable(EditorBrowsableState.Never)]
    bool IEquatable<AssistantResponseFormat>.Equals(AssistantResponseFormat other)
        => (this._plainTextValue is not null && other?._plainTextValue is not null && this._plainTextValue == other._plainTextValue)
        || (this._binaryValue is not null && other?._binaryValue is not null && this._binaryValue.ToString() == other._binaryValue.ToString());

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj)
        => obj is AssistantResponseFormat format && this.Equals(format);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode()
        => _plainTextValue?.GetHashCode() ?? _binaryValue.GetHashCode();

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator ==(AssistantResponseFormat first, AssistantResponseFormat second)
        => first?.Equals(second) == true;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator !=(AssistantResponseFormat first, AssistantResponseFormat second)
        => first?.Equals(second) != true;

    internal AssistantResponseFormat(BinaryData binaryValue)
    {
        _binaryValue = binaryValue;
    }

    internal AssistantResponseFormat(string plainTextValue)
    {
        _plainTextValue = plainTextValue;
    }

    public static implicit operator AssistantResponseFormat(BinaryData binaryData) => new(binaryData);
}