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
                $newPropertyDeclaration = "$propertyDeclaration{ get; set; }"
            }
            $content = $content -replace [regex]::Escape($match.Value), $newPropertyDeclaration
        }

        Set-Content -Path $_.FullName -Value $content -NoNewline
    }
}

Update-Set-Accessors