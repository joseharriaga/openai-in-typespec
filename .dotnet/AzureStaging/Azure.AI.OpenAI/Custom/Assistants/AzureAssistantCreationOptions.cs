// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI.Internal;
using OpenAI.Assistants;
using System.ClientModel.Primitives;

namespace Azure.AI.OpenAI.Assistants;

/**
 * Temporary: test use only
 */

public static partial class AzureAssistantCreationOptionsExtensions
{
    public static AzureChatDataSource GetTestDataSource(this AssistantCreationOptions options)
    {
        return options?.TryGetSardValue("test-string", out AzureChatDataSource value) == true ? value : null;
    }

    public static void SetTestDataSource(this AssistantCreationOptions options, AzureChatDataSource value)
    {
        options?.SetSardValue("test-string", value);
    }
}