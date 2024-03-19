using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAI;

// SSE specification: https://html.spec.whatwg.org/multipage/server-sent-events.html#parsing-an-event-stream
internal readonly struct ServerSentEvent
{
    public ReadOnlyMemory<char> EventName { get; }
    public ReadOnlyMemory<char> Data { get; }
    public ReadOnlyMemory<char> LastEventId { get; }
    public TimeSpan? ReconnectionTime { get; }

    private readonly IReadOnlyList<ServerSentEventField> _fields;
    private readonly string _multiLineData;

    internal ServerSentEvent(IReadOnlyList<ServerSentEventField> fields)
    {
        _fields = fields;
        StringBuilder multiLineDataBuilder = null;
        for (int i = 0; i < _fields.Count; i++)
        {
            ReadOnlyMemory<char> fieldValue = _fields[i].Value;
            switch (_fields[i].FieldType)
            {
                case ServerSentEventFieldKind.Event:
                    EventName = fieldValue;
                    break;
                case ServerSentEventFieldKind.Data:
                    {
                        if (multiLineDataBuilder != null)
                        {
                            multiLineDataBuilder.Append(fieldValue);
                        }
                        else if (Data.IsEmpty)
                        {
                            Data = fieldValue;
                        }
                        else
                        {
                            multiLineDataBuilder ??= new();
                            multiLineDataBuilder.Append(fieldValue);
                            Data = null;
                        }
                        break;
                    }
                case ServerSentEventFieldKind.Id:
                    LastEventId = fieldValue;
                    break;
                case ServerSentEventFieldKind.Retry:
                    ReconnectionTime = Int32.TryParse(fieldValue.ToString(), out int retry) ? TimeSpan.FromMilliseconds(retry) : null;
                    break;
                default:
                    break;
            }
            if (multiLineDataBuilder != null)
            {
                _multiLineData = multiLineDataBuilder.ToString();
                Data = _multiLineData.AsMemory();
            }
        }
    }
}