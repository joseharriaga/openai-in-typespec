// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.OpenAI.Chat;

[Flags]
public enum DataSourceOutputContextFlags : int
{
    Intent = 1 << 0,
    Citations = 1 << 1,
    AllRetrievedDocuments = 1 << 2,
}