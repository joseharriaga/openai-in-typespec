using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Chat;

/// <summary>
/// Request-level options for chat completion.
/// </summary>
public partial class ChatCompletionOptions : IJsonModel<ChatCompletionOptions>
{
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.FrequencyPenalty" />
    public float? FrequencyPenalty { get; init; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.LogitBias" />
    public IDictionary<int, int> TokenSelectionBiases { get; init; } = new ChangeTrackingDictionary<int, int>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Logprobs" />
    public bool? IncludeLogProbabilities { get; init; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.TopLogprobs" />
    public int? LogProbabilityCount { get; init; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.MaxTokens" />
    public int? MaxTokens { get; init; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.PresencePenalty" />
    public float? PresencePenalty { get; init; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.ResponseFormat" />
    public ChatResponseFormat? ResponseFormat { get; init; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Seed" />
    public int? Seed { get; init; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Stop" />
    public IList<string> StopSequences { get; } = new ChangeTrackingList<string>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Temperature" />
    public float? Temperature { get; init; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.TopP" />
    public float? NucleusSamplingFactor { get; init; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Tools" />
    public IList<ChatToolDefinition> Tools { get; } = new ChangeTrackingList<ChatToolDefinition>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.ToolChoice" />
    public ChatToolConstraint? ToolConstraint { get; init; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.User" />
    public string User { get; init; }
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.Functions" />
    public IList<ChatFunctionDefinition> Functions { get; } = new ChangeTrackingList<ChatFunctionDefinition>();
    /// <inheritdoc cref="Internal.Models.CreateChatCompletionRequest.FunctionCall" />
    public ChatFunctionConstraint? FunctionConstraint { get; init; }

    internal BinaryData GetInternalStopSequences()
    {
        if (!Optional.IsCollectionDefined(StopSequences))
        {
            return null;
        }
        return BinaryData.FromObjectAsJson(StopSequences);
    }

    internal IDictionary<string, int> GetInternalLogitBias()
    {
        ChangeTrackingDictionary<string, int> packedLogitBias = [];
        foreach (KeyValuePair<int, int> pair in TokenSelectionBiases)
        {
            packedLogitBias[$"{pair.Key}"] = pair.Value;
        }
        return packedLogitBias;
    }

    internal IList<Internal.Models.ChatCompletionTool> GetInternalTools()
    {
        ChangeTrackingList<Internal.Models.ChatCompletionTool> internalTools = [];
        foreach (ChatToolDefinition tool in Tools)
        {
            if (tool is ChatFunctionToolDefinition functionTool)
            {
                Internal.Models.FunctionObject functionObject = new(
                    functionTool.Description,
                    functionTool.FunctionName,
                    CreateInternalFunctionParameters(functionTool.Parameters),
                    serializedAdditionalRawData: null);
                internalTools.Add(new(functionObject));
            }
        }
        return internalTools;
    }

    internal IList<Internal.Models.ChatCompletionFunctions> GetInternalFunctions()
    {
        ChangeTrackingList<Internal.Models.ChatCompletionFunctions> internalFunctions = new();
        foreach (ChatFunctionDefinition function in Functions)
        {
            Internal.Models.ChatCompletionFunctions internalFunction = new(
                function.Description,
                function.FunctionName,
                CreateInternalFunctionParameters(function.Parameters),
                serializedAdditionalRawData: null);
            internalFunctions.Add(internalFunction);
        }
        return internalFunctions;
    }

    internal static Internal.Models.FunctionParameters CreateInternalFunctionParameters(BinaryData parameters)
    {
        Internal.Models.FunctionParameters internalParameters = new();
        if (parameters == null)
        {
            return internalParameters;
        }
        JsonElement parametersElement = JsonDocument.Parse(parameters.ToString()).RootElement;
        foreach (JsonProperty property in parametersElement.EnumerateObject())
        {
            BinaryData propertyData = BinaryData.FromString(property.Value.GetRawText());
            internalParameters.AdditionalProperties[property.Name] = propertyData;
        }
        return internalParameters;
    }

    void IJsonModel<ChatCompletionOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    ChatCompletionOptions IJsonModel<ChatCompletionOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        // TODO: Use partial writing 'W*'

        throw new NotImplementedException();
    }

    BinaryData IPersistableModel<ChatCompletionOptions>.Write(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    ChatCompletionOptions IPersistableModel<ChatCompletionOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }

    string IPersistableModel<ChatCompletionOptions>.GetFormatFromOptions(ModelReaderWriterOptions options)
    {
        throw new NotImplementedException();
    }
}