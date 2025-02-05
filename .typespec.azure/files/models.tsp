import "@typespec/versioning";
// import "../main.tsp";
import "../../.typespec/files/models.tsp";

using TypeSpec.OpenAPI;
using TypeSpec.Versioning;

namespace AzureOpenAI;

@withoutOmittedProperties("status")
@added(AzureOpenAIServiceApiVersion.v2024_10_21)
model OpenAIFileWithOmittedProperties is OpenAI.OpenAIFile;

@added(AzureOpenAIServiceApiVersion.v2024_10_21)
model AzureOpenAIFile {
  ...OpenAIFileWithOmittedProperties;
  status:
    | "uploaded"
    | "pending"
    | "running"
    | "processed"
    | "error"
    | "deleting"
    | "deleted";
}
