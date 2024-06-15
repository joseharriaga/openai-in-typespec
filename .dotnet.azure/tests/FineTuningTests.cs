// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using OpenAI.FineTuning;

namespace Azure.AI.OpenAI.Tests;

public class FineTuningTests : TestBase<FineTuningClient>
{
    [Test]
    [Category("Smoke")]
    public void CanCreateClient() => Assert.That(GetTestClient(), Is.InstanceOf<FineTuningClient>());
}