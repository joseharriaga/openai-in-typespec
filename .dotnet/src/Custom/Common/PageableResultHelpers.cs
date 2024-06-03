using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

#nullable enable

namespace OpenAI;

internal class PageableResultHelpers
{
    public static PageableResult<T> Create<T>(Func<string?, string?, PageResult<T>> getInitialPage, Func<string?, string?, PageResult<T>>? getNextPage) where T : notnull
        => new FuncPageable<T>(getInitialPage, getNextPage);

    public static AsyncPageableResult<T> Create<T>(Func<string?, string?, Task<PageResult<T>>> getInitialPage, Func<string?, string?, Task<PageResult<T>>>? getNextPage) where T : notnull
        => new FuncAsyncPageable<T>(getInitialPage, getNextPage);

    private class FuncAsyncPageable<T> : AsyncPageableResult<T> where T : notnull
    {
        private readonly Func<string?, string?, Task<PageResult<T>>> _getInitialPage;
        private readonly Func<string?, string?, Task<PageResult<T>>>? _getNextPage;

        public FuncAsyncPageable(Func<string?, string?, Task<PageResult<T>>> getInitialPage, Func<string?, string?, Task<PageResult<T>>>? getNextPage)
        {
            _getInitialPage = getInitialPage;
            _getNextPage = getNextPage;
        }

        public override async IAsyncEnumerable<PageResult<T>> AsPages(string? pageToken = default)
        {
            Func<string?, string?, Task<PageResult<T>>>? getPage = _getInitialPage;

            if (getPage == null)
            {
                yield break;
            }

            string? requestPageToken = pageToken;
            string? prevPageToken = null;

            do
            {
                PageResult<T> page = await getPage(requestPageToken, prevPageToken).ConfigureAwait(false);
                SetRawResponse(page.GetRawResponse());
                yield return page;
                prevPageToken = requestPageToken;
                requestPageToken = page.NextPageToken;
                getPage = _getNextPage;
            }
            while (!string.IsNullOrEmpty(pageToken) && getPage != null);
        }
    }

    private class FuncPageable<T> : PageableResult<T> where T : notnull
    {
        private readonly Func<string?, string?, PageResult<T>> _getInitialPage;
        private readonly Func<string?, string?, PageResult<T>>? _getNextPage;

        public FuncPageable(Func<string?, string?, PageResult<T>> getInitialPage, Func<string?, string?, PageResult<T>>? getNextPage)
        {
            _getInitialPage = getInitialPage;
            _getNextPage = getNextPage;
        }

        public override IEnumerable<PageResult<T>> AsPages(string? pageToken = default)
        {
            Func<string?, string?, PageResult<T>>? getPage = _getInitialPage;

            if (getPage == null)
            {
                yield break;
            }

            string? requestPageToken = pageToken;
            string? prevPageToken = null;

            do
            {
                PageResult<T> page = getPage(requestPageToken, prevPageToken);
                SetRawResponse(page.GetRawResponse());
                yield return page;
                prevPageToken = requestPageToken;
                requestPageToken = page.NextPageToken;
                getPage = _getNextPage;
            }
            while (!string.IsNullOrEmpty(requestPageToken) && getPage != null);
        }
    }
}
