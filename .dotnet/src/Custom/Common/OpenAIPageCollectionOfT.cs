using OpenAI.Custom.Common;
using System;
using System.ClientModel;
using System.ClientModel.Primitives;

namespace OpenAI;

public class OpenAIPageCollection<T> : PageCollection<OpenAIPage<T>, T, OpenAIPageToken>
{
    internal OpenAIPageCollection(OpenAIPageToken firstPageToken) : base(firstPageToken)
    {
    }

    public override OpenAIPage<T> GetPage(OpenAIPageToken pageToken)
    {
        throw new NotImplementedException();
    }

    public static OpenAIPageCollection<T> FromClientResult(ClientResult result)
    {

    }
}
