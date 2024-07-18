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

/**
 * The AzureChatDataSourceAuthenticationOptions model.
 */
@Immutable
public class AzureChatDataSourceAuthenticationOptions
    implements JsonSerializable<AzureChatDataSourceAuthenticationOptions> {
    /*
     * The type property.
     */
    @Generated
    private String type = "AzureChatDataSourceAuthenticationOptions";

    /**
     * Creates an instance of AzureChatDataSourceAuthenticationOptions class.
     */
    @Generated
    public AzureChatDataSourceAuthenticationOptions() {
    }

    /**
     * Get the type property: The type property.
     * 
     * @return the type value.
     */
    @Generated
    public String getType() {
        return this.type;
    }

    /**
     * {@inheritDoc}
     */
    @Generated
    @Override
    public JsonWriter toJson(JsonWriter jsonWriter) throws IOException {
        jsonWriter.writeStartObject();
        jsonWriter.writeStringField("type", this.type);
        return jsonWriter.writeEndObject();
    }

    /**
     * Reads an instance of AzureChatDataSourceAuthenticationOptions from the JsonReader.
     * 
     * @param jsonReader The JsonReader being read.
     * @return An instance of AzureChatDataSourceAuthenticationOptions if the JsonReader was pointing to an instance of
     * it, or null if it was pointing to JSON null.
     * @throws IOException If an error occurs while reading the AzureChatDataSourceAuthenticationOptions.
     */
    @Generated
    public static AzureChatDataSourceAuthenticationOptions fromJson(JsonReader jsonReader) throws IOException {
        return jsonReader.readObject(reader -> {
            String discriminatorValue = null;
            try (JsonReader readerToUse = reader.bufferObject()) {
                readerToUse.nextToken(); // Prepare for reading
                while (readerToUse.nextToken() != JsonToken.END_OBJECT) {
                    String fieldName = readerToUse.getFieldName();
                    readerToUse.nextToken();
                    if ("type".equals(fieldName)) {
                        discriminatorValue = readerToUse.getString();
                        break;
                    } else {
                        readerToUse.skipChildren();
                    }
                }
                // Use the discriminator value to determine which subtype should be deserialized.
                if ("connection_string".equals(discriminatorValue)) {
                    return AzureChatDataSourceConnectionStringAuthenticationOptions.fromJson(readerToUse.reset());
                } else if ("key_and_key_id".equals(discriminatorValue)) {
                    return AzureChatDataSourceKeyAndKeyIdAuthenticationOptions.fromJson(readerToUse.reset());
                } else if ("encoded_api_key".equals(discriminatorValue)) {
                    return AzureChatDataSourceEncodedApiKeyAuthenticationOptions.fromJson(readerToUse.reset());
                } else if ("access_token".equals(discriminatorValue)) {
                    return AzureChatDataSourceAccessTokenAuthenticationOptions.fromJson(readerToUse.reset());
                } else if ("system_assigned_managed_identity".equals(discriminatorValue)) {
                    return AzureChatDataSourceSystemAssignedManagedIdentityAuthenticationOptions
                        .fromJson(readerToUse.reset());
                } else if ("user_assigned_managed_identity".equals(discriminatorValue)) {
                    return AzureChatDataSourceUserAssignedManagedIdentityAuthenticationOptions
                        .fromJson(readerToUse.reset());
                } else if ("api_key".equals(discriminatorValue)) {
                    return AzureChatDataSourceApiKeyAuthenticationOptions.fromJson(readerToUse.reset());
                } else {
                    return fromJsonKnownDiscriminator(readerToUse.reset());
                }
            }
        });
    }

    @Generated
    static AzureChatDataSourceAuthenticationOptions fromJsonKnownDiscriminator(JsonReader jsonReader)
        throws IOException {
        return jsonReader.readObject(reader -> {
            AzureChatDataSourceAuthenticationOptions deserializedAzureChatDataSourceAuthenticationOptions
                = new AzureChatDataSourceAuthenticationOptions();
            while (reader.nextToken() != JsonToken.END_OBJECT) {
                String fieldName = reader.getFieldName();
                reader.nextToken();

                if ("type".equals(fieldName)) {
                    deserializedAzureChatDataSourceAuthenticationOptions.type = reader.getString();
                } else {
                    reader.skipChildren();
                }
            }

            return deserializedAzureChatDataSourceAuthenticationOptions;
        });
    }
}
