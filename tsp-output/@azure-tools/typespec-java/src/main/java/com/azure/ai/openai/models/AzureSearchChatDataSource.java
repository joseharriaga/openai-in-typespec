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
 * Represents a data source configuration that will use an Azure Search resource.
 */
@Immutable
public final class AzureSearchChatDataSource extends AzureChatDataSource {
    /*
     * The differentiating type identifier for the data source.
     */
    @Generated
    private String type = "azure_search";

    /*
     * The parameter information to control the use of the Azure Search data source.
     */
    @Generated
    private final AzureSearchChatDataSourceParameters parameters;

    /**
     * Creates an instance of AzureSearchChatDataSource class.
     * 
     * @param parameters the parameters value to set.
     */
    @Generated
    public AzureSearchChatDataSource(AzureSearchChatDataSourceParameters parameters) {
        this.parameters = parameters;
    }

    /**
     * Get the type property: The differentiating type identifier for the data source.
     * 
     * @return the type value.
     */
    @Generated
    @Override
    public String getType() {
        return this.type;
    }

    /**
     * Get the parameters property: The parameter information to control the use of the Azure Search data source.
     * 
     * @return the parameters value.
     */
    @Generated
    public AzureSearchChatDataSourceParameters getParameters() {
        return this.parameters;
    }

    /**
     * {@inheritDoc}
     */
    @Generated
    @Override
    public JsonWriter toJson(JsonWriter jsonWriter) throws IOException {
        jsonWriter.writeStartObject();
        jsonWriter.writeJsonField("parameters", this.parameters);
        jsonWriter.writeStringField("type", this.type);
        return jsonWriter.writeEndObject();
    }

    /**
     * Reads an instance of AzureSearchChatDataSource from the JsonReader.
     * 
     * @param jsonReader The JsonReader being read.
     * @return An instance of AzureSearchChatDataSource if the JsonReader was pointing to an instance of it, or null if
     * it was pointing to JSON null.
     * @throws IllegalStateException If the deserialized JSON object was missing any required properties.
     * @throws IOException If an error occurs while reading the AzureSearchChatDataSource.
     */
    @Generated
    public static AzureSearchChatDataSource fromJson(JsonReader jsonReader) throws IOException {
        return jsonReader.readObject(reader -> {
            AzureSearchChatDataSourceParameters parameters = null;
            String type = "azure_search";
            while (reader.nextToken() != JsonToken.END_OBJECT) {
                String fieldName = reader.getFieldName();
                reader.nextToken();

                if ("parameters".equals(fieldName)) {
                    parameters = AzureSearchChatDataSourceParameters.fromJson(reader);
                } else if ("type".equals(fieldName)) {
                    type = reader.getString();
                } else {
                    reader.skipChildren();
                }
            }
            AzureSearchChatDataSource deserializedAzureSearchChatDataSource = new AzureSearchChatDataSource(parameters);
            deserializedAzureSearchChatDataSource.type = type;

            return deserializedAzureSearchChatDataSource;
        });
    }
}
