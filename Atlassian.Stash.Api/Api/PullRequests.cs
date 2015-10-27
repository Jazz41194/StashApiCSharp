using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlassian.Stash.Api.Entities;
using Atlassian.Stash.Api.Enums;
using Atlassian.Stash.Api.Enums.PullRequest;
using Atlassian.Stash.Api.Helpers;
using Atlassian.Stash.Api.Workers;

namespace Atlassian.Stash.Api.Api
{
    public class PullRequests
    {
        private const string PULL_REQUESTS = "/rest/api/1.0/projects/{0}/repos/{1}/pull-requests";
        private const string PULL_REQUEST_ACTIVITY = "/rest/api/1.0/projects/{0}/repos/{1}/pull-requests/{2}/activities";
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

            string requestUrl = UrlBuilder.FormatRestApiUrl(PULL_REQUESTS, null, projectKey, repositorySlug);

            PullRequest pr = await _httpWorker.PostAsync(requestUrl, pullRequest);

            return pr;
        }

        public async Task<ResponseWrapper<PullRequest>> GetAll(string projectKey, string repositorySlug)
        {
            var reqOpt = new RequestOptions() { State = PullRequestState.All };

            string requestUrl = UrlBuilder.FormatRestApiUrl(PULL_REQUESTS, reqOpt, projectKey, repositorySlug);

            ResponseWrapper<PullRequest> res = await _httpWorker.GetAsync<ResponseWrapper<PullRequest>>(requestUrl);

            return res;
        }

        public async Task<ResponseWrapper<Activity>> GetActivities(string projectKey, string repositorySlug,
            PullRequest pullRequest)
        {
            string requestUrl = UrlBuilder.FormatRestApiUrl(PULL_REQUEST_ACTIVITY, null, projectKey, repositorySlug,
                pullRequest.Id);

            ResponseWrapper<Activity> res = await _httpWorker.GetAsync<ResponseWrapper<Activity>>(requestUrl);

            return res;
        }
    }
}
