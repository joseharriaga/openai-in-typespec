using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI;

internal class PageableResultHelpers
{
    public static PageableResult<T> Create<T>(Func<string?, string?, ClientPage<T>> getInitialPage, Func<string?, string?, ClientPage<T>>? getNextPage) where T : notnull
        => new FuncPageable<T>(getInitialPage, getNextPage);

    public static AsyncPageableResult<T> Create<T>(Func<string?, string?, Task<ClientPage<T>>> getInitialPage, Func<string?, string?, Task<ClientPage<T>>>? getNextPage) where T : notnull
        => new FuncAsyncPageable<T>(getInitialPage, getNextPage);

    private class FuncAsyncPageable<T> : AsyncPageableResult<T> where T : notnull
    {
        private readonly Func<string?, string?, Task<ClientPage<T>>> _getInitialPage;
        private readonly Func<string?, string?, Task<ClientPage<T>>>? _getNextPage;

        public FuncAsyncPageable(Func<string?, string?, Task<ClientPage<T>>> getInitialPage, Func<string?, string?, Task<ClientPage<T>>>? getNextPage)
        {
            _getInitialPage = getInitialPage;
            _getNextPage = getNextPage;
        }

        protected override async IAsyncEnumerable<ClientPage<T>> AsPagesCore(string pageToken)
        {
            Func<string?, string?, Task<ClientPage<T>>>? getPage = _getInitialPage;

            if (getPage == null)
            {
                yield break;
            }

            string? requestPageToken = pageToken;
            string? prevPageToken = null;

            while (requestPageToken != null && getPage != null)
            {
                ClientPage<T> page = await getPage(requestPageToken, prevPageToken).ConfigureAwait(false);
                SetRawResponse(page.GetRawResponse());
                yield return page;
                prevPageToken = requestPageToken;
                requestPageToken = page.NextPageToken;
                getPage = _getNextPage;
            }
        }
    }

    private class FuncPageable<T> : PageableResult<T> where T : notnull
    {
        private readonly Func<string?, string?, ClientPage<T>> _getInitialPage;
        private readonly Func<string?, string?, ClientPage<T>>? _getNextPage;

        public FuncPageable(Func<string?, string?, ClientPage<T>> getInitialPage, Func<string?, string?, ClientPage<T>>? getNextPage)
        {
            _getInitialPage = getInitialPage;
            _getNextPage = getNextPage;
        }

        protected override IEnumerable<ClientPage<T>> AsPagesCore(string pageToken)
        {
            // TODO: make requestPageToken non-nullable.
            Func<string?, string?, ClientPage<T>>? getPage = _getInitialPage;

            if (getPage == null)
            {
                yield break;
            }

            string? requestPageToken = pageToken;
            string? prevPageToken = null;
            
            while (requestPageToken != null && getPage != null)
            {
                ClientPage<T> page = getPage(requestPageToken, prevPageToken);
                SetRawResponse(page.GetRawResponse());
                yield return page;
                prevPageToken = requestPageToken;
                requestPageToken = page.NextPageToken;
                getPage = _getNextPage;
            }
        }
    }
}
