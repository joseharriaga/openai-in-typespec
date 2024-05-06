// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI;
using OpenAI;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI;

/// <summary>
/// A helper class to standardize custom protocol message creation across various Azure OpenAI scenario clients.
/// </summary>
internal class AzureOpenAIPipelineMessageBuilder
{
    private readonly ClientPipeline _pipeline;
    private readonly Uri _endpoint;
    private readonly string _deploymentName;
    private string _operation;
    private readonly List<KeyValuePair<string, string>> _queryStringParameters = [];
    private string _method;
    private BinaryContent _content;
    private string _contentTypeHeader;
    private string _acceptHeader;
    private RequestOptions _options;
    private bool? _bufferResponse;

    /// <summary>
    /// Creates a new instance of <see cref="AzureOpenAIPipelineMessageBuilder"/>.
    /// </summary>
    /// <param name="pipeline"></param>
    /// <param name="endpoint"></param>
    /// <param name="apiVersion"></param>
    /// <param name="deploymentName"></param>
    public AzureOpenAIPipelineMessageBuilder(ClientPipeline pipeline, Uri endpoint, string apiVersion, string deploymentName = null)
    {
        _pipeline = pipeline;
        _endpoint = endpoint;
        _deploymentName = deploymentName;
        _queryStringParameters.Add(new KeyValuePair<string, string>("api-version", apiVersion));
    }

    public AzureOpenAIPipelineMessageBuilder WithOperation(string operation)
    {
        _operation = operation;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithOptionalQueryParameter(string name, string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _queryStringParameters.Add(new(name, value));
        }
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithMethod(string requestMethod)
    {
        _method = requestMethod;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithContent(BinaryContent content, string contentType)
    {
        _content = content;
        _contentTypeHeader = contentType;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithAccept(string acceptHeaderValue)
    {
        _acceptHeader = acceptHeaderValue;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithOptions(RequestOptions requestOptions)
    {
        _options = requestOptions;
        return this;
    }

    public AzureOpenAIPipelineMessageBuilder WithResponseContentBuffering(bool? shouldBufferContent)
    {
        _bufferResponse = shouldBufferContent;
        return this;
    }

    public PipelineMessage Build()
    {
        Argument.AssertNotNullOrWhiteSpace(_method, nameof(_method));

        PipelineMessage message = _pipeline.CreateMessage();
        message.ResponseClassifier = AzureOpenAIClient.PipelineMessageClassifier200;
        if (_bufferResponse.HasValue)
        {
            message.BufferResponse = _bufferResponse.Value;
        }
        PipelineRequest request = message.Request;
        request.Method = _method;
        SetUri(request);
        SetHeaders(request);
        request.Content = _content;
        if (_options is not null)
        {
            message.Apply(_options);
        }
        return message;
    }

    private void SetUri(PipelineRequest request)
    {
        ClientUriBuilder uriBuilder = new();
        uriBuilder.Reset(_endpoint);

        bool hasTrailingSlash = _endpoint.AbsoluteUri.EndsWith("/");
        uriBuilder.AppendPath($"{(hasTrailingSlash ? "" : "/")}openai", escape: false);

        if (!string.IsNullOrEmpty(_deploymentName))
        {
            uriBuilder.AppendPath($"/deployments/", escape: false);
            uriBuilder.AppendPath(_deploymentName, escape: true);
        }

        if (!string.IsNullOrEmpty(_operation))
        {
            uriBuilder.AppendPath(_operation, escape: false);
        }

        foreach (KeyValuePair<string, string> queryStringPair in _queryStringParameters)
        {
            uriBuilder.AppendQuery(queryStringPair.Key, queryStringPair.Value, escape: true);
        }

        request.Uri = uriBuilder.ToUri();
    }

    private void SetHeaders(PipelineRequest request)
    {
        if (!string.IsNullOrEmpty(_acceptHeader))
        {
            request.Headers.Set("Accept", _acceptHeader);
        }
        if (!string.IsNullOrEmpty(_contentTypeHeader))
        {
            request.Headers.Set("Content-Type", _contentTypeHeader);
        }
    }
}