import "@typespec/http";
import "@typespec/openapi3";
import "@typespec/openapi";
import "@typespec/versioning";

import "../../.typespec.azure/assistants";
import "../../.typespec.azure/chat";
import "../../.typespec.azure/files";
import "../../.typespec.azure/images";
import "../../.typespec.azure/runs";
import "../../.typespec.azure/messages";

using TypeSpec.Http;
using TypeSpec.Versioning;

@service({
  title: "Azure OpenAI Service",
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
@server(
  "{endpoint}/openai",
  "Azure OpenAI APIs for completions and search",
  {
    @doc("""
      Supported Cognitive Services endpoints (protocol and hostname, for example:
      https://westus.api.cognitive.microsoft.com).
      """)
    endpoint: string,
  }
)
@useAuth(
  ApiKeyAuth<ApiKeyLocation.header, "api-key"> | OAuth2Auth<[
    {
      type: OAuth2FlowType.implicit,
      authorizationUrl: "https://login.microsoftonline.com/common/oauth2/v2.0/authorize",
      scopes: ["https://cognitiveservices.azure.com/.default"],
    }
  ]>
)
@versioned(AzureOpenAI.AzureOpenAIServiceApiVersion)
namespace AzureOpenAI;

/**
 * Known service API versions for Azure OpenAI.
 */
enum AzureOpenAIServiceApiVersion {
  /**
   * The 2024-06-01 (stable) service API version label.
   */
  v2024_06_01: "2024-06-01",

  /**
   * The 2024-08-01-preview service API version label.
   */
  v2024_08_01_preview: "2024-08-01-preview",

  /**
   * The 2024-09-01-preview service API version label.
   */
  v2024_09_01_preview: "2024-09-01-preview",

  /**
   * The 2024-10-01-preview service API version label.
   */
  v2024_10_01_preview: "2024-10-01-preview",

  /**
   * The 2024-10-21 (stable) service API version label.
   */
  v2024_10_21: "2024-10-21",
}
