import "../common";
import "../../.typespec/assistants";

using OpenAI;

namespace AzureOpenAI;

model BingSearchToolDefinition extends OpenAI.AssistantToolDefinition {
  @doc("""
    The type of tool being defined: `browser`
    """)
  type: "browser";

  browser?: {
    @doc("""
      The resource ID of the Bing Search resource to use.
      """)
    bing_resource_id: string;
  };
}
