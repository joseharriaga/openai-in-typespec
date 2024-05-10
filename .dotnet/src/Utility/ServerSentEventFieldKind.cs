namespace OpenAI;

// SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html
internal enum ServerSentEventFieldKind
{
    Ignore,
    Event,
    Data,
    Id,
    Retry,
}
