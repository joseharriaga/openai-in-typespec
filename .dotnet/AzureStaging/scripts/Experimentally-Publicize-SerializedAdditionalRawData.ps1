$generatedCodeRoot = Join-Path $PSScriptRoot .. src Generated -Resolve

$originalString = "private IDictionary<string, BinaryData> _serializedAdditionalRawData;"
$publicString = "public IDictionary<string, BinaryData> SerializedAdditionalRawData"
$additionalLines = @(
    "/// <summary>"
    "/// Gets the dictionary containing additional raw data to serialize."
    "/// </summary>"
    "/// <remarks>"
    "/// NOTE: This mechanism added for subclients pending availability of a C# language feature."
    "///       It is subject to change and not intended for stable use."
    "/// </remarks>"
    "[Experimental(`"OPENAI002`")]"
    "[EditorBrowsable(EditorBrowsableState.Never)]"
    $publicString
    "    => _serializedAdditionalRawData ??= new ChangeTrackingDictionary<string, BinaryData>();"
)

Get-ChildItem $generatedCodeRoot -File -Filter "*.cs" | ForEach-Object {
    $file = $_
    $filename = $_.FullName
    $match = Select-String -Path $filename -Pattern "^(\s*)$originalString([`r`n]*)"
    $alreadyMatched = Select-String -Path $filename -Pattern "^.*$publicString.*"
    if ($match -and (-not $alreadyMatched)) {
        Write-Output "Adding SerializedAdditionalRawData: $($_.Name)"
        $line = $match.Matches[0].Groups[0]
        $spaces = $match.Matches[0].Groups[1]
        $trailingNewlines = $match.Matches[0].Groups[2]
        $replacement = "$line`n"
        foreach ($additionalLine in $additionalLines) {
            $replacement += "`n$spaces$additionalLine"
        }
        $replacement += "$trailingNewlines"
        $content = Get-Content -Path $file -Raw
        $content = $content -creplace "$line", "$replacement"

        $componentModelMatch = Select-String -Path $filename -Pattern "^using System.ComponentModel"
        if (-not $componentModelMatch) {
            $content = $content -creplace `
                "using System.Collections.Generic;", `
                ("using System.Collections.Generic;`n" `
                + "using System.ComponentModel;`n" `
                + "using System.Diagnostics.CodeAnalysis;")
        }

        Set-Content $filename -Value $content
    }
    $match = Select-String -Path $filename -Pattern "options.Format != `"W`""
    if ($match) {
        Write-Output "Removing `"W`"-format serialization restriction: $($_.Name)"
        $content = Get-Content -Path $file -Raw
        $content = $content -creplace "options.Format != `"W`"", "true"
        Set-Content $filename -Value $content
    }
}
