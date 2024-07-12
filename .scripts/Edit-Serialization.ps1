function Edit-Serialization {
    param(
        [string] $Filename,
        [string[]] $InputRegex,
        [string[]] $OutputString,
        [int] $OutputIndentation
    )
    $root = Split-Path $PSScriptRoot -Parent
    $directory = Join-Path -Path $root -ChildPath ".dotnet\src\Generated\Models"
    $file = Get-ChildItem -Path $directory -Filter $Filename
    $content = Get-Content -Path $file -Raw

    Write-Output "Editing $($file.FullName)"

    $regex = "(?s)"
    foreach ($line in $InputRegex) { $regex += "\s+" + $line }

    if ($content -cnotmatch $regex)
    {
        throw "The code does not match the expected pattern. If this is by design, please update or disable this edit."
    }
    else
    {
        $output = ""
        foreach ($line in $OutputString) { $output += "`r`n" + $line.PadLeft($line.Length + $OutputIndentation) }

        $content = $content -creplace $regex, $output
        $content | Set-Content -Path $file.FullName -NoNewline
    }
}

function Edit-AssistantSerialization {
    $filename = "Assistant.Serialization.cs"

    # response_format serialization
    $inputRegex = @(
        "if \(Optional\.IsDefined\(ResponseFormat\)\)",
        "\{"
        "    writer\.WritePropertyName\(`"response_format`"u8\);"
        "    writer\.WriteObjectValue<AssistantResponseFormat>\(ResponseFormat, options\);"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (Optional.IsDefined(ResponseFormat))",
        "{",
        "    if (ResponseFormat != null)",
        "    {",
        "        writer.WritePropertyName(`"response_format`"u8);",
        "        writer.WriteObjectValue<AssistantResponseFormat>(ResponseFormat, options);",
        "    }",
        "    else",
        "    {",
        "        writer.WriteNull(`"response_format`");",
        "    }",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # response_format deserialization
    $inputRegex = @(
        "if \(property\.NameEquals\(`"response_format`"u8\)\)",
        "\{"
        "    if \(property\.Value\.ValueKind == JsonValueKind\.Null\)"
        "    \{"
        "        continue;"
        "    \}"
        "    responseFormat = AssistantResponseFormat\.DeserializeAssistantResponseFormat\(property\.Value, options\);"
        "    continue;"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (property.NameEquals(`"response_format`"u8))",
        "{",
        "    if (property.Value.ValueKind == JsonValueKind.Null)",
        "    {",
        "        responseFormat = null;",
        "        continue;",
        "    }",
        "    responseFormat = AssistantResponseFormat.DeserializeAssistantResponseFormat(property.Value, options);",
        "    continue;",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 16
}

function Edit-AssistantCreationOptionsSerialization {
    $filename = "AssistantCreationOptions.Serialization.cs"

    # response_format serialization
    $inputRegex = @(
        "if \(Optional\.IsDefined\(ResponseFormat\)\)",
        "\{"
        "    writer\.WritePropertyName\(`"response_format`"u8\);"
        "    writer\.WriteObjectValue<AssistantResponseFormat>\(ResponseFormat, options\);"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (Optional.IsDefined(ResponseFormat))",
        "{",
        "    if (ResponseFormat != null)",
        "    {",
        "        writer.WritePropertyName(`"response_format`"u8);",
        "        writer.WriteObjectValue<AssistantResponseFormat>(ResponseFormat, options);",
        "    }",
        "    else",
        "    {",
        "        writer.WriteNull(`"response_format`");",
        "    }",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # response_format deserialization
    $inputRegex = @(
        "if \(property\.NameEquals\(`"response_format`"u8\)\)",
        "\{"
        "    if \(property\.Value\.ValueKind == JsonValueKind\.Null\)"
        "    \{"
        "        continue;"
        "    \}"
        "    responseFormat = AssistantResponseFormat\.DeserializeAssistantResponseFormat\(property\.Value, options\);"
        "    continue;"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (property.NameEquals(`"response_format`"u8))",
        "{",
        "    if (property.Value.ValueKind == JsonValueKind.Null)",
        "    {",
        "        responseFormat = null;",
        "        continue;",
        "    }",
        "    responseFormat = AssistantResponseFormat.DeserializeAssistantResponseFormat(property.Value, options);",
        "    continue;",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 16
}

function Edit-AssistantModificationOptionsSerialization {
    $filename = "AssistantModificationOptions.Serialization.cs"

    # response_format serialization
    $inputRegex = @(
        "if \(Optional\.IsDefined\(ResponseFormat\)\)",
        "\{"
        "    writer\.WritePropertyName\(`"response_format`"u8\);"
        "    writer\.WriteObjectValue<AssistantResponseFormat>\(ResponseFormat, options\);"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (Optional.IsDefined(ResponseFormat))",
        "{",
        "    if (ResponseFormat != null)",
        "    {",
        "        writer.WritePropertyName(`"response_format`"u8);",
        "        writer.WriteObjectValue<AssistantResponseFormat>(ResponseFormat, options);",
        "    }",
        "    else",
        "    {",
        "        writer.WriteNull(`"response_format`");",
        "    }",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # response_format deserialization
    $inputRegex = @(
        "if \(property\.NameEquals\(`"response_format`"u8\)\)",
        "\{"
        "    if \(property\.Value\.ValueKind == JsonValueKind\.Null\)"
        "    \{"
        "        continue;"
        "    \}"
        "    responseFormat = AssistantResponseFormat\.DeserializeAssistantResponseFormat\(property\.Value, options\);"
        "    continue;"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (property.NameEquals(`"response_format`"u8))",
        "{",
        "    if (property.Value.ValueKind == JsonValueKind.Null)",
        "    {",
        "        responseFormat = null;",
        "        continue;",
        "    }",
        "    responseFormat = AssistantResponseFormat.DeserializeAssistantResponseFormat(property.Value, options);",
        "    continue;",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 16
}

function Edit-InternalCreateThreadAndRunRequestSerialization {
    $filename = "InternalCreateThreadAndRunRequest.Serialization.cs"

    # tool_choice serialization
    $inputRegex = @(
        "if \(Optional\.IsDefined\(ToolChoice\)\)",
        "\{"
        "    writer\.WritePropertyName\(`"tool_choice`"u8\);"
        "    writer\.WriteObjectValue<ToolConstraint>\(ToolChoice, options\);"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (Optional.IsDefined(ToolChoice))",
        "{",
        "    if (ToolChoice != null)",
        "    {",
        "        writer.WritePropertyName(`"tool_choice`"u8);",
        "        writer.WriteObjectValue<ToolConstraint>(ToolChoice, options);",
        "    }",
        "    else",
        "    {",
        "        writer.WriteNull(`"tool_choice`");",
        "    }",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # tool_choice deserialization
    $inputRegex = @(
        "if \(property\.NameEquals\(`"tool_choice`"u8\)\)",
        "\{"
        "    if \(property\.Value\.ValueKind == JsonValueKind\.Null\)"
        "    \{"
        "        continue;"
        "    \}"
        "    toolChoice = ToolConstraint\.DeserializeToolConstraint\(property\.Value, options\);"
        "    continue;"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (property.NameEquals(`"tool_choice`"u8))",
        "{",
        "    if (property.Value.ValueKind == JsonValueKind.Null)",
        "    {",
        "        toolChoice = null;",
        "        continue;",
        "    }",
        "    toolChoice = ToolConstraint.DeserializeToolConstraint(property.Value, options);",
        "    continue;",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 16

    # response_format serialization
    $inputRegex = @(
        "if \(Optional\.IsDefined\(ResponseFormat\)\)",
        "\{"
        "    writer\.WritePropertyName\(`"response_format`"u8\);"
        "    writer\.WriteObjectValue<AssistantResponseFormat>\(ResponseFormat, options\);"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (Optional.IsDefined(ResponseFormat))",
        "{",
        "    if (ResponseFormat != null)",
        "    {",
        "        writer.WritePropertyName(`"response_format`"u8);",
        "        writer.WriteObjectValue<AssistantResponseFormat>(ResponseFormat, options);",
        "    }",
        "    else",
        "    {",
        "        writer.WriteNull(`"response_format`");",
        "    }",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # response_format deserialization
    $inputRegex = @(
        "if \(property\.NameEquals\(`"response_format`"u8\)\)",
        "\{"
        "    if \(property\.Value\.ValueKind == JsonValueKind\.Null\)"
        "    \{"
        "        continue;"
        "    \}"
        "    responseFormat = AssistantResponseFormat\.DeserializeAssistantResponseFormat\(property\.Value, options\);"
        "    continue;"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (property.NameEquals(`"response_format`"u8))",
        "{",
        "    if (property.Value.ValueKind == JsonValueKind.Null)",
        "    {",
        "        responseFormat = null;",
        "        continue;",
        "    }",
        "    responseFormat = AssistantResponseFormat.DeserializeAssistantResponseFormat(property.Value, options);",
        "    continue;",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 16
}

function Edit-RunCreationOptionsSerialization {
    $filename = "RunCreationOptions.Serialization.cs"

    # tool_choice serialization
    $inputRegex = @(
        "if \(Optional\.IsDefined\(ToolConstraint\)\)",
        "\{"
        "    writer\.WritePropertyName\(`"tool_choice`"u8\);"
        "    SerializeToolConstraint\(writer, options\);"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (Optional.IsDefined(ToolConstraint))",
        "{",
        "    if (ToolConstraint != null)",
        "    {",
        "        writer.WritePropertyName(`"tool_choice`"u8);",
        "        SerializeToolConstraint(writer, options);",
        "    }",
        "    else",
        "    {",
        "        writer.WriteNull(`"tool_choice`");",
        "    }",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # tool_choice deserialization
    $inputRegex = @(
        "if \(property\.NameEquals\(`"tool_choice`"u8\)\)",
        "\{"
        "    if \(property\.Value\.ValueKind == JsonValueKind\.Null\)"
        "    \{"
        "        continue;"
        "    \}"
        "    toolChoice = Assistants\.ToolConstraint\.DeserializeToolConstraint\(property\.Value, options\);"
        "    continue;"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (property.NameEquals(`"tool_choice`"u8))",
        "{",
        "    if (property.Value.ValueKind == JsonValueKind.Null)",
        "    {",
        "        toolChoice = null;",
        "        continue;",
        "    }",
        "    toolChoice = Assistants.ToolConstraint.DeserializeToolConstraint(property.Value, options);",
        "    continue;",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 16

    # response_format serialization
    $inputRegex = @(
        "if \(Optional\.IsDefined\(ResponseFormat\)\)",
        "\{"
        "    writer\.WritePropertyName\(`"response_format`"u8\);"
        "    writer\.WriteObjectValue<AssistantResponseFormat>\(ResponseFormat, options\);"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (Optional.IsDefined(ResponseFormat))",
        "{",
        "    if (ResponseFormat != null)",
        "    {",
        "        writer.WritePropertyName(`"response_format`"u8);",
        "        writer.WriteObjectValue<AssistantResponseFormat>(ResponseFormat, options);",
        "    }",
        "    else",
        "    {",
        "        writer.WriteNull(`"response_format`");",
        "    }",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # response_format deserialization
    $inputRegex = @(
        "if \(property\.NameEquals\(`"response_format`"u8\)\)",
        "\{"
        "    if \(property\.Value\.ValueKind == JsonValueKind\.Null\)"
        "    \{"
        "        continue;"
        "    \}"
        "    responseFormat = AssistantResponseFormat\.DeserializeAssistantResponseFormat\(property\.Value, options\);"
        "    continue;"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (property.NameEquals(`"response_format`"u8))",
        "{",
        "    if (property.Value.ValueKind == JsonValueKind.Null)",
        "    {",
        "        responseFormat = null;",
        "        continue;",
        "    }",
        "    responseFormat = AssistantResponseFormat.DeserializeAssistantResponseFormat(property.Value, options);",
        "    continue;",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 16
}

function Edit-ThreadRunSerialization {
    $filename = "ThreadRun.Serialization.cs"

    # tool_choice serialization
    $inputRegex = @(
        "writer\.WritePropertyName\(`"tool_choice`"u8\);"
        "writer\.WriteObjectValue<ToolConstraint>\(ToolConstraint, options\);"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (ToolConstraint != null)",
        "{",
        "    writer.WritePropertyName(`"tool_choice`"u8);",
        "    writer.WriteObjectValue<ToolConstraint>(ToolConstraint, options);",
        "}",
        "else",
        "{",
        "    writer.WriteNull(`"tool_choice`");",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # tool_choice deserialization
    $inputRegex = @(
        "if \(property\.NameEquals\(`"tool_choice`"u8\)\)",
        "\{"
        "    toolChoice = Assistants\.ToolConstraint\.DeserializeToolConstraint\(property\.Value, options\);"
        "    continue;"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (property.NameEquals(`"tool_choice`"u8))",
        "{",
        "    if (property.Value.ValueKind == JsonValueKind.Null)",
        "    {",
        "        toolChoice = null;",
        "        continue;",
        "    }",
        "    toolChoice = Assistants.ToolConstraint.DeserializeToolConstraint(property.Value, options);",
        "    continue;",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 16

    # response_format serialization
    $inputRegex = @(
        "writer\.WritePropertyName\(`"response_format`"u8\);"
        "writer\.WriteObjectValue<AssistantResponseFormat>\(ResponseFormat, options\);"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (ResponseFormat != null)",
        "{",
        "    writer.WritePropertyName(`"response_format`"u8);",
        "    writer.WriteObjectValue<AssistantResponseFormat>(ResponseFormat, options);",
        "}",
        "else",
        "{",
        "    writer.WriteNull(`"response_format`");",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 12

    # response_format deserialization
    $inputRegex = @(
        "if \(property\.NameEquals\(`"response_format`"u8\)\)",
        "\{"
        "    responseFormat = AssistantResponseFormat\.DeserializeAssistantResponseFormat\(property\.Value, options\);"
        "    continue;"
        "\}"
    )
    $outputString = @(
        "// CUSTOM: Made nullable."
        "if (property.NameEquals(`"response_format`"u8))",
        "{",
        "    if (property.Value.ValueKind == JsonValueKind.Null)",
        "    {",
        "        responseFormat = null;",
        "        continue;",
        "    }",
        "    responseFormat = AssistantResponseFormat.DeserializeAssistantResponseFormat(property.Value, options);",
        "    continue;",
        "}"
    )
    Edit-Serialization -Filename $filename -InputRegex $inputRegex -OutputString $outputString -OutputIndentation 16
}

# Edit-AssistantSerialization
# Edit-AssistantCreationOptionsSerialization
# Edit-AssistantModificationOptionsSerialization
# Edit-InternalCreateThreadAndRunRequestSerialization
# Edit-RunCreationOptionsSerialization
# Edit-ThreadRunSerialization