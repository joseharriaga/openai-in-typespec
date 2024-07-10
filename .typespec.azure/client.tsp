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

        createSpeech is OpenAI.Audio.createSpeech;
        createTranscription is OpenAI.Audio.createTranscription;
        createTranslation is OpenAI.Audio.createTranslation;
    }
}


