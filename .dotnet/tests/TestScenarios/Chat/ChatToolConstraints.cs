using NUnit.Framework;
using OpenAI.Chat;
using System;
using System.ClientModel;

namespace OpenAI.Tests.Chat;

public partial class ChatToolConstraintTests
{
    [Test]
    public void BasicTypeManipulationWorks()
    {
        Assert.That(ChatToolChoice.Auto.ToString(), Is.EqualTo("\"auto\""));
        Assert.That(ChatToolChoice.None.ToString(), Is.EqualTo("\"none\""));
        Assert.That(ChatToolChoice.Auto, Is.Not.EqualTo(ChatToolChoice.None));

        ChatTool functionTool = ChatTool.CreateFunctionTool(
            "test_function_tool",
            "description isn't applicable"
        );

        ChatToolChoice choiceFromTool = new(functionTool);
        Assert.That(choiceFromTool.ToString(), Is.EqualTo(@$"{{""type"":""function"",""function"":{{""name"":""{functionTool.FunctionName}""}}}}"));

        ChatToolChoice otherChoice = new(ChatTool.CreateFunctionTool("test_function_tool"));
        Assert.That(choiceFromTool, Is.EqualTo(otherChoice));
        Assert.That(otherChoice, Is.Not.EqualTo(ChatToolChoice.Auto));
    }

    [Test]
    public void ConstraintsWork()
    {
        ChatClient client = new("gpt-3.5-turbo");

        foreach (var (choice, reason) in new (ChatToolChoice, ChatFinishReason)[]
        {
            (null, ChatFinishReason.ToolCalls),
            (ChatToolChoice.None, ChatFinishReason.Stop),
            (new ChatToolChoice(s_numberForWordTool), ChatFinishReason.Stop),
            (ChatToolChoice.Auto, ChatFinishReason.ToolCalls),
            // TODO: Add test for ChatToolChoice.Required
        })
        {
            ChatCompletionOptions options = new()
            {
                Tools = { s_numberForWordTool },
                ToolChoice = choice,
            };
            ClientResult<ChatCompletion> result = client.CompleteChat([new UserChatMessage("What's the number for the word 'banana'?")], options);
            Assert.That(result.Value.FinishReason, Is.EqualTo(reason));
        }
    }

    private static ChatTool s_numberForWordTool = ChatTool.CreateFunctionTool(
        "get_number_for_word",
        "gets an arbitrary number assigned to a given word",
        BinaryData.FromString("""
            {
                "type": "object",
                "properties": {
                    "word": {
                        "type": "string"
                    }
                }
            }
            """)
        );
}
