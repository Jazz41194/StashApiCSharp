using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlassian.Stash.Api.Enums;
using Atlassian.Stash.Api.Enums.PullRequest;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Atlassian.Stash.Api.Entities
{
    public class Activity
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActivityAction Action {get; set;}
        [JsonProperty("comment")]
        public Comment Comment { get; set; }
        [JsonProperty("commentAction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CommentAction CommentAction { get; set; }
    }
}
