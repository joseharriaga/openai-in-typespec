import "./main.tsp";
import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;


namespace OpenAI {
    @@withoutOmittedProperties(CreateChatCompletionRequest, "stream_options");
}

namespace AzureOpenAI {
}


