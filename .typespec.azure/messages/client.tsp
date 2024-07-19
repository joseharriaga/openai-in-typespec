import "@azure-tools/typespec-client-generator-core";
import "./models.tsp";

using Azure.ClientGenerator.Core;

namespace AzureOpenAI;

@@access(MessageContentTextAnnotationsBingSearchUrlCitation, Access.public);
@@usage(MessageContentTextAnnotationsBingSearchUrlCitation, Usage.output);

@@access(MessageDeltaContentTextAnnotationsBingSearchUrlCitation,
  Access.public
);
@@usage(MessageDeltaContentTextAnnotationsBingSearchUrlCitation, Usage.output);
