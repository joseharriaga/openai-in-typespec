// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Images;
using OpenAI.VectorStores;
using System.ClientModel;

namespace Azure.AI.OpenAI.Tests;

internal class TestConfig
{
    private readonly dynamic _dynamicConfig;

    public TestConfig()
    {
        string configPath = Path.Combine(AssetFolderName, AssetFilename);
        if (File.Exists(configPath))
        {
            using Stream configStream = File.OpenRead(configPath);
            BinaryData configData = BinaryData.FromStream(configStream);
            _dynamicConfig = configData.ToDynamicFromJson();
        }
    }

    public Uri GetEndpointFor<TClient>()
    {
        dynamic configNode = GetConfigNode<TClient>();
        string endpointFromVariable = configNode?.endpoint_name is not null
            ? Environment.GetEnvironmentVariable(configNode.endpoint_name) : null;
        string rawEndpoint = configNode?.endpoint
            ?? endpointFromVariable
            ?? throw new KeyNotFoundException($"{typeof(TClient)}: endpoint");

        return new Uri(rawEndpoint);
    }

    public ApiKeyCredential GetApiKeyFromEnvironmentFor<TClient>()
    {
        string environmentVariableName = GetConfigNode<TClient>()?.api_key_name
            ?? throw new KeyNotFoundException($"{typeof(TClient)}: api_key_name");
        string rawKeyFromEnvironment = Environment.GetEnvironmentVariable(environmentVariableName)
            ?? throw new KeyNotFoundException(environmentVariableName);
        return new(rawKeyFromEnvironment);
    }

    public string GetDeploymentNameFor<TClient>()
        => GetConfigNode<TClient>()?.deployment
            ?? throw new NotImplementedException();

    private dynamic GetConfigNode<TClient>()
    {
        switch (typeof(TClient).Name)
        {
#pragma warning disable OPENAI001
            case nameof(AssistantClient): return _dynamicConfig?.assistants;
#pragma warning restore
            case nameof(AudioClient): return _dynamicConfig?.audio;
            case nameof(BatchClient): return _dynamicConfig?.batch;
            case nameof(ChatClient): return _dynamicConfig?.chat;
            case nameof(EmbeddingClient): return _dynamicConfig?.embeddings;
            case nameof(FileClient): return _dynamicConfig?.files;
            case nameof(FineTuningClient): return _dynamicConfig?.fine_tuning;
            case nameof(ImageClient): return _dynamicConfig?.images;
#pragma warning disable OPENAI001
            case nameof(VectorStoreClient): return _dynamicConfig?.vector_stores;
#pragma warning restore
            default: throw new NotImplementedException(typeof(TClient).Name);
        }
    }

    private const string AssetFolderName = "Assets";
    private const string AssetFilename = "test_config.json";
}