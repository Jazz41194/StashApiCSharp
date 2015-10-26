
using Atlassian.Stash.Api.Enums;

namespace Atlassian.Stash.Api.Helpers
{
    public class RequestOptions
    {
        public int? Limit { get; set; }
        public int? Start { get; set; }
        public string At { get; set; }
        public PullRequestState? State { get; set; }
    }
}
