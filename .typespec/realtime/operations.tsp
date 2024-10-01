import "./models/requests.tsp";
import "./models/responses.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI.Realtime;

@route("realtime")
@tag("Realtime")
@summary("Starts a real-time conversation session.")
op startRealtimeSession(
  @body requestMessages: RealtimeRequestCommand[],
): RealtimeResponseCommand[];
