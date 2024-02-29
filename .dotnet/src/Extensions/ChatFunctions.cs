using OpenAI.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace OpenAI.Chat;

/// <summary> The service client for the OpenAI Chat Completions endpoint. </summary>
public class ChatFunctions
{
    static readonly BinaryData s_noparams = BinaryData.FromString("""{ "type" : "object", "properties" : {} }""");

    readonly Dictionary<string, MethodInfo> _methods = new Dictionary<string, MethodInfo>();
    readonly List<ChatToolDefinition> _definitions = new List<ChatToolDefinition>();

    /// <summary>
    /// TBD.
    /// </summary>
    /// <param name="functions"></param>
    public ChatFunctions(params Type[] functions)
    {
        foreach (var functionHolder in functions) Add(functionHolder);
    }

    public IList<ChatToolDefinition> Definitions => _definitions;

    public void Add(Type functions)
    {
        foreach (MethodInfo function in functions.GetMethods(BindingFlags.Public | BindingFlags.Static))
        {
            Add(function);
        }
    }
    public void Add(MethodInfo function)
    {
        var name = MethodInfoToName(function);
        var tool = new ChatFunctionToolDefinition(name);
        tool.Parameters = ParametersToJson(function.GetParameters());
        tool.Description = MethodInfoToDescription(function);

        _definitions.Add(tool);
        _methods[name] = function;
    }

    public string Call(string name, object[] arguments)
    {
        MethodInfo method = _methods[name];
        object result = method.Invoke(null, arguments);
        return result.ToString();
    }
    public string Call(ChatFunctionToolCall call)
    {
        var arguments = new List<object>();
        if (call.Arguments != "{}")
        {
            var document = JsonDocument.Parse(call.Arguments);
            var json = document.RootElement;
            foreach (JsonProperty argument in json.EnumerateObject())
            {
                var value = argument.Value;
                switch (value.ValueKind)
                {
                    case JsonValueKind.String: arguments.Add(value.GetString()!); break;
                    case JsonValueKind.Number: arguments.Add(value.GetDouble()); break;
                    case JsonValueKind.True: arguments.Add(true); break;
                    case JsonValueKind.False: arguments.Add(false); break;
                    default: throw new NotImplementedException();
                }
            }
        }
        var name = call.Name;
        var result = Call(name, arguments.ToArray());
        return result;
    }

    public IEnumerable<ChatRequestToolMessage> CallAll(IEnumerable<ChatToolCall> toolCalls)
    {
        var messages = new List<ChatRequestToolMessage>();
        foreach (ChatToolCall toolCall in toolCalls)
        {
            ChatFunctionToolCall functionToolCall = toolCall as ChatFunctionToolCall;
            var result = Call(functionToolCall);
            messages.Add(new ChatRequestToolMessage(toolCall.Id, result));
        }
        return messages;
    }
    protected virtual string MethodInfoToDescription(MethodInfo function)
    {
        var description = function.Name;
        var attribute = function.GetCustomAttribute<DescriptionAttribute>();
        if (attribute!=null)
        {
            description = attribute.Description;
        }
        return description;
    }
    protected virtual string ParameterInfoToDescription(ParameterInfo parameter)
    {
        var description = parameter.Name;
        var attribute = parameter.GetCustomAttribute<DescriptionAttribute>();
        if (attribute!=null)
        {
            description = attribute.Description;
        }
        return description;
    }
    protected virtual string MethodInfoToName(MethodInfo function)
    {
        var sb = new StringBuilder();
        sb.Append(function.Name);
        foreach (var parameter in function.GetParameters())
        {
            sb.Append($"_{ClrToJsonTypeUtf16(parameter.ParameterType)}");
        }
        return sb.ToString();
    }
    protected ReadOnlySpan<byte> ClrToJsonTypeUtf8(Type clrType)
    {
        if (clrType == typeof(double)) return "number"u8;
        if (clrType == typeof(string)) return "string"u8;
        if (clrType == typeof(bool)) return "bool"u8;
        else throw new NotImplementedException();
    }
    protected string ClrToJsonTypeUtf16(Type clrType)
    {
        if (clrType == typeof(double)) return "number";
        if (clrType == typeof(string)) return "string";
        if (clrType == typeof(bool)) return "bool";
        else throw new NotImplementedException();
    }
    private BinaryData ParametersToJson(ParameterInfo[] parameters)
    {
        if (parameters.Length == 0) return s_noparams;

        var required = new List<string>();
        MemoryStream stream = new MemoryStream();
        var writer = new Utf8JsonWriter(stream);
        writer.WriteStartObject();
        writer.WriteString("type"u8, "object"u8);
        writer.WriteStartObject("properties"u8);
        foreach (ParameterInfo parameter in parameters)
        {
            writer.WriteStartObject(parameter.Name!);
            writer.WriteString("type"u8, ClrToJsonTypeUtf8(parameter.ParameterType));
            writer.WriteString("description"u8, ParameterInfoToDescription(parameter));
            writer.WriteEndObject();
            required.Add(parameter.Name!);
        }
        writer.WriteEndObject(); // properties
        writer.WriteStartArray("required");
        foreach (string requiredParameter in required)
        {
            writer.WriteStringValue(requiredParameter);
        }
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Flush();
        stream.Position = 0;
        return BinaryData.FromStream(stream);
    }
}
