// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// Code generated by Microsoft (R) TypeSpec Code Generator.

package com.azure.ai.openai.models;

import com.azure.core.annotation.Generated;
import com.azure.core.annotation.Immutable;
import com.azure.json.JsonReader;
import com.azure.json.JsonSerializable;
import com.azure.json.JsonToken;
import com.azure.json.JsonWriter;
import java.io.IOException;
import java.util.List;

/**
 * An additional property, added to chat completion response messages, produced by the Azure OpenAI service when using
 * extension behavior. This includes intent and citation information from the On Your Data feature.
 */
@Immutable
public final class AzureChatMessageContext implements JsonSerializable<AzureChatMessageContext> {
    /*
     * The detected intent from the chat history, which is used to carry conversation context between interactions
     */
    @Generated
    private String intent;

    /*
     * The citations produced by the data retrieval.
     */
    @Generated
    private List<AzureChatMessageContextCitation> citations;

    /*
     * Summary information about documents retrieved by the data retrieval operation.
     */
    @Generated
    private AzureChatMessageContextAllRetrievedDocuments allRetrievedDocuments;

    /**
     * Creates an instance of AzureChatMessageContext class.
     */
    @Generated
    private AzureChatMessageContext() {
    }

    /**
     * Get the intent property: The detected intent from the chat history, which is used to carry conversation context
     * between interactions.
     * 
     * @return the intent value.
     */
    @Generated
    public String getIntent() {
        return this.intent;
    }

    /**
     * Get the citations property: The citations produced by the data retrieval.
     * 
     * @return the citations value.
     */
    @Generated
    public List<AzureChatMessageContextCitation> getCitations() {
        return this.citations;
    }

    /**
     * Get the allRetrievedDocuments property: Summary information about documents retrieved by the data retrieval
     * operation.
     * 
     * @return the allRetrievedDocuments value.
     */
    @Generated
    public AzureChatMessageContextAllRetrievedDocuments getAllRetrievedDocuments() {
        return this.allRetrievedDocuments;
    }

    /**
     * {@inheritDoc}
     */
    @Generated
    @Override
    public JsonWriter toJson(JsonWriter jsonWriter) throws IOException {
        jsonWriter.writeStartObject();
        jsonWriter.writeStringField("intent", this.intent);
        jsonWriter.writeArrayField("citations", this.citations, (writer, element) -> writer.writeJson(element));
        jsonWriter.writeJsonField("all_retrieved_documents", this.allRetrievedDocuments);
        return jsonWriter.writeEndObject();
    }

    /**
     * Reads an instance of AzureChatMessageContext from the JsonReader.
     * 
     * @param jsonReader The JsonReader being read.
     * @return An instance of AzureChatMessageContext if the JsonReader was pointing to an instance of it, or null if it
     * was pointing to JSON null.
     * @throws IOException If an error occurs while reading the AzureChatMessageContext.
     */
    @Generated
    public static AzureChatMessageContext fromJson(JsonReader jsonReader) throws IOException {
        return jsonReader.readObject(reader -> {
            AzureChatMessageContext deserializedAzureChatMessageContext = new AzureChatMessageContext();
            while (reader.nextToken() != JsonToken.END_OBJECT) {
                String fieldName = reader.getFieldName();
                reader.nextToken();

                if ("intent".equals(fieldName)) {
                    deserializedAzureChatMessageContext.intent = reader.getString();
                } else if ("citations".equals(fieldName)) {
                    List<AzureChatMessageContextCitation> citations
                        = reader.readArray(reader1 -> AzureChatMessageContextCitation.fromJson(reader1));
                    deserializedAzureChatMessageContext.citations = citations;
                } else if ("all_retrieved_documents".equals(fieldName)) {
                    deserializedAzureChatMessageContext.allRetrievedDocuments
                        = AzureChatMessageContextAllRetrievedDocuments.fromJson(reader);
                } else {
                    reader.skipChildren();
                }
            }

            return deserializedAzureChatMessageContext;
        });
    }
}
