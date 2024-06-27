import "./main.tsp";
import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;
using OpenAI;

@@clientName(ModifyAssistantRequest, "AssistantModificationOptions", "csharp");
@@clientName(ModifyAssistantRequest.tools, "defaultTools", "csharp");
@@clientName(ModifyAssistantRequest.top_p, "nucleusSamplingFactor", "csharp");
