import "./main.tsp";
import "../.typespec/audio/main.tsp";

import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;

namespace OpenAI {
    @@withoutOmittedProperties(CreateChatCompletionRequest, "stream_options");
}

namespace AzureOpenAI.Client {
    
    @client({
        name: "AzureOpenAIClient",
        service: AzureOpenAI,
    })
    interface AzureOpenAIClient {
        createSpeech is OpenAI.Audio.createSpeech;
    }
}
