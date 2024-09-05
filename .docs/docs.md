# Docs / samples for openai.com

## The main quickstart (https://platform.openai.com/docs/quickstart)

> JonathanCrd

### Make your first API request

```csharp
dotnet add package OpenAI
```

### Generate text

```csharp
using OpenAI;
using OpenAI.Chat;

ChatClient chatClient = new OpenAIClient().GetChatClient(model: "gpt-4o-mini");

List<ChatMessage> messages =
[
    new SystemChatMessage("You are a helpful assistant."),
    new UserChatMessage("Write a haiku about recursion in programming.")
];

ChatCompletion completion = chatClient.CompleteChat(messages);

Console.WriteLine(completion);
```

### Generate an image

```csharp
using OpenAI;
using OpenAI.Images;

ImageClient imageClient = new OpenAIClient().GetImageClient("dall-e-3");

GeneratedImage image = imageClient.GenerateImage("A cute baby sea otter");

Console.WriteLine($"Image URL: {image.ImageUri}");
```

### Create vector embeddings

```csharp
using OpenAI;
using OpenAI.Embeddings;

EmbeddingClient embeddingClient = new OpenAIClient().GetEmbeddingClient("text-embedding-3-large");

Embedding embedding = embeddingClient.GenerateEmbedding("The quick brown fox jumped over the lazy dog");

Console.WriteLine(string.Join(", ", embedding.Vector.ToArray()));
```

## The guides (https://platform.openai.com/docs/guides/*)

### Text generation

> JonathanCrd

```csharp
// TODO
```

### Vision

> JonathanCrd

#### Quickstart

```csharp
// TODO
```

#### Uploading base 64 encouded images

```csharp
// TODO
```

#### Multiple image inputs

```csharp
// TODO
```

#### Low or high fidelity image understanding

```csharp
// TODO
```

### Function calling

> JonathanCrd

#### Step 1

```csharp
// TODO
```

#### Step 2 

```csharp
// TODO
```

#### Step 3 

```csharp
// TODO
```

#### Step 4a

```csharp
// TODO
```

#### Step 4b

```csharp
// TODO
```

#### Step 4c

```csharp
// TODO
```

#### Step 4d

```csharp
// TODO
```

#### Step 5

```csharp
// TODO
```

#### Handling edge cases

```csharp
// TODO
```

#### Function calling with Structured Outputs

```csharp
// TODO
```

#### Configuring parallel function calling - part1

```csharp
// TODO
```

#### Configuring parallel function calling - part2

```csharp
// TODO
```

#### Configuring function calling behavior using the tool_choice parameter

```csharp
// TODO
```

#### Use enums for function arguments when possible

```csharp
// TODO
```

### Structured Outputs

#### Introduction

```csharp
// TODO
```

#### Chain of thought

```csharp
// TODO
```

#### Structured data extraction

```csharp
// TODO
```

#### UI Generation

```csharp
// TODO
```

#### Moderation

```csharp
// TODO
```

#### Refusals with Structured Outputs

```csharp
// TODO
```

### Chat completions

*Getting started*
```csharp
using OpenAI.Chat;

ChatClient client = new(
    model: "gpt-4o",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

ChatCompletion completion = client.CompleteChat(new List<ChatMessage> {
    new SystemChatMessage("You are a helpful assistant."),
    new UserChatMessage("Who won the world series in 2020?"),
    new SystemChatMessage("The Los Angeles Dodgers won the World Series in 2020."),
    new UserChatMessage("Where was it played?")
});
```

*Extracting response*
```csharp
var message = completion.Content[0].Text;
```

### Fine-tuning

*Uploading a training file*
```csharp
using OpenAI;
using OpenAI.Files;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var fileName = "mydata.jsonl";
var file = BinaryData.FromBytes(File.ReadAllBytes(fileName));

OpenAIFileInfo fileInfo = client.GetFileClient().UploadFile(
    file,
    fileName,
    FileUploadPurpose.FineTune);

```

*Create a fine-tuned model: part 1*
```csharp
using OpenAI.FineTuning;

FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var content = BinaryContent.Create(
    BinaryData.FromObjectAsJson(new
    {
        training_file = "file_abc123", 
        model="gpt-4o-mini"
    })
);
```

*Create a fine-tuned model: part 2*
```csharp
using OpenAI.FineTuning;

FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

// List 10 fine-tuning jobs
client.GetJobs(null, 10, new RequestOptions() { });

// Retrieve the state of a fine-tune
client.GetJob("ftjob-abc123", new RequestOptions() { });

// Cancel a job
client.CancelJob("ftjob-abc123", new RequestOptions() { });

// List up to 10 events from a fine-tuning job
client.GetJobEvents("ftjob-abc123", null, 10, new RequestOptions() { });

// Delete a fine-tuned model (must be an owner of the org the model was created in)
client.DeleteModel("ft:gpt-3.5-turbo:acemeco:suffix:abc123");
```

