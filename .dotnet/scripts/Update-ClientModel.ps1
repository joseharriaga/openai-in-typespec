function Update-OpenAIClient {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Generated"
    $file = Get-ChildItem -Path $directory -Filter "OpenAIClient.cs"
    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $content = $content -creplace "_keyCredential", "_credential"

    $content | Set-Content -Path $file.FullName -NoNewline
}

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
        $content = $content -creplace "RequestOptions context = FromCancellationToken\(cancellationToken\);\s+", ""
        $content = $content -creplace "ClientResult result = await (?<method>\w+)\(context\)\.ConfigureAwait\(false\);", "ClientResult result = await `${method}(DefaultRequestContext).ConfigureAwait(false);"
        $content = $content -creplace "ClientResult result = (?<method>\w+)\(context\);", "ClientResult result = `${method}(DefaultRequestContext);"
        $content = $content -creplace "ClientResult result = await (?<method>\w+)\((?<params>[(\w+)(\?.ToString\(\)*)(,\s\w+)]*), context\)\.ConfigureAwait\(false\);", "ClientResult result = await `${method}(`${params}, DefaultRequestContext).ConfigureAwait(false);"
        $content = $content -creplace "ClientResult result = (?<method>\w+)\((?<params>[(\w+)(\?.ToString\(\)*)(,\s\w+)]*), context\);", "ClientResult result = `${method}(`${params}, DefaultRequestContext);"


        # Modify protocol methods
        $content = $content -creplace "\/\/\/ Please try the simpler <see cref=`"(?<method>\w+)\(CancellationToken\)`"/> convenience overload with strongly typed models first.", "/// Please try the simpler <see cref=`"`${method}()`"/> convenience overload with strongly typed models first."
        $content = $content -creplace "\/\/\/ Please try the simpler <see cref=`"(?<method>\w+)\((?<params>[(\w+)(\?*)(,\s\w+)]*),CancellationToken\)`"/> convenience overload with strongly typed models first.", "/// Please try the simpler <see cref=`"`${method}(`${params})`"/> convenience overload with strongly typed models first."
        $content = $content -creplace "\/\/\/ <param name=`"context`"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>", "/// <param name=`"options`"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>"
        $content = $content -creplace "\/\/\/ <exception cref=`"MessageFailedException`">", "/// <exception cref=`"ClientResultException`">"
        $content = $content -creplace "\(RequestOptions context", "(RequestOptions options"
        $content = $content -creplace " RequestOptions context", " RequestOptions options"
        $content = $content -creplace "context\)", "options)"

        # Create request
        $content = $content -creplace " RequestOptions context", " RequestOptions options"
        $content = $content -creplace "if \(context != null\)", "if (options != null)"
        $content = $content -creplace "message\.Apply\(context\)", "message.Apply(options)"

        # Clean up ApiKeyCredential
        $content = $content -creplace "<param name=`"keyCredential`">", "<param name=`"credential`">"
        $content = $content -creplace "_keyCredential", "_credential"
        $content = $content -creplace " keyCredential", " credential"

        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

function Update-AssemblyInfo {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath "src\Properties"
    $file = Get-ChildItem -Path $directory -Filter "AssemblyInfo.cs"
    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $content = $content -creplace "\[assembly: InternalsVisibleTo\(`"OpenAI\.Tests`"\)\]", "// [assembly: InternalsVisibleTo(`"OpenAI.Tests`")]"

    $content | Set-Content -Path $file.FullName -NoNewline
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

Update-OpenAIClient
Update-Subclients
Update-AssemblyInfo
Update-InternalClientUriBuilder