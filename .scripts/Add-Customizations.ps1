function Remove-PseudoSuppressedTypes {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"
    $targets = @(
        # "Unknown",
    )
    foreach ($target in $targets) {
        Get-ChildItem -Path $directory -Filter "$target*" | ForEach-Object {
            Write-Output "Virtual [CodeGenSuppressType]: Removing $($_.Name)"
            $_ | Remove-Item
        }
    }
}

function Internalize-SerializedAdditionalRawData {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"
    Get-ChildItem -Path $directory -Filter "*.cs" | ForEach-Object {
        $file = $_
        $filename = $_.FullName
        $match = Select-String -Path $filename -Pattern "^(\s*)private (IDictionary<string, BinaryData> _serializedAdditionalRawData)"
        if ($match) {
            Write-Output "Internalizing _serializedAdditionalRawData: $($_.Name)"
            $content = Get-Content -Path $file -Raw
            $content = $content -creplace $match.Matches[0].Groups[0], "$($match.Matches[0].Groups[1])internal $($match.Matches[0].Groups[2])"
            $content | Set-Content -Path $filename -NoNewline
        }
    }
}

function Enable-Global-AdditionalRawDataSerialization {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"
    Get-ChildItem -Path $directory -Filter "*.cs" | ForEach-Object {
        $match = Select-String -Path $_.FullName -Pattern "options.Format != `"W`""
        if ($match) {
            Write-Output "Removing `"W`"-format serialization restriction: $($_.Name)"
            $content = Get-Content -Path $_ -Raw
            $content = $content -creplace "options.Format != `"W`"", "true"
            Set-Content $_ -Value $content -NoNewline
        }
    }
}

function Update-Set-Accessors {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"
    Get-ChildItem -Path $directory -Filter "*.cs" | Where-Object { $_.Name -notlike 'Internal*' } | ForEach-Object {
        $content = Get-Content -Path $_.FullName -Raw

        $pattern = '([^{]*){ get; set; }'
        $matches = [regex]::Matches($content, $pattern)

        if ($matches) {
            Write-Output "Editing $($_.Name): adjusting { set; } accessors"
        }
        foreach ($match in $matches) {
            $propertyDeclaration = $match.Groups[1].Value
            if ($propertyDeclaration -like "*List<*" -or $propertyDeclaration -like "*Dictionary<*") {
                $newPropertyDeclaration = "$propertyDeclaration{ get; }"
            } else {
                $newPropertyDeclaration = "$propertyDeclaration{ get; init; }"
            }
            $content = $content -replace [regex]::Escape($match.Value), $newPropertyDeclaration
        }

        Set-Content -Path $_.FullName -Value $content -NoNewline
    }
}

function Remove-Generated-Comments {
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated"
    Get-ChildItem -Recurse -File -Path $directory -Filter "*.cs" | ForEach-Object {
        Write-Output $_.Name
        $content = Get-Content -Path $_.FullName -Raw
        $content = $content -replace " *///.*[\r\n]*", ""
        Set-Content -Path $_.FullName -Value $content -NoNewLine
    }
}

Remove-PseudoSuppressedTypes
Internalize-SerializedAdditionalRawData
Enable-Global-AdditionalRawDataSerialization
Update-Set-Accessors
Remove-Generated-Comments