*Use a fine-tuned model*
```csharp
using OpenAI.Chat;

ChatClient client = new(
    model: "ft:gpt-4o-mini:my-org:custom_suffix:id",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

ChatCompletion completion = client.CompleteChat(new List<ChatMessage> {
    new SystemChatMessage("You are a helpful assistant."),
    new UserChatMessage("Hello!")
});

Console.WriteLine($"[ASSISTANT]: {completion}");
```

*Iterating on hyperparameters*
```csharp
using OpenAI.FineTuning;

FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var content = BinaryContent.Create(
    BinaryData.FromObjectAsJson(new {
        training_file = "file_abc123",
        model = "gpt-4o-mini",
        hyperparameters = new { n_epochs = 2 }
    })
);

ClientResult result = client.CreateJob(content);
```

### Batch

*Uploading Your Batch Input File*
```csharp
using OpenAI;
using OpenAI.Files;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var fileName = "batchinput.jsonl";
var file = BinaryData.FromBytes(File.ReadAllBytes(fileName));

OpenAIFileInfo batchInputFile = client.GetFileClient().UploadFile(
    file,
    fileName,
    FileUploadPurpose.Batch);
```

*Creating the Batch*
```csharp
using OpenAI.Batch;
using System.Text.Json;
using System.ClientModel;

BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var content = BinaryContent.Create(
    BinaryData.FromObjectAsJson(new
    {
        input_file_id = batchInputFile.Id,
        endpoint = "/v1/chat/completions",
        completion_window = "24h", 
        metadata = { 
            description = "nightly eval job" 
        }
    })
);
```

*Checking the Status of a Batch*
```csharp
using OpenAI.Batch;

BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
var result = client.GetBatch("batch_abc123", new RequestOptions { });
```

*Retrieving the Results*
```csharp
using OpenAI;
using System.ClientModel.Primitives;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var response = client.GetFileClient().DownloadFile("file-xyz123");
var bytes = response.Value.ToArray();
var text = BitConverter.ToString(bytes);

Console.WriteLine(text);
```

*Cancelling a Batch*
```csharp
using OpenAI.Batch;
using System.ClientModel.Primitives;

BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
var result = client.GetBatch("batch_abc123", new RequestOptions { });
```

*Getting a List of All Batches*
```csharp
using OpenAI.Batch;
using System.ClientModel.Primitives;

BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
var result = client.GetBatches(null, 10, new RequestOptions {});
```

### Image generation

*Generate an image*
```csharp
using OpenAI.Images;
using System.ClientModel;

var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

var client = new ImageClient(
    "dall-e-3",
    new ApiKeyCredential(apiKey)
);

var image = client.GenerateImage(
    "A cute little sea otter.",
    new () {
        Quality = GeneratedImageQuality.Standard,
        Size = GeneratedImageSize.W1024xH1024,
    });

Console.WriteLine(image.Value.ImageUri);
```

*Edits (DALL·E 2 only)*
```csharp
using OpenAI;
using OpenAI.Images;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var image = client.GetImageClient("dall-e-2").GenerateImageEdit(
    "otter.png", 
    "A cute baby sea otter wearing a beret",
    "mask.png",
    new () { 
        Size = GeneratedImageSize.W1024xH1024 
    }
);

Console.WriteLine(image.Value.ImageUri);
```

*Variations (DALL·E 2 only)*
```csharp
using OpenAI;
using OpenAI.Images;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var image = client.GetImageClient("dall-e-2").GenerateImageVariation(
    "otter.png",
    new () { 
        Size = GeneratedImageSize.W1024xH1024 
    }
);

Console.WriteLine(image.Value.ImageUri);
```

### Text to speech

*Quickstart*
```csharp
using OpenAI.Audio;

AudioClient client = new(
    model: "tts-1", 
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

var response = client.GenerateSpeechFromText(
    "Today is a wonderful day to build something people love!", 
    GeneratedSpeechVoice.Alloy
);

string filePath = Path.Combine("speech.mp3");
using (var fileWriter = new BinaryWriter(File.Open(filePath, FileMode.Create))) {
    fileWriter.Write(response.Value);
}

```

### Speech to text

*Transcriptions: part 1*
```csharp
using OpenAI.Audio;

AudioClient client = new(
    model: "whisper-1",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

string filePath = Path.Combine("speech.mp3");
AudioTranscription transcription = client.TranscribeAudio(filePath);

Console.WriteLine($"{transcription.Text}");
```

