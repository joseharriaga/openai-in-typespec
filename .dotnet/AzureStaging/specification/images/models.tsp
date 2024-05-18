import "../common";
import "../../../../images";

using OpenAI;

namespace AzureOpenAI;

model AzureImage extends Image {
  prompt_filter_results: AzureContentFilterImagePromptResults;
  content_filter_results: AzureContentFilterImageResponseResults;
}