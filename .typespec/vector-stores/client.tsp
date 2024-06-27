import "@azure-tools/typespec-client-generator-core";
import "./custom.tsp";
import "./models.tsp";

using Azure.ClientGenerator.Core;
using OpenAI;

@@access(FileChunkingStrategyResponseParam, Access.public);
@@usage(FileChunkingStrategyResponseParam, Usage.input | Usage.output);

// TODO: Auto should only be an input.
@@access(AutoChunkingStrategyResponseParam, Access.public);
@@usage(AutoChunkingStrategyResponseParam, Usage.input | Usage.output);