*Transcriptions: part 2*
```csharp
using OpenAI.Audio;

AudioClient client = new(
    model: "whisper-1",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

string filePath = Path.Combine("speech.mp3");
AudioTranscription transcription = client.TranscribeAudio(filePath,
    new() {
        ResponseFormat = AudioTranscriptionFormat.Text,
    });

Console.WriteLine($"{transcription.Text}");
```

*Translations*
```csharp
using OpenAI.Audio;

AudioClient client = new(
    model: "whisper-1",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

string filePath = Path.Combine("speech.mp3");
AudioTranslation translation = client.TranslateAudio(filePath);

Console.WriteLine($"{translation.Text}");
```

*Timestamps*
```csharp
using OpenAI.Audio;

AudioClient client = new(
    model: "whisper-1",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

string filePath = Path.Combine("speech.mp3");
AudioTranscription transcription = client.TranscribeAudio(
    filePath,
    new() {
        ResponseFormat = AudioTranscriptionFormat.Verbose,
        Granularities = AudioTimestampGranularities.Word
    }
);
```

### Embeddings

```csharp
using OpenAI.Embeddings;

EmbeddingClient client = new(
    model: "text-embedding-3-small", 
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

string input = "Your text string goes here";
var respose = client.GenerateEmbedding(input);

Console.WriteLine(respose.Value.Vector);
```

### Moderation

```csharp
using OpenAI.Models;
using OpenAI.Moderations;

ModerationClient client = new(
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

var moderation = client.ClassifyTextInput("Sample text goes here.");
```


## API Reference (https://platform.openai.com/docs/api-reference/*)

### Introduction

```csharp
dotnet add package OpenAI
```

### Authentication

```csharp
using OpenAI;

OpenAIClient client = new(
    Environment.GetEnvironmentVariable("OPENAI_API_KEY"), 
    new OpenAIClientOptions()
    {
        OrganizationId = "YOUR_ORG_ID",
        ProjectId = "PROJECT_ID"
    });
```

### Making requests

```csharp
using OpenAI.Chat;

ChatClient client = new(
    model: "gpt-4o",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

ChatCompletion completion = client.CompleteChat(new List<ChatMessage> {
    new SystemChatMessage("You are a helpful assistant."),
    new UserChatMessage("Hello!")
});

Console.WriteLine($"[ASSISTANT]: {completion}");
```

### Streaming

```csharp
using OpenAI.Chat;

ChatClient client = new(
    model: "gpt-4o",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

AsyncCollectionResult<StreamingChatCompletionUpdate> updates
    = client.CompleteChatStreamingAsync(new List<ChatMessage> {
        new SystemChatMessage("You are a helpful assistant."),
        new UserChatMessage("Hello!")
    });

Console.WriteLine($"[ASSISTANT]:");
await foreach (StreamingChatCompletionUpdate update in updates) {
    foreach (ChatMessageContentPart updatePart in update.ContentUpdate) {
        Console.Write(updatePart.Text);
    }
}
```

### Audio

#### Create speech

```csharp
using OpenAI.Audio;

AudioClient client = new(
    model: "tts-1", 
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

var response = client.GenerateSpeechFromText(
    "The quick brown fox jumped over the lazy dog.", 
    GeneratedSpeechVoice.Alloy
);

string filePath = Path.Combine("speech.mp3");
using (var fileWriter = new BinaryWriter(File.Open(filePath, FileMode.Create))) {
    fileWriter.Write(response.Value);
}
```

#### Create transcription

```csharp
using OpenAI.Audio;

AudioClient client = new(
    model: "whisper-1",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

string filePath = Path.Combine("speech.mp3");
AudioTranscription transcription = client.TranscribeAudio(filePath);

Console.WriteLine($"{transcription.Text}");
```

#### Create translation

```csharp
using OpenAI.Audio;

AudioClient client = new(
    model: "whisper-1",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

string filePath = Path.Combine("speech.mp3");
AudioTranslation translation = client.TranslateAudio(filePath);

Console.WriteLine($"{translation.Text}");
```

### Chat

#### Create chat completion - Default

```csharp
using OpenAI.Chat;

ChatClient client = new(
    model: "gpt-4o",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

ChatCompletion completion = client.CompleteChat(new List<ChatMessage> {
    new SystemChatMessage("You are a helpful assistant."),
    new UserChatMessage("Hello!")
});

Console.WriteLine($"[ASSISTANT]: {completion}");
```

#### Create chat completion - Image input

