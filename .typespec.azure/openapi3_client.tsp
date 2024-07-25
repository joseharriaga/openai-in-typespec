import "./main.tsp";
import "./client.tsp";

import "@typespec/openapi3";

using TypeSpec.OpenAPI;

// the @extension decorator does not accept symbols as arguments, therefore OpenAI.CreateChatCompletionResponse is passed as a string
// Alternatively, we can decorate the method directly at the source. In my experience, some pipelines
// which are specific to a generated SDK language, don't necessarily pull packages unrelated to what 
// the specifically generate. For example, the Java Azure SDK pipeline won't have @typespec/openapi3
// available, so using elements from that package will cause the project to not compile.

// That's mainly why I am defining `openapi3_client.tsp`, so we have an entry point where we can assume
// and we explecitly state that the @typespec/openapi3 package will be available.

// Currently the project however, is making abundant usage of the `@tag` decorator, which in the Java 
// pipeline will certainly cause issues, like it was aforementioned

// I left the ad-hoc usage of the decorator commented out in the model definition, for reference.
@@extension(AzureOpenAI.AzureCreateChatCompletionResponse, "x-inherits-from-model", "OpenAI.CreateChatCompletionResponse");

