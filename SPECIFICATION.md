## High level overview

- One collection of TypeSpec files (multiple interacting projects) as the source of truth for everything:
  - Generated OpenAI and Azure OpenAI specifications (openapi3)
  - Generated standalone Azure libraries (replacement for current project)
  - Generated OpenAI .NET library (aspiration: get Stainless on board to converge someday for other languages; not an immediate consideration but a north star)
  - Generated Azure OpenAI companion libraries
- TypeSpec files for Azure are as purely focused on Azure as possible -- i.e. we don't maintain a bunch of parallel forests of nested models and reuse as much of the operation definitions as we can, too
- Azure definition can be robust to shifting non-Azure changes (like the stream_options timing we've seen recently) via project-level manipulation that still allows generators to retain an inheritance relationship


## Open questions

### Do we want models in the Azure layer that extend from the vanilla OpenAI layer in TSP to coexist in the generated artifacts? (swagger/SDKs)?

I don't think the complete and correct types for both need to simultaneously exist within the same output unit, but we do need to retain the external derivation relationship; it's OK if AOAI's openapi3 document doesn't express "OpenAI's CreateChatCompletionRequest has stream_options, but then Azure OpenAI's removes it," but we do need the ability for a companion library to say "AOAI's request type still inherits from the (external) OAI request type, and we might just remove, hide, or override defaults and valid client values of a small number of things (depending on language approach)"