```csharp
using OpenAI;
using OpenAI.Chat;

ChatClient client = new(
    model: "gpt-4o",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

ChatCompletion completion = client.CompleteChat(new List<ChatMessage> {
        new UserChatMessage(new List<ChatMessageContentPart> {
            ChatMessageContentPart.CreateTextMessageContentPart("What's in this image?"),
            ChatMessageContentPart.CreateImageMessageContentPart(
                new Uri("https://upload.wikimedia.org/wikipedia/commons/thumb/d/dd/Gfp-wisconsin-madison-the-nature-boardwalk.jpg/2560px-Gfp-wisconsin-madison-the-nature-boardwalk.jpg"))
        })
    });

Console.WriteLine($"[ASSISTANT]: {completion}");
```

#### Create chat completion - Streaming

```csharp
using System.ClientModel;
using OpenAI.Chat;

ChatClient client = new(
    model: "gpt-4o",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

AsyncCollectionResult<StreamingChatCompletionUpdate> updates
    = client.CompleteChatStreamingAsync(new List<ChatMessage> {
        new SystemChatMessage("You are a helpful assistant."),
        new UserChatMessage("Hello!")
    });

Console.WriteLine($"[ASSISTANT]:");
await foreach (StreamingChatCompletionUpdate update in updates) {
    foreach (ChatMessageContentPart updatePart in update.ContentUpdate) {
        Console.Write(updatePart.Text);
    }
}
```

#### Create chat completion - Functions

```csharp
using OpenAI.Chat;

ChatTool getCurrentLocationTool = ChatTool.CreateFunctionTool(
    functionName: nameof(GetCurrentLocation),
    functionDescription: "Get the user's current location"
);

ChatTool getCurrentWeatherTool = ChatTool.CreateFunctionTool(
    functionName: nameof(GetCurrentWeather),
    functionDescription: "Get the current weather in a given location",
    functionParameters: BinaryData.FromString("""
        {
            "type": "object",
            "properties": {
                "location": {
                    "type": "string",
                    "description": "The city and state, e.g. Boston, MA"
                },
                "unit": {
                    "type": "string",
                    "enum": [ "celsius", "fahrenheit" ],
                    "description": "The temperature unit to use. Infer this from the specified location."
                }
            },
            "required": [ "location" ]
        }
        """)
);

ChatClient client = new(
    model: "gpt-4o",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

List<ChatMessage> messages = [
    new UserChatMessage("What's the weather like today?"),
];

ChatCompletionOptions options = new()
{
    Tools = { getCurrentLocationTool, getCurrentWeatherTool },
};

ChatCompletion chatCompletion = client.CompleteChat(messages, options);
```

#### Create chat completion - Logprobs

```csharp
using OpenAI;
using OpenAI.Chat;

ChatClient client = new(
    model: "gpt-4o",
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

ChatCompletion completion = client.CompleteChat(
    new List<ChatMessage> { new UserChatMessage("Hello!") },
    new ChatCompletionOptions() { IncludeLogProbabilities = true, TopLogProbabilityCount = 2 }
);

Console.WriteLine($"[ASSISTANT]: {completion}");
```

### Embeddings

#### Create embeddings

```csharp
using OpenAI.Embeddings;

EmbeddingClient client = new(
    model: "text-embedding-3-small", 
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

string description = "The quick brown fox jumped over the lazy dog";
client.GenerateEmbedding(description);
```

### Fine-tuning

#### Create fine-tuning job

```csharp
using OpenAI.FineTuning;

FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var content = BinaryContent.Create(
    BinaryData.FromObjectAsJson(new
    {
        training_file = "file_abc123"
    })
);

ClientResult result = client.CreateJob(content);
```

#### List fine-tuning jobs

```csharp
using OpenAI.FineTuning;

FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var result = client.GetJobs(null, null, new RequestOptions() { });
```

#### List fine-tuning events

```csharp
using OpenAI.FineTuning;

FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var result = client.GetJobEvents("ftjob-abc123", null, 2, new RequestOptions() { });
```

#### List fine-tuning checkpoints

```csharp
TODO
```

#### Retrieve fine-tuning job

```csharp
using OpenAI.FineTuning;


FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
var result = client.GetJob("ftjob-abc123", new RequestOptions() { });
```

#### Cancel fine-tuning

```csharp
using OpenAI.FineTuning;

FineTuningClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
var result = client.CancelJob("ftjob-abc123", new RequestOptions() { });
```

### Batch

#### Create batch

```csharp
using OpenAI.Batch;
using System.Text.Json;
using System.ClientModel;

BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var content = BinaryContent.Create(
    BinaryData.FromObjectAsJson(new
    {
        input_file_id = "file-abc123",
        endpoint = "/v1/chat/completions",
        completion_window = "24h"
    })
);

var result = client.CreateBatch(content);
```

#### Retrieve batch

