using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace OpenAI.FineTuning;

[CodeGenModel("CreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum")]
internal readonly partial struct InternalCreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum { }

[CodeGenModel("CreateFineTuningJobRequestHyperparametersLearningRateMultiplierOption")]
public partial class HyperparameterLearningRate : IEquatable<double>, IEquatable<int>, IEquatable<string>, IJsonModel<HyperparameterLearningRate>
{
    private readonly string _stringValue;
    private readonly double? _doubleValue;

    internal HyperparameterLearningRate(string predefinedLabel) => _stringValue = predefinedLabel;

    public HyperparameterLearningRate(double learningRateMultiplier) => _doubleValue = learningRateMultiplier;

    public static HyperparameterLearningRate CreateAuto() => new(InternalCreateFineTuningJobRequestHyperparametersLearningRateMultiplierChoiceEnum.Auto.ToString());
    public static HyperparameterLearningRate CreateMultiplier(double learningRateMultiplier) => new(learningRateMultiplier);

    public static implicit operator HyperparameterLearningRate(double learningRateMultiplier) => new(learningRateMultiplier);
    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator ==(HyperparameterLearningRate first, HyperparameterLearningRate second)
    {
        if (first is null && second is null) return true;
        if (first is null || second is null) return false;
        if (first._doubleValue.HasValue != second._doubleValue.HasValue) return false;
        if (first._doubleValue.HasValue) return first._doubleValue == second._doubleValue;
        return first._stringValue == second._stringValue;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator !=(HyperparameterLearningRate first, HyperparameterLearningRate second) => !(first == second);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Equals(double other) => _doubleValue == other;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Equals(int other) => _doubleValue == other;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool Equals(string other) => _doubleValue is null && _stringValue == other;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object other) => other is HyperparameterLearningRate cc && cc == this;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => _doubleValue?.GetHashCode() ?? _stringValue.GetHashCode();

    void IJsonModel<HyperparameterLearningRate>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        SerializeHyperparameterLearningRate(this, writer, options);
    }

    HyperparameterLearningRate IJsonModel<HyperparameterLearningRate>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeHyperparameterLearningRate(document.RootElement, options);
    }

    internal static void SerializeHyperparameterLearningRate(HyperparameterLearningRate instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        if (instance._doubleValue is not null)
        {
            writer.WriteNumberValue(instance._doubleValue.Value);
        }
        else
        {
            writer.WriteStringValue(instance._stringValue);
        }
    }

    BinaryData IPersistableModel<HyperparameterLearningRate>.Write(ModelReaderWriterOptions options)
        => CustomSerializationHelpers.SerializeInstance(this, options);

    HyperparameterLearningRate IPersistableModel<HyperparameterLearningRate>.Create(BinaryData data, ModelReaderWriterOptions options)
        => CustomSerializationHelpers.DeserializeNewInstance(this, DeserializeHyperparameterLearningRate, data, options);

    internal static HyperparameterLearningRate DeserializeHyperparameterLearningRate(JsonElement element, ModelReaderWriterOptions options = null)
    {
        options ??= ModelSerializationExtensions.WireOptions;

        return element.ValueKind switch
        {
            JsonValueKind.Number => new(element.GetDouble()),
            JsonValueKind.String => new(element.GetString()),
            _ => throw new ArgumentException($"Unsupported JsonValueKind", nameof(HyperparameterLearningRate))
        };
    }

    string IPersistableModel<HyperparameterLearningRate>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
}