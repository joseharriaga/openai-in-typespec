// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// Code generated by Microsoft (R) TypeSpec Code Generator.

package com.azure.ai.openai.models;

/**
 * Defines values for AzureContentFilterSeverityResultSeverity.
 */
public enum AzureContentFilterSeverityResultSeverity {
    /**
     * Enum value safe.
     */
    SAFE("safe"),

    /**
     * Enum value low.
     */
    LOW("low"),

    /**
     * Enum value medium.
     */
    MEDIUM("medium"),

    /**
     * Enum value high.
     */
    HIGH("high");

    /**
     * The actual serialized value for a AzureContentFilterSeverityResultSeverity instance.
     */
    private final String value;

    AzureContentFilterSeverityResultSeverity(String value) {
        this.value = value;
    }

    /**
     * Parses a serialized value to a AzureContentFilterSeverityResultSeverity instance.
     * 
     * @param value the serialized value to parse.
     * @return the parsed AzureContentFilterSeverityResultSeverity object, or null if unable to parse.
     */
    public static AzureContentFilterSeverityResultSeverity fromString(String value) {
        if (value == null) {
            return null;
        }
        AzureContentFilterSeverityResultSeverity[] items = AzureContentFilterSeverityResultSeverity.values();
        for (AzureContentFilterSeverityResultSeverity item : items) {
            if (item.toString().equalsIgnoreCase(value)) {
                return item;
            }
        }
        return null;
    }

    /**
     * {@inheritDoc}
     */
    @Override
    public String toString() {
        return this.value;
    }
}