```csharp
using OpenAI.Batch;
using System.ClientModel.Primitives;

BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
var result = client.GetBatch("batch_abc123", new RequestOptions { });
```

#### Cancel batch

```csharp
using OpenAI.Batch;
using System.ClientModel.Primitives;

BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
var result = client.GetBatch("batch_abc123", new RequestOptions { });
```

#### List batch

```csharp
using OpenAI.Batch;
using System.ClientModel.Primitives;

BatchClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
var result = client.GetBatches(null, null, new RequestOptions {});
```

### Files

#### Upload file

```csharp
using OpenAI;
using OpenAI.Files;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var fileName = "monthly_sales.json";
var file = BinaryData.FromBytes(File.ReadAllBytes(fileName));

OpenAIFileInfo fileInfo = client.GetFileClient().UploadFile(
    file,
    fileName,
    FileUploadPurpose.FineTune);

```

#### List files

```csharp
using OpenAI;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var files = client.GetFileClient().GetFiles();
foreach (var file in files.Value) {
    Console.WriteLine($"{file.Filename} ({file.Id})");
}
```

#### Retrieve file

```csharp
using OpenAI;
using OpenAI.Files;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var file = client.GetFileClient().GetFile("file-abc123");
Console.WriteLine($"{file.Value.Filename} ({file.Value.Id})");
```

#### Delete file

```csharp
using OpenAI;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var fileContents = client.GetFileClient().DeleteFile("file-abc123");
```

### Images

#### Create image

```csharp
using OpenAI;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var image = client.GetImageClient("dall-e-3").GenerateImage("A cute little sea otter.");
Console.WriteLine(image.Value.ImageUri);
```

#### Create image edit

```csharp
using OpenAI;
using OpenAI.Images;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var image = client.GetImageClient("dall-e-2").GenerateImageEdit(
    "otter.png", 
    "A cute baby sea otter wearing a beret",
    "mask.png"
);

Console.WriteLine(image.Value.ImageUri);
```

#### Create image variation

```csharp
using OpenAI;

OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

var image = client.GetImageClient("dall-e-2").GenerateImageVariation("otter.png");
Console.WriteLine(image.Value.ImageUri);
```

### Models

#### List models

```csharp
using OpenAI.Models;

ModelClient client = new(
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

foreach (var model in client.GetModels().Value) {
    Console.WriteLine(model.Id);
}
```

#### Retrieve model

```csharp
using OpenAI.Models;

ModelClient client = new(
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

var model = client.GetModel("babbage-002");
Console.WriteLine(model.Value.Id);
```

#### Delete a fine-tuned model

```csharp
using OpenAI.Models;

ModelClient client = new(
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

var success = client.DeleteModel("ft:gpt-4o-mini:acemeco:suffix:abc123");
Console.WriteLine(success);
```

### Moderations

#### Create moderation

```csharp
using OpenAI.Moderations;

ModerationClient client = new(
    Environment.GetEnvironmentVariable("OPENAI_API_KEY")
);

var moderation = client.ClassifyTextInput("I want to kill them.");
```

### Assistants

#### Create assistant

*Code interpreter*
```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

Assistant assistant = assistantClient.CreateAssistant(
    model: "gpt-4o",
    new AssistantCreationOptions()
    {   Name = "Math Tutor",
        Instructions = "You are a personal math tutor. When asked a question, write and run .NET code to answer the question.",
        Tools = { new CodeInterpreterToolDefinition() }
    });
```

*Files*
```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

Assistant assistant = assistantClient.CreateAssistant(
    model: "gpt-4o",
    new AssistantCreationOptions()
    {   Name = "Math Tutor",
        Instructions = "You are a personal math tutor. When asked a question, write and run .NET code to answer the question.",
        Tools = { new FileSearchToolDefinition() },
        ToolResources = new() { FileSearch = new() { NewVectorStores = {new VectorStoreCreationHelper(["vs_123"])}}}
    });
```

#### List assistants

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI;
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
assistantClient.GetAssistants(new AssistantCollectionOptions()
{
    Order = ListOrder.OldestFirst,
    PageSize = 20
});
```

NOTE / TODO: The python samples have 'limit' is that the same property conceptually as 'PageSize'?

#### Retrieve assistant

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var response = assistantClient.GetAssistant("asst_abc123");
Console.WriteLine(response.Value.Id);
```

#### Modify assistant

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var response = assistantClient.ModifyAssistant(
    "asst_abc123",
    new AssistantModificationOptions()
    {
        Instructions = "You are an HR bot, and you have access to files to answer employee questions about company policies. Always response with info from either of the files.",
        Name = "HR Helper",
        Model = "gpt-4o",
        DefaultTools = { new FileSearchToolDefinition() }
    });
