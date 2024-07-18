// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// Code generated by Microsoft (R) TypeSpec Code Generator.

package com.azure.ai.openai.models;

import com.azure.core.annotation.Generated;
import com.azure.core.annotation.Immutable;
import com.azure.json.JsonReader;
import com.azure.json.JsonToken;
import com.azure.json.JsonWriter;
import java.io.IOException;

/**
 * The AzureChatDataSourceAccessTokenAuthenticationOptions model.
 */
@Immutable
public final class AzureChatDataSourceAccessTokenAuthenticationOptions
    extends AzureChatDataSourceAuthenticationOptions {
    /*
     * The type property.
     */
    @Generated
    private String type = "access_token";

    /*
     * The access_token property.
     */
    @Generated
    private final String accessToken;

    /**
     * Creates an instance of AzureChatDataSourceAccessTokenAuthenticationOptions class.
     * 
     * @param accessToken the accessToken value to set.
     */
    @Generated
    public AzureChatDataSourceAccessTokenAuthenticationOptions(String accessToken) {
        this.accessToken = accessToken;
    }

    /**
     * Get the type property: The type property.
     * 
     * @return the type value.
     */
    @Generated
    @Override
    public String getType() {
        return this.type;
    }

    /**
     * Get the accessToken property: The access_token property.
     * 
     * @return the accessToken value.
     */
    @Generated
    public String getAccessToken() {
        return this.accessToken;
    }

    /**
     * {@inheritDoc}
     */
    @Generated
    @Override
    public JsonWriter toJson(JsonWriter jsonWriter) throws IOException {
        jsonWriter.writeStartObject();
        jsonWriter.writeStringField("access_token", this.accessToken);
        jsonWriter.writeStringField("type", this.type);
        return jsonWriter.writeEndObject();
    }

    /**
     * Reads an instance of AzureChatDataSourceAccessTokenAuthenticationOptions from the JsonReader.
     * 
     * @param jsonReader The JsonReader being read.
     * @return An instance of AzureChatDataSourceAccessTokenAuthenticationOptions if the JsonReader was pointing to an
     * instance of it, or null if it was pointing to JSON null.
     * @throws IllegalStateException If the deserialized JSON object was missing any required properties.
     * @throws IOException If an error occurs while reading the AzureChatDataSourceAccessTokenAuthenticationOptions.
     */
    @Generated
    public static AzureChatDataSourceAccessTokenAuthenticationOptions fromJson(JsonReader jsonReader)
        throws IOException {
        return jsonReader.readObject(reader -> {
            String accessToken = null;
            String type = "access_token";
            while (reader.nextToken() != JsonToken.END_OBJECT) {
                String fieldName = reader.getFieldName();
                reader.nextToken();

                if ("access_token".equals(fieldName)) {
                    accessToken = reader.getString();
                } else if ("type".equals(fieldName)) {
                    type = reader.getString();
                } else {
                    reader.skipChildren();
                }
            }
            AzureChatDataSourceAccessTokenAuthenticationOptions deserializedAzureChatDataSourceAccessTokenAuthenticationOptions
                = new AzureChatDataSourceAccessTokenAuthenticationOptions(accessToken);
            deserializedAzureChatDataSourceAccessTokenAuthenticationOptions.type = type;

            return deserializedAzureChatDataSourceAccessTokenAuthenticationOptions;
        });
    }
}
