function Update-Subclients {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    $files = Get-ChildItem -Path $($directory + "\*") -Include "*.cs" -Exclude "OpenAIClient.cs", "OpenAIClientOptions.cs"

    foreach ($file in $files) {
        $content = Get-Content -Path $file -Raw

        Write-Output "Editing $($file.FullName)"

        # Delete FromCancellationToken
        $content = $content -creplace "(?s)\s+internal static RequestOptions FromCancellationToken\(CancellationToken cancellationToken = default\).*?return new RequestOptions\(\) \{ CancellationToken = cancellationToken \};.*?\}", ""

        # # Modify convenience methods
        $content = $content -creplace "\s+\/\/\/ <param name=`"cancellationToken`"> The cancellation token to use. </param>", ""
        $content = $content -creplace "\(CancellationToken cancellationToken = default\)", "()"
        $content = $content -creplace ", CancellationToken cancellationToken = default\)", ")"
        $content = $content -creplace "RequestOptions options = FromCancellationToken\(cancellationToken\);\s+", ""
        $content = $content -creplace "ClientResult result = await (?<method>\w+)\(options\)\.ConfigureAwait\(false\);", "ClientResult result = await `${method}(DefaultRequestContext).ConfigureAwait(false);"
        $content = $content -creplace "ClientResult result = (?<method>\w+)\(options\);", "ClientResult result = `${method}(DefaultRequestContext);"
        $content = $content -creplace "ClientResult result = await (?<method>\w+)\((?<params>[(\w+)(\?.ToString\(\)*)(,\s\w+)]*), options\)\.ConfigureAwait\(false\);", "ClientResult result = await `${method}(`${params}, DefaultRequestContext).ConfigureAwait(false);"
        $content = $content -creplace "ClientResult result = (?<method>\w+)\((?<params>[(\w+)(\?.ToString\(\)*)(,\s\w+)]*), options\);", "ClientResult result = `${method}(`${params}, DefaultRequestContext);"

        # Modify protocol methods
        $content = $content -creplace "\/\/\/ Please try the simpler <see cref=`"(?<method>\w+)\(CancellationToken\)`"/> convenience overload with strongly typed models first.", "/// Please try the simpler <see cref=`"`${method}()`"/> convenience overload with strongly typed models first."
        $content = $content -creplace "\/\/\/ Please try the simpler <see cref=`"(?<method>\w+)\((?<params>[(\w+)(\?*)(,\s\w+)]*),CancellationToken\)`"/> convenience overload with strongly typed models first.", "/// Please try the simpler <see cref=`"`${method}(`${params})`"/> convenience overload with strongly typed models first."
        $content = $content -creplace "\/\/\/ <exception cref=`"MessageFailedException`">", "/// <exception cref=`"ClientResultException`">"

        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

function Update-InternalClientUriBuilder {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated\Internal"
    $file = Get-ChildItem -Path $directory -Filter "ClientUriBuilder.cs"
    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $content = $content -creplace "value = value\.Substring\(1\);", "// value = value.Substring(1);"

    $content | Set-Content -Path $file.FullName -NoNewline
}

function Remove-Utf8JsonRequestBody {
    $root = Split-Path $PSScriptRoot -Parent
    $filePath = Join-Path -Path $root -ChildPath "src\Generated\Internal\Utf8JsonRequestBody.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

function Remove-RequestContentHelper {
    $root = Split-Path $PSScriptRoot -Parent
    $filePath = Join-Path -Path $root -ChildPath "src\Generated\Internal\RequestContentHelper.cs"
    $file = Get-ChildItem -Path $filePath

    Write-Output "Removing $($file.FullName)"

    Remove-Item $file
}

function Partialize-ClientPipelineExtensions {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated\Internal"
    $file = Get-ChildItem -Path $directory -Filter "ClientPipelineExtensions.cs"
    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $content = $content -creplace "internal static class ClientPipelineExtensions", "internal static partial class ClientPipelineExtensions"

    $content | Set-Content -Path $file.FullName -NoNewline
}

Update-Subclients
Update-InternalClientUriBuilder
Remove-Utf8JsonRequestBody
Remove-RequestContentHelper
Partialize-ClientPipelineExtensions