Console.WriteLine(response.Value.Id);
```

#### Delete assistant

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var response = assistantClient.DeleteAssistant("asst_abc123");
Console.WriteLine(response.Value);
```

### Threads

#### Create thread

*Empty*
```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var emptyThread = assistantClient.CreateThread();
Console.WriteLine(emptyThread.Value.Id);
```

*Messages*
```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var thread = assistantClient.CreateThread(new ThreadCreationOptions()
{
    InitialMessages = {
        "Hello, what is AI?",
        "How does AI work? Explain it in simple terms."
    }
});
Console.WriteLine(thread.Value.Id);
```

#### Retrieve thread

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var thread = assistantClient.GetThread("thread_abc123");
Console.WriteLine(thread.Value.Id);
```

#### Modify thread

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var thread = assistantClient.ModifyThread("thread_abc123", new ThreadModificationOptions() 
{
    Metadata = new Dictionary<string, string>
    {
        { "modified", "true" },
        { "user", "abc123" }
    }
});
Console.WriteLine(thread.Value.Id);
```

#### Delete thread

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var thread = assistantClient.DeleteThread("thread_abc123");
Console.WriteLine(thread.Value);
```

### Messages

#### Create message

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var message = assistantClient.CreateMessage("thread_abc123", MessageRole.User, [
        MessageContent.FromText("How does AI work? Explain it in simple terms.")
    ]);
Console.WriteLine(message.Value.Id);
```

#### List messages

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var messages = assistantClient.GetMessages("thread_abc123");
Console.WriteLine(messages);
```

#### Retrieve message

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var message = assistantClient.GetMessage("thread_abc123", "msg_abc123");
Console.WriteLine(message.Value.Id);
```

#### Modify message

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var message = assistantClient.ModifyMessage("thread_abc123", "msg_abc12", 
    new MessageModificationOptions() { 
        Metadata = new Dictionary<string, string> 
        {
            { "modified", "true" },
            { "user", "abc123" }
        }
    });
Console.WriteLine(message.Value.Id);
```

#### Delete message

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var message = assistantClient.DeleteMessage("thread_abc123", "msg_abc123");
Console.WriteLine(message.Value);
```

### Runs

#### Create run

*Default*
```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var run = assistantClient.CreateRun("thread_abc123", "asst_abc123");
Console.WriteLine(run.Value.Id);
```

*Streaming*
```csharp
// TODO
```

*Streaming with Functions*
```csharp
//TODO
```

#### Create thread and run

*Default*
```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var run = assistantClient.CreateThreadAndRun("asst_abc123", new ThreadCreationOptions() {
    InitialMessages = {
        "Explain deep learning to a 5 year old."
    }
});
Console.WriteLine(run.Value.Id);
```

NOTE / TODO: Is InitialMessages the same as the following nodejs code?

```javascript
  thread={
    "messages": [
      {"role": "user", "content": "Explain deep learning to a 5 year old."}
    ]
  }
```

*Streaming*
```csharp
// TODO
```

*Streaming with Functions*
```csharp
//TODO
```

#### List runs

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var runs = assistantClient.GetRuns("thread_abc123");
Console.WriteLine(runs);
```

#### Retrieve run

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var run = assistantClient.GetRun("thread_abc123", "run_abc123");
Console.WriteLine(run.Value.Id);
```

#### Modify run

```csharp
// TODO: ModifyRun not available in the SDK?
```

#### Submit tool outputs to run

*Default*
```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var run = assistantClient.SubmitToolOutputsToRun("thread_123", "run_123", [
    new ToolOutput("call_001", "70 degrees and sunny.")
]);
Console.WriteLine(run.Value.Id);
```

*Streaming*
```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var streamingUpdates = assistantClient.SubmitToolOutputsToRunStreaming("thread_123", "run_123", [
    new ToolOutput("call_001", "70 degrees and sunny.")
]);

foreach (var streamingUpdate in streamingUpdates) {
    Console.WriteLine(streamingUpdate.UpdateKind);
}
```

#### Cancel a run

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var result = assistantClient.CancelRun("thread_abc123", "run_abc123");
Console.WriteLine(result.Value);
```

### Run Steps

#### List run steps

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var runSteps = assistantClient.GetRunSteps("thread_abc123", "run_abc123");
Console.WriteLine(runSteps);
```

#### Retrieve run step

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.Assistants;

AssistantClient assistantClient = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));

var runStep = assistantClient.GetRunStep("thread_abc123", "run_abc123", "step_abc123");
Console.WriteLine(runStep.Value.Id);
```

### Vector Stores

#### Create vector store

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var store = client.CreateVectorStore(new VectorStoreCreationOptions() { 
    Name = "Support FAQ"
});
Console.WriteLine(store.Value.Id);
```

