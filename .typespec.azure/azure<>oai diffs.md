## Operations

Listing differences in the request/response models between Azure and non-Azure

### `/completions`

- `CreateCompletionRequest`
  - Additional Azure field: `completion_config`
  - non-Azure has `model`

- `CreateCompletionResponse`
  - non-Azure has `system_fingerprint`
  - Azure has `prompt_filter_results`
  - Azure has under `choices`->`content_filter_results`


### `/embeddings`

- `CreateEmbeddingRequest`
  - Azure has `input_type`
  - non-Azure has `model`

- `CreateEmbeddingResponse`
  - Identical

### `/chat/completions`
- `CreateChatCompletionRequest`
  - Azure has an additional header called `apim-request-id`
  - Azure has `data_sources`
  - non-Azure has the additional:
    - `model`
    - `stream_options`
    - `parallel_tool_calls`
  - non-Azure fields `funcionts` and `function_call` marked as deprecated (not in Azure)

- `CreateChatCompletionResponse`
  - Azure has `prompt_filter_results`
  - Azure has `choices` -> `content_filter_results`
  - Azure has `choices` -> `message` -> `context`
  - non-Azure the field `choices` -> `message` -> `function_call` is deprecated (not in Azure)
  
### `/audio/transcriptions`

- `CreateTranscriptionRequest`
  - Non-Azure has `model`
  
- `CreateTranscriptionResponse`  (there is `verbose` and `simple`)
    - Azure has for the `audioVerboseResponse` case, the addtional field called `task`

### `/audio/translations`

- `CreateTranslationRequest`
  - non-Azure has `model`

### `/audio/speech`

- `CreateSpeechRequest`
  - non-Azure has `model` field

- `Response`
  - non-Azure has a header called `Transfer-Encoding` value is probably `chunked` (not sure)

### `/image/generations`

- `CreateImageRequest`
  - non-Azure has `model`

- `Response`
  - Azure has `prompt_filter_results` and `content_filter_resuts`

### `image/edit`

- **Operation missing in AOAI**

### `image/variations`

- **Operation missing in AOAI**
