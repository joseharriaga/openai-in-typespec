import "./models.tsp";
import "./operations.tsp";

import "@typespec/openapi";

using TypeSpec.OpenAPI;

namespace OpenAI;

@@extension(OpenAI.MessageObject,
  "x-oaiMeta",
  """
    name: The message object
    beta: true
    example: |
        {
        "id": "msg_abc123",
        "object": "thread.message",
        "created_at": 1698983503,
        "thread_id": "thread_abc123",
        "role": "assistant",
        "content": [
            {
            "type": "text",
            "text": {
                "value": "Hi! How can I help you today?",
                "annotations": []
            }
            }
        ],
        "file_ids": [],
        "assistant_id": "asst_abc123",
        "run_id": "run_abc123",
        "metadata": {}
        }
  """
);

@@extension(OpenAI.Messages.deleteMessage,
  "x-oaiMeta",
  """
  name: Delete message
          group: threads
          beta: true
          returns: Deletion status
          examples:
            request:
              curl: |
                curl -X DELETE https://api.openai.com/v1/threads/thread_abc123/messages/msg_abc123 \\
                  -H "Content-Type: application/json" \\
                  -H "Authorization: Bearer $OPENAI_API_KEY" \\
                  -H "OpenAI-Beta: assistants=v2"
              python: |
                from openai import OpenAI
                client = OpenAI()

                deleted_message = client.beta.threads.messages.delete(
                  message_id="msg_abc12",
                  thread_id="thread_abc123",
                )
                print(deleted_message)
              node.js: |-
                import OpenAI from "openai";

                const openai = new OpenAI();

                async function main() {
                  const deletedMessage = await openai.beta.threads.messages.del(
                    "thread_abc123",
                    "msg_abc123"
                  );
                
                  console.log(deletedMessage);
                }
            response: |
              {
                "id": "msg_abc123",
                "object": "thread.message.deleted",
                "deleted": true
              }
  """
);
