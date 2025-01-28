# A conversion of the OpenAI OpenAPI to TypeSpec

For information on spec ingestion, see the Sorento wiki page:
https://dev.azure.com/project-argos/Sorento/_wiki/wikis/Sorento.wiki/3021/Generate-OpenAI's-YAML-Spec

Snapshot: $M
```
commit 9ca412840f1554cc23857a6a2aa1e66c231a8b40 (HEAD -> master, origin/master)
Author: root <root@root.k8s.local>
Date:   Wed Jan 22 19:03:08 2025 +0000
```

Ingestion tool: https://project-argos@dev.azure.com/project-argos/Sorento/_git/sdk
```
commit f9e16b8f3216c20b03fb3dd0083e3b03a11bce34 (HEAD -> user/travisw/migrate-spec-ingestion-tool, origin/user/travisw/migrate-spec-ingestion-tool)
Author: Travis Wilson <travisw@microsoft.com>
Date:   Mon Jan 27 17:36:50 2025 -0800
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
