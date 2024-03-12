

using OpenAI.Chat;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;

namespace Azure.AI.OpenAI.Chat;

public class AzureChatClient : ChatClient
{
    private string _deploymentName;
    private string _apiVersion;

    public AzureChatClient(string deploymentName) : base(deploymentName)
    {
        _deploymentName = deploymentName;
        _apiVersion = "2024-02-15-preview";
    }

    protected override Uri CreateChatRequestUri()
    {
        UriBuilder builder = new(GetEndpoint());
        builder.Path += $"/deployments/{_deploymentName}/chat/completions";
        builder.Query += $"?api-version={_apiVersion}";
        return builder.Uri;
    }

    public new ClientResult<AzureChatCompletion> CompleteChat(string message, AzureChatCompletionOptions options = null)
    {
        ClientResult<ChatCompletion> baseResult = base.CompleteChat(message, options);
        AzureChatCompletion azureChatCompletion = new(baseResult.Value);
        return ClientResult.FromValue(azureChatCompletion, baseResult.GetRawResponse());
    }

    protected override PipelineMessage CreateChatRequest(IEnumerable<ChatRequestMessage> messages, ChatCompletionOptions options = null, int? choiceCount = null, bool? stream = null)
    {
        PipelineMessage baseMessage = base.CreateChatRequest(messages, options, choiceCount, stream);

        return baseMessage;
    }

}