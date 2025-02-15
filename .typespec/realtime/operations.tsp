import "../common";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

interface Realtime {
  @route("realtime")
  @tag("Realtime")
  @summary("Starts a real-time conversation session.")
  startRealtimeSession(
    ...RealtimeBetaHeader,
    @body requestMessages: RealtimeClientEvent[],
  ): RealtimeServerEvent[];
}

alias RealtimeBetaHeader = {
  @header("OpenAI-Beta") openAIBeta: "realtime=v1";
};
