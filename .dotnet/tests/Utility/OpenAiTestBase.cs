#nullable enable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenAI.Assistants;
using OpenAI.Audio;
using OpenAI.Batch;
using OpenAI.Chat;
using OpenAI.Embeddings;
using OpenAI.Files;
using OpenAI.Images;
using OpenAI.TestFramework;
using OpenAI.TestFramework.Recording.Proxy;
using OpenAI.TestFramework.Recording.Proxy.Service;
using OpenAI.TestFramework.Recording.RecordingProxy;
using OpenAI.TestFramework.Recording.Sanitizers;
using OpenAI.TestFramework.Utils;
using OpenAI.VectorStores;

namespace OpenAI.Tests.Utility;

public class OpenAiTestBase : RecordedClientTestBase
{
    private const string KEY_ENV = "OPENAI_API_KEY";
    private const string SMALL_1x1_PNG = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAIAAACQd1PeAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAFiQAABYkAZsVxhQAAAAMSURBVBhXY2BgYAAAAAQAAVzN/2kAAAAASUVORK5CYII=";

    public OpenAiTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
    {
        TestEnvironment = new();

        TestCredential = Mode switch
        {
            RecordedTestMode.Playback => new ApiKeyCredential("FAKE_API_KEY"),
            _ => new ApiKeyCredential(Environment.GetEnvironmentVariable(KEY_ENV)
                ?? throw new InvalidOperationException($"{KEY_ENV} environment variable was not set"))
        };

        // Remove some of the default sanitizers to customize their behaviour
        RecordingOptions.SanitizersToRemove.AddRange(
        [
            "AZSDK4001", // Masks the host name in URL
            "AZSDK3430", // OpenAI liberally uses "id" in its JSON responses, and we want to keep them in the recordings
            "AZSDK3493", // $..name in JSON. OpenAI uses this for things that don't need to be sanitized
            "AZSDK3431", // $..token in JSON. OpenAI uses this to identify log probabilities
        ]);

        // Sanitize some request and/or response headers to prevent details from leaking into recordings
        RecordingOptions.SanitizeHeaders(
            "openai-organization",
            "X-Request-ID");

        // Because the current implementation of multi-part form content data in OpenAI and Azure OpenAI uses random
        // to generate boundaries, this causes problems during playback as the boundary will be different each time.
        // Longer term, we should find a way to pass the TestRecording.Random to the multi-part form generator in the
        // code. The simplest solution for now is to disable recording the body for these mime types
        RecordingOptions.RequestOverride = request =>
        {
            if (request?.Headers.GetFirstOrDefault("Content-Type")?.StartsWith("multipart/form-data") == true)
            {
                return RequestRecordMode.RecordWithoutRequestBody;
            }

            return RequestRecordMode.Record;
        };
        RecordingOptions.Sanitizers.Add(new HeaderRegexSanitizer("Content-Type")
        {
            Regex = @"multipart/form-data; boundary=[^\s]+",
            Value = "multipart/form-data; boundary=***"
        });

        // Data URIs trimmed to prevent the recording from being too large
        RecordingOptions.Sanitizers.Add(new BodyKeySanitizer("$..url")
        {
            Regex = @"(?<=data:image/png;base64,)(.+)",
            Value = SMALL_1x1_PNG
        });

        // Base64 encoded images in the response are replaced with a 1x1 black pixel PNG image to reduce recording size
        RecordingOptions.Sanitizers.Add(new BodyKeySanitizer($"..b64_json")
        {
            Value = SMALL_1x1_PNG
        });

        // Sanitize returned image URLs
        RecordingOptions.Sanitizers.Add(new BodyKeySanitizer("$..url")
        {
            Regex = @"https?://.+",
            Value = "https://sanitized/generated/image.png"
        });
    }

    public OpenAiTestBase(bool isAsync, string defaultModel, RecordedTestMode? mode = null) : this(isAsync, mode)
    {
        DefaultModel = defaultModel;
    }

    TestEnvironment TestEnvironment { get; }

    public string? DefaultModel { get; }

    public ApiKeyCredential TestCredential { get; }

    public virtual OpenAIClient GetTestTopLevel(ApiKeyCredential? credential = null, OpenAIClientOptions? options = null)
    {
        credential ??= TestCredential;

        options ??= new();
        options.AddPolicy(new TestPipelinePolicy(DumpMessage), PipelinePosition.PerTry);
        options = ConfigureClientOptions(options);

        OpenAIClient topLevel = new(credential, options);
        return topLevel;
    }

    public virtual TClient GetTestClient<TClient>(string? model = null, ApiKeyCredential? credential = null, OpenAIClientOptions? options = null)
    {
        OpenAIClient topLevel = GetTestTopLevel(credential, options);
        return GetTestClient<TClient>(topLevel, model);
    }

    public virtual TOther GetTestClientFrom<TOther>(object client, string? model = null)
    {
        var topLevel = (OpenAIClient?)GetClientContext(client);
        if (topLevel == null)
        {
            throw new NotSupportedException(
                "The client provided was not properly wrapped for automatic sync/async. Please make sure to get your test client " +
                "instances using the GetTestClient() methods");
        }

        return GetTestClient<TOther>(topLevel, model);
    }

