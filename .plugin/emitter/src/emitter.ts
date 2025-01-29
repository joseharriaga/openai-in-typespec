import { EmitContext } from "@typespec/compiler";

import {
    $onEmit as $OnMGCEmit,
    NetEmitterOptions
} from "@typespec/http-client-csharp";

export async function $onEmit(context: EmitContext<NetEmitterOptions>) {
    context.options["plugin-name"] = "OpenAILibraryPlugin";
    context.options["emitter-extension-path"] = import.meta.url;
    await $OnMGCEmit(context);
}