// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !AZURE_OPENAI_GA

using Azure.Core;
using System.ClientModel;
using System.Web;

namespace Azure.AI.OpenAI.RealtimeConversation;

/// <summary>
/// The scenario client used for Files operations with the Azure OpenAI service.
/// </summary>
/// <remarks>
/// To retrieve an instance of this type, use the matching method on <see cref="AzureOpenAIClient"/>.
/// </remarks>
internal partial class AzureRealtimeConversationClient : RealtimeConversationClient
{
    private readonly Uri _endpoint;
    private readonly ApiKeyCredential _credential;
    private readonly TokenCredential _tokenCredential;
    private readonly List<string> _tokenAuthorizationScopes;
    private readonly string _userAgent;

    public AzureRealtimeConversationClient(Uri endpoint, string deploymentName, ApiKeyCredential credential, AzureOpenAIClientOptions options = null)
        : base(deploymentName, credential, new OpenAIClientOptions() { Endpoint = endpoint })
    {
        options ??= new();
        _endpoint = GetEndpoint(
            endpoint,
            deploymentName,
            options.GetRawServiceApiValueForClient(this.GetType()));
        _credential = credential;
        Core.TelemetryDetails telemetryDetails = new(typeof(AzureOpenAIClient).Assembly, options?.UserAgentApplicationId);
        _userAgent = telemetryDetails.ToString();
    }

    public AzureRealtimeConversationClient(Uri endpoint, string deploymentName, TokenCredential credential, AzureOpenAIClientOptions options = null)
        : base(deploymentName, credential: new("placeholder") , new OpenAIClientOptions() { Endpoint = endpoint })
    {
        options ??= new();
        _endpoint = GetEndpoint(
            endpoint,
            deploymentName,
            options.GetRawServiceApiValueForClient(this.GetType()));
        _tokenCredential = credential;
        _tokenAuthorizationScopes = [options?.Audience?.ToString() ?? AzureOpenAIAudience.AzurePublicCloud.ToString()];
        Core.TelemetryDetails telemetryDetails = new(typeof(AzureOpenAIClient).Assembly, options?.UserAgentApplicationId);
        _userAgent = telemetryDetails.ToString();
    }

    private static Uri GetEndpoint(Uri endpoint, string deploymentName, string apiVersion)
    {
        UriBuilder uriBuilder = new(endpoint);
        var queryBuilder = HttpUtility.ParseQueryString(uriBuilder.Query);
        bool isLegacyNoDeployment = string.IsNullOrEmpty(deploymentName);

        uriBuilder.Scheme = uriBuilder.Scheme switch
        {
            "http" => "ws",
            "https" => "wss",
            _ => uriBuilder.Scheme,
        };

        uriBuilder.Path = uriBuilder.Path.TrimEnd('/');

        if (isLegacyNoDeployment)
        {
            uriBuilder.Path = TrimEnd(uriBuilder.Path, "openai");
            apiVersion = "alpha";
        }
        else
        {
            queryBuilder["deployment"] = deploymentName;
        }

        queryBuilder["api-version"] = apiVersion;

        uriBuilder.Path += "/realtime";
        uriBuilder.Query = queryBuilder.ToString();

        return uriBuilder.Uri;
    }

    private static string TrimEnd(string original, string value)
    {
        if (original.EndsWith(value))
        {
            return original.Remove(original.Length - value.Length);
        }
        return original;
    }
}

#endif
