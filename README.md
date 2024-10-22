# A conversion of the OpenAI OpenAPI to TypeSpec

For information on spec ingestion, see the Sorento wiki page:
https://dev.azure.com/project-argos/Sorento/_wiki/wikis/Sorento.wiki/3021/Generate-OpenAI's-YAML-Spec

Snapshot: 9da44b1e126916bbd4ab0bd62accf5622a3ec6ba
Ingestion tool: 0e44bfd35faf03b24521a2ef9cf2aaabfe5763a0 (HEAD -> user/travisw/migrate-spec-ingestion-tool, origin/user/travisw/migrate-spec-ingestion-tool)

There are some deltas:

### Changes to API Semantics

- Many things are missing defaults (mostly due to bug where we can't set null defaults)
- Error responses have been added.
- Where known, the `object` property's type is narrowed from string to the constant value it will always be

### Changes to API metadata or OpenAPI format

- Much of the x-oaiMeta entries have not been added.
- In some cases, new schemas needed to be defined in order to be defined in TypeSpec (e.g. because the constraints could not be added to a model property with a heterogeneous type)
- There is presently no way to set `title`
