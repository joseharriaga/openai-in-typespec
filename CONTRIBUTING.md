# CONTRIBUTING

## Setup

To install dependencies, run the following command to install the necessary tools:
`npm install`

## How to run code generation OpenAI

1. Regenerate the OpenAPI spec by running the following command:
    `npx tsp compile .\openai-in-typespec\main.tsp --emit @typespec/openapi3`
1. Regenerate the library by running the following command:
    `npx tsp compile .\openai-in-typespec\main.tsp --emit @azure-tools/typespec-csharp --option @azure-tools/typespec-csharp.emitter-output-dir=.\openai-in-typespec\.dotnet\src`
1. Run the following script:
    `.\openai-in-typespec\.scripts\Update-ClientModel.ps1`
1. Run the following script:
    `.\openai-in-typespec\.scripts\ConvertTo-Internal.ps1`
1. Run the following script:
    `.\openai-in-typespec\.scripts\Add-Customizations.ps1`

## How to run code generation Azure OpenAI


### Azure OpenAI OpenAPI file

To regenearte the OpenAPI file in `./.typespec.azure/azure-openai-openapi3.yaml`, run the following command from the root of the project folder:

```bash
tsp compile .typespec.azure/client.tsp --emit @typespec/openapi3 
```