    public virtual TimeSpan GetTimeout(TimeSpan timeout)
        => TimeSpan.FromMilliseconds(GetTimeout((int)Math.Ceiling(timeout.TotalMilliseconds)));

    public virtual int GetTimeout(int timeoutInMs)
    {
        if (Mode == RecordedTestMode.Playback)
        {
            return 10;
        }

        return timeoutInMs;
    }

    protected virtual TClient GetTestClient<TClient>(OpenAIClient topLevel, string? model = null)
    {
#pragma warning disable OPENAI001
        object client = typeof(TClient).Name switch
        {
            nameof(AssistantClient) => topLevel.GetAssistantClient(),
            nameof(AudioClient) => topLevel.GetAudioClient(model ?? DefaultModel ?? "whisper-1"),
            nameof(BatchClient) => topLevel.GetBatchClient(),
            nameof(ChatClient) => topLevel.GetChatClient(model ?? DefaultModel ?? "gpt-4o-mini"),
            nameof(EmbeddingClient) => topLevel.GetEmbeddingClient(model ?? "text-embedding-3-small"),
            nameof(FileClient) => topLevel.GetFileClient(),
            nameof(ImageClient) => topLevel.GetImageClient(model ?? DefaultModel ?? "dall-e-3"),
            nameof(VectorStoreClient) => topLevel.GetVectorStoreClient(),
            _ => throw new NotImplementedException(),
        };
#pragma warning restore OPENAI001

        object wrappedForSyncAsync = WrapClient(typeof(TClient), client, topLevel, null);
        return (TClient)wrappedForSyncAsync;
    }

    protected override RecordedTestMode GetDefaultRecordedTestMode()
    {
        string? modeString = TestContext.Parameters["TestMode"]
            ?? Environment.GetEnvironmentVariable("OPENAI_TEST_MODE")
            ?? Environment.GetEnvironmentVariable("AZURE_TEST_MODE");

        if (Enum.TryParse(modeString, true, out RecordedTestMode mode))
        {
            return mode;
        }

        return RecordedTestMode.Playback;
    }

    protected override ProxyServiceOptions CreateProxyServiceOptions()
        => new()
        {
            DotnetExecutable = TestEnvironment.DotNetExe.FullName,
            TestProxyDll = TestEnvironment.TestProxyDll.FullName,
            DevCertFile = TestEnvironment.TestProxyHttpsCert.FullName,
            DevCertPassword = TestEnvironment.TestProxyHttpsCertPassword,
            StorageLocationDir = TestEnvironment.TestRecordingsDirectory?.FullName
                ?? TestEnvironment.RepoRoot.FullName
        };

    protected override RecordingStartInformation CreateRecordingSessionStartInfo()
    {
        Type type = GetType();

        string baseDir;

        if (TestEnvironment.TestRecordingsDirectory != null)
        {
            baseDir = TestEnvironment.TestRecordingsDirectory.FullName;
        }
        else
        {
            DirectoryInfo? sourceRoot = AssemblyHelper.GetAssemblySourceDir(type.Assembly);
            baseDir = PathHelpers.GetRelativePath(
                TestEnvironment.RepoRoot.FullName,
                sourceRoot?.FullName ?? TestEnvironment.SourceRoot.FullName);
        }

        string recordingFile = Path.Combine(
            baseDir,
            "SessionRecords",
            type.Name,
            GetRecordedTestFileName());

        return new()
        {
            RecordingFile = recordingFile,
            AssetsFile = TestEnvironment.TestRecordingConfig?.FullName
        };
    }

    private static void DumpMessage(PipelineMessage? message)
    {
        Console.WriteLine($"--- New request ---");
        IEnumerable<string> headerPairs = message?.Request?.Headers?.Select(header => $"{header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}")
            ?? Array.Empty<string>();
        string headers = string.Join(',', headerPairs);
        Console.WriteLine($"Headers: {headers}");
        Console.WriteLine($"{message?.Request?.Method} URI: {message?.Request?.Uri}");
        if (message?.Request?.Content != null)
        {
            string? contentType = "Unknown Content Type";
            if (message.Request.Headers?.TryGetValue("Content-Type", out contentType) == true
                && contentType == "application/json")
            {
                using MemoryStream stream = new();
                message.Request.Content.WriteTo(stream, default);
                stream.Position = 0;
                using StreamReader reader = new(stream);
                Console.WriteLine(reader.ReadToEnd());
            }
            else
            {
                string length = message.Request.Content.TryComputeLength(out long numberLength)
                        ? $"{numberLength} bytes"
                        : "unknown length";
                Console.WriteLine($"<< Non-JSON content: {contentType} >> {length}");
            }
        }
        if (message?.Response != null)
        {
            Console.WriteLine("--- Begin response content ---");
            Console.WriteLine(message.Response.Content?.ToString());
            Console.WriteLine("--- End of response content ---");
        }
    }
}
