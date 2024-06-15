import "./models.rai.tsp";

namespace AzureOpenAI;

/** The details of an error resulting from an Azure OpenAI service request. */
model AzureOpenAIError<T> {
  /** The distinct, machine-generated identifier for the error. */
  code?: string;

  /** A human-readable message associated with the error. */
  message?: string;

  /** If applicable, the request input parameter associated with the error */
  param?: string;

  /** If applicable, the input line number associated with the error. */
  type?: string;

  /** If applicable, an upstream error that originated this error. */
  inner_error?: {
    /** The code associated with the inner error. */
    code?: "ResponsibleAIPolicyViolation";

    /** If applicable, the modified prompt used for generation. */
    revised_prompt?: string;

    /** The content filter result details associated with the inner error. */
    content_filter_results?: T;
  };
}

/** A structured representation of an error an Azure OpenAI request. */
model AzureOpenAIErrorResponse<T> {
  error?: T;
}

/** The structured representation of an error from an Azure OpenAI chat completion request. */
model AzureOpenAIChatError
  is AzureOpenAIError<AzureContentFilterResultForPrompt>;

/** The structured representation of an error from an Azure OpenAI image generation request. */
model AzureOpenAIDalleError
  is AzureOpenAIError<AzureContentFilterImagePromptResults>;
