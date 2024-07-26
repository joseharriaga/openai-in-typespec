function Remove-CollectionSetters {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"
    $files = Get-ChildItem -Path $($directory + "\*") -Include "*.cs"

    foreach ($file in $files) {
        $content = Get-Content -Path $file -Raw

        Write-Output "Editing $($file.FullName)"

        $content = $content -creplace "internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; set; }", "internal IDictionary<string, BinaryData> SerializedAdditionalRawData { get; }"
        $content = $content -creplace "public IDictionary<string, string> Metadata { get; set; }", "public IDictionary<string, string> Metadata { get; }"

        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

Remove-CollectionSetters