// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI.Assistants;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.FineTuning;
using OpenAI.Images;
using OpenAI.VectorStores;

namespace Azure.AI.OpenAI.Tests;

#pragma warning disable OPENAI001
#pragma warning disable AOAI001

public class VersionTests : AoaiTestBase<ChatClient>
{
    public VersionTests() : base(isAsync: true) { }
    public VersionTests(bool isAsync) : base(isAsync) { }

    [Test]
    [Category("Smoke")]
    public void VersionAsStringWorks()
    {
        // ==, .Equals(): exact match
        Assert.That(ServiceVersion.V20240701Preview, Is.EqualTo("2024-07-01-preview"));
        Assert.That("2024-07-01-preview", Is.EqualTo(ServiceVersion.V20240701Preview));
        Assert.That(ServiceVersion.V20240701Preview == "2024-07-01-preview");
        Assert.That("2024-07-01-preview" == ServiceVersion.V20240701Preview);
        Assert.That(ServiceVersion.V20240801Preview, Is.Not.EqualTo("2024-07-01-preview"));
        Assert.That("2024-07-01-preview", Is.Not.EqualTo(ServiceVersion.V20240801Preview));
        Assert.That(ServiceVersion.V20240801Preview != "2024-07-01-preview");
        Assert.That("2024-07-01-preview" != ServiceVersion.V20240801Preview);

        // >, .CompareTo(): date sort
        Assert.That(ServiceVersion.V20240701Preview, Is.LessThan(ServiceVersion.V20240801Preview));
        Assert.That(ServiceVersion.V20240701Preview, Is.GreaterThan("2024-06-15-test"));
        Assert.That(new ServiceVersion("2050-01-01"), Is.GreaterThanOrEqualTo("2050-01-01"));
        Assert.That(ServiceVersion.V20240701Preview > ServiceVersion.V20240601);
        Assert.That(ServiceVersion.V20240701Preview < "2024-07-15");
        Assert.That(ServiceVersion.V20240701Preview >= "2024-07-01-other");
        Assert.That(ServiceVersion.V20240701Preview <= "2024-07-01-other");
    }
}