#### List vector stores

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var stores = client.GetVectorStores();
Console.WriteLine(stores);
```

#### Retrieve vector store

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var store = client.GetVectorStore("vs_abc123");
Console.WriteLine(store.Value.Id);
```

#### Modify vector store

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var store = client.ModifyVectorStore("vs_abc123", new VectorStoreModificationOptions()
{
    Name = "Support FAQ"
});
Console.WriteLine(store.Value.Id);
```

#### Delete vector store

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var result = client.DeleteVectorStore("vs_abc123");
Console.WriteLine(result.Value);
```

### Vector Store Files

#### Create vector store file

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var file = client.AddFileToVectorStore("vs_abc123", "file-abc123");
Console.WriteLine(file.Value.FileId);
```

#### List vector store files

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var files = client.GetFileAssociations("vs_abc123");
Console.WriteLine(files);
```

#### Retrieve vector store file

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var file = client.GetFileAssociation("vs_abc123", "file-abc123");
Console.WriteLine(file);
```

#### Delete vector store file

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var result = client.RemoveFileFromStore("vs_abc123", "file-abc123");
Console.WriteLine(result.Value);
```

### Vector Store File Batches

#### Create vector store file batch 

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var batch = client.CreateBatchFileJob("vs_abc123", ["file-abc123", "file-abc456"]);
Console.WriteLine(batch.Value.BatchId);
```

#### Retrieve vector store file batch

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var batch = client.GetBatchFileJob("vs_abc123", "vsfb_abc123");
Console.WriteLine(batch.Value.BatchId);
```

#### Cancel vector store file batch

```csharp
// Assistants is a beta API and subject to change.
// Acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
using OpenAI.VectorStores;

VectorStoreClient client = new(new(Environment.GetEnvironmentVariable("OPENAI_API_KEY")));
var result = client.CancelBatchFileJob("vs_abc123", "vsfb_abc123");
Console.WriteLine(result.Value);
```

#### List vector store files in a batch

```csharp
// TODO Missing from SDK?
```

## The assistants API quickstart (https://platform.openai.com/docs/assistants/quickstart)

#### Step 1: Create an Assistant
```csharp
using OpenAI;
using OpenAI.Assistants;

// Assistants is a beta API and subject to change; acknowledge its experimental status by suppressing the matching warning.
#pragma warning disable OPENAI001
OpenAIClient client = new(Environment.GetEnvironmentVariable("OPENAI_API_KEY"));
AssistantClient assistantClient = client.GetAssistantClient();

AssistantCreationOptions assistantOptions = new() {
    Name = "Math Tutor",
    Instructions = "You are a personal math tutor. Write and run code to answer math questions.",
    Tools = {new CodeInterpreterToolDefinition()}
};
Assistant assistant = assistantClient.CreateAssistant(model: "gpt-4o", assistantOptions);
```

#### Step 2: Create a Thread
```csharp
AssistantThread thread = assistantClient.CreateThread();
```

#### Step 3: Add a Message to the Thread
```csharp
ThreadMessage message = assistantClient.CreateMessage(thread, MessageRole.User, ["I need to solve the equation `3x + 11 = 14`. Can you help me?"]);
```

#### Step 4 - With streaming

```csharp
CollectionResult<StreamingUpdate> streamingUpdates = assistantClient.CreateRunStreaming(
    thread,
    assistant,
    new RunCreationOptions()
    {
        InstructionsOverride = "Please address the user as Jane Doe. The user has a premium account."
    });

foreach (StreamingUpdate streamingUpdate in streamingUpdates)
{
    if (streamingUpdate.UpdateKind == StreamingUpdateReason.RunCreated)
    {
        Console.WriteLine($"assistant > ");
    }
    
    if (streamingUpdate is MessageContentUpdate contentUpdate)
    {
        Console.Write(Regex.Unescape(contentUpdate.Text));
    }
}
```

NOTE / TODO: In the Python and Node.js snippet the example is more detailed, using an event model to post updates about tool usage. We could not figure out how to replicate this in the .NET SDK. Is there an equivalent event-based model for .NET? Or is there a way to implement this same sample using the model here? Here's an example from the Node.js snippet:

