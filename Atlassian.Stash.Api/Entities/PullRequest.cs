﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlassian.Stash.Api.Converters;
using Atlassian.Stash.Api.Enums;
using Atlassian.Stash.Api.Enums.PullRequest;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Atlassian.Stash.Api.Entities
{
    public class PullRequest
    {
        public string Id { get; set; }
        public string Version { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PullRequestState State { get; set; }
        [JsonProperty("open")]
        public bool Open { get; set; }
        [JsonProperty("closed")]
        public bool Closed { get; set; }
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime CreatedDate { get; set; }
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime UpdatedDate { get; set; }
        [JsonProperty("fromRef")]
        public Ref FromRef { get; set; }
        [JsonProperty("toRef")]
        public Ref ToRef { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        public AuthorWrapper Author { get; set; }
        [JsonProperty("reviewers")]
        public AuthorWrapper[] Reviewers { get; set; }
        public List<AuthorWrapper> Participants { get; set; }

        public Link Link { get; set; }
        public Links Links { get; set; }
    }
}
