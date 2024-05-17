import "../../../../chat";

using OpenAI;

namespace AzureOpenAI;

model AzureCreateChatCompletionResponse extends CreateChatCompletionResponse {
  prompt_filter_results?: {
    prompt_index: int32;
    content_filter_results: {
      ...AzureContentFilterResultCommon;
      jailbreak: AzureContentFilterDetectionResult;
    }[];
  }[];
}

model AzureChatCompletionResponseMessage extends ChatCompletionResponseMessage {
  context?: {
    intent?: string;
    citations?: {
      content: string;
      title?: string;
      url?: string;
      filepath?: string;
      chunk_id?: string;
    }[];
  };
}

model AzureContentFilterResult {
  severity: "safe" | "low" | "medium" | "high";
  filtered: boolean;
}

model AzureContentFilterDetectionResult {
  detected: boolean;
  filtered: boolean;
}

model AzureContentFilterCitedDetectionResult {
  ...AzureContentFilterDetectionResult;
  license: string;
  url?: url;
}

model AzureContentFilterBlocklistIdResult {
  id: string;
  filtered: boolean;
}

alias AzureContentFilterResultCommon = {
  sexual?: AzureContentFilterResult;
  violence?: AzureContentFilterResult;
  hate?: AzureContentFilterResult;
  selfHarm?: AzureContentFilterResult;
  profanity?: AzureContentFilterDetectionResult;
  customBlocklists?: AzureContentFilterBlocklistIdResult[];

  @doc("""
    Describes an error returned if the content filtering system is
    down or otherwise unable to complete the operation in time.
    """)
  error?: Record<unknown>;
};

model AzureContentFilterResultForChoice {
  ...AzureContentFilterResultCommon;
  protected_material_text?: AzureContentFilterDetectionResult;
  protected_material_code?: AzureContentFilterCitedDetectionResult;
}