```javascript
const run = openai.beta.threads.runs.stream(thread.id, {
    assistant_id: assistant.id
  })
    .on('textCreated', (text) => process.stdout.write('\nassistant > '))
    .on('textDelta', (textDelta, snapshot) => process.stdout.write(textDelta.value))
    .on('toolCallCreated', (toolCall) => process.stdout.write(`\nassistant > ${toolCall.type}\n\n`))
    .on('toolCallDelta', (toolCallDelta, snapshot) => {
      if (toolCallDelta.type === 'code_interpreter') {
        if (toolCallDelta.code_interpreter.input) {
          process.stdout.write(toolCallDelta.code_interpreter.input);
        }
        if (toolCallDelta.code_interpreter.outputs) {
          process.stdout.write("\noutput >\n");
          toolCallDelta.code_interpreter.outputs.forEach(output => {
            if (output.type === "logs") {
              process.stdout.write(`\n${output.logs}\n`);
            }
          });
        }
      }
    });
```

#### Step 4 - Create a Run - Without streaming
```csharp
ThreadRun threadRun = assistantClient.CreateRun(thread, assistant, new(){
    InstructionsOverride = "Please address the user as Jane Doe. The user has a premium account."});

// Poll the run until it is no longer queued or in progress
do
{
    Thread.Sleep(TimeSpan.FromSeconds(1));
    threadRun = assistantClient.GetRun(threadRun.ThreadId, threadRun.Id);
} while (!threadRun.Status.IsTerminal);

if (threadRun.Status == RunStatus.Completed) {
    IEnumerable<ThreadMessage> resultMessages = assistantClient.GetMessages(threadRun.ThreadId).GetAllValues();
    foreach (var resultMessage in resultMessages.Reverse()) {
        Console.WriteLine($"{resultMessage.Role} > ${resultMessage.Content[0].Text}");
    }
} else {
    Console.WriteLine(threadRun.Status);
}
```

## The assistants deep dive (https://platform.openai.com/docs/assistants/deep-dive/*)

#### Creating Assistants - part 1

```csharp
var fileName = "revenue-forecast.csv";
var file = BinaryData.FromBytes(File.ReadAllBytes(fileName));

OpenAIFileInfo fileInfo = client.GetFileClient().UploadFile(
    file,
    fileName,
    FileUploadPurpose.Assistants);
```

#### Creating Assistants - part 2

```csharp
AssistantClient assistantClient = client.GetAssistantClient();

AssistantCreationOptions assistantOptions = new() {
    Name = "Data Visualizer",
    Instructions = "You are great at creating beautiful data visualizations. You analyze data present in .csv files, understand trends, and come up with data visualizations relevant to those trends. You also share a brief text summary of the trends observed.",
    Tools = {new CodeInterpreterToolDefinition()},
    ToolResources = new() {
        CodeInterpreter = new() {
            FileIds = {fileInfo.Id}
        }
    }
};
Assistant assistant = assistantClient.CreateAssistant(model: "gpt-4o", assistantOptions);
```

#### Managing Threads and Messages

```csharp
AssistantThread thread = assistantClient.CreateThread();

ThreadMessage message = assistantClient.CreateMessage(
    thread: thread,
    role: MessageRole.User,
    content: ["Create 3 data visualizations based on the trends in this file."],
    options: new() {
        Attachments = [new(fileId: fileInfo.Id, tools: [new CodeInterpreterToolDefinition()])]
    });
```

#### Creating image input content

```csharp
var fileName = "myImage.png";
var file = BinaryData.FromBytes(File.ReadAllBytes(fileName));

OpenAIFileInfo fileInfo = client.GetFileClient().UploadFile(
    file,
    fileName,
    FileUploadPurpose.Vision);

AssistantThread thread = assistantClient.CreateThread(new ThreadCreationOptions()
{
    InitialMessages =
    {
        new ThreadInitializationMessage(
            role: MessageRole.User,
            content: [
                "What is the difference between these images?",
                MessageContent.FromImageFileId(fileInfo.Id),
                MessageContent.FromImageUrl(new Uri("https://example.com/image.png"))
            ]),
    }
});
```

#### Low or high fidelity image understanding

```csharp
AssistantThread thread = assistantClient.CreateThread(new ThreadCreationOptions()
{
    InitialMessages =
    {
        new ThreadInitializationMessage(
            role: MessageRole.User,
            content: [
                "What is this an image of?",
                MessageContent.FromImageUrl(new Uri("https://example.com/image.png"), detail: MessageImageDetail.High)
            ]),
    }
});
```

#### Message annotations
Python only snippet

#### Runs and Run Steps - part 1

```csharp
ThreadRun threadRun = assistantClient.CreateRun(thread, assistant);
```

#### Runs and Run Steps - part 2

```csharp
ThreadRun threadRun = assistantClient.CreateRun(thread, assistant, new(){
    ModelOverride = "gpt-4o",
    InstructionsOverride = "Please address the user as Jane Doe. The user has a premium account.",
    ToolsOverride = {new CodeInterpreterToolDefinition()}});
```
