// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.Batch;

namespace Azure.AI.OpenAI.Tests;

public class BatchTests : TestBase<BatchClient>
{
    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<BatchClient>());
}