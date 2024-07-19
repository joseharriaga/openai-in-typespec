import "../../.typespec/messages";

using TypeSpec.OpenAPI;

namespace AzureOpenAI;

model MessageContentTextAnnotationsBingSearchUrlCitation
  extends OpenAI.MessageContentTextObjectAnnotation {
  @doc("""
  Always `url_citation`.
  """)
  type: "url_citation";

  /** The text in the message content that needs to be replaced. */
  text: string;

  url_citation: {
    url: url;
    title: string;
  };

  @minValue(0)
  start_index: int32;

  @minValue(0)
  end_index: int32;
}

model MessageDeltaContentTextAnnotationsBingSearchUrlCitation
  extends OpenAI.MessageDeltaTextContentAnnotation {
  /** The index of the annotation in the text content part. */
  index: int32;

  @doc("""
  Always `url_citation`.
  """)
  type: "url_citation";

  /** The text in the message content that needs to be replaced. */
  text?: string;

  url_citation?: {
    url?: url;
    title?: string;
  };

  @minValue(0)
  start_index?: int32;

  @minValue(0)
  end_index?: int32;
}
