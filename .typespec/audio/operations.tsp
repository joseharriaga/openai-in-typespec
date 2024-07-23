import "@typespec/http";
import "@typespec/openapi";

import "../common";
import "./models.tsp";

using TypeSpec.Http;
using TypeSpec.OpenAPI;

namespace OpenAI;

interface Audio {
  @route("/audio/speech")
  @post
  @operationId("createSpeech")
  @tag("Audio")
  @summary("Generates audio from the input text.")
  op createSpeech(
    @body requestBody: CreateSpeechRequest
  ): {
    /** chunked */
    @header("Transfer-Encoding") transferEncoding?: string;
    @header contentType: "application/octet-stream";
    @body @encode("binary") audio: bytes;
  };

  @route("/audio/transcriptions")
  @post
  @operationId("createTranscription")
  @tag("Audio")
  @summary("Transcribes audio into the input language.")
  op createTranscription(
    @header contentType: "multipart/form-data",
    @body requestBody: CreateTranscriptionRequest,
  ):
    | CreateTranscriptionResponseVerboseJson
    | CreateTranscriptionResponseJson
    | {
        // TODO: This response is not defined in the OpenAPI spec.
        @header contentType: "text/plain";
        @body text: string;
      }
    | ErrorResponse;

  @route("/audio/translations")
  @post
  @operationId("createTranslation")
  @tag("Audio")
  @summary("Translates audio into English..")
  op createTranslation(
    @header contentType: "multipart/form-data",
    @body requestBody: CreateTranslationRequest,
  ):
    | CreateTranslationResponseVerboseJson
    | CreateTranslationResponseJson
    | {
        // TODO: This response is not defined in the OpenAPI spec.
        @header contentType: "text/plain";
        @body text: string;
      }
    | ErrorResponse;
}
