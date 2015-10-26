using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlassian.Stash.Api.Entities;
using Atlassian.Stash.Api.Enums;
using Atlassian.Stash.Api.Helpers;
using Atlassian.Stash.Api.Workers;

namespace Atlassian.Stash.Api.Api
{
    public class PullRequests
    {
        private const string PULL_REQUEST = "/rest/api/1.0/projects/{0}/repos/{1}/pull-requests";
        private HttpCommunicationWorker _httpWorker;

        internal PullRequests(HttpCommunicationWorker httpWorker)
        {
            _httpWorker = httpWorker;
        }

        public async Task<PullRequest> Create(string projectKey, string repositorySlug,
            PullRequest pullRequest)
        {
            if (pullRequest.State == PullRequestState.All)
            {
                throw new ArgumentOutOfRangeException("Pull-Request state can't be equal 'ALL'");
            }

            string requestUrl = UrlBuilder.FormatRestApiUrl(PULL_REQUEST, null, projectKey, repositorySlug);

            PullRequest pr = await _httpWorker.PostAsync(requestUrl, pullRequest);

            return pr;
        }

        public async Task<ResponseWrapper<PullRequest>> GetAll(string projectKey, string repositorySlug)
        {
            var reqOpt = new RequestOptions() { State = PullRequestState.All };

            string requestUrl = UrlBuilder.FormatRestApiUrl(PULL_REQUEST, reqOpt, projectKey, repositorySlug);

            ResponseWrapper<PullRequest> res = await _httpWorker.GetAsync<ResponseWrapper<PullRequest>>(requestUrl);

            return res;
        }
    }
}
