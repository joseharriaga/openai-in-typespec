using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace OpenAI.Moderations
{
    [CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<OpenAI.Moderations.ModerationResult>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
    public partial class ModerationResult : IJsonModel<ModerationResult>
    {
        // CUSTOM:
        // - Serializes `ModerationCategories` and `ModerationCategoryScores` properties.
        void IJsonModel<ModerationResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ModerationResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ModerationResult)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("flagged") != true)
            {
                writer.WritePropertyName("flagged"u8);
                writer.WriteBooleanValue(Flagged);
            }
            if (SerializedAdditionalRawData?.ContainsKey("categories") != true)
            {
                writer.WritePropertyName("categories"u8);
                InternalModerationCategories internalCategories = new(
                    hate: Hate.Flagged,
                    hateThreatening: HateThreatening.Flagged,
                    harassment: Harassment.Flagged,
                    harassmentThreatening: HarassmentThreatening.Flagged,
                    illicit: Illicit.Flagged,
                    illicitViolent: IllicitViolent.Flagged,
                    selfHarm: SelfHarm.Flagged,
                    selfHarmIntent: SelfHarmIntent.Flagged,
                    selfHarmInstructions: SelfHarmInstructions.Flagged,
                    sexual: Sexual.Flagged,
                    sexualMinors: SexualMinors.Flagged,
                    violence: Violence.Flagged,
                    violenceGraphic: ViolenceGraphic.Flagged,
                    serializedAdditionalRawData: null);
                writer.WriteObjectValue(internalCategories, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("category_scores") != true)
            {
                writer.WritePropertyName("category_scores"u8);
                InternalModerationCategoryScores internalCategoryScores = new(
                    hate: Hate.Score,
                    hateThreatening: HateThreatening.Score,
                    harassment: Harassment.Score,
                    harassmentThreatening: HarassmentThreatening.Score,
                    illicit: Illicit.Score,
                    illicitViolent: IllicitViolent.Score,
                    selfHarm: SelfHarm.Score,
                    selfHarmIntent: SelfHarmIntent.Score,
                    selfHarmInstructions: SelfHarmInstructions.Score,
                    sexual: Sexual.Score,
                    sexualMinors: SexualMinors.Score,
                    violence: Violence.Score,
                    violenceGraphic: ViolenceGraphic.Score,
                    serializedAdditionalRawData: null);
                writer.WriteObjectValue(internalCategoryScores, options);
            }
            if (SerializedAdditionalRawData?.ContainsKey("category_applied_input_types") != true)
            {
                writer.WritePropertyName("category_applied_input_types"u8);
                InternalCreateModerationResponseResultCategoryAppliedInputTypes internalAppliedInputTypes = new(
                    hate: Hate.InputKinds.ToInternalInputKinds(),
                    hateThreatening: HateThreatening.InputKinds.ToInternalInputKinds(),
                    harassment: Harassment.InputKinds.ToInternalInputKinds(),
                    harassmentThreatening: HarassmentThreatening.InputKinds.ToInternalInputKinds(),
                    illicit: Illicit.InputKinds.ToInternalInputKinds(),
                    illicitViolent: IllicitViolent.InputKinds.ToInternalInputKinds(),
                    selfHarm: SelfHarm.InputKinds.ToInternalInputKinds().Select(kind => new InternalCreateModerationResponseResultCategoryAppliedInputTypesSelfHarm1(kind)).ToList(),
                    selfHarmIntent: SelfHarmIntent.InputKinds.ToInternalInputKinds().Select(kind => new InternalCreateModerationResponseResultCategoryAppliedInputTypesSelfHarmIntent(kind)).ToList(),
                    selfHarmInstructions: SelfHarmInstructions.InputKinds.ToInternalInputKinds().Select(kind => new InternalCreateModerationResponseResultCategoryAppliedInputTypesSelfHarmInstruction(kind)).ToList(),
                    sexual: Sexual.InputKinds.ToInternalInputKinds().Select(kind => new InternalCreateModerationResponseResultCategoryAppliedInputTypesSexual(kind)).ToList(),
                    sexualMinors: SexualMinors.InputKinds.ToInternalInputKinds(),
                    violence: Violence.InputKinds.ToInternalInputKinds().Select(kind => new InternalCreateModerationResponseResultCategoryAppliedInputTypesViolence(kind)).ToList(),
                    violenceGraphic: ViolenceGraphic.InputKinds.ToInternalInputKinds().Select(kind => new InternalCreateModerationResponseResultCategoryAppliedInputTypesViolenceGraphic(kind)).ToList(),
                    serializedAdditionalRawData: null);
                writer.WriteObjectValue(internalAppliedInputTypes, options);
            }
            if (SerializedAdditionalRawData != null)
            {
                foreach (var item in SerializedAdditionalRawData)
                {
                    if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                    {
                        continue;
                    }
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static ModerationResult DeserializeModerationResult(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            bool flagged = default;

            InternalModerationCategories internalCategories = default;
            InternalModerationCategoryScores internalCategoryScores = default;
            InternalCreateModerationResponseResultCategoryAppliedInputTypes internalAppliedInputTypes = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("flagged"u8))
                {
                    flagged = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("categories"u8))
                {
                    internalCategories = InternalModerationCategories.DeserializeInternalModerationCategories(property.Value, options);
                    continue;
                }
                if (property.NameEquals("category_scores"u8))
                {
                    internalCategoryScores = InternalModerationCategoryScores.DeserializeInternalModerationCategoryScores(property.Value, options);
                    continue;
                }
                if (property.NameEquals("category_applied_input_types"u8))
                {
                    internalAppliedInputTypes = InternalCreateModerationResponseResultCategoryAppliedInputTypes.DeserializeInternalCreateModerationResponseResultCategoryAppliedInputTypes(property.Value, options);
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new ModerationResult(
               flagged: flagged,
               hate: new ModerationCategory(internalCategories.Hate, internalCategoryScores.Hate, internalAppliedInputTypes?.Hate),
               hateThreatening: new ModerationCategory(internalCategories.HateThreatening, internalCategoryScores.HateThreatening, internalAppliedInputTypes?.HateThreatening),
               harassment: new ModerationCategory(internalCategories.Harassment, internalCategoryScores.Harassment, internalAppliedInputTypes?.Harassment),
               harassmentThreatening: new ModerationCategory(internalCategories.HarassmentThreatening, internalCategoryScores.HarassmentThreatening, internalAppliedInputTypes?.HarassmentThreatening),
               illicit: new ModerationCategory(internalCategories.Illicit, internalCategoryScores.Illicit, internalAppliedInputTypes?.Illicit),
               illicitViolent: new ModerationCategory(internalCategories.IllicitViolent, internalCategoryScores.IllicitViolent, internalAppliedInputTypes?.IllicitViolent),
               selfHarm: new ModerationCategory(internalCategories.SelfHarm, internalCategoryScores.SelfHarm, internalAppliedInputTypes?.SelfHarm?.Select(item => item.ToString())),
               selfHarmIntent: new ModerationCategory(internalCategories.SelfHarmIntent, internalCategoryScores.SelfHarmIntent, internalAppliedInputTypes?.SelfHarmIntent?.Select(item => item.ToString())),
               selfHarmInstructions: new ModerationCategory(internalCategories.SelfHarmInstructions, internalCategoryScores.SelfHarmInstructions, internalAppliedInputTypes?.SelfHarmInstructions?.Select(item => item.ToString())),
               sexual: new ModerationCategory(internalCategories.Sexual, internalCategoryScores.Sexual, internalAppliedInputTypes?.Sexual?.Select(item => item.ToString())),
               sexualMinors: new ModerationCategory(internalCategories.SexualMinors, internalCategoryScores.SexualMinors, internalAppliedInputTypes?.SexualMinors),
               violence: new ModerationCategory(internalCategories.Violence, internalCategoryScores.Violence, internalAppliedInputTypes?.Violence?.Select(item => item.ToString())),
               violenceGraphic: new ModerationCategory(internalCategories.ViolenceGraphic, internalCategoryScores.ViolenceGraphic, internalAppliedInputTypes?.ViolenceGraphic?.Select(item => item.ToString())),
               serializedAdditionalRawData: serializedAdditionalRawData);
        }
    }
}
