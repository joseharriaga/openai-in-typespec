namespace AzureOpenAI;

model AzureContentFilterSeverityResult {
  filtered: boolean;
  severity: "safe" | "low" | "medium" | "high";
}

model AzureContentFilterDetectionResult {
  filtered: boolean;
  detected: boolean;
}

model AzureContentFilterBlocklistIdResult {
  id: string;
  filtered: boolean;
}

alias AzureContentFilterCategoriesBase = {
  sexual?: AzureContentFilterSeverityResult;
  violence?: AzureContentFilterSeverityResult;
  hate?: AzureContentFilterSeverityResult;
  self_harm?: AzureContentFilterSeverityResult;
  profanity?: AzureContentFilterDetectionResult;
  custom_blocklists?: AzureContentFilterBlocklistResult;
  error: {
    code: string;
    message: string;
  };
};

model AzureContentFilterBlocklistResult {
  filtered: boolean;
  details?: {
    filtered: boolean;
    id: string;
  }[];
}

model AzureContentFilterResultForPrompt {
  prompt_index?: int32;
  content_filter_results?: {
    ...AzureContentFilterCategoriesBase;
    jailbreak: AzureContentFilterDetectionResult;
    indirect_attack: AzureContentFilterDetectionResult;
  };
}

model AzureContentFilterResultForChoice {
  ...AzureContentFilterCategoriesBase;
  protected_material_text?: AzureContentFilterDetectionResult;
  protected_material_code?: {
    ...AzureContentFilterDetectionResult;
    citation?: {
      license?: string;
      URL?: url;
    };
  };
}

model AzureContentFilterImageResponseResults {
  sexual?: AzureContentFilterSeverityResult;
  violence?: AzureContentFilterSeverityResult;
  hate?: AzureContentFilterSeverityResult;
  self_harm?: AzureContentFilterSeverityResult;
}

model AzureContentFilterImagePromptResults
  extends AzureContentFilterImageResponseResults {
  profanity?: AzureContentFilterDetectionResult;
  custom_blocklists?: AzureContentFilterBlocklistResult;
  jailbreak: AzureContentFilterDetectionResult;
}
