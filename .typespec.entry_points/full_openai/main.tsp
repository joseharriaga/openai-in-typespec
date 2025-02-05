import "@typespec/http";
import "@typespec/openapi3";
import "@typespec/openapi";

import "../../.typespec/administration";
import "../../.typespec/audio";
import "../../.typespec/assistants";
import "../../.typespec/batch";
import "../../.typespec/chat";
import "../../.typespec/completions";
import "../../.typespec/embeddings";
import "../../.typespec/files";
import "../../.typespec/fine-tuning";
import "../../.typespec/images";
import "../../.typespec/messages";
import "../../.typespec/models";
import "../../.typespec/moderations";
import "../../.typespec/realtime";
import "../../.typespec/runs";
import "../../.typespec/threads";
import "../../.typespec/vector-stores";
import "../../.typespec/uploads";

using TypeSpec.Http;

/** The OpenAI REST API. Please see https://platform.openai.com/docs/api-reference for more details. */
@service({
  title: "OpenAI API",
  termsOfService: "https://openai.com/policies/terms-of-use",
  contact: {
    name: "OpenAI Support",
    url: "https://help.openai.com",
  },
  license: {
    name: "MIT",
    url: "https://github.com/openai/openai-openapi/blob/master/LICENSE",
  },
})
@server("https://api.openai.com/v1", "OpenAI Endpoint")
@useAuth(BearerAuth)
namespace OpenAI;
