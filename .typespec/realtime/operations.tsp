import "./models.tsp";

using TypeSpec.Http;

namespace OpenAI;

interface Realtime {
  @route("realtime")
  @tag("Realtime")
  @summary("Starts a real-time conversation session.")
  startRealtimeSession(
    @body requestMessages: RealtimeClientEvent[],
  ): RealtimeServerEvent[];
}
