import "./models.rai.tsp";

namespace AzureOpenAI;

model AzureOpenAIError<T> {
  code?: int32;
  message?: string;
  param?: string;
  type?: string;
  inner_error?: {
    code?: "ResponsibleAIPolicyViolation";
    revised_prompt?: string;
    content_filter_results?: T;
  };
}

model AzureOpenAIChatError
  is AzureOpenAIError<AzureContentFilterResultForPrompt>;
model AzureOpenAIDalleError
  is AzureOpenAIError<AzureContentFilterImagePromptResults>;

model AzureOpenAIErrorResponse<T> {
  error?: T;
}
