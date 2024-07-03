import "./main.tsp";
import "@azure-tools/typespec-client-generator-core";
import "../.typespec/audio";

using Azure.ClientGenerator.Core;

namespace OpenAI {
    @@withoutOmittedProperties(CreateChatCompletionRequest, "stream_options");
}

namespace AzureOpenAI.Client {

    using OpenAI;

    @client({
        name: "AzureOpenAIClient",
        service: AzureOpenAI,
    })
    interface AzureOpenAIClient {
        // This generates a duplicate entry in the OpenAPI file
        // Also the path seems to be incorrect. It seems to ignore the path from the interface `AzureChat`
        createChatCompletion is AzureOpenAI.AzureChat.createChatCompletion;

        createSpeech is OpenAI.Audio.createSpeech;
    }
}


