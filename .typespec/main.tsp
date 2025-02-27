import "@typespec/http";
import "@typespec/openapi";

import "./administration";
import "./audio";
import "./assistants";
import "./batch";
import "./chat";
import "./completions";
import "./embeddings";
import "./files";
import "./fine-tuning";
import "./images";
import "./messages";
import "./models";
import "./moderations";
import "./realtime";
import "./runs";
import "./threads";
import "./vector-stores";
import "./uploads";

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
