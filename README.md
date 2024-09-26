# A conversion of the OpenAI OpenAPI to TypeSpec

Snapshot: https://raw.githubusercontent.com/openai/openai-openapi/f990f1d36ccea1e0da552db05469a58e51f592ee/openapi.yaml
Ingestion tool: 8f1bbe03198b9947343cbf2d029eb321313d3f0a


There are some deltas:

### Changes to API Semantics

- Many things are missing defaults (mostly due to bug where we can't set null defaults)
- Error responses have been added.
- Where known, the `object` property's type is narrowed from string to the constant value it will always be

### Changes to API metadata or OpenAPI format

- Much of the x-oaiMeta entries have not been added.
- In some cases, new schemas needed to be defined in order to be defined in TypeSpec (e.g. because the constraints could not be added to a model property with a heterogeneous type)
- There is presently no way to set `title`
