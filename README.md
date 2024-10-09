# A conversion of the OpenAI OpenAPI to TypeSpec

Snapshot: 0a7fa51f7860d3da39c9af3cfc43688cdca19fbe
Ingestion tool: a58c83859965121d1fe4dd68e04dae5e95e0b86c

There are some deltas:

### Changes to API Semantics

- Many things are missing defaults (mostly due to bug where we can't set null defaults)
- Error responses have been added.
- Where known, the `object` property's type is narrowed from string to the constant value it will always be

### Changes to API metadata or OpenAPI format

- Much of the x-oaiMeta entries have not been added.
- In some cases, new schemas needed to be defined in order to be defined in TypeSpec (e.g. because the constraints could not be added to a model property with a heterogeneous type)
- There is presently no way to set `title`
