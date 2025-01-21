# A conversion of the OpenAI OpenAPI to TypeSpec

For information on spec ingestion, see the Sorento wiki page:
https://dev.azure.com/project-argos/Sorento/_wiki/wikis/Sorento.wiki/3021/Generate-OpenAI's-YAML-Spec

Snapshot: https://project-argos@dev.azure.com/project-argos/Sorento/_git/export-api
```
commit 41af04dc4767cfd11ca4fbc7edf2e5a67a564440 (HEAD -> main, origin/main)
Author: Git-Mirror-Tool Synchronizer <git-sync-vm-umi@microsoft.com>
Date:   Mon Jan 13 22:49:02 2025 +0000
```

Ingestion tool: https://project-argos@dev.azure.com/project-argos/Sorento/_git/sdk
```
commit c41442a13bf38ac4f30840bee648488991661e17 (HEAD -> user/travisw/migrate-spec-ingestion-tool, origin/user/travisw/migrate-spec-ingestion-tool)
Author: Travis Wilson <travisw@microsoft.com>
Date:   Thu Jan 9 14:24:11 2025 -0800
```

There are some deltas:

### Changes to API Semantics

- Many things are missing defaults (mostly due to bug where we can't set null defaults)
- Error responses have been added.
- Where known, the `object` property's type is narrowed from string to the constant value it will always be

### Changes to API metadata or OpenAPI format

- Much of the x-oaiMeta entries have not been added.
- In some cases, new schemas needed to be defined in order to be defined in TypeSpec (e.g. because the constraints could not be added to a model property with a heterogeneous type)
- There is presently no way to set `title`
