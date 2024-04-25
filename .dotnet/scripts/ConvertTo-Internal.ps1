function Edit-GeneratedOpenAIClient {
    $root = Split-Path $PSScriptRoot -Parent

    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    $file = Get-ChildItem -Path $directory -Filter "OpenAIClient.cs"

    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    # $content = $content -creplace "public partial class", "internal partial class"
    # $content = $content -creplace "public readonly partial struct", "internal readonly partial struct"
    # $content = $content -creplace "public static partial class", "internal static partial class"
    # $content = $content -creplace "namespace OpenAI", "namespace OpenAI.Internal"
    # $content = $content -creplace "using OpenAI.Models;", "using OpenAI.Internal.Models;"
    $content = $content -creplace "private (OpenAI.)?(?<var>\w+) _cached(\w+);", "private OpenAI.Internal.`${var} _cached`${var};"
    $content = $content -creplace "(?s)\s+private OpenAI\.Internal\.EmbeddingClient _cachedEmbeddingClient;", ""
    $content = $content -creplace "public virtual (OpenAI.)?(?<var>\w+) Get(\w+)Client", "internal OpenAI.Internal.`${var} Get`${var}Client"
    $content = $content -creplace "ref _cached(\w+), new (OpenAI.)?(?<var>\w+)", "ref _cached`${var}, new OpenAI.Internal.`${var}"

    $content | Set-Content -Path $file.FullName -NoNewline
}

function Edit-GeneratedSubclients {
    $root = Split-Path $PSScriptRoot -Parent

    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    $files = Get-ChildItem -Path $($directory + "\*") -Include "*.cs" -Exclude "OpenAIClient.cs", "OpenAIClientOptions.cs", "OpenAIModelFactory.cs"

    $exclusions = @(
        "EmbeddingClient.cs"
    )

    foreach ($file in $files) {
        if ($exclusions -contains $file.Name) {
            continue
        }

        $content = Get-Content -Path $file -Raw

        Write-Output "Editing $($file.FullName)"

        $content = $content -creplace "public partial class", "internal partial class"
        $content = $content -creplace "public readonly partial struct", "internal readonly partial struct"
        $content = $content -creplace "public static partial class", "internal static partial class"
        $content = $content -creplace "namespace OpenAI", "namespace OpenAI.Internal"
        $content = $content -creplace "using OpenAI.Models;", "using OpenAI.Internal.Models;"

        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

function Edit-GeneratedModels {
    $root = Split-Path $PSScriptRoot -Parent

    $directory = Join-Path -Path $root -ChildPath "src\Generated\Models"
    $files = Get-ChildItem -Path $($directory + "\*") -Include "*.cs"
    
    $exclusions = @(
        "CreateEmbeddingRequestModel.cs",
        "CreateEmbeddingResponseObject.cs",
        "Embedding.cs", "Embedding.Serialization.cs",
        "EmbeddingCollection.cs", "EmbeddingCollection.Serialization.cs",
        "EmbeddingObject.cs",
        "EmbeddingOptions.cs", "EmbeddingOptions.Serialization.cs",
        "EmbeddingOptionsEncodingFormat.cs",
        "EmbeddingTokenUsage.cs", "EmbeddingTokenUsage.Serialization.cs"
    )

    foreach ($file in $files) {
        if ($exclusions -contains $file.Name) {
            continue
        }

        $content = Get-Content -Path $file -Raw

        Write-Output "Editing $($file.FullName)"

        $content = $content -creplace "public partial class", "internal partial class"
        $content = $content -creplace "public readonly partial struct", "internal readonly partial struct"
        $content = $content -creplace "public static partial class", "internal static partial class"
        $content = $content -creplace "namespace OpenAI", "namespace OpenAI.Internal"
        $content = $content -creplace "using OpenAI.Models;", "using OpenAI.Internal.Models;"

        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

function Edit-GeneratedModelFactory {
    $root = Split-Path $PSScriptRoot -Parent

    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    $file = Get-ChildItem -Path $directory -Filter "OpenAIModelFactory.cs"

    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $content = $content -creplace "using OpenAI.Models;", "using OpenAI.Internal.Models;"

    $content | Set-Content -Path $file.FullName -NoNewline
}

function Remove-GeneratedTests {
    $root = Split-Path $PSScriptRoot -Parent

    $directory = Join-Path -Path $root -ChildPath "tests\Generated"
    Remove-Item -LiteralPath $directory -Recurse -Force
}

Edit-GeneratedOpenAIClient
Edit-GeneratedSubclients
Edit-GeneratedModels
Edit-GeneratedModelFactory
Remove-GeneratedTests
