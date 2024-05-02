// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;

namespace Azure.AI.OpenAI.Staging;

public partial class AzureOpenAIClientOptions : OpenAIClientOptions
{
    public string ApiVersion { get; }

    public AzureOpenAIClientOptions()
        : this(AzureOpenAIServiceApiVersion.Latest)
    { }

    public AzureOpenAIClientOptions(string apiVersion)
        : base()
    {
        ApiVersion = apiVersion;
    }

    public partial class AzureOpenAIServiceApiVersion
    {
        public static string Latest => v2024_04_01_Preview;
        public static string v2024_04_01_Preview => "2024-04-01-preview";
    }
